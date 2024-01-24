using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Exame
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            bool kt = true;
            Hashtable ht = new Hashtable();            
            int choice = printChoice();
            Student student = new Student();

            //Student student1 = new Student(111, "Dam Luan", "Nam", 26, "DEV2312LM-NETCOERE.24");
            //student1.MarkList[0] = 9;
            //student1.MarkList[1] = 8;
            //student1.MarkList[2] = 7.5f; 
            //student1.CalAvg();
            //ht.Add(student1.StudID, student1);
            while (kt)
            {               
                switch (choice)
                {
                    case 1:
                        student = InsertNewStudent();
                        ht.Add(student.StudID, student);
                        choice = printChoice();
                        break;
                    case 2:
                        foreach (var key in ht.Keys)
                        {
                            (ht[key] as Student).Print();
                        }
                        choice = printChoice();
                        break;
                    case 3:
                        student.CalAvg();
                        student.Print();
                        choice = printChoice();
                        break;
                    case 4:
                        kt = false;
                        Environment.Exit(0);// exit
                        break;
                    default:
                        Console.WriteLine("Please select between 1 and 4");
                        choice =printChoice();
                        break;
                }
            }
            
            
                

            
           
        }
        static int printChoice()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("=========================");
            Console.WriteLine("1.Inser new Student");
            Console.WriteLine("2.Display all the student the list");
            Console.WriteLine("3.Calculator average mark");
            Console.WriteLine("4.Exit");
            return int.Parse(Console.ReadLine());
        }
        static Student InsertNewStudent()
        {
            Student student = new Student();
            bool kt =true;
            do
            {
                
                Console.Write("Input Student ID: ");
                try
                {
                    student.StudID = Convert.ToInt32(Console.ReadLine());
                    kt = false;
                }
                catch (InvalidCastException ex)
                {
                    kt = true;
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    kt = true;
                    Console.WriteLine("Khong duoc nhap ky tu");
                }
            } while (kt);
            Console.Write("Input Student Name: ");
            student.StudName = Console.ReadLine();
            Console.Write("Input Student gender: ");
            student.StudGender = Console.ReadLine();
            do
            {

                Console.Write("Input Student age: ");
                try
                {
                    student.StudAge = Convert.ToInt32(Console.ReadLine());
                    kt = false;
                }
                catch (InvalidCastException ex)
                {
                    kt = true;
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    kt = true;
                    Console.WriteLine("Khong duoc nhap ky tu");
                }
            } while (kt);           
            
            Console.Write("Input Student class: ");
            student.StudClass = Console.ReadLine();
            Console.WriteLine("Input Student mark:");
            do
            {

                Console.Write("\tInput mark 1:");
                try
                {
                    student.MarkList[0] = float.Parse(Console.ReadLine());
                    kt = false;
                }
                catch (InvalidCastException ex)
                {
                    kt = true;
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    kt = true;
                    Console.WriteLine("Khong duoc nhap ky tu");
                }
            } while (kt);
            do
            {

                Console.Write("\tInput mark 2:");
                try
                {
                    student.MarkList[1] = float.Parse(Console.ReadLine());
                    kt = false;
                }
                catch (InvalidCastException ex)
                {
                    kt = true;
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    kt = true;
                    Console.WriteLine("Khong duoc nhap ky tu");
                }
            } while (kt);
            do
            {

                Console.Write("\tInput mark 2:");
                try
                {
                    student.MarkList[2] = float.Parse(Console.ReadLine());
                    kt = false;
                }
                catch (InvalidCastException ex)
                {
                    kt = true;
                    Console.WriteLine(ex.ToString());
                }
                catch (FormatException ex)
                {
                    kt = true;
                    Console.WriteLine("Khong duoc nhap ky tu");
                }
            } while (kt);

            return student;
        }
    }
}