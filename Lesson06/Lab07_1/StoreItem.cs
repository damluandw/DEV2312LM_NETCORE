using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class StoreItem
    {
        public int ItemNo { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }

        public StoreItem() { }

        public StoreItem(int itemNo, string itemName, decimal price)
        {
            ItemNo = itemNo;
            ItemName = itemName;
            Price = price;
        }
        public override string ToString()
        {
            return string.Format("\tItemNo: {0} \n\tItemName: {1} \n\tPrice: {2}", ItemNo, ItemName, Price);
        }
    }
}
