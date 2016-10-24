#region

using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Access.Dao;
using NLog;

//using dao;

#endregion

namespace AccessVersionChecker.Model.Util
{
  public static class AccessUtil
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private const string AccessVersionNotFound = "-1";

    public static string GetAccessVersion(string mdbPath)
    {
      if (string.IsNullOrEmpty(mdbPath))
        throw new ArgumentException("Path to the DB is not valid");

      // Read the access version and project version from the MDB file
      string accessVersion;
      bool validParameter = TryReadParameter(mdbPath, out accessVersion);

      return !validParameter ? AccessVersionNotFound : accessVersion;
    }

    private static bool TryReadParameter(string mdbPath, out string accessVersion)
    {
      Database db = null;
      accessVersion = AccessVersionNotFound;

      try
      {
        // Attempt to read properties from access using DAO.
        var engine = new DBEngine();
        Logger.Debug("DAO engine version=" + engine.Version);

        db = engine.OpenDatabase(mdbPath, false, true, "");
        Logger.Debug("DB=" + db.Version);

        if (db.Properties.Count == 0) return false;

        // Get the access version
        var accessVersionProperty = db.Properties
                                      .Cast<Property>()
                                      .SingleOrDefault(p => p.Name == "AccessVersion");

        if (accessVersionProperty == null)
          return false;

        string accessVersionString = accessVersionProperty.Value.ToString();

        if (string.IsNullOrEmpty(accessVersionString))
          return false;

        accessVersion = accessVersionString;
      }
      catch (COMException ex)
      {
        Logger.Log(LogLevel.Debug, ex);

        // Attempt to find the cause why the version could not be read
        if (ex.Message.StartsWith("Not a valid password.", StringComparison.Ordinal))
        {
          accessVersion = "invalid_password";
          return true;
        }
        else if (ex.Message.StartsWith("Unrecognized database format", StringComparison.Ordinal))
        {
          accessVersion = "corrupt";
          return true;
        }

        return false;
      }
      catch (Exception ex)
      {
        Logger.Log(LogLevel.Debug, ex);
        return false;
      }
      finally
      {
        if (db != null) db.Close();
      }

      return true;
    }

    /// <summary>
    ///   Returns the access file format based on the access version.
    ///   The name of the file format is based on the first access version that used the new format.
    ///   Acc2 is the first file format used by access version 1 to 2.
    ///   acc2007 is the latest file format used by access version 12+.
    ///   A file format changes for example when a new type of field is added.
    /// </summary>
    /// <param name="accessVersion">The access verion number in this format: xx.yy</param>
    /// <returns>The access file format</returns>
    public static AccessFileFormat GetAccessFileFormat(string accessVersion)
    {
      switch (accessVersion)
      {
        case "01":
        case "02":
        case "02.00":
          return AccessFileFormat.Acc2;
        case "06":
        case "06.68":
          return AccessFileFormat.Acc95;
        case "07":
        case "07.53":
          return AccessFileFormat.Acc97;
        case "08.50":
          return AccessFileFormat.Acc2000;
        case "09.50":
          return AccessFileFormat.Acc2000_2003;
        case "12":
          return AccessFileFormat.Acc2007;
        default:
          return AccessFileFormat.Unknown;
      }
    }
  }
}