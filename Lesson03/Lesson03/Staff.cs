using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    internal class Staff: Person
    {
        public float Salary { get; set; }

        public Staff() { 
        }
        public Staff(int id, string name, string address, string phone, float baseSalary,float salary):base(id,name, address,phone, baseSalary) { 
            this.Salary = salary;
        }
        public void printInfo()
        {
            //Console.WriteLine("ID: {0}",Id);
            //Console.WriteLine("Name: {0}", Name);
            //Console.WriteLine("Adress: {0}", Address);
            //Console.WriteLine("Phone: {0}", Phone);
            base.printInfo();
            Console.WriteLine("Salary: {0}", Salary);
        }


        //ghi đè phương thức overriding (polymorphism)
        public override float GetSalary()
        {
            return base.GetSalary() + Salary;
        }
        public override string ToString()
        {
            return base.ToString() + string.Format(" | {0}" , Salary);
        }
    }
}
