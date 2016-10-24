#region

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AccessVersionChecker.Controller.Task;
using AccessVersionChecker.Model;

#endregion

namespace AccessVersionChecker.Controller
{
  /// <summary>
  ///   This controller handles all input from the Main form screen.
  /// </summary>
  public class MainFormController
  {
    private const string ComptabilityReportName = "Access databases comptability report";

    private readonly ModelFacade _facade = new ModelFacade();
    private readonly IMainFormView _view;
    private readonly TaskContainer _taskContainer;

    public MainFormController(IMainFormView view, TaskContainer taskContainer)
    {
      _view = view;
      _taskContainer = taskContainer;

      _view.ComptabilityVersions = new List<int>
      {
        2016
      };

      // By default sort the grid by comptability
      view.SortOnComptability();
    }

    public void AddDatabases(IEnumerable<string> accessDbFileNames)
    {
      var task = new AddDatabasesTask(accessDbFileNames, _facade, _view);
      _taskContainer.ExecuteTask(task);
    }

    public void ReadFromTextFile(string filePath)
    {
      if (string.IsNullOrEmpty(filePath)) return;

      var task = new ReadAccDbPathsFromTextFileTask(filePath, _facade, _view);
      _taskContainer.ExecuteTask(task);
    }

    public void ClearRows()
    {
      _view.ClearRows();
    }

    public void ExportToExcel(string excelFilePath)
    {
      if (string.IsNullOrEmpty(excelFilePath)) return;

      var table = new List<List<string>>();

      // Table Header
      table.Add(new List<string>
      {
        "Database Name",
        "Owner",
        "Version",
        "File format",
        "Comptability",
        "Created",
        "Last Modified",
        "Path"
      });

      // Convert the grid rows to rows of strings
      foreach (var row in _view.Rows)
      {
        var rowAsText = new List<string>
        {
          row.DbName,
          row.Owner,
          row.Version,
          row.AccessFileFormat,
          row.Compatible,
          row.Created.HasValue ? row.Created.Value.ToShortDateString() : "",
          row.LastModified.HasValue ? row.LastModified.Value.ToShortDateString() : "",
          row.Path
        };

        table.Add(rowAsText);
      }

      _facade.ExportToExcel(ComptabilityReportName, table, excelFilePath);
    }

    public static void OpenLink(string filePath)
    {
      if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
      {
        Process.Start(filePath);
      }
    }

    public void CancelCurrentTask()
    {
      _taskContainer.CancelCurrentTask();
    }
  }
}