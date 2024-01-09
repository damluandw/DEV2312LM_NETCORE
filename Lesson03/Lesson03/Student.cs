using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    internal class Student
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //contructor
        public Student()
        {
            Id = 0;
            Name = "";
            Age = 0;
        }
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        // method

        public void Display()
        {
            Console.WriteLine("ID: {0}", Id);
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Age: " + Age);
        }
    }
}
