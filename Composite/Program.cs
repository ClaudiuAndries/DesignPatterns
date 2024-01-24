using System.Text;

namespace CompositeDesignPattern;


public class Composite
{
    public virtual string Name { get; set; } = "Leaf";
    public string Color;

    protected Lazy<List<Composite>> children = new Lazy<List<Composite>>();
    public List<Composite> Children => children.Value;

    public void Print(StringBuilder sb, int depth)
    {
        sb.Append(new string('*', depth))
           .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : Color)
           .AppendLine(Name);
        foreach (var child in Children) 
            child.Print(sb, depth + 1);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        Print(sb, 0);
        return sb.ToString();
    }
}

public class Circle : Composite
{
    public override string Name => "Circle";
}
public class Square : Composite
{
    public override string Name => "Square";
}

class MainApp
{
    static void Main()
    {
        Composite composite = new Composite { Name = "Root" };

        composite.Children.Add(new Circle { Color = "Red" });
        composite.Children.Add(new Square { Color = "Yellow" });


        Composite composite2 = new Composite();
        composite2.Children.Add(new Circle { Color = "Blue" });
        composite2.Children.Add(new Square { Color = "Blue" });

        composite.Children.Add(composite2);

        Console.WriteLine(composite);

    }
}