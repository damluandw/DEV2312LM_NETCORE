using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson02
{
    /// <summary>
    /// Tạo lớp đối tượng Employee
    /// tạo các thuộc tínhh tự động : ID, fullName, salary
    /// tạo phương thức printInfo
    ///     hiển thị thông tin nhân vân
    ///  test trong main của programs
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public double  salary { get; set; }

        public void printInfo()
        {
            Console.WriteLine("Id:\t" + Id);
            Console.WriteLine("Name:\t" + fullName);
            Console.WriteLine("salary:\t" + salary);
        }

        public Employee(int Id, string fullName, double salary)
        {
            this.Id = Id;
            this.fullName = fullName;
            this.salary = salary;
        }
        public Employee()
        {
        }
    }
}
