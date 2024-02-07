namespace TemplateMethodDesignPattern;

public abstract class Game
{
    public void Run()
    {
        Start();
        while (!HaveWinner)
        {
            TakeTurn();
        }

        Console.WriteLine($"Player {WinningPlayer} wins");
    }

    protected int currentPlayer;
    protected readonly int numberPlayers;

    protected Game(int numberPlayers)
    {
        this.numberPlayers = numberPlayers;
    }

    protected abstract void Start();
    protected abstract void TakeTurn();
    protected abstract bool HaveWinner { get; }
    protected abstract int WinningPlayer { get; }
}

public class Chess : Game
{
    public Chess() : base(2)
    {
    }

    protected override void Start()
    {
        Console.WriteLine($"Starting a game of chess with {numberPlayers} players");
    }

    protected override void TakeTurn()
    {
        Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}");
        currentPlayer = (currentPlayer +1 ) % numberPlayers;
    }

    protected override bool HaveWinner => turn == maxTurns;
    protected override int WinningPlayer => currentPlayer;

    private int turn = 1;
    private int maxTurns = 10;
}

public class Program
{
    static void Main(string[] args)
    {
        var chess = new Chess();
        chess.Run();
    }
}

