using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07_3_P2
{
    internal class Student
    {
        public string Id { get; set; }
        public string Name { get; set;}
        public double TheoryMark { get; set;}
        public double LabMark { get; set; }

        public Student() { }
        public Student(string id, string name, double theoryMark, double labMark)
        {
            Id = id;
            Name = name;
            TheoryMark = theoryMark;
            LabMark = labMark;
        }
    }
}
