using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_4_P2
{
    internal class Department
    {
        private string name;
        private Employee[] employees;
        public Department() { }
        public Department(string name, int n)
        {
            this.name = name;
            this.employees = new Employee[n];
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name == null)
                    throw new ArgumentNullException();
                name = value;
            }
        }

        public Employee this[int index]
        {
            get
            {
                if (index < 0 || index > employees.Length - 1)
                    return null;
                return employees[index];
            }

            set
            {
                if (index < 0 || index > employees.Length - 1)
                    throw new AggregateException();
                employees[index] = value;
            }
        }
        public Employee this[string name]
        {
            get
            {
                foreach (Employee chapter in employees)
                    if (chapter.name == name) return chapter;
                return null;
            }
        }
    }
}
