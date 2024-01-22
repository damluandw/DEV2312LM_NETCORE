namespace Lab07_3_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine("Nhap thong tin sinh vien");
            Console.Write("ID:");
            student.Id = Console.ReadLine();
            Console.Write("Name:");
            student.Name = Console.ReadLine();
            try
            {
                Console.Write("TheoryMark:");
                student.TheoryMark = Convert.ToDouble( Console.ReadLine());
                if (student.TheoryMark < 0 || student.TheoryMark > 10)
                    throw new InvalidMarkException();
                Console.Write("LabMark:");
                student.LabMark = Convert.ToDouble(Console.ReadLine());
                if (student.LabMark < 0 || student.LabMark > 10)
                    throw new InvalidMarkException();
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

    public class InvalidMarkException : Exception {
        public InvalidMarkException():base("Diem phai nam trong khoang 0-10") { }
    }
}