#region

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace AccessVersionChecker.Model.Util
{
  /// <summary>
  ///   The CSV writer allows to export text to a csv file.
  ///   This file can be viewed with excel.
  /// </summary>
  public class CsvWriter
  {
    /// <summary>
    ///   Export a table of strings into a CSV file. Each string is put into a cell.
    /// </summary>
    /// <param name="table">the text that should be put into the CSV.</param>
    /// <param name="csvFilePath">The path of the file to store the text in</param>
    public void Write(string title, List<List<string>> table, string csvFilePath)
    {
      if (table.Count == 0) return;

      var sb = new StringBuilder(table.Count*70);

      sb.AppendLine("sep =,");

      foreach (var row in table)
      {
        var csvRow = row.Select(cell => "\"" + cell + "\"").ToArray();
        sb.AppendLine(string.Join(",", csvRow));
      }

      File.WriteAllText(csvFilePath, sb.ToString());
    }
  }
}