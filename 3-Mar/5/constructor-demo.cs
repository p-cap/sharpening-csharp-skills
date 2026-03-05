
// this should NOT cause an error because we can use parameterless constructor
var myClass = new MyClass();

// this should cause an error because structs are NOT allowed to have parameterless constructors
var myStruct = new MyStruct();


public struct MyStruct
{
    public int Value;

    // Uncommenting the following line will result in a compile-time error.
    public MyStruct() {} // Error: Structs cannot have a parameterless constructor

    public MyStruct(int value)
    {
        Value = value;
    }
}

public class MyClass
{
    public int Value;

    // This is a valid parameterless constructor
    public MyClass() {}

    public MyClass(int value)
    {
        Value = value;
    }
}