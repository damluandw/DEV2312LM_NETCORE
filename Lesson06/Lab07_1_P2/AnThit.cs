using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DongVat.AnThit
{
    internal class CaSau
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public CaSau() { }

        public CaSau(int id, string name, double weight)
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
    internal class Ho
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Ho() { }

        public Ho(int id, string name, double weight)
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
    internal class SuTu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public SuTu() { }

        public SuTu(int id, string name, double weight)
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
