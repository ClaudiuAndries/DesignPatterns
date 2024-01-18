using System;
namespace FactoryMethod;


public class Point
{
    private double x, y;

    protected Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // factory property

    public static Point Origin => new Point(0, 0);

    // singleton field
    public static Point Origin2 = new Point(0, 0);

    // factory method

    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }

    public static Point NewPolarPoint(double rho, double theta)
    {
        return null;
    }

    // make it lazy
    public static class Factory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Sin(theta), theta * Math.Cos(rho)); ;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var origin = Point.Origin;

        var p2 = Point.Factory.NewCartesianPoint(1, 2);
    }
}