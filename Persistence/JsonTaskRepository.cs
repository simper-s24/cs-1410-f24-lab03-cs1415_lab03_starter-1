using Logic;
using System.Text.Json;

namespace Persistence;

internal record TaskWrapper(int Id, string Title, string Description, bool IsComplete);


public class JsonTaskRepository : ITaskItemRepository
{
    private readonly string path;

    public JsonTaskRepository(string path)
    {
        this.path = path;
    }

    public IEnumerable<TaskItem> LoadTasks()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonSerializer
                .Deserialize<TaskWrapper[]>(json)
                .Select(t => new TaskItem(t.Id, t.Title, t.Description, t.IsComplete));
        }
        return [];
    }

    public void SaveTasks(IEnumerable<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(path, json);
    }
}
