using Business;
using Business.Dealership;
namespace Lab07_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House("HS12345",452000);
            Console.WriteLine("House detail");
            Console.WriteLine(house.ToString());

            Car car = new Car("CAR12345", 45200);
            Console.WriteLine("Car detail");
            Console.WriteLine(car.ToString());

        }
    }
}