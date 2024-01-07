using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    /// <summary>
    /// lớp tính toán; static method; ref ;out ...
    /// </summary>
    internal class Caculator
    {
        //method static
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mul(int a, int b)
        {
            return a * b;
        }

        // out parameter
        public void Calc(int a, int b, out int cong, out int tru)
        {
            cong = a + b;
            tru = a - b;
        }
        // ref parameter
        public void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y;
            y = temp;            
        }
        public void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
