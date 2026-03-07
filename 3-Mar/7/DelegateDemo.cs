// what is a delegate?
// variable that points to a function is a delegate? What does that even mean?
// Delegate is a type-safe function pointer
// IT IS A VARIABLE THAT HOLDS REFERENCE TO FUNCTION THAN A VALUE

// 1. Declaration: Defines the "shape" (Input: string, Output: void)
public delegate void SayWassup(string msg);

class Program
{
    static void Main()
    {
        // 2. Instantiation: Point the delegate to a specific method
        SayWassup mySayWassup = Kamusta;

        // 3. Invocation: Call the delegate like a function
        mySayWassup("YO");
    }
    static void Kamusta(string text)
    {
        Console.WriteLine($"{text} from p-cap");
    }
}


