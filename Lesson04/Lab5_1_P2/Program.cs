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

            int viTriDau = 0;
            int viTriCuoi = 0;
            int soLuong = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                soLuong++;
                if (numbers[i] < 0)
                {
                    int SL2 = 0;
                    for (int j = i; j < numbers.Length; j++)
                    {
                        if (numbers[j] < 0)
                        {

                        }
                    }
                }               
                
            }


        }

       /* public int SoNguyenDuongLienTiep(int[] arr, int soLuong)
        {
            int sl=0;
            for (int i = 0; i < arr.Length; i++)
            {
                sl++;
                if (arr[i] < 0)
                {
                    SoNguyenDuongLienTiep();


                }
                return sl;

            }
        }*/
    }
}