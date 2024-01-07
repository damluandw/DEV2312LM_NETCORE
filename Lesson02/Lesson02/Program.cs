namespace Lesson02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo đối tượng
            Category  category = new Category();
            // Truy cập đến thuộc tính
            //category.ID = 1;
            //category.Name = "Khoa";
            //// Tuy cập đến phương thức
            //category.Display();

         /*   Employee employee = new Employee();
            employee.Id = 1;
            employee.fullName = "DamLuan";
            employee.salary = 9;
            employee.printInfo();
            employee = new Employee(222, "Devmaster", 622);
            employee.printInfo();
*/

            // test Caculator
            // sử dụng phương thức tĩnh
            int kq = Caculator.Add(10, 20);
            Console.WriteLine(kq);
            kq = Caculator.Sub(10, 20);
            Console.WriteLine(kq);
            //kq = Caculator.Mul(10, 20); -> errorr
            Caculator caculator = new Caculator();
            kq = caculator.Mul(10, 20);
            Console.WriteLine(kq);

            // ref// out
            int cong, tru;
            caculator.Calc(10, 20, out cong,out tru);
            Console.WriteLine("Cong:\t" + cong);
            Console.WriteLine("Tru:\t" + tru);

            int num1 = 100;
            int num2 = 200;
            Console.WriteLine("num1: {0} / num2 {1}" , num1, num2);
            caculator.Swap(num1,num2);
            Console.WriteLine("swap num1: {0} / num2 {1}", num1, num2);
            caculator.Swap(ref num1,ref num2);
            Console.WriteLine("swap(ref) num1: {0} / num2 {1}", num1, num2);

        }
    }
}