namespace Lab1_Phan2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Nhập xuất với C#");
            // Xuất ra màn hình write // writeline
            //int a = 100; int b = 50;
            //int c = a + b;
            //Console.WriteLine(a + " + " + b + " = " + c);
            //Console.WriteLine("{0} + {1} = {2}", a, b, c);
            /*     // Nhập Read/Readline
                 string name;
                 int age;
                 Console.Write("Nhập tên: ");
                 name = Console.ReadLine();
                 Console.Write("Nhập tuổi: ");
                 //age = Convert.ToInt32(Console.ReadLine());
                 age = int.Parse(Console.ReadLine());
                 Console.WriteLine("Wellcome to, {0}, age {1}", name, age);*/

            // Chuyển đổi kiểu/ ép kiểu
            /*    double x = 10.69;
                Console.WriteLine("Kiểu số thực {0}", x);
                int y = (int)x;
                Console.WriteLine("Ép kiểu từ double -> int {0}", y);*/

            // Các cấu trúc điều kheienr
            // if
            // if đơn
            //Console.WriteLine("nhập vào 1 số:");
            //int n = int.Parse(Console.ReadLine());
            //if (n > 10)
            //{
            //    Console.WriteLine(" {0} lớn hơn 10",n);
            //}
            //// if - else
            //// kiểm tra số n là chẵn hay lẻ
            //if (n %2==0) 
            //{
            //    Console.WriteLine(" {0} là số chẵn", n);
            //}
            //else
            //{
            //    Console.WriteLine(" {0} là số lẻ", n);
            //}
            //// if - else if
            //// kiểm tra số n là số dương, âm hay bằng 0
            //if (n  == 0)
            //{
            //    Console.WriteLine(" {0} bằng 0", n);
            //}
            //else if (n > 0)
            //{
            //    Console.WriteLine(" {0} là số dương", n);
            //}
            //else
            //{
            //    Console.WriteLine(" {0} là số âm", n);
            //}
            // nasted if
            // nhập số a,b => giải phương trình bậc 1 với hệ số a,b
            /*    int a, b;
                Console.Write("nhập vào số a:");
                a = int.Parse(Console.ReadLine());
                Console.Write("nhập vào số b:");
                b = int.Parse(Console.ReadLine());
                if (a == 0)
                {
                    if (b != 0)
                    {
                        Console.WriteLine(" Phương trình vô nghiệm");
                    }
                    else
                    {
                        Console.WriteLine(" Phương trình có vô số nghiệm");
                    }
                }
                else
                {
                    double c = (double)-b / (double)a;
                    Console.WriteLine("Phương trình có nghiệm {0:F2}", c);
                }

                // Cấu trúc switch case
                //Nhập 1 số(1 chữ số ) -> đọc thành lời việt
                int num;
                Console.Write("Num =");
                num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 0:
                        Console.WriteLine("Không");
                        break;
                    case 1:
                        Console.WriteLine("Một");
                        break;
                    case 2:
                        Console.WriteLine("Hai");
                        break;
                    case 3:
                        Console.WriteLine("Ba");
                        break;
                    case 4:
                        Console.WriteLine("Bốn");
                        break;
                    case 5:
                        Console.WriteLine("Năm");
                        break;
                    case 6:
                        Console.WriteLine("Sáu");
                        break;
                    case 7:
                        Console.WriteLine("Bảy");
                        break;
                    case 8:
                        Console.WriteLine("Tám");
                        break;
                    case 9:
                        Console.WriteLine("Chín");
                        break;
                    default:
                        Console.WriteLine("Bạn nhập sai");
                        break;                    
                }*/

            // lặp for
            /*    for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("============= for khuyet");
                for (byte i = 0; ; i++)
                {
                    if (i == 9)
                    {
                        break;
                    }
                    Console.WriteLine(i);
                }
                int j=1;
                for (; ; )
                {
                    Console.WriteLine(j);
                    j++;
                    if (j == 9)
                    {
                        break;
                    }
                }
                Console.WriteLine("============= for khong than");
                for (int i = 0; i < 10; Console.WriteLine(i), i++) ;


                //While
                int x = 0;
                while (x<10)
                {
                    Console.WriteLine(x);
                    x++;
                }*/
            bool flag = false;
            while (flag = !flag)
            {
                Console.WriteLine(flag);
            }
            // true
            flag = true;
            while (flag = !flag)
            {
                Console.WriteLine(flag);
            }
            //không thực hiện
            flag = true;
            while (!flag)
            {
                Console.WriteLine(flag);
            }
            //không thực hiện
            flag = true;
            while (flag)
            {
                Console.WriteLine(flag);
            }
            //->vô hạn
        }
    }
}