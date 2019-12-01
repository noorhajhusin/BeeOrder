using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BeeOrder.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [ForeignKey("UserID")]
        public ICollection<Order> Orders { get; set; }
        [ForeignKey("GetUserID")]
        public ICollection<Order> GetOrders { get; set; }

    }
}