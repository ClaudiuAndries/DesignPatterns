namespace NullObjectDesignPattern;

public interface ILog
{
    void Info(string msg);
    void Warn(string msg);
}

public class ConsoleLog : ILog
{
    public void Info(string msg)
    {
        Console.WriteLine(msg);
    }

    public void Warn(string msg)
    {
        Console.WriteLine($"WARNING!!!: {msg}");
    }
}


public class BankAccount
{
    private ILog log;
    private int balance;

    public BankAccount(ILog log)
    {
        this.log = log;
    }

    public void Deposit(int amount)
    {
        balance += amount;
        log.Info($"Deposited {amount}, balance is now {balance}");
    }
}

public class NullLog : ILog
{
    public void Info(string msg)
    {
    }

    public void Warn(string msg)
    {
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var bankAccount = new BankAccount(new NullLog());

        bankAccount.Deposit(100);
    }
}
