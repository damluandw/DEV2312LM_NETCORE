using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_1
{
    internal class Product
    {
        public string name { get; set; }
        public double cost { get; set; }
        public int onhand { get; set; }

        public Product() { }
        public Product(string name, double cost,int onhand)
        {
            this.name = name;
            this.cost = cost;
            this.onhand = onhand;
        }
        public override string ToString()
        {
            return string.Format("{0,-10}Cost: {1,6:C}  On hand: {2}", name, cost, onhand);
        }
    }
}
