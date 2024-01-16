using System.Collections;

namespace Lab06_1_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            Book[] books = {
                new Book(11, "Sach 1" , "Tac gia 1", "Nhi Dong",1995,200000),
                new Book(22, "Sach 2" , "Tac gia 2", "NSX 2",1992,230000),
                new Book(33, "Sach 3" , "Tac gia 3", "NSX 1",2000,440000),
                new Book(44, "Sach 4" , "Tac gia 4", "NSX 3",1995,560000),
                new Book(55, "Sach 5" , "Tac gia 4", "NSX 1",2014,280000),
                new Book(66, "Sach 6" , "Tac gia 11", "Nhi Dong",2006,400000),
                new Book(77, "Sach 7" , "Tac gia 11", "NSX 3",2009,760000),
                new Book(88, "Sach 8" , "Tac gia 2", "NSX 4 ",2010,320000),
                new Book(99, "Sach 9" , "Tac gia 3", "NSX 6",2011,120000),
                new Book(111, "Sach 11" , "Tac gia 4", "Nhi Dong",1996,650000),
            };

            array.AddRange(books);
            array.Sort( new SortPriceASC());
            printObject(array);

            Console.WriteLine("Nhap sach can tim kiem");
            string search = Console.ReadLine();
            foreach(Book book in array)
            {
                if (book.Title.ToUpper().Contains(search.ToUpper()))
                {
                    Console.WriteLine(book.ToString());
                }
            }

            
            Console.WriteLine("Nhung cuon sach xuat ban nam 2014: ");
            foreach (Book book in array)
            {
                if (book.Year == 2014)
                {
                    Console.WriteLine(book.ToString());
                }
            }

            Console.WriteLine("Xoa sach cua nha xuat ban nhi dong: ");
        
            ArrayList arrayRemove = new ArrayList();
            arrayRemove.AddRange( books);
            //int index = 0;
            foreach (Book book in arrayRemove)
            {
                if (book.Publisher == "Nhi Dong")
                {
                    array.Remove(book);
                }
            }
          
            array.Remove(arrayRemove);
            Console.WriteLine("Danh sach sau khi xoa la: ");
            printObject(array);

        }


        static void printObject(ArrayList arr)
        {
            Console.WriteLine("Danh sách:");
            foreach (Book item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
        class SortPriceASC : IComparer
        {
            public int Compare(object? obj1, object? obj2)
            {
                Book b1 = (Book)obj1;
                Book b2 = (Book)obj2;
                if (b1.Price > b2.Price)
                    return 1;
                else if (b1.Price < b2.Price)
                    return -1;
                return 0;
            }
        }

    }


}