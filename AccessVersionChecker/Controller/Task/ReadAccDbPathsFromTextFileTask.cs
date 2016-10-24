#region

using System.Collections.Generic;
using System.ComponentModel;
using AccessVersionChecker.Model;
using AccessVersionChecker.Model.Util;
using AccessVersionChecker.Util;
using NLog;

#endregion

namespace AccessVersionChecker.Controller.Task
{
  internal class ReadAccDbPathsFromTextFileTask : ITask
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly string _filePath;
    private readonly ModelFacade _facade;
    private readonly IMainFormView _view;
    private ITaskProgress _taskProgress;
    private BackgroundWorker _worker;
    public TaskContainer TaskContainer { set; private get; }

    public ReadAccDbPathsFromTextFileTask(string filePath, ModelFacade facade, IMainFormView view)
    {
      _filePath = filePath;
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
      _taskProgress = new SimpleBackgroundWorker(_worker);

      var comptabilityVersion = _view.ComptabilityVersion;
      _view.DisableInput();
      _worker.RunWorkerAsync(comptabilityVersion);
    }

    public void Cancel()
    {
      _worker.CancelAsync();
    }

    private void Task_Run(object sender, DoWorkEventArgs e)
    {
      int comptabilityVersion = int.Parse(e.Argument + "");
      var allAccessFileInfo = _facade.ReadFromTextFile(_filePath, _taskProgress);

      foreach (var db in allAccessFileInfo)
      {
        db.CompatibleValue = _facade.IsCompatible(db.FileFormatValue, comptabilityVersion);
      }

      if (_taskProgress.CancelRequested())
      {
        e.Cancel = true;
      }
      else
      {
        e.Result = allAccessFileInfo;
      }
    }

    private void Task_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      _view.ProgressChanged(e.ProgressPercentage);
    }

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
        _view.ClearRows();
        var allAccessFileInfo = (IEnumerable<AccessFileInfo>) e.Result;

        foreach (var accessFileInfo in allAccessFileInfo)
        {
          _view.Add(accessFileInfo);
        }
      }

      _view.SortOnComptability();
      _view.RowDataChanged();
      _view.ProgressChanged(0);
      _view.EnableInput();

      TaskContainer.Task_ProgressCompleted();
    }
  }
}