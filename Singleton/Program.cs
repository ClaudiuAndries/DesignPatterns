using MoreLinq;
namespace Singleton;

public interface IDatabase
{
    int GetPopulation(string name);
}

public sealed class SingletonDatabase : IDatabase
{
    private Dictionary<string, int> capitals;

    private SingletonDatabase()
    {
        Console.WriteLine("Initializing database");

        capitals = File.ReadAllLines(
          Path.Combine(
            new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
          )
          .Batch(2)
          .ToDictionary(
            list => list.ElementAt(0).Trim(),
            list => int.Parse(list.ElementAt(1)));
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }

    // laziness + thread safety
    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
    {
        return new SingletonDatabase();
    });

    public static IDatabase Instance => instance.Value;
}

class MainApp
{
    static void Main()
    {
        var db = SingletonDatabase.Instance;

        // works just fine while you're working with a real database.
        var city = "Tokyo";
        Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
    }
}