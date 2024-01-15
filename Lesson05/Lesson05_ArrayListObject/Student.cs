using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05_ArrayListObject
{
    internal class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Student() { }
        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-15} {2,-10}",id,name,age);
        }
    }
}
