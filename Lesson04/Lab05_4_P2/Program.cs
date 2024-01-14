namespace Lab05_4_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department b = new Department("Van Phong", 4);
            b[0] = new Employee(211,"Khoa", 23);
            b[1] = new Employee(261,"Long", 26);
            b[2] = new Employee(222,"Tung", 24);
            b[3] = new Employee(981,"Anh", 27);
            //in thông tin sách
            Console.WriteLine(b.Name);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(b[i]);
            }
        }
    }
}
