using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using BeeOrder.Models;
using System.Data.Entity;

namespace BeeOrder.Service
{
    [DataContract]
    public class MyService : IMyService
    {

        User checkUser(string UserName, string Password)
        {
            using (var context = new OrderContext())
            {
                return context.Users.FirstOrDefault(c => c.UserName.ToUpper() == UserName.ToUpper() && c.Password == Password);
            }
        }

        public GetItemsRespond GetFoods(string UserName, string Password)
        {
            using (var context = new OrderContext())
            {
                var items = context.Items.Where(c=>c.ItemType==ItemType.Food).Select(c => new OrderItemRespond { ID = c.ID, Description = c.Description ?? "", Name = c.Name ?? "", Place = c.Place ?? "", Price = (int)c.Price }).ToList();
                return new GetItemsRespond { Items = items };
            }
        }

        public GetItemsRespond GetDrinks(string UserName, string Password)
        {
            using (var context = new OrderContext())
            {
                var items = context.Items.Where(c => c.ItemType == ItemType.Drink).Select(c => new OrderItemRespond { ID = c.ID, Description = c.Description ?? "", Name = c.Name ?? "", Place = c.Place ?? "", Price = (int)c.Price }).ToList();
                return new GetItemsRespond { Items = items };
            }
        }

        public LoginRespond Login(string UserName, string Password)
        {
            using (var context = new OrderContext())
            {
                var user = checkUser(UserName, Password);
                if (user == null)
                {
                    return new LoginRespond {Status="UserNotFound",Name="" };
                }
                else return new LoginRespond { Status = "Success", Name = user.Name ?? "" };
            }
        }

        public OrderRespond Order(List<OrderItemRequest> Items, string UserName, string Password)
        {
            var user = checkUser(UserName, Password);
            if (user == null)
            {
                return new OrderRespond { Status = "UserNotFound" };
            }
            try
            {
                if (Items.Count == 0) { return null; }
            }
            catch
            {
                return new OrderRespond { Status = "ReadingDataError" };
            }
            using (var context = new OrderContext())
            {
                OrderItem orderItem;
                Order order;
                var un = context.Items.FirstOrDefault(c => c.Name == "غير موجود");
                if (un == null) un = new Item { Name = "غير موجود", Place = "" };
                try
                {
                    order = new Order { DateTime = DateTime.Now.AddHours(-2), UserID = user.ID };
                    foreach (var item in Items)
                    {
                        if (item.ItemID == -1)
                        {
                            orderItem = new OrderItem { Order = order, Quantity = 0, Description = item.Description, Item =un };
                        }
                        else orderItem = new OrderItem { Order = order, Quantity = item.Quantity, Description = item.Description, ItemID = item.ItemID };
                        context.OrderItems.Add(orderItem);
                    }
                    context.Orders.Add(order);
                    context.SaveChanges();
                    return new OrderRespond { Status = "Success" }; 
                }
                catch
                {
                    return new OrderRespond { Status = "UnknownError" } ;
                }
            }
        }

        public List<PlaceRespond> GetPlaces(string UserName, string Password)
        {
            using (var context = new OrderContext())
            {
                var items = context.Places.Select(c=>new PlaceRespond {ID=c.ID,Name=c.Name,Description=c.Description }).ToList();
                return items;
            }
        }

        public GetOrdesRespond GetOrders(string UserName, string Password)
        {
            var user = checkUser(UserName, Password);
            if (user == null)
            {
                return new GetOrdesRespond { Status = "UserNotFound" };
            }
            using (var context = new OrderContext())
            {
                try
                {
                    var filterdOrders = context.Orders.Where(c => !c.IsDone).Include(c => c.OrderItems.Select(x => x.Item)).Include(c => c.User).ToList();
                    if (filterdOrders.Count == 0) return new GetOrdesRespond
                    {
                        Status = "Empty",
                        Details = new List<GetOrderDetailRespond>(),
                        Total = 0,
                        UserOrderItems = new List<GetOrderUserTotalRespond>()
                    };
                    var userOrders = new List<GetOrderUserTotalRespond>();
                    foreach (var orderUser in filterdOrders.Select(c => c.User).Distinct())
                    {
                        var items = context.Items.SqlQuery($@"select  distinct Items.* from Users,Orders,OrderItems ,Items
                                                         where 
                                                         Orders.IsDone=0 and
                                                         OrderItems.ItemID=Items.ID and
                                                         OrderItems.OrderID=Orders.ID and
                                                         Orders.UserID={orderUser.ID}").ToList();
                        var orderItems = context.OrderItems.SqlQuery($@"select  distinct orderItems.* from Users,Orders,OrderItems
                                                         where 
                                                         Orders.IsDone=0 and
                                                         OrderItems.OrderID=Orders.ID and
                                                         Orders.UserID={orderUser.ID}").ToList();
                        userOrders.Add(new GetOrderUserTotalRespond
                        {
                            UserName = orderUser.Name,
                            Total = (int)orderItems.Sum(c => c.Quantity * items.First(x => x.ID == c.ItemID).Price),
                            Items = items.Select(c => new GetOrderUserItem
                            {
                                Description = orderItems.Where(x => x.ItemID == c.ID).Select(s => s.Description + " x" + s.Quantity).Concat(),
                                ItemName = c.Name,
                                Quantity = (int)filterdOrders.Where(x => x.UserID == orderUser.ID).Select(z => z.OrderItems.Where(x => x.ItemID == c.ID).Sum(x => x.Quantity)).Sum()
                            }).ToList()
                        });
                    }

                    var dItems = context.Items.SqlQuery($@"select  distinct Items.* from Users,Orders,OrderItems ,Items
                                                         where 
                                                         Orders.IsDone=0 and
                                                         OrderItems.ItemID=Items.ID and
                                                         OrderItems.OrderID=Orders.ID").ToList();
                    var dOrderItems = context.OrderItems.SqlQuery($@"select  distinct orderItems.* from Users,Orders,OrderItems
                                                         where 
                                                         Orders.IsDone=0 and
                                                         OrderItems.OrderID=Orders.ID").ToList();

                    var detailedOrders = dItems.Select(c => new GetOrderDetailRespond
                    {
                        Descriptions = dOrderItems.Where(x => x.ItemID == c.ID).Select(s => s.Description+" x"+s.Quantity).Concat(),
                        ItemName = c.Name,
                        Quantity = (int)filterdOrders.Select(z => z.OrderItems.Where(x => x.ItemID == c.ID).Sum(x => x.Quantity)).Sum()
                    }).ToList();

                    int total = userOrders.Sum(c => c.Total);
                    foreach (var item in filterdOrders)
                    {
                        item.Seen = true;
                        item.SeenTime = DateTime.Now.AddHours(-2);
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    context.SaveChanges();
                    return new GetOrdesRespond
                    {
                        Status = "Success",
                        UserOrderItems = userOrders,
                        Details = detailedOrders,
                        Total = total
                    };
                }
                catch (Exception ee)
                {
                    return new GetOrdesRespond
                    {
                        Status = ee.Message,
                        Details = new List<GetOrderDetailRespond>(),
                        Total = 0,
                        UserOrderItems = new List<GetOrderUserTotalRespond>()
                    };
                }
            }
        }

        public OrdersDoneRespond OrdersDone(string UserName, string Password)
        {
            var user = checkUser(UserName, Password);
            if (user == null)
            {
                return new OrdersDoneRespond { Status = "UserNotFound" };
            }
            using (var context = new OrderContext())
            {
                try
                {
                    foreach (var item in context.Orders.Where(c=>!c.IsDone))
                    {
                        item.IsDone = true;
                        item.GetUserID = user.ID;
                        item.DoneTime = DateTime.Now.AddHours(-2);
                    }
                    context.SaveChanges();
                    return new OrdersDoneRespond { Status = "Success" };
                }
                catch
                {
                    return new OrdersDoneRespond { Status = "Failed" };
                }
            }
        }
    }
}
