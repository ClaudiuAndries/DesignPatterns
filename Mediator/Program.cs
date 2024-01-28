using System.Threading.Tasks.Dataflow;

namespace MediatorDesignPattern;

public class Person
{
    public string Name;
    public ChatRoom room;
    private List<string> chatLog = new List<string>();

    public Person(string name)
    {
        Name = name;
    }

    public void Say(string message)
    {
        room.Broadcast(Name, message);
    }

    public void PrivateMessage(string who, string message)
    {
        room.Message(Name, who, message);
    }

    public void Recive(string sender, string message)
    {
        string s = $"{sender}: {message}";
        chatLog.Add(s);
        Console.WriteLine($"[{Name}'s chat session] {s}");
    }
}

public class ChatRoom
{
    private List<Person> people = new List<Person>();

    public void Join(Person p)
    {
        string joinMsg = $"{p.Name} joins the chat";
        Broadcast("room", joinMsg);
        p.room = this;
        people.Add(p);
    }

    public void Broadcast(string source, string message)
    {
        foreach (var p in people)
        {
            if (p.Name != source)
                p.Recive(source, message);
        }
    }

    public void Message(string source, string destination, string message)
    {
        people.FirstOrDefault(p => p.Name == destination)
            ?.Recive(source, message);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var room = new ChatRoom();

        var john = new Person("John");
        var jane = new Person("Jane");

        room.Join(john);
        room.Join(jane);

        john.Say("Hi");
        jane.Say("Hello john");

        jane.PrivateMessage("john", "Hello there");
    }
}
