using TaskManager.Core.Models;

namespace TaskManager.Tests;

public class TaskContextTests
{
    [Fact]
    public void AddTask_AddsTaskToContext()
    {
        var context = new TaskContext();
        var task = context.AddTask(
            "Lære MVC",
            "Bygge taskmanager",
            new DateTime(2030, 1, 1)
        );

        Assert.Equal(1, context.Count);
        Assert.Equal(1, task.Id);
    }

    [Fact]
    public void AddTask_GeneratesUniqueIds()
    {
        var context = new TaskContext();

        var first = context.AddTask("Task 1", "Først task", new DateTime(2030, 1, 1));

        var second = context.AddTask("Task 2", "Second task", new DateTime(2030, 1, 1));

        Assert.Equal(1, first.Id);
        Assert.Equal(2, second.Id);
    }

    [Fact]
    public void CompleteTask_ReturnsFalse_WhenTaskDoesNotExist()
    {
        var context = new TaskContext();

        var result = context.CompleteTask(1234);

        Assert.False(result);
    }
}