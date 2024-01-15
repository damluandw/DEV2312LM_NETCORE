namespace Lab05_3_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap nam sinh: ");
            int namsinh = Convert.ToInt32(Console.ReadLine());
            string canchi = tinhCan(namsinh);
            canchi += " " + tinhChi(namsinh);
            Console.WriteLine(canchi);
        }
        static string tinhCan(int namsinh)
        {
            String can = "";
            switch (namsinh % 10)
            {
                case 0:
                    can = "CANH";
                    break;
                case 1:
                    can = "TÂN";
                    break;
                case 2:
                    can = "NHÂM";
                    break;
                case 3:
                    can = "QUÝ";
                    break;
                case 4:
                    can = "GIÁP";
                    break;
                case 5:
                    can = "ẤT";
                    break;
                case 6:
                    can = "BÍNH";
                    break;
                case 7:
                    can = "ĐINH";
                    break;
                case 8:
                    can = "MẬU";
                    break;
                case 9:
                    can = "KỶ";
                    break;
            }
            return can;
        }
        static String tinhChi(int namsinh)
        {
            String chi = "";
            switch (namsinh % 12)
            {
                case 0:
                    chi = "THÂN";
                    break;
                case 1:
                    chi = "DẬU";
                    break;
                case 2:
                    chi = "TUẤT";
                    break;
                case 3:
                    chi = "HỢI";
                    break;
                case 4:
                    chi = "TÝ";
                    break;
                case 5:
                    chi = "SỬU";
                    break;
                case 6:
                    chi = "DẦN";
                    break;
                case 7:
                    chi = "MẸO";
                    break;
                case 8:
                    chi = "THÌN";
                    break;
                case 9:
                    chi = "TỴ";
                    break;
                case 10:
                    chi = "NGỌ";
                    break;
                case 11:
                    chi = "MÙI";
                    break;
            }
            return chi;
        }
    }
}
