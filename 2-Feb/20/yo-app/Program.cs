// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Yo Mundo! ");
Console.WriteLine(TaskStatus.Completed);

// why not a valid modifier for this case????
// static List<Task> tasks = new List<Task>();
List<Task> tasks = new List<Task>();

while(true)
{
    Console.WriteLine("Task Manager");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Update Task Status");
    Console.WriteLine("4. Exit");

    // Converting null literal or possible null value to non-nullable type.
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask();
            break;
        case "2":
            ViewTasks();
            break;
        case "3":
            UpdateTaskStatus();
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid choice, try again.");
            break;
    }
    Console.WriteLine();
}


void AddTask()
{
    Console.Write("Enter task title: ");
    string title = Console.ReadLine();
    tasks.Add(new Task(title));
    Console.WriteLine("Task added.");
}

void ViewTasks()
{
    Console.WriteLine("Tasks:");
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i].Title} - Status: {tasks[i].Status}");
    }
}

void UpdateTaskStatus()
{
    ViewTasks();
    Console.Write("Select a task number to upgrade: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber <= tasks.Count) {
        Console.WriteLine("Select New Status: ");
        foreach (var status in Enum.GetValues(typeof(TaskStatus)))
        {
            Console.WriteLine($"{(int)status}, status");
        }
        if (int.TryParse(Console.ReadLine(), out int statusNumber) && Enum.IsDefined(typeof(TaskStatus), statusNumber))
        {
            tasks[taskNumber - 1].Status = (TaskStatus)statusNumber;
            Console.WriteLine("Task status updated.");
        } 
        else
        {
            Console.WriteLine("Invalid Staus");
        }
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}


public enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}

public class Task
{
    public string Title {get; set;}
    public TaskStatus Status {get; set;}

    public Task(string title)
    {
        Title = title;
        Status = TaskStatus.Pending;

    }
}
