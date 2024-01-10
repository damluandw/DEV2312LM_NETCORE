using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson04
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Student() { }
        public Student(int id, string name, int age) {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public void Show()
        {
            Console.WriteLine(" {0,5} {1,20} {2,3}",Id,Name,Age);
        }

        public override string ToString()
        {
            return string.Format(" {0,5} {1,20} {2,3}", Id, Name, Age);
        }
    }
}
