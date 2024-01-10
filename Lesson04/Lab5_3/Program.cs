namespace Lab5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Student st = new Student(3,2);
            st[0] = "Nam";
            st[0, 0] = 9;
            st[0, 1] = 6.5;
            st[1] = "Long";
            st[1, 0] = 6;
            st[1, 1] = 7;
            st[1] = "Khoa";
            st[1, 0] = 6.8;
            st[1, 1] = 7.9;
            for (int i = 0; i < 3; i++) {
                Console.WriteLine("Họ và tên: ", st[i]);
                Console.Write("Điểm: ");
                for (int j = 0; j < 2; j++)
                {
                    Console.Write( st[i,j] +",");
                }
                Console.WriteLine();
            }
        }
    }
}