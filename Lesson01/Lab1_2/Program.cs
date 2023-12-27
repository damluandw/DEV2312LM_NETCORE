 namespace Lab1_2
{
    internal class Program
    {
        /// <summary>
        /// Chương trình minh hoạ việc sử dụng biến, hằng số và kiểu dữ liệu
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int id = 1;
            string name = "Dam Luan";
            byte age = 26;
            char gender = 'M';
            const float percent = 75.50F;
            Console.WriteLine("Student ID {0}", id);
            Console.WriteLine("Student Name {0}", name);
            Console.WriteLine("Age {0}", age);
            Console.WriteLine("Gender {0}", gender);
            Console.WriteLine("Percentage ID {0}", percent);
            Console.Read();
        }
    }
}