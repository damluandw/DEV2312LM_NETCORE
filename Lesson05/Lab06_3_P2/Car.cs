using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab06_3_P2
{
    internal class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Car() { }
        public Car(string name, string color) { 
            this.Name = name;
            this.Color = color;
        }

        public override string ToString()
        {
            return string.Format(this.Name + " - " + this.Color);
        }
    }
}
