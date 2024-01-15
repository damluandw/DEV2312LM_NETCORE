
using System.Collections;
using System.Text;

namespace Lesson05_ArrayListObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Arrlisst object");
            ArrayList arr = new ArrayList();
            arr.Add(new Student(111, "Luận", 26));
            Student[] students =
            {
                new Student(222, "Devmaster", 23),
                new Student(333,"Khoa",28),
                new Student(){id= 444,name= "Long",age = 24}
            };
            arr.AddRange(students);
            printObject(arr);

            //Sắp xếp
            // Sắp xếp theo tuổi tăng dần
            arr.Sort(new SortAgeASC());
            printObject(arr);

            //Sắp xếp
            // Sắp xếp theo tuổi tăng dần
            arr.Sort(new SortNameDESC());
            printObject(arr);


            // HashTable 
            Hashtable ht = new Hashtable();
            Student student = new Student(123,"DamLuan",26);
            ht.Add(student.id, student);
            Console.WriteLine("List key");
            foreach(var key in ht.Keys)
            {
                Console.WriteLine(key +"-----------"+ ht.Keys.ToString());
            }
            Console.WriteLine("List values");
            foreach (var value in ht.Values)
            {
                Console.WriteLine(value);
            }
        }


        static void printObject(ArrayList arr)
        {
            Console.WriteLine("Danh sách:");
            foreach (Student item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }       

    }
    class SortAgeASC: IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            Student student1 = (Student)obj1;
            Student student2 = (Student)obj2;
            return student1.age - student2.age;
        }
    }

    class SortNameDESC: IComparer
    {
        public int Compare(object? obj1, object? obj2)
        {
            Student student1 = (Student)obj1;
            Student student2 = (Student)obj2;
            return student2.name.CompareTo(student1.name);
        }
    }

}