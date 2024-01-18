namespace Lab07_4_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lecture lecture = new Lecture();
            Console.WriteLine("Nhap thong tin giang vien");
            Console.Write("Name:");
            lecture.Name = Console.ReadLine();
            try
            {
                Console.Write("Salary:");
                lecture.Salary = Convert.ToDouble(Console.ReadLine());
                if (lecture.Salary  < 60000)
                    throw new AmountException("Salary khong duoc nho hon 60,000$");
                Console.Write("Bonus:");
                lecture.Bonus = Convert.ToDouble(Console.ReadLine());
                if (lecture.Bonus > 10000)
                    throw new AmountException("Thuong khong duoc lon hon 10,000$");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Khong duoc nhap ky tu cho mang so");
            }
        }
    }

    public class AmountException :Exception { 
        public AmountException(string msg):base(msg) {
        }
    }
}
