namespace Lab05_2_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = {
                { 1, 7, 6, 4 } ,
                { 4, 5, 9, 21 } ,
                { 9, 5, 3, 8 } ,
                { 5, 3, 6, 9 }
            };


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int tong = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        tong += arr[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Tong cac phan tu ma co chi so hang bang chi so cot: " + tong);
            Console.WriteLine("Phan tu nho  nhat tren cot la: ");
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int min = arr[0, i];
                for (int j = 1; j < arr.GetLength(0); j++)
                {
                    if (min > arr[j, i])
                    {
                        min = arr[j, i];
                    }
                }
                Console.WriteLine(" so nho nhat cot {0} la: {1}", i, min);
            }

            Console.Write("Các số chia hết cho 7 là: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] % 7 == 0)
                    {
                        Console.Write(arr[i, j] + "\t");
                    }
                }
            }
            Console.WriteLine();

            tong = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == 0 || i == arr.GetLength(0)-1 || j == 0 || j == arr.GetLength(1)-1)
                    {
                        tong += arr[i, j];
                    }
                }
            }
            Console.WriteLine("Tong cac phan tu nam tren duong vien cua mang la: " + tong);

            Console.WriteLine("Mang 1 chieu la: ");
            int[] arr1 = new int[16];
            int count = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr1[count] = arr[i, j];
                    count++;
                }
                
            }
            Array.Sort(arr1);
            foreach (int i in arr1)
            {
                Console.Write(i+", ");
            }
           
        }
    }
}
