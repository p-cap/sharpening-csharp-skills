Console.WriteLine("#-- Yo Mundo --#");
Console.WriteLine("Class Demo");


var mytask = new Task("wassup");
Console.WriteLine(mytask.Title);
Console.WriteLine(mytask.Status);



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

