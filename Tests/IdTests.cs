namespace Tests;

public class IdTests
{
    [Fact]
    public void ObjectConstructionAssignsId()
    {
        var t1 = new TaskItem();
        Assert.True(t1.Id > 0);
    }

    [Fact]
    public void ObjectsGetSequentialIds()
    {
        var t1 = new TaskItem();
        var origId = t1.Id;
        var t2 = new TaskItem();
        var newId = t2.Id;
        Assert.True(newId > origId);
    }
}
