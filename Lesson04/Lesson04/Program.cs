using System.Xml.Linq;

namespace Lesson04
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] a;
            int[] b = new int[10];
            float[] c = new float[] { 1.2f, 1.3f, 1.5f, 1.8f };
            string[] names = { "Hùng", "Dũng", "Sang", "Trọng" };
            b[0] = 100;
            b[5] = 500;
            b[9] = 900;
            Console.WriteLine("b[5]: {0}", b[5]);
            // DUyệt mảng
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write("{0,5}", b[i]);
            }
            Console.WriteLine();

            foreach (int item in b)
            {
                Console.Write("{0,5}", item);
            }
            Console.WriteLine();

            foreach (string item in names)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            //Khởi tạo mảng đối tượng sinh viên gồm 5 đối tượng
            // gán giá trị và in ra màn hình
            //Student student1 = new Student(21, "Hoang", 23);
            //Student student2 = new Student(31, "Hai", 26);
            //Student student3 = new Student(39, "Ha", 22);
            //Student student4 = new Student(35, "Hung", 24);
            //Student student5 = new Student(45, "Cuong", 27);
            Student[] students = {
                new Student(21, "Hoang", 23),
                new Student(31, "Hai", 26),
                new Student(39, "Ha", 22),
                new Student(35, "Hung", 24),
                new Student(45, "Cuong", 27)
            };
            ////Student[] students = { student1, student2, student3, student4, student5 };
            //Student[] students = new Student[5];
            //students[0] = student1;
            //students[1] = student2;
            //students[2] = student3;
            //students[3] = student4;
            //students[4] = student5;
            //Console.WriteLine("student1" + student1.Id + student1.Name + student1.Age);
            //Console.WriteLine("students[0]" + students[0].Id + students[0].Name +  students[0].Age);
            foreach (Student item in students)
            {
                Console.WriteLine(item.ToString());
            }

            //Sắp xếp theo tuổi giảm dần
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = i; j < students.Length; j++)
                {
                    if (students[i].Age > students[j].Age)
                    {
                        Student st = students[i];
                        students[i] = students[j];
                        students[j] = st;
                    }
                }
            }
            foreach (Student item in students)
            {
                Console.WriteLine(item.ToString());
            }
            int[] arr = { 1, 9, 5, 8, 10, 23, 24, 13 };
            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
            Array.Reverse(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
            Array.Sort(arr,(x,y) => { return y - x; });
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }


            Array.Sort(students, (x, y) => { return y.Age - x.Age; });
            foreach (var item in students)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}