using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply
{
    internal class Manufacturer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Manufacturer() { }   
        public Manufacturer(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public override string ToString()
        {
            return "\tName: " + Name + "\n\tEmail: " + Email +"\n\tPhone" + Phone;
        }
    }
}
