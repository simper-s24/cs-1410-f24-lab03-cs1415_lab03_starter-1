namespace Tests;

public class GenerateReportTests
{
    [Fact]
    public void ReportWithZeroItems()
    {
        var actualReport = TaskItem.GenerateReport([]);
        var expectedReport = """
                 ID Title
            ======================================================

            """;
        Assert.Equal(expectedReport, actualReport);
    }

    [Fact]
    public void ReportWithOneItem()
    {
        var actualReport = TaskItem.GenerateReport([new TaskItem(15, "Task Fifteen", "Description", true)]);
        var expectedReport = """
                 ID Title
            ======================================================
            [X]  15 Task Fifteen

            """;
        Assert.Equal(expectedReport, actualReport);
    }

    [Fact]
    public void ReportWithShorterAndLongerDatesStillLineUp()
    {
        var actualReport = TaskItem.GenerateReport([
            new TaskItem(1, "Task One", "Description", true),
            new TaskItem(15, "Task Fifteen", "Description", false),
            new TaskItem(159, "Task One Hundred Fifty Nine", "Description", true),
        ]);
        var expectedReport = """
                 ID Title
            ======================================================
            [X]   1 Task One
            [ ]  15 Task Fifteen
            [X] 159 Task One Hundred Fifty Nine

            """;
        Assert.Equal(expectedReport, actualReport);
    }
}