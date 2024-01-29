using System.Text;

namespace StrategyDesignPattern;

public enum OutputFormat
{
    Markdown,
    Html
}

public interface IListStrategy
{
    void Start(StringBuilder  sb);
    void End(StringBuilder  sb);
    void AddListItem(StringBuilder  sb, string item);
}

public class HtmlListStrategy : IListStrategy
{
    public void Start(StringBuilder sb)
    {
        sb.AppendLine("<ul>");
    }

    public void End(StringBuilder sb)
    {
        sb.AppendLine("</ul>");
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($" <li>{item}</li>");
    }
}

public class MarkdownlListStrategy : IListStrategy
{
    public void Start(StringBuilder sb)
    {
    }

    public void End(StringBuilder sb)
    {
    }

    public void AddListItem(StringBuilder sb, string item)
    {
        sb.AppendLine($" * {item}");
    }
}

public class TextProcessor
{
    private StringBuilder sb = new StringBuilder();
    private IListStrategy listStrategy;

    public void SetOutputFormat(OutputFormat format)
    {
        switch (format)
        {
            case OutputFormat.Markdown:
                listStrategy = new MarkdownlListStrategy();
                break;
            case OutputFormat.Html:
                listStrategy = new HtmlListStrategy();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(format), format, null);
        }
    }

    public void AppendList(IEnumerable<string> items)
    {
        listStrategy.Start(sb);
        foreach (string item in items)
        {
            listStrategy.AddListItem(sb, item);
        }
        listStrategy.End(sb);
    }

    public StringBuilder Clear()
    {
        return sb.Clear();
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}



internal class Program
{
    static void Main(string[] args)
    {
        var tp = new TextProcessor();

        tp.SetOutputFormat(OutputFormat.Markdown);
        tp.AppendList(new[] {"foo", "bar", "baz"});
        Console.WriteLine(tp);

        tp.Clear();

        tp.SetOutputFormat(OutputFormat.Html);
        tp.AppendList(new[] { "foo", "bar", "baz" });
        Console.WriteLine(tp);
    }
}
