#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using AccessVersionChecker.Model.Util;
using NLog;

#endregion

namespace AccessVersionChecker.Model
{
  /// <summary>
  ///   The Facade allows to retrieve info about access files.
  /// </summary>
  public class ModelFacade
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///   Try to get file information for each access database specified in the text file.
    ///   The input file should have a path to an access databases on each line.
    ///   If the file does not exist skip and log it.
    /// </summary>
    /// <param name="textFilePath">The path of the text file to read from</param>
    /// <param name="taskProgress">The class that handles the progress of this method</param>
    /// <returns>The fileinfo for each access file that was parsed from the text file</returns>
    public IEnumerable<AccessFileInfo> ReadFromTextFile(string textFilePath, ITaskProgress taskProgress = null)
    {
      var accessFiles = new List<AccessFileInfo>();
      var accessDbPaths = File.ReadLines(textFilePath).ToList();
      int proccessedCount = 0;
      int totalLines = accessDbPaths.Count();

      // For each access path
      foreach (var accDbPath in accessDbPaths)
      {
        // Check for cancel request
        if (taskProgress != null && taskProgress.CancelRequested())
        {
          return new List<AccessFileInfo>();
        }

        // Get the file info
        if (File.Exists(accDbPath))
        {
          var fileInfo = GetAccessFileInfo(accDbPath);
          accessFiles.Add(fileInfo);
        }
        else
        {
          Logger.Info(accDbPath + " is not a valid path.");
        }

        // Report the progress
        proccessedCount++;
        if (taskProgress != null)
        {
          int percentage = (int) (proccessedCount*100.0)/totalLines;
          taskProgress.ReportProgress(percentage);
        }
      }

      return accessFiles;
    }

    /// <summary>
    ///   Get the file info from the mdb access database located at the given path.
    /// </summary>
    /// <param name="mdbPath">A path to an access database</param>
    /// <returns>The file info for the access database ready to use in the UI</returns>
    public AccessFileInfo GetAccessFileInfo(string mdbPath)
    {
      Logger.Debug("Getting access file info for db:" + mdbPath);

      if (!File.Exists(mdbPath)) return AccessFileInfo.Null();

      // Get the file properties: file owner, file created date, file modified date
      // Get the access properties: access version + access file format
      var fileProperties = WindowsUtil.GetProperties(mdbPath);
      var accVersion = AccessUtil.GetAccessVersion(mdbPath);
      var accFileFormat = AccessUtil.GetAccessFileFormat(accVersion);

      return new AccessFileInfo(
        mdbPath,
        accVersion,
        accFileFormat,
        false,
        fileProperties.FileOwner,
        fileProperties.DateCreated,
        fileProperties.DateModified
      );
    }

    /// <summary>
    ///   Check if the given fileFormat is compatible with the given comptability version number.
    /// </summary>
    /// <param name="fileFormat">An access file format</param>
    /// <param name="comptabilityVersion">The access version number to check against (default = Access 2016)</param>
    /// <returns></returns>
    public bool IsCompatible(AccessFileFormat fileFormat, int comptabilityVersion = 2016)
    {
      if (comptabilityVersion == 2016)
        return
          (fileFormat != AccessFileFormat.Acc2) &&
          (fileFormat != AccessFileFormat.Acc95) &&
          (fileFormat != AccessFileFormat.Acc97) &&
          (fileFormat != AccessFileFormat.Unknown);
      else
        return false;
    }

    /// <summary>
    ///   Export the text rows to excel
    /// </summary>
    /// <param name="table">Rows of text to display in excel</param>
    /// <param name="excelFilePath">The excel to create (the file will be created if it does not exist)</param>
    public void ExportToExcel(string title, List<List<string>> table, string excelFilePath)
    {
      new CsvWriter().Write(title, table, excelFilePath);
    }
  }
}