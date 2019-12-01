using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BeeOrder.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int? ItemID { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}