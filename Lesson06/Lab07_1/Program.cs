using Store;
namespace Lab07_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supply.Manufacturer  dealer = new Supply.Manufacturer("Coca cola","cocacola@gmail.com","0662156778");
            Console.WriteLine("Manufacturer");
            Console.WriteLine(dealer.ToString());
            StoreItem si = new StoreItem(11,"Fanta",80.00M);
            Console.WriteLine("Store Item");
            Console.WriteLine(si.ToString());
        }
    }
}