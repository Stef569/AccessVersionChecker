#region

using System.ComponentModel;
using AccessVersionChecker.Model.Util;

#endregion

namespace AccessVersionChecker.Util
{
  public class SimpleBackgroundWorker : ITaskProgress
  {
    private readonly BackgroundWorker _worker;

    public SimpleBackgroundWorker(BackgroundWorker worker)
    {
      _worker = worker;
    }

    public void ReportProgress(int percentProgress)
    {
      _worker.ReportProgress(percentProgress);
    }

    public bool CancelRequested()
    {
      return _worker.CancellationPending;
    }
  }
}