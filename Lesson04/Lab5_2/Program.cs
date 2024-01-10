namespace Lab5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr =
            {
                {1, 2, 3,4 },
                {5, 8, 6, 4 },
                {3, 3, 3,5} 
            };
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,8}",arr[i, j]);
                }
                Console.WriteLine();
            }

            Console.Write("Các số có chỉ sổ hàng bằng chỉ số cột: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j){

                        Console.Write("{0,3}", arr[i, j]);
                    }
                    
                }
                
            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int max = arr[i, 0];
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (max < arr[i, j])
                    {
                        max = arr[i, j];
                    }
                }
                Console.WriteLine("Phan tu lon nhat cua hang thu {0} la: {1,3}", i, max);

            }
        }

        

    }
}