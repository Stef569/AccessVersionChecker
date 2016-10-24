#region

using System;
using Microsoft.WindowsAPICodePack.Shell;

#endregion

namespace AccessVersionChecker.Model.Util
{
  internal static class WindowsUtil
  {
    public static FileProperties GetProperties(string filePath)
    {
      var file = ShellFile.FromFilePath(filePath);

      return new FileProperties(
        file.Properties.System.FileOwner.Value,
        file.Properties.System.DateCreated.Value,
        file.Properties.System.DateModified.Value
      );
    }

    public struct FileProperties
    {
      public readonly string FileOwner;
      public readonly DateTime? DateCreated;
      public readonly DateTime? DateModified;

      public FileProperties(string fileOwner, DateTime? dateCreated, DateTime? dateModified)
      {
        FileOwner = fileOwner;
        DateCreated = dateCreated;
        DateModified = dateModified;
      }
    }
  }
}