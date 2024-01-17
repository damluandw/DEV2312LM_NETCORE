namespace Lesson06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee(1,"Nguyen Van A","0945667886", 13212425.2),
                new Employee(2,"Nguyen Van B","0945667886", 13212425.5),
                new Employee(3,"Nguyen Van C","0945667886", 13212425.1)
            };
            Console.WriteLine("Danh sach nhan vien");
            foreach (Employee e in list)
            {
                Console.WriteLine(e.ToString());
            }

            // sort
            //list.Sort((x, y) => { return (int)(y.Salary - x.Salary); });
            list.Sort((x, y) => {
                if (y.Salary > x.Salary)
                    return 1;
                else if (y.Salary > x.Salary)
                    return -1;
                return 0;
            });
            Console.WriteLine("Danh sach nhan vien");
            foreach (Employee e in list)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}