namespace Lab07_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[5];
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("a[{0}] =", i + 1);
                    data[i] = Convert.ToByte(Console.ReadLine());
                }
            }catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Khong duoc nhap ky tu cho mang so");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Khong duoc nhap gia tri nam ngoai mien 0-255");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Loi vuot qua pham vi  cua mang");
            }
            Console.WriteLine("Noi dung cua mang");
            for (int i = 0;i < 5; i++)
            {
                Console.Write("{0} ", data[i]);
            }
        }
    }
}