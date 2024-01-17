using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson06
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        public Employee(int id, string name, string phone, double salary)
        {
            Id = id;
            Name = name;
            Phone = phone;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return string.Format("{0,-5}{1,-15} {2,-15} {3:#,##0.##}",Id, Name, Phone, Salary); 
        }
    }
}
