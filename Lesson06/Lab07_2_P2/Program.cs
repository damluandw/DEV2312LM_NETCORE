namespace Lab07_2_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
            int number;
            string str = "acd";
            try
            {
                //InvalidCastException
                number = Convert.ToInt32(str);
                //IndexOutOfRangeException
                int[] ints = new int[3];
                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(ints[i].ToString());
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //ArrayTypeMismatchException
                try
                {
                    int[] ints = new int[3];
                    ints[0] = Convert.ToInt32(str);
                }
                catch (ArrayTypeMismatchException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

          

        }
    }
}