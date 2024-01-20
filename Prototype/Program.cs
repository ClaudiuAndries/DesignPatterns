using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype;


public static class ExtensionMethods
{
    public static T DeepCopy<T>(this T self)
    {
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, self);
        stream.Seek(0, SeekOrigin.Begin);
        object copy = formatter.Deserialize(stream);
        stream.Close();
        return (T)copy;
    }

    public static T DeepCopyXml<T>(this T self)
    {
        using(var ms = new MemoryStream())
        {

            XmlSerializer s = new XmlSerializer(typeof(T));
            s.Serialize(ms, self);
            ms.Position = 0;
            return (T)s.Deserialize(ms);
        }
    }
}

//[Serializable]
public class Person 
{
    public Person()
    {
    }


    public string[] Names;
    public Address Address;

    public Person(string[] names, Address address)
    {
        Names = names;
        Address = address;
    }

    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
    }
}
//[Serializable]
public class Address 
{
    public string StreetName;
    public int HouseNumber;
    public Address(string streetName, int houseNumber)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
    }
    
    public Address()
    {
    }

    public override string ToString()
    {
        return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }
}

class MainApp
{
    static void Main()
    {
        var John = new Person(new[] { "John", "Smith" },
            new Address("Test Road", 123));

        var Jane = John.DeepCopyXml();
        Jane.Names[0] = "Jane";
        Jane.Address.HouseNumber = 321;

        Console.WriteLine(John);
        Console.WriteLine(Jane);
    }
}