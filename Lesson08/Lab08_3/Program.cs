namespace Lab08_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 7, 9, 3, 5, 2, 1, 0, 6, 4, 3, 1 };
            string[] words = { "chỉ", "trích", "phê", "phán", "người", "khác", "giống", "như", "con", "chim", "bồ", "câu", "đưa","thư","bao","giờ","cũng","chạy","về","nơi","xuất","phát" };

            List<Film> films = new List<Film>()
            {
            new Film ( "F01", "Diep Van", 120000 ),
            new Film ( "F02", "Tam quoc dien nghia", 130000 ),
            new Film ( "F03", "Thieu lam truyen ky", 160000 ),
            new Film ( "F04", "Nguoi nhen 2", 100000 ),
            new Film ( "F05", "Ngan hang tinh yeu", 120000 ),
            new Film ( "F06", "Nguoi dep va quai thu", 340000 ),
            new Film ( "F07", "Biet dong sai gon", 230000 ),
            new Film ( "F08", "Diep Van", 190000 ),
            };

            IEnumerable<int> queryNumber = from n in numbers where n %2 == 0 select n;
            Show<int>(queryNumber, "Loc so chan");
  
            IEnumerable<string> queryString = words.Where(s =>  s.Length >4);
            Show<string>(queryString, "Loc cac tu co do dai lon hon 4");

            IEnumerable<string> queryT = words.Where(s => s.StartsWith("T"));
            Show<string>(queryT, "Loc cac tu co chu bat dau bang T");

            IEnumerable<int> uniqueNumber =numbers.Distinct();
            Show<int>(uniqueNumber, "Loc cac so trung nhau");

            var countDisninct = numbers.Distinct().Count();
            Console.WriteLine("Dem co bao nhieu so khong trung nhau: " + countDisninct);

            var fournumber = numbers.Take(4);
            Show<int>(fournumber, "Lay 4 so dau tien trong day");

            var twoWord = words.Take(2);
            Show<string>(twoWord, "Lay 2 tu dau tien trong chuoi");

            var searchWord = words.Where(w => w.Contains("t"));
            Show<string>(searchWord, "Cac tu trong chuoi co chua chu t:");

            //sap xep don gia va lay gia tri dau  tien co don gia nho hon 200000
            var queryFilm = films.OrderBy(f => f.FilmPrice).Select(x => new { x.FilmID, x.FilmName, x.FilmPrice })
                .ToList().TakeWhile(t => t.FilmPrice < 200000);
            //bo qua 3 phan tu dau
            var skipNumber = numbers.Skip(3);
            Show<int>(skipNumber, "bo qua 3 phan tu dau");
            //bo qua 4 phan tu dau, lay 3 phan tu ke tiep
            var skipTakeNumber = numbers.Skip(4).Take(3);
            Show<int>(skipTakeNumber, "bo qua 4 phan tu dau, lay 3 phan tu ke tiep");

            // sap xep giam dan sau do lay cac phan tu nho hon 5
            var sortNumber = numbers.OrderByDescending(x => x).SkipWhile(x => x >= 5);
            Show<int>(sortNumber, "sap xep giam dan sau do lay cac phan tu nho hon 5");


        }

        static void Show<T>(IEnumerable<T> data, string message)
        {
            Console.WriteLine(message);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}