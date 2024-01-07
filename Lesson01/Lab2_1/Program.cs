namespace Lab2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ten thue bao: ");
            string tenThueBao = Console.ReadLine();

            Console.Write("Nhap so thoi gian: ");
            int thoiGian = int.Parse( Console.ReadLine());

            double cuocPhi = 0;
            //Cach 1
            if (thoiGian <= 30)
            {
                cuocPhi = 30;
            }
            else if (thoiGian <= 50 && thoiGian > 30)
            {
                cuocPhi = (double)30 + (double)(thoiGian - 30) * 1.2;
            }
            else {
                cuocPhi = (double)30 + (double)20 * 1.2 + (double)(thoiGian - 50)*1.5;
            }

            Console.Write("Thue bao: {0} su dung {1} phut co cuoc phi la: {2:C}", tenThueBao, thoiGian, cuocPhi);
        }
    }
}
