namespace Lab3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.make = "Toyota";
            car.model = "MR2";
            car.color = "black";
            car.year = "1995";
            Console.WriteLine("Thong tin chi tiet:");
            Console.WriteLine("Make: " + car.make);   
            Console.WriteLine("Model: "+ car.model);
            Console.WriteLine("Color: " + car.color);
            Console.WriteLine("Year release: " + car.year);
            car.Start();
            car.Stop();
        }
    }
}