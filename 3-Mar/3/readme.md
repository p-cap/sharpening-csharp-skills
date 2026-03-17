## Learning Code My Way
- Reference to follow
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/
- Topics
- Copy Pasta Code and commenting for further questioning and explanations
- Document that explains the code based on flow and order of declaration
- Output of the app
- FAQs for follow-up questions or other questions that linger within the codebase

## Topic(s)


## Document how to code this app
1. Declare Monitoring namespace with an enum, interface, and struct
2. Declare `HealthStatus` enum
3. Declare `IScanner` interface so the class `DeploymentManager` class can implement it
4. Declare `ScanResults` struct so that it can be used inside the DeploymentManager Scan function 
5. Ensure we have the ScanResults's constructor
6. Add the `NotifyDelegate` delegate type function which is instantiated and set from `_logger.LogToConsole`
7. Declare the `DeploymentManager` class that implements `IScanner`
8. Added the `Logging` namespace that has `Logger` struct with `LogToConsole` function
9. Instantiate the `Logging.Logger` struct
10. Declare the `NotifyDelegate` and set it to the `_logger.LogToConsole`
11. call `notifier(logMsg,currentStatus);` which is the `NotifyDelegate` instance
12. Implement the `Run()` function to call the `Scan("https://p-cap.ai");`
13. Instantiate `Monitoring.DeploymentManager()`
14. Call its `Run()` function

## OUTPUT
```
--- Deployment Monitoring System ---
[Healthy] LOG: Checked: https://p-cap.ai: OK (200)
```

## FAQs
- what is really a struct vs a class? What's the difference?
- Use primary constructor IDE0290 which was suggested by the compiler?
- variable that points to a function is a delegate? What does that even mean?
- What is a delegate? And, how are we able to set the notifier with the _logger.LogToConsole?
- If Run is calling scan, can we just encapsulate Scan?
    - We can say that we are encapsulating the Scan function
    - We are hiding implementation details -> When a user calls `monitor.Run()`, they don't need to know that `Run` 
- Member can be made 'readonly' (IDE0251)...what makes the compilter suggest that the member can be made readonly?
- CA1822: Mark members as static? Why mark it as static?