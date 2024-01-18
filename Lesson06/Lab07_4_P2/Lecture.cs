using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07_4_P2
{
    internal class Lecture
    {
        public string Name { get; set; }    
        public double Salary { get; set; }
        public double Bonus { get; set; }
        public Lecture() { }
        public Lecture(string name, double salary, double bonus)
        {
            Name = name;
            Salary = salary;
            Bonus = bonus;
        }

        public override string ToString()
        {
            return "Name: " + Name +" \tSalary: "+ Salary + "\tBonus"+ Bonus;
        }
    }
}
