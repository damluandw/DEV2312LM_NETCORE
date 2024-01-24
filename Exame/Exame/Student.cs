using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exame
{
    internal class Student:IStudent
    {
       public int StudID { get; set; }
        public string StudName { get; set; }
        public string StudGender { get; set; }
        public int StudAge { get; set; }
        public string StudClass { get; set; }
        public  float StudAvgMark { get; private set; }

        public float[] MarkList;

        public Student()
        {
            MarkList = new float[3];
        }
        public Student(int studID, string studName, string studGender, int studAge, string studClass)
        {
            StudID = studID;
            StudName = studName;
            StudGender = studGender;
            StudAge = studAge;
            StudClass = studClass;
            MarkList = new float[3];
        }

        public void Print()
        {
            Console.WriteLine("StudID: {0,5} StudName: {1,-20} StudAge: {2,2} StudClass: {3,-20} StudAvgMark: {4:#,###.##}", StudID, StudName, StudAge, StudClass, StudAvgMark);

        }

        //chỉ mục đơn
        public float this[int i]
        {
            get { return MarkList[i]; }
            set { MarkList[i] = value; }
        }
        public void CalAvg()
        {
            float sum = 0;
            for(int i = 0; i < MarkList.Length; i++)
            {
                sum += MarkList[i];
            }
            StudAvgMark = sum / MarkList.Length;
        }

    }
}
