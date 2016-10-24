#region

using System;

#endregion

namespace AccessVersionChecker.Controller.Task
{
  public class TaskContainer
  {
    private ITask _currentTask;

    public void ExecuteTask(ITask task)
    {
      if (_currentTask != null)
        throw new InvalidOperationException("Another task is still running");

      task.TaskContainer = this;
      _currentTask = task;
      _currentTask.Run();
    }

    public void CancelCurrentTask()
    {
      if (_currentTask != null)
      {
        _currentTask.Cancel();
        _currentTask = null;
      }
    }

    public void Task_ProgressCompleted()
    {
      _currentTask = null;
    }
  }
}