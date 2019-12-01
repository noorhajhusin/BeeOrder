using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BeeOrder.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public int? GetUserID { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public DateTime? SeenTime { get; set; }
        [DataMember]
        public DateTime? DoneTime { get; set; }
        [DataMember]
        [DefaultValue(false)]
        public bool IsDone { get; set; }
        [DataMember]
        [DefaultValue(false)]
        public bool Seen { get; set; }

        public User User { get; set; }
        public User GetUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}