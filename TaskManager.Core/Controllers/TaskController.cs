using TaskManager.Core.Models;
using TaskManager.Core.Views;

namespace TaskManager.Core.Controllers;

public class TaskController
{
    private readonly TaskContext _context;
    private readonly ViewGenerator _view;

    public TaskController(TaskContext context, ViewGenerator view)
    {
        _context = context;
        _view = view;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            _view.DisplayMainMenu();

            var choice = _view.GetInput("Velg et alternativ: ");

            switch (choice)
            {
                case "1":
                    ViewAllTasks(); 
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    _view.DisplayMessage("Ugyldig valg.");
                    _view.WaitForKey();
                    break;
            }
        }

        _view.DisplayMessage("Programmet avsluttes.");
    }
    private void ViewAllTasks()
    {
        var tasks = _context.GetAllTasks();
        _view.DisplayTasks(tasks, "Alle oppgaver");
        _view.WaitForKey();
    }
    private void AddTask()
    {
        var title = _view.GetInput("Tittel: ");
        var description = _view.GetInput("Beskrivelse: ");
        var dueDate = _view.GetDateInput("Frist: ");

        try
        {
            var task = _context.AddTask(title, description, dueDate);

            _view.DisplayMessage($"Oppgave {task.Id} ble opprettet.");
        }
        catch (ArgumentException exception)
        {
            _view.DisplayMessage(exception.Message);
        }

        _view.WaitForKey();
    }
    private void CompleteTask()
    {
        var tasks = _context.GetAllTasks();

        _view.DisplayTasks(tasks, "Alle oppgaver");

        if (tasks.Count == 0)
        {
            _view.WaitForKey();
            return;
        }

        var id = _view.GetIntInput("Id på oppgaven: ");

        var success = _context.CompleteTask(id);

        if (success)
        {
            _view.DisplayMessage("Oppgaven ble markert som utført.");
        }
        else
        {
            _view.DisplayMessage("Fant ingen oppgave med den id-en");
        }

        _view.WaitForKey();
    }
}