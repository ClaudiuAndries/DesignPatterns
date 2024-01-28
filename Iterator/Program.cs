namespace Iterator2DesignPattern;
public class Node<T>
{
    public T Value;
    public Node<T> Left, Right;
    public Node<T> Parent;

    public Node(T value)
    {
        Value = value;
    }

    public Node(T value, Node<T> left, Node<T> right)
    {
        Value = value;
        Left = left;
        Right = right;
        left.Parent = right.Parent = this;
    }

}
public class BinaryTree<T>
{
    private Node<T> root;

    public BinaryTree(Node<T> root)
    {
        this.root = root;
    }
    public IEnumerable<Node<T>> InOrder
    {
        get
        {
            IEnumerable<Node<T>> Traverse(Node<T> current)
            {
                if (current.Left != null)
                {
                    foreach (var left in Traverse((current.Left)))
                        yield return left;
                }
                yield return current;

                if (current.Right != null)
                {
                    foreach (var right in Traverse((current.Right)))
                        yield return right;
                }
            }

            foreach (var node in Traverse(root))
            {
                yield return node;
            }
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
        var tree = new BinaryTree<int>(root);
        Console.WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));
    }
}
