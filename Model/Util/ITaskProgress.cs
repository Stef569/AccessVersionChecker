namespace AccessVersionChecker.Model.Util
{
  /// <summary>
  ///   Allows to control the progress of a task.
  ///   Progress is reported using <see cref="ReportProgress" />.
  ///   A task can be cancelled by setting <see cref="CancelRequested" /> to true
  /// </summary>
  public interface ITaskProgress
  {
    /// <summary>
    ///   Report the progress as a percentage
    /// </summary>
    /// <param name="percentProgress">The percentage of the background operation from 0 to 100</param>
    void ReportProgress(int percentProgress);

    /// <summary>
    ///   The task should periodically check for a cancel request.
    /// </summary>
    /// <returns>If the task should be cancelled</returns>
    bool CancelRequested();
  }
}