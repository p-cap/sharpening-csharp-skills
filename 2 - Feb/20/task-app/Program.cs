using Microsoft.VisualBasic;

Console.WriteLine("#-- Task App Mock --#");

/*
- Initialize a list of task
- Uses while loop for the console display 
- Asks for user input
- the user input will call specific functions based on the input
- the console app does:
    - task addition
    - task display
    - task update 
- IN THE SWITCH STATEMENT, 4 HAS THE RETURN KEYWORD AND I THIHK 4 IS WHAT TERMINATES THE WHILE LOOP?
- In this console app, the top-level statements are variable initializations and functions/methods
- On the other hand, class and enum are not top-level statement
*/


List<Task> tasks = [];

while(true)
{
    Console.WriteLine("Task Manager");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Update Task Status");
    Console.WriteLine("4. Exit");   

    string choice = Console.ReadLine();

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
    Console.WriteLine("Task added. ");
}

void ViewTasks()
{
    Console.WriteLine("Tasks: ");
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i].Title} - Status: {tasks[i].Status}");
    }
}

void UpdateTaskStatus()
{
    ViewTasks();
    Console.Write("Select a task number upgrade: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber <= tasks.Count)
    {
        Console.WriteLine("Select New Status: ");
        foreach (var status in Enum.GetValues(typeof(TaskStatus)))
        {
            Console.WriteLine($"{(int)status}:  {status}");
        }
        
        if (int.TryParse(Console.ReadLine(), out int statusNumber) && Enum.IsDefined(typeof(TaskStatus), statusNumber))
        {
            tasks[taskNumber - 1].Status = (TaskStatus)statusNumber;
            Console.WriteLine("Task status updated. ");
        }
        else
        {
            Console.WriteLine("Invalid Status");
        }
    }
    else
    {
        Console.WriteLine("Invalid Task number");
    }
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

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}
