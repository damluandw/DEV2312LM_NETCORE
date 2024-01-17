using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DongVat.AnTap
{
    internal class AnTap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public AnTap() { }

        public AnTap(int id, string name, double weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
        }
        public override string ToString()
        {
            return "\tID: " + Id + "\n\tName:" + Name + "\n\tWeight:" + Weight;
        }
    }
}
