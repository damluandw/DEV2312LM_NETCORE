using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        // member: field // properties(attribute)
        //fileds
        private int id;
        //private string name;
        // method
        public int ID { get { return id; } set { id = value; } }
        public string Name { get; set; }
        /*
         private string _Name
        public string Name{
                get { return _Name; } 
                set { _Name = value; }
        }
         */

        public void Display() {
            Console.WriteLine("Id:\t" + ID);
            Console.WriteLine("Name:\t" + Name);
        }


    }
}
