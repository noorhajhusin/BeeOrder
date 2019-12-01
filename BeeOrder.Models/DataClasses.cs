using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeeOrder.Models
{
    public static class ss
    {
        public static string Concat(this IEnumerable<string> source)
        {
            string res = "";
            int i = 1;
            foreach (var item in source)
            {
                res += $"{i} - {item ?? ""}\n";
                i++;
            }
            return res;
        }
    }

    [DataContract]
    public class OrderItemRequest
    {
        [DataMember]
        public int ItemID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Description { get; set; }

    }

    [DataContract]
    public class LoginRespond
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
    [DataContract]
    public class OrdersDoneRespond
    {
        [DataMember]
        public string Status { get; set; }
    }
    [DataContract]
    public class OrderRespond
    {
        [DataMember]
        public string Status { get; set; }
    }
    [DataContract]
    public class GetItemsRespond
    {
        [DataMember]
        public List<OrderItemRespond> Items { get; set; }
    }
    [DataContract]
    public class GetOrders
    {
        [DataMember]
        public List<OrderItemRespond> Orders { get; set; }
    }
    [DataContract]
    public class OrderItemRespond
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
        public int Price { get; set; }
    }
    [DataContract]
    public class GetOrderDetailRespond
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Descriptions { get; set; }
    }
    [DataContract]
    public class GetOrderUserItem
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
    [DataContract]
    public class GetOrderUserTotalRespond
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public List<GetOrderUserItem> Items { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
    [DataContract]
    public class GetOrdesRespond
    {
        [DataMember]
        public List<GetOrderUserTotalRespond> UserOrderItems { get; set; }
        [DataMember]
        public List<GetOrderDetailRespond> Details { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
    [DataContract]
    public class PlaceRespond
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
