var myUsingPrimaryConstructor = new UsingPrimaryConstructor(67, "six-seven");
Console.WriteLine(myUsingPrimaryConstructor.StatusCode);
Console.WriteLine(myUsingPrimaryConstructor.Message);

public struct UsingPrimaryConstructor(int code, string msg)
{
    public int StatusCode = code;
    public string Message = msg;
}


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

