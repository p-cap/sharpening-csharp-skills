/*
What is the difference between a struct and a class???
*/

// Struct is a VALUE type while class is a REFERENCE type

// instantiating mystruct
var myStruct = new MyStruct(67);

// this shows that structs are value types which means myStructTwo does not affect myStruct even though we change myStructTwo's value
var myStructTwo = myStruct;
myStructTwo.Value = 76;

// myStructTwo DID NOT affect the value of myStruct
Console.WriteLine($"The value of myStruct is {myStruct.Value}");
Console.WriteLine($"The value of myStruct is {myStructTwo.Value}");


var myClassOne = new MyClass(96);
// myClassTwo is referencing myClassOne
var myClassTwo = myClassOne;
myClassTwo.Value = 69;

// the value should equal because myClassTwo references myClassOne
// In C#, when you assign one instance of a class to another variable, you are copying the reference of the object, not the object itself.
Console.WriteLine(myClassOne.Value == myClassTwo.Value);
Console.WriteLine($"reference to myClassOne is {myClassOne}");
public struct MyStruct
{
    public int Value;

    public MyStruct(int value)
    {
        Value = value;
    }
}

public class MyClass
{
    public int Value;

    public MyClass(int value)
    {
        Value = Value;
    }
}