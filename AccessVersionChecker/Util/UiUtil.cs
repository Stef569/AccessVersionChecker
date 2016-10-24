#region

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace AccessVersionChecker.Util
{
  public static class UiUtil
  {
    /// <summary>
    ///   Sets the progress bar value, without using Windows Aero animation
    /// </summary>
    public static void SetProgressWithoutAnimation(this ProgressBar pb, int value)
    {
      // To get around this animation, we need to move the progress bar backwards.
      if (value == pb.Maximum)
      {
        // Special case (can't set value > Maximum).
        pb.Value = value; // Set the value
        pb.Value = value - 1; // Move it backwards
      }
      else
      {
        pb.Value = value + 1; // Move past
      }

      pb.Value = value; // Move to correct value
    }

    #region GRID

    public static List<List<string>> GridToText(DataGridView dgv)
    {
      var table = new List<List<string>>();
      var headers = dgv.Columns.Cast<DataGridViewColumn>();

      var headersAsText = new List<string>();
      foreach (var column in headers)
        headersAsText.Add(column.HeaderText);

      table.Add(headersAsText);

      foreach (DataGridViewRow row in dgv.Rows)
      {
        var rowAsText = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value + "").ToList();

        table.Add(rowAsText);
      }

      return table;
    }

    public static DataGridViewColumn GetColumnByName(DataGridView grid, string name)
    {
      return
        grid.Columns
            .Cast<DataGridViewColumn>()
            .FirstOrDefault(col => col.Name == name);
    }

    #endregion

    #region DIALOG

    public static IEnumerable<string> OpenMultiSelectFileDialog(string filter, Form parent)
    {
      var openFileDialog = new OpenFileDialog
      {
        Filter = filter,
        Multiselect = true
      };

      return openFileDialog.ShowDialog(parent) != DialogResult.OK ? new string[] {} : openFileDialog.FileNames;
    }

    public static string OpenFileDialog(string filter, Form parent)
    {
      var openFileDialog = new OpenFileDialog
      {
        Filter = filter
      };

      return openFileDialog.ShowDialog(parent) != DialogResult.OK ? null : openFileDialog.FileName;
    }

    public static string SaveFileDialog(string fileName, string defaultExtension, string filter, Form parent)
    {
      var saveFileDialog = new SaveFileDialog
      {
        FileName = fileName,
        Filter = filter,
        DefaultExt = defaultExtension
      };

      return saveFileDialog.ShowDialog(parent) != DialogResult.OK ? null : saveFileDialog.FileName;
    }

    #endregion
  }
}