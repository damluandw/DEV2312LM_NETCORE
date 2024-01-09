using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1
{
    internal class ListBox : Window
    {
        private string listBoxContents;
        public ListBox(int top , int left, string contents) : base(top, left)
        {
            listBoxContents = contents;
        }
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine("Write string to the list box {0}", listBoxContents);
        }
    }
}
