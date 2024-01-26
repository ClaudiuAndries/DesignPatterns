//using System.Security.Cryptography.X509Certificates;

//namespace ProtectionProxyDesignPattern;

//public interface ICar
//{
//    void Drive();
//}

//public class Car : ICar
//{
//    public void Drive()
//    {
//        Console.WriteLine("You are driving");
//    }
//}

//public class Driver
//{
//    public int Age { get; set; }

//    public Driver(int age)
//    {
//        Age = age;
//    }
//}

//public class CarProxi : ICar
//{
//    private Driver driver;
//    private Car car = new Car();

//    public CarProxi(Driver driver)
//    {
//        this.driver = driver;
//    }

//    public void Drive()
//    {
//        if (driver.Age >= 16)
//        {
//            car.Drive();
//        }
//        else
//        {
//            Console.WriteLine("too young");
//        }
//    }
//}
////internal class Program
////{
////    static void Main(string[] args)
////    {
////        ICar car = new CarProxi(new Driver(12));
////        car.Drive();
////    }
////}
