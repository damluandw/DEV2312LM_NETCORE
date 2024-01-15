using System.Collections;

namespace Lab06_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            array.Add(new Product("A",5.9,3));
            array.Add(new Product("B", 4.6, 4));
            array.Add(new Product("C", 4.9, 3));
            array.Add(new Product("D", 7.8, 7));
            array.Add(new Product("E", 3.2, 9));
            array.Add(new Product("F", 5.6, 8));
            Console.WriteLine("Product list: ");
            foreach(Product p in array)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}