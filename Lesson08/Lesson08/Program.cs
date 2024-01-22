namespace Lesson08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinQ!");
            // tập dữ liệu số
            int[] numbers = { 00, 6, 4, 2, 5, 7, 8, 2, 4, 9, 1, 9 };
            string[] words = { "chỉ", "trích", "phê", "phán", "người", "khác", "giống", "như", "con" };

            List<Film> films = new List<Film>()
            {
            new Film ( "F01", "Diep Van", 120000 ),
            new Film ( "F02", "Diep Van", 120000 ),
            new Film ( "F03", "Diep Van", 120000 ),
            new Film ( "F04", "Diep Van", 120000 ),
            new Film ( "F05", "Diep Van", 120000 ),
            new Film ( "F06", "Diep Van", 120000 ),
            new Film ( "F07", "Diep Van", 120000 ),
            new Film ( "F08", "Diep Van", 120000 ),
            };
            var list = from n in numbers select n;
            Console.WriteLine("Ket qua: ");
            printNumber(list);
            Console.WriteLine();
            list = from n in numbers where n > 5 select n;
            printNumber(list);
            Console.WriteLine();
            list = numbers.Where(n => n > 5);
            printNumber(list);
            Console.WriteLine();
            list = numbers.Skip(3);//.SkipWhile(n => n>3);
            printNumber(list);
            Console.WriteLine();
            list = numbers.SkipWhile(n => n > 3);
            printNumber(list);
            Console.WriteLine();
            list = numbers.OrderBy(x => x);
            printNumber(list);
            Console.WriteLine();
            list = numbers.OrderByDescending(x => x);
            printNumber(list);

            var ds = from p in films select p;
            Console.WriteLine();
            ds = films.Where(x => x.FilmPrice > 100000);
            printFlim(ds);
        }

        static void printNumber(IEnumerable<int> list)
        {
            Console.WriteLine("Danh sach");
            foreach (var item in list)
            {
                Console.Write("{0,5}", item);
            }
        }
        static void printFlim(IEnumerable<Film> list)
        {
            Console.WriteLine("Danh sach film");
            foreach (var item in list)
            {
                Console.WriteLine("{0,5} {1,-30} {2,20}", item.FilmID, item.FilmName, item.FilmPrice);
            }
        }
    }
}