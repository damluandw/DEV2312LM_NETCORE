namespace Lab08_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new Customer[]
            {
                new Customer (5,"Sam"),
                new Customer (6,"Dave"),
                new Customer (7,"Julia"),
                new Customer (8,"Sue"),
            };
            var orders = new Order[]
            {
                new Order (5,"Book"),
                new Order (6,"Game"),
                new Order (7,"Computer"),
                new Order (8,"Phone"),
            };

            var query = from c in customers
                        join o in orders on c.Id equals o.Id
                        select new { c.Name, o.Product };
            foreach (var group in query)
            {
                Console.WriteLine ("{0} bought {1}", group.Name, group.Product);
            }
        }
    }
}