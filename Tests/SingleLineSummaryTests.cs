using Logic;

namespace Tests;

public class SingleLineSummaryTests
{
    [Fact]
    public void SingleDigitIdWorks()
    {
        //Arrange
        var task = new TaskItem(1, "Task 1", "This is a long description", false);
        var expectedSummary = "[ ]   1 Task 1";

        //Act
        var actualSummary = task.SingleLineSummary();

        //Assert
        Assert.Equal(expectedSummary, actualSummary);
    }

    [Fact]
    public void TwoDigitIdWorks()
    {
        //Arrange
        var task = new TaskItem(12, "Task 1", "This is a long description", false);
        var expectedSummary = "[ ]  12 Task 1";

        //Act
        var actualSummary = task.SingleLineSummary();

        //Assert
        Assert.Equal(expectedSummary, actualSummary);
    }

    [Fact]
    public void ThreeDigitIdWorks()
    {
        //Arrange
        var task = new TaskItem(123, "Task 1", "This is a long description", false);
        var expectedSummary = "[ ] 123 Task 1";

        //Act
        var actualSummary = task.SingleLineSummary();

        //Assert
        Assert.Equal(expectedSummary, actualSummary);
    }
}
