using System;

Console.WriteLine("--- Deployment Monitoring System ---");

// 11. Instantiate Monitoring Deployment manager class
var monitor = new Monitoring.DeploymentManager();
monitor.Run();

// 1. Declare Monitoring namespace with an enum, interface, and struct
namespace Monitoring
{
    // 2. HealthStatus enum
    public enum HealthStatus { Healthy, Warning, Critical }

    // 3. IScanner interface
    public interface IScanner
    {
        void Scan(string url);
    }

    // 4. ScanResults struct
    // struct and class are quite similar
    // FAQ: what is really a struct vs a class?
    public struct ScanResults
    {
        public int StatusCode;
        public string Message;

        // 4a. ScanResults constructor
        // FAQ: Use primary constructor IDE0290
        public ScanResults(int code, string msg)
        {
            StatusCode = code;
            Message = msg;
        }
    }

    // 5. NotifyDelegate delegate type
    // FAQ: variable that points to a function is a delegate?
    public delegate void NotifyDelegate(string message, HealthStatus status);

    // 6. DeploymentManager class that implements IScanner
    public class DeploymentManager: IScanner
    {
        // FAQ: What is a practical application where "nested namespace" is needed
        // FAQ: Add readonly modifier (IDE0044)?
        private Logging.Logger _logger = new();

        // 8. DeploymentManager implementing IScanner
        public void Scan(string url)
        {
            
            // FAQ: What is the difference between a struct and a class?
            var result = new ScanResults(200, "OK");

            HealthStatus currentStatus = HealthStatus.Healthy;

            string logMsg = $"Checked: {url}: {result.Message} ({result.StatusCode})";

            // 9. Declare a NotifyDelegate instance
            // FAQ: What is a delegate?
            // FAQ: How are we able to set the notifier with the _logger.LogToConsole?
            NotifyDelegate notifier = _logger.LogToConsole;
            notifier(logMsg,currentStatus);
        }   

        // 10. Added Run function to call the scan function
        // FAQ: If Run is calling scan, can we just encapsulate Scan?
        // FAQ: Make Scan private?
        public void Run()
        {
            Scan("https://p-cap.ai");
        }
    }
    // 7. Logging namespace 
    namespace Logging
    {
        public struct Logger
        {
            // Member can be made 'readonly' (IDE0251)
            // CA1822: Mark members as static
            public  void LogToConsole(string msg, HealthStatus status)
            {
                Console.WriteLine($"[{status}] LOG: {msg}");
            }
        }
    }
}
