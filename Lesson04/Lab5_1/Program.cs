using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers  = {56,45,88,41,6,12, 12, 23, 32, 43 };
            foreach (int number in numbers)
            {
                Console.Write("{0,6}",number );
            }
            int[] numbers1 = numbers;
            Array.Sort(numbers1);
            Console.WriteLine();
            Console.WriteLine("Phân tử nhỏ nhất của mảng: {0}", numbers1[0]);
            bool kt = true;
            int lenght = numbers.Length;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != numbers1[lenght - i - 1]) {
                    kt = false;
                    break;
                }
            }
            if( kt )
            {
                Console.WriteLine("Mảng đã cho là mảng đối xứng");
            }else
            {
                Console.WriteLine("Mảng đã cho không là mảng đối xứng");
            }
        }
    }
}