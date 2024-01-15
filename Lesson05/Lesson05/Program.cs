using System.Collections;

namespace Lesson05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            array.Add("Dam Luan");
            array.Add("Cuc");
            array.Add("");
            array.Add("Khoa");
            array.Add("10");


            //search
            if (array.Contains("Cuc"))
            {
                int index = array.IndexOf("Cuc");

            }
        }

        static void printArr(ArrayList al)
        {
            Console.WriteLine("======Danh sach phan tu mang");
            foreach (int i in al)
            {
                Console.WriteLine(i);
            }
        }

        class SortDesc : IComparer
        {
            public int Compare(object x, object y)
            {
                string a = x.ToString();
                string b = y.ToString();
                return b.CompareTo(a);
            }
        }
       
    }

}