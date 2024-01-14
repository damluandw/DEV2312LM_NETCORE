using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5_1_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 56, 45, -6, 41, 5, 12, 12, 23, 32, 43 };
            foreach (int number in numbers)
            {
                Console.Write("{0,6}", number);
            }
            Console.WriteLine();
            
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
               if(min > numbers[i])
                {
                    min = numbers[i];
                }
            }
            Console.WriteLine("Phân tử nhỏ nhất của mảng: {0}", min);
            Console.WriteLine();
            int[] numbers1 = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers1[numbers.Length - 1 - i] = numbers[i];
            } 
            
            foreach (int number in numbers1)
            {
                Console.Write("{0,6}", number);
            }

            Console.WriteLine();
            Console.WriteLine("Mảng tăng dần");
            Array.Sort(numbers);
            foreach (int number in numbers)
            {
                Console.Write("{0,6}", number);
            }

            Console.WriteLine();
            Console.WriteLine("Mảng giảm dần");
            Array.Sort(numbers, (x, y) => { return y - x; });
            foreach (int number in numbers)
            {
                Console.Write("{0,6}", number);
            }
            Console.WriteLine();
            Console.Write("Mảng có các số nguyên tố là: ");
            foreach (int number in numbers)
            {
                bool kt = true; 
                for(int i =2; i< number/2; i++)
                {
                    if (number % i==0)
                    {
                        kt =false;
                    }
                }
                if (kt)
                {
                    Console.Write(number + ",");
                }
            }
            Console.WriteLine();
            int soLuong = 0;
            int[] numbers2 =  { 56, 45, -6, 41, 5, 12, 12, 23, 32, 43 };
            soLuong = SoNguyenDuongLienTiep(numbers2, 0, 0);        
            Console.WriteLine("Số lượng số nguyên dương liền kề: "+soLuong);

        }
        static int SoNguyenDuongLienTiep(int[] arr,int soLuong, int vitri)
        {
            if (soLuong > arr.Length / 2)
            {
                return soLuong;
            }                
            else
            {
                soLuong = 0;
                for (int i = vitri; i < arr.Length; i++)
                {
                    
                    if (arr[i] >= 0)
                    {                       
                        soLuong++;
                        Console.WriteLine(i);
                    }
                    else
                    {
                        Console.WriteLine(arr[i]);
                        SoNguyenDuongLienTiep(arr, soLuong, i+1);
                    }
                }
               
            }
            return soLuong;

        }

    }
}