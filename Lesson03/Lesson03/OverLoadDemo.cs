using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03
{
    /// <summary>
    /// Cài đặt tính chất đa hình trong OOP
    /// - có cùng tên
    /// - danh sách tham số khác nhau
    /// - nếu danh sách tham số giống thì phải khác nhau về kiểu dữ liệu
    /// </summary>
    internal class OverLoadDemo
    {
        public int Sum(int a)
        {
            int tong=0;
            for(int i = 0; i < a; i++)
            {
                tong += i;
            }
            return tong;
        }
        public int Sum(int a, int b)
        {
            int tong =a +b;            
            return tong;
        }
        public double Sum(double a, double b)
        {
            double tong = a + b;
            return tong;
        }
    }
}
