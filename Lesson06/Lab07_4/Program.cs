namespace Lab07_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intCnt;
            int number =0;
            Console.WriteLine("Nhap 1 so: ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number <= 0)
                {
                    throw new InvalidInputNumber();
                }
            }catch (InvalidInputNumber ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Khong duoc nhap ky tu cho mang so");
            }finally {
                if(number > 0)
                {
                    for (intCnt = 0; intCnt <= 10; intCnt++)
                    {
                        Console.WriteLine(intCnt* number);
                    }
                }              
            }

        }

       
    }
    public class InvalidInputNumber : Exception { 
        public InvalidInputNumber():base("Hay nhap so >0")
        {

        }
    }
}