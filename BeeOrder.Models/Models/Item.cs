using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BeeOrder.Models
{
    public enum ItemType
    {
        Food=0,
        Drink=1,
    }

    [DataContract]
    public class Item
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Place { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public ItemType ItemType { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}