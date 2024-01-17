using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    internal class House
    {
        public string HouseNo { get; set; }
        public double Price { get; set; }
        public House() { }
        public House(string houseNo, double price)
        {
            HouseNo = houseNo;
            Price = price;
        }
        public override string ToString()
        {
            return "\tHouseNo: " + HouseNo + "\n\tPrice: " +Price ;
        }
    }
    namespace Dealership
    {
        public class Car
        {
            public string CarNo { get; set; }
            public double Price { get; set; }
            public Car() { }
            public Car(string carNo, double price)
            {
                CarNo = carNo;
                Price = price;
            }

            public override string ToString()
            {
                return "\tCarNo: " + CarNo + "\n\tPrice: " + Price;
            }
        }

    }
}
