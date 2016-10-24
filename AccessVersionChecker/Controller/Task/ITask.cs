namespace AccessVersionChecker.Controller.Task
{
  public interface ITask
  {
    void Run();

    void Cancel();

    TaskContainer TaskContainer { set; }
  }
}