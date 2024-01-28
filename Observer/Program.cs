using System.Threading.Channels;

namespace ObserverDesignPattern;

public class Person
{
    public event EventHandler<FallsIllEventArgs> FallsIll;

    public void CatchACold()
    {
        FallsIll?.Invoke(this, new FallsIllEventArgs{ Address = "Test" });
    }
}

public class  FallsIllEventArgs
{
    public string Address;
}

internal class Program
{
    static void Main(string[] args)
    {
        var person = new Person();

        person.FallsIll += CallDoctor;

        person.CatchACold();

        person.FallsIll -= CallDoctor;
    }

    private static void CallDoctor(object? sender, FallsIllEventArgs e)
    {
        Console.WriteLine($"A doctor has been called to {e.Address}");
    }
}
 
