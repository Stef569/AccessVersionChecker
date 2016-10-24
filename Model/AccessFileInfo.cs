#region

using System;

#endregion

namespace AccessVersionChecker.Model
{
  /// <summary>
  ///   Contains information about an access database.
  ///   Contains translations for the UI
  /// </summary>
  public class AccessFileInfo
  {
    public string DbName { get; private set; }
    public string Path { get; set; }
    public string Owner { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastModified { get; set; }

    public string VersionValue { private get; set; }

    public string Version
    {
      get
      {
        switch (VersionValue)
        {
          case "invalid_password":
            return "Password protected";
          case "corrupt":
            return "Corrupt Database";
          default:
            return VersionValue;
        }
      }
    }

    public AccessFileFormat FileFormatValue { get; set; }

    public string AccessFileFormat
    {
      get
      {
        switch (FileFormatValue)
        {
          case Model.AccessFileFormat.Acc2:
            return "2";
          case Model.AccessFileFormat.Acc95:
            return "95";
          case Model.AccessFileFormat.Acc97:
            return "97";
          case Model.AccessFileFormat.Acc2000:
            return "2000";
          case Model.AccessFileFormat.Acc2000_2003:
            return "2000-2003";
          case Model.AccessFileFormat.Acc2007:
            return "2007";
          default:
            return "Unknown";
        }
      }
    }

    public bool CompatibleValue { private get; set; }
    public string Compatible => CompatibleValue ? "Yes" : "No";

    public AccessFileInfo(string path, string versionValue, AccessFileFormat fileFormatValue,
                          bool compatibleValue, string owner, DateTime? created, DateTime? lastModified)
    {
      DbName = System.IO.Path.GetFileName(path);
      Path = path;
      VersionValue = versionValue;
      FileFormatValue = fileFormatValue;
      CompatibleValue = compatibleValue;
      Owner = owner;
      Created = created;
      LastModified = lastModified;
    }

    // Use the public constructor
    private AccessFileInfo()
    {
    }

    public static AccessFileInfo Null()
    {
      return new AccessFileInfo();
    }

    protected bool Equals(AccessFileInfo other)
    {
      return string.Equals(Path, other.Path);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((AccessFileInfo) obj);
    }

    public override int GetHashCode()
    {
      return Path != null ? Path.GetHashCode() : 0;
    }
  }
}