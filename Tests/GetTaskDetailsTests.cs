namespace Tests;

public class GetTaskDetailsTests
{
    [Fact]
    public void BasicDetails()
    {
        var t = new TaskItem(1, "VS", "Visual Studio", false);        
        var expected = """
            Task ID: 1 (NOT Complete)
            Title: VS
            Description: Visual Studio
            """.Replace("\r\n", "\n");
        var actual = t.GetTaskDetails();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BasicDetailsCompleteTask()
    {
        var t = new TaskItem(123, "Task Title", "Unit Testing Rocks", true);
        var expected = """
            Task ID: 123 (COMPLETE)
            Title: Task Title
            Description: Unit Testing Rocks
            """.Replace("\r\n", "\n");
        var actual = t.GetTaskDetails();

        Assert.Equal(expected, actual);
    }
}
