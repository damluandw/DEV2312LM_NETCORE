using System.Numerics;

namespace Lab08_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = { "To", "ve", "hon", "nguoi", "thi", "nguoi", "se", "tro", "thanh", "ke", "thu", "cua", "ta", "Chiu", "nhuong", "nguoi", "thi", "nguoi", "se", "la", "ban", "cua", "ta" };
            IEnumerable<string> result1 = from m in data select m;
            Console.WriteLine("Hiển thị kết quả");
            foreach (string item in result1) Console.Write(item + " ");

            IEnumerable<string> result2 = from m in data where m.Equals("nguoi") select m;

            Console.WriteLine("\nTruy van theo dieu kien");
            foreach (var item in result2)
            {
                Console.Write(item + " ");
            }

            //sap xep
            IEnumerable<string> result3 = from m in data orderby m select m;
            Console.WriteLine("\nHien thi sap xep");
            foreach (var item in result3)
            {
                Console.Write(item + " ");
            }

            //lay du lieu moi
            var result4 = from m in data select new { Thuong = m.ToLower(), Hoa = m.ToUpper() };
            Console.WriteLine("\nChu thuong va chu hoa");
            foreach (var item in result4)
            {
                Console.WriteLine(item.Thuong + "-" + item.Hoa);
            }

        }
    }
}