#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AccessVersionChecker.Model;
using NLog;

#endregion

namespace AccessVersionChecker.Controller.Task
{
  public class AddDatabasesTask : ITask
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly List<string> _accessDbFilePathsToAdd;
    private readonly ModelFacade _facade;
    private readonly IMainFormView _view;
    private BackgroundWorker _worker;
    public TaskContainer TaskContainer { set; private get; }

    public AddDatabasesTask(IEnumerable<string> accessDbAccessDbFilePaths, ModelFacade facade, IMainFormView view)
    {
      _accessDbFilePathsToAdd = accessDbAccessDbFilePaths.ToList();
      _facade = facade;
      _view = view;
    }

    public void Run()
    {
      _worker = new BackgroundWorker
      {
        WorkerReportsProgress = true,
        WorkerSupportsCancellation = true
      };

      _worker.DoWork += Task_Run;
      _worker.ProgressChanged += Task_ProgressChanged;
      _worker.RunWorkerCompleted += Task_ProgressCompleted;

      for (int i = _accessDbFilePathsToAdd.Count - 1; i >= 0; i--)
      {
        foreach (var db in _view.Rows)
        {
          string dbPath = _accessDbFilePathsToAdd[i];

          if (db.Path == dbPath)
          {
            _accessDbFilePathsToAdd.RemoveAt(i);
            Logger.Debug("Skipping " + db.Path + " the database is already added to the UI.");
            break;
          }
        }
      }

      int comptabilityVersion = _view.ComptabilityVersion;
      _view.DisableInput();
      _worker.RunWorkerAsync(comptabilityVersion);
    }

    public void Cancel()
    {
      _worker.CancelAsync();
    }

    /// <summary>
    ///   This method runs in a background thread
    /// </summary>
    private void Task_Run(object sender, DoWorkEventArgs e)
    {
      int comptabilityVersion = int.Parse(e.Argument + "");

      var dbs = new List<AccessFileInfo>();
      int totalDbFilesToProcess = _accessDbFilePathsToAdd.Count;

      // For each access database path
      foreach (var dbPath in _accessDbFilePathsToAdd)
      {
        // Check for cancel request
        if (_worker.CancellationPending)
        {
          e.Cancel = true;
          return;
        }

        // Get the file info
        var db = _facade.GetAccessFileInfo(dbPath);
        db.CompatibleValue = _facade.IsCompatible(db.FileFormatValue, comptabilityVersion);
        dbs.Add(db);

        // Report the progress
        int percentage = (int) (dbs.Count*100.0)/totalDbFilesToProcess;
        _worker.ReportProgress(percentage);
      }

      e.Result = dbs;
    }

    /// <summary>
    ///   Reports progress on the UI thread
    /// </summary>
    private void Task_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      _view.ProgressChanged(e.ProgressPercentage);
    }

    /// <summary>
    ///   Show the results on the UI thread
    /// </summary>
    private void Task_ProgressCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Cancelled)
      {
        _view.ProgressChanged(0);
        _view.EnableInput();
        return;
      }

      if (e.Error != null)
        Logger.Error(e.Error);

      if (e.Result != null)
      {
        var accessDbs = (IEnumerable<AccessFileInfo>) e.Result;

        foreach (var db in accessDbs)
        {
          _view.Add(db);
        }
      }

      _view.SortOnComptability();
      _view.RowDataChanged();
      _view.ProgressChanged(0);

      TaskContainer.Task_ProgressCompleted();
      _view.EnableInput();
    }
  }
}