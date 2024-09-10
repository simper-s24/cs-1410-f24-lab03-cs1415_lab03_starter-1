namespace Logic;

public interface ITaskItemRepository
{
    void SaveTasks(IEnumerable<TaskItem> tasks);
    IEnumerable<TaskItem> LoadTasks();
}
