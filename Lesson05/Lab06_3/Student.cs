using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_3
{
    internal class Student
    {
        public string id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public bool gender { get; set; }
        public double avg { get; set; }

        public Student() { }

        public Student(string id, string firstName, string lastName, bool gender, double avg)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.avg = avg;
        }

        public override string ToString()
        {
            return "ID: " +id + " FullName: "+ firstName +" " +lastName+ " Gender: " +(gender? "Male": "Female")+" Average mark: "+avg; 
        }
    }
}
