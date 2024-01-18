namespace Builder;

public class Pizza
{
    public string Dough, Sauce, Cheese, Topping, Size;

    // address
    public string StreetAddress, Postcode, City;

    public override string ToString()
    {
        return $"{nameof(Dough)}: {Dough}, {nameof(Sauce)}: {Sauce}, {nameof(Cheese)}: {Cheese}, {nameof(Topping)}: {Topping}, {nameof(Size)}: {Size}, {nameof(StreetAddress)}: {StreetAddress}, " +
               $"{nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}";
    }
}

public class PizzaBuilder // Facade
{
    protected Pizza pizza = new Pizza();

    public PizzaIngredientsBuilder Ingredients => new PizzaIngredientsBuilder(pizza);
    public PizzaAddressBuilder Address => new PizzaAddressBuilder(pizza);

    public static implicit operator Pizza(PizzaBuilder pb) => pb.pizza; 
}
//INGREDIENTS
public class PizzaIngredientsBuilder : PizzaBuilder
{
    public PizzaIngredientsBuilder(Pizza pizza)
    {
        this.pizza = pizza;
    }
    public PizzaIngredientsBuilder SetDough(string dough)
    {
        pizza.Dough = dough;
        return this;
    }
    public PizzaIngredientsBuilder SetSauce(string sauce)
    {
        pizza.Sauce = sauce;
        return this;
    }
    public PizzaIngredientsBuilder SetTopping(string topping)
    {
        pizza.Topping = topping;
        return this;
    }
    public PizzaIngredientsBuilder SetSize(string size)
    {
        pizza.Size = size;
        return this;
    }
}
// Address
public class PizzaAddressBuilder : PizzaBuilder
{
    public PizzaAddressBuilder(Pizza pizza)
    {
        this.pizza = pizza;
    }
    public PizzaAddressBuilder At(string streetAddress)
    {
        pizza.StreetAddress = streetAddress;
        return this;
    }
    public PizzaAddressBuilder WithPostcode(string postcode)
    {
        pizza.Postcode = postcode;
        return this;
    }
    public PizzaAddressBuilder AtCity(string city)
    {
        pizza.City = city;
        return this;
    }
}


class MainApp
{
    static void Main()
    {
        var pizzaBuilder = new PizzaBuilder();
        Pizza pizza = pizzaBuilder.Ingredients
                        .SetDough("Normal")
                        .SetSauce("Ketchup")
                        .SetSize("Large")
                        .SetTopping("Test")
                    .Address
                        .At("Street Test")
                        .AtCity("Iasi")
                        .WithPostcode("A12 B345");

        Console.WriteLine(pizza);
    }
}
