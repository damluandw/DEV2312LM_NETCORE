using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_3
{
    internal class Student
    {
        string[] name;
        double[,] marks;
        public Student() { 
        }      
        public Student(int n, int m) 
        {
            this.name =  new string[n];
            this.marks = new double[n,m];
        }

        //chỉ mục đơn
        public string this[int i]
        {
            get { return name[i]; }
            set { name[i] = value; }
        }

        //chỉ mục kép
        public double this[int i , int j]
        {
            get { return marks[i,j]; }
            set { marks[i,j] = value; }
        }
    }
}
