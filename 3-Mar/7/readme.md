## Learning Code My Way
- Reference to follow
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/
- Topics
- Copy Pasta Code and commenting for further questioning and explanations
- Document that explains the code based on flow and order of declaration
- Output of the app
- FAQs for follow-up questions or other questions that linger within the codebase

## Topic(s)
- Use primary constructor IDE0290
- What is a `delegate`?

## Tidbit
- `#error version` inside my code can give me the c# language version

## Using the primary constructor
- because I am using C# version 14, I can use the primary constructor for my parameters
- the code below is NOT using the primary constructor to pass parameters into the class
```
public struct NotUsingPrimaryConstrutor
{
    public string Primary;
    public int Version;

    public NotUsingPrimaryConstrutor(string p, int v)
    {
        Primary = p;
        Version = v;
    }
}

```
- I used quick fix to change my class into using the primary constructor in accepting parameters
```
public struct UsingPrimaryConstructor(int code, string msg)
{
    public int StatusCode = code;
    public string Message = msg;
}
```

## Using delegate 
- What is a delegate -> it is a variable that holds reference to a function than a value
- Steps on how we showcased `delegate`
    - declaration -> define the shape of the delegate
    - instantiation -> points the delegate to a specific method. NOTE: make sure the method has the same shape as the delegate
    - invocation -> call the delegate as a function
