using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_2
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() { }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
