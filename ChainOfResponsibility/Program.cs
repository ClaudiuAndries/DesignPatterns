using System.ComponentModel.Design;

namespace ChainOfResponsibilityDesignPattern;

public class Creature
{
    public string Name;
    public int Attack, Defense;

    public Creature(int defense, int attack, string name)
    {
        Defense = defense;
        Attack = attack;
        Name = name;
    }

    public override string ToString()
    {
        return $" Attack: {Attack}, Defense: {Defense}, Name: {Name}";
    }
}

public class CreatureModifier
{
    protected Creature creature;
    protected CreatureModifier next; // linked list


    public CreatureModifier(Creature creature)
    {
        this.creature = creature;
    }

    public void Add(CreatureModifier cm)
    {
        if (next != null) next.Add(cm);
        else next = cm;
    }

    public virtual void Handle()
    {
        next?.Handle();
    }
}

public class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Creature creature) : base(creature)
    {

    }

    public override void Handle()
    {
        Console.WriteLine($"Doubling {creature.Name}'s attack");
        creature.Attack *= 2;
        base.Handle();
    }
}

public class IncreaseDefenseModifier : CreatureModifier
{
    public IncreaseDefenseModifier(Creature creature) : base(creature)
    {

    }

    public override void Handle()
    {
        Console.WriteLine($"Increase {creature.Name}'s defense");
        creature.Defense += 3;
        base.Handle();
    }
}

public class NoBonusesModifier :  CreatureModifier
{
    public NoBonusesModifier(Creature creature) : base(creature)
    {

    }

    public override void Handle()
    {

    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var goblin = new Creature(2, 2, "Goblin");
        Console.WriteLine(goblin);

        var root = new CreatureModifier(goblin);

        root.Add((new NoBonusesModifier(goblin)));

        Console.WriteLine("Let's double the goblin's attack");
        root.Add((new DoubleAttackModifier(goblin)));

        Console.WriteLine("Let's increase the goblin's defense");
        root.Add((new IncreaseDefenseModifier(goblin)));

        root.Handle();
        Console.WriteLine(goblin);
    }
}

