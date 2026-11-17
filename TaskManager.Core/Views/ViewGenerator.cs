using TaskManager.Core.Models;

namespace TaskManager.Core.Views;

public class ViewGenerator : IViewGenerator
{
    public void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("""
        === TASK MANAGER ===
        1. Vis alle oppgaver
        2. Legg til oppgave
        3. Marker oppgave som fullført
        0. Avslutt
        ====================
        """);
    }
    public void DisplayTasks(IEnumerable<IUserTask> tasks, string header)
    {
        Console.WriteLine($" === {header} ===");

        var hasTasks = false;

        foreach(var task in tasks)
        {
            hasTasks = true;

            var status = task.IsCompleted ? "FERDIG" : "ÅPEN";

            Console.WriteLine($"{task.Id}. {status} : {task.Title} (frist: {task.DueDate})");
        }
        if (!hasTasks)
        {
            Console.WriteLine("Ingen oppgaver.");
        }
    }
    public void DisplayMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
    }
    public string GetInput(string prompt)
    {
        Console.Write(prompt);

        return Console.ReadLine() ?? string.Empty;
    }
    public int GetIntInput(string prompt)
    {
        while(true)
        {
            var input = GetInput(prompt);

            if(int.TryParse(input, out var value))
            {
                return value;
            }

            DisplayMessage("Skriv et gyldig heltall.");
        }
    }

    public DateTime GetDateInput(string prompt)
    {
        while(true)
        {
            var input = GetInput(prompt);

            if (DateTime.TryParse(input,out var date))
            {
                return date;
            }


            DisplayMessage("Skriv en gyldig dato.");
        }
    }

    public void WaitForKey()
    {
        Console.WriteLine();
        Console.WriteLine("Trykk en tast for å fortsette...");

        Console.ReadKey();
    }
}