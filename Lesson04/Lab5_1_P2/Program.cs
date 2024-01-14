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
            int[] numbers2 =  { -1, 45, -6, 41, 5, -1, 12, 3, 32, 43 };
            soLuong = SoNguyenDuongLienTiep(numbers2, 0, 0);        
            Console.WriteLine("Số lượng số nguyên dương liền kề: "+soLuong);

            int tong = 0;
            int dem = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    tong += numbers[i];
                    dem++;
                }
            }
            Console.WriteLine("TB cong cac phan tu duong la: " + tong/dem);
            bool kt1 = true;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if(numbers[i]* numbers[i+1] > 0)
                {
                    kt1 = false; break;
                }
            }
            if(kt1)
            {
                Console.WriteLine("Mảng chứa các phần tử âm dương đan xen");
            }
            else
            {
                Console.WriteLine("Mảng không chứa các phần tử âm dương đan xen");
            }

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
                Console.WriteLine("soLuong: " + soLuong);
                for (int i = vitri; i < arr.Length; i++)
                {
                    
                    if (arr[i] >= 0)
                    {                       
                        soLuong++;
                        Console.WriteLine("i:"+ i+ "\tsoLuong  2: " + soLuong);
                    }
                    else if (arr[i] < 0)
                    {
                        Console.WriteLine("arr:"+arr[i]);
                        int soluong2 = SoNguyenDuongLienTiep(arr, soLuong, i+1);
                        if(soLuong > soluong2)                        {

                            return soLuong;
                        }
                        else
                        {
                            return soluong2;
                        }
                    }

                }
               
            }
            return soLuong;

        }

    }
}