using Logic;
using Persistence;

var taskRepository = new JsonTaskRepository("tasks.json");
var logic = new TaskListLogic(taskRepository);

while (true)
{
    Console.Clear();
    Console.WriteLine("World's Best To-Do App");
    Console.WriteLine();
    Console.WriteLine(TaskItem.GenerateReport(logic.Tasks));

    Console.WriteLine("\n'+' to add a task\n'x' to toggle as task's completion status\n'i' to view a task's information");
    switch (Console.ReadKey().KeyChar)
    {
        case '+':
            addTask();
            break;
        case 'x':
            toggleComplete();
            break;
        case 'i':
            showDetails();
            break;
    }
}

void addTask()
{
    var task = GetNewTask();
    logic.AddTask(task);
}

void toggleComplete()
{
    var taskId = GetTaskId();
    var task = logic.GetTaskById(taskId);
    task.ToggleIsComplete();
}

void showDetails()
{
    var taskId = GetTaskId();
    var task = logic.Tasks.FirstOrDefault(task => task.Id == taskId);
    var details = task.GetTaskDetails();
    Console.Clear();
    Console.WriteLine(details);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Press [Enter] to continue.");
    Console.ReadLine();
}

int GetTaskId()
{
    Console.WriteLine();
    Console.Write("Enter the id of the task: ");
    int taskId = -1;
    while (!int.TryParse(Console.ReadLine(), out taskId) && !logic.Tasks.Any(t => t.Id == taskId)) ;
    return taskId;
}

TaskItem GetNewTask()
{
    Console.WriteLine();
    Console.Write("New task title: ");
    var title = Console.ReadLine();

    Console.Write("New task description: ");
    var description = Console.ReadLine();

    return new TaskItem(logic.Tasks.Count() + 1, title, description, false);
}
