namespace Logic;

public class TaskListLogic
{
    private readonly ITaskItemRepository taskRepository;

    private List<TaskItem> tasks = new();
    public IEnumerable<TaskItem> Tasks => tasks.AsEnumerable();

    public TaskListLogic(ITaskItemRepository taskRepository)
    {
        this.taskRepository = taskRepository;
        tasks.AddRange(taskRepository.LoadTasks());
        tasks.Sort((t1, t2) => t1.Id - t2.Id);
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
        taskRepository.SaveTasks(tasks);
    }

    public TaskItem GetTaskById(int taskId)
    {
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        return task;
    }
}
