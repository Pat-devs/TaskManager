using TaskManager.Core.Models;

namespace TaskManager.Tests;

public class UserTaskTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        var dueDate = new DateTime(2030, 1, 1);
        var task = new UserTask(
            1, 
            "Filme video",
            "Filme lang video",
            dueDate
        );

        Assert.Equal(1, task.Id);
        Assert.Equal("Filme video", task.Title);
        Assert.Equal("Filme lang video", task.Description);
        Assert.Equal(dueDate, task.DueDate);
        Assert.False(task.IsCompleted);
    }

    [Fact]
    public void MarkAsCompleted_SetsIsCompletedToTrue()
    {
        var dueDate = new DateTime(2030, 1, 1);
        var task = new UserTask(
            1, 
            "Filme video",
            "Filme lang video",
            dueDate
        );

        task.MarkAsCompleted();

        Assert.True(task.IsCompleted);
    }
}
