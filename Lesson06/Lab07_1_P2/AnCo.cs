using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DongVat.AnCo
{
    internal class Bo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Bo() { }

        public Bo(int id, string name, double weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
        }
        public override string ToString()
        {
            return "\tID: "+ Id + "\n\tName:" + Name + "\n\tWeight:" +Weight;
        }
    }
    internal class Trau
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Trau() { }

        public Trau(int id, string name, double weight)
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
    internal class De
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public De() { }

        public De(int id, string name, double weight)
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
