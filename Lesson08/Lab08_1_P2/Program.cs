using System.Diagnostics;
using System.Xml.Linq;

namespace Lab08_1_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book(1,"Lap trinh Java","TG12", 9800,"Giao duc" ,1998),
                new Book(2,"Lap trinh Cshap","TG21", 2400,"Giao duc" ,2000),
                new Book(3,"SQL server","TG31", 700,"Giao duc" ,2001),
                new Book(4,"Khoa hoc may tinh","TG54", 2300,"Giao duc" ,2012),
                new Book(5,"Luat co ban","TG33", 2700,"Giao duc" ,2006),
                new Book(6,"Kinh doanh tu con so khong","TG21", 4300,"NSB 321" ,2006),
                new Book(7,"Cha giau cha ngheo","TG56", 5600,"NSB 76" ,2016),
                new Book(8,"Danh thuc con nguoi phi thuong trong ban","TG77", 7800,"NSB 1" ,2015),
                new Book(9,"Muon kiep nhan sinh","TG444", 9600,"NSB 81" ,2008),
                new Book(10,"Hoa vang tren co xanh","TG144", 3500,"NSB7 1" ,2004),
            };

            Console.WriteLine();
            var queryAll = from book in books select book;
            Show(queryAll,"Danh sach tat ca cac quyen sach");
            Console.WriteLine();
            var query = from book in books where book.Price>1000 && book.Price <5000  select book;
            Console.WriteLine();
            Show(query, "Danh sach co gia tu 1000 den 5000 ");
            query = books.Where(x=> x.Year == 2015);
            Console.WriteLine();
            Show(query, "Danh sach xuat ban nam 2015 ");
            query = books.Where(x => x.Name.Contains("Lap trinh"));
            Console.WriteLine();
            Show(query, "Danh sach quyen sach co ten lap trinh");
            query = books.Where(x => x.Pushlisher.Contains("Giao duc"));
            Console.WriteLine();
            Show(query, "Danh sach co nha xuat ban giao duc ");
        }

        static void Show(IEnumerable<Book> data, string message)
        {
            Console.WriteLine(message);
            foreach (var item in data)
            {
                Console.WriteLine("ID: {0,4} Name: {1,-30} Author: {2,-20} Price: {3,15} Pushlisher: {4,-20} Year: {5,6}", item.Id, item.Name, item.Author, item.Price, item.Pushlisher, item.Year);
            }
        }
    }
}