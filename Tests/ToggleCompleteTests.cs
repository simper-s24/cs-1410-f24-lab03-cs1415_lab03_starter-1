namespace Tests;

public class ToggleCompleteTests
{
    [Fact]
    public void FalseBecomesTrue()
    {
        var t = new TaskItem();
        t.ToggleIsComplete();
        Assert.True(t.IsComplete);
    }

    [Fact]
    public void TrueBecomesFalse()
    {
        var t = new TaskItem(1, "Task1", "Task1", true);
        t.ToggleIsComplete();
        Assert.False(t.IsComplete);
    }
}
