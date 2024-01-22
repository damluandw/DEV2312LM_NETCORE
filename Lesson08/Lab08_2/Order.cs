using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_2
{
    internal class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public Order() { }
        public Order(int id, string product)
        {
            Id = id;
            Product = product;
        }
    }
}
