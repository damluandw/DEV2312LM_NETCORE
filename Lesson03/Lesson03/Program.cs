namespace Lesson03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");
            Student student = new Student();
            student.Display();

            student = new Student(111, "Devmaster", 6);
            student.Display(); 


            student.Id = 1;
            student.Name = "Test";
            student.Age = 30;
            student.Display();*/

            /*OverLoadDemo over = new OverLoadDemo();
            int res = over.Sum(10);
            Console.WriteLine("tong : {0} =>{1}",10,res);
            res = over.Sum(0,10);
            Console.WriteLine("tong : {0},{1} =>{2}",0, 10, res);

            double kq = over.Sum(10.1f,10.2f);
            Console.WriteLine("tong : {0},{1} =>{2}", 10.1, 10.2, kq);*/
            /*Animal animal = new Animal();
            animal.Eat();
            animal.DoSomething();

            Cat cat = new Cat();
            cat.Eat();
            cat.DoSomething();
            cat.Action();*/

            // inderistance
            Staff staff = new Staff();
            staff.printInfo();
            staff = new Staff(123,"Dam Luan", "25 vu ngoc phan", "09768563", 1000, 123.123f);
            staff.printInfo();
            Console.WriteLine(staff.ToString());
        }
    }
}