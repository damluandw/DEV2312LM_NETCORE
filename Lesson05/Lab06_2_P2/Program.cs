using System.Collections;

namespace Lab06_2_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Monday");
            hashtable.Add(2, "Tuesday");
            hashtable.Add(3, "Wednesday");
            hashtable.Add(4, "Thursday");
            hashtable.Add(5, "Friday");
            hashtable.Add(6, "Saturday");
            hashtable.Add(7, "Sunday");
            bool kt = false;
            foreach (var key in hashtable.Keys)
            {
               
                if (hashtable[key] == "Tuesday")
                {
                    kt = true;   
                    break;
                }
            }
            if (kt)
                Console.WriteLine("Có tìm thấy ngay Tuesday");
            else
                Console.WriteLine("Không tìm thấy ngay Tuesday");

            foreach (var key in hashtable.Keys)
            {
                Console.WriteLine(key.ToString() + " - " + hashtable[key]);
            }

        }
    }
}
