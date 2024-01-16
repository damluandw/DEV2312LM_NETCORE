namespace Lab06_3_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>()
            {
                new Car("Toyota", "black"),
                new Car("Toyota", "red"),
                new Car("Toyota", "blue"),
                new Car("Toyota", "white"),
                new Car("BMW", "black"),
                new Car("BMW", "red"),
                new Car("BMW", "blue"),
                new Car("BMW", "white"),
                new Car("MayBach", "black"),
                new Car("MayBach", "red")
            };

            list.RemoveAll((x) => { return x.Color == "red"; });

            foreach (Car car in list)
            {
                Console.WriteLine(car.ToString());
            }


        }
    }
}
