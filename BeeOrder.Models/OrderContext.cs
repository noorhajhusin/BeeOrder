using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeeOrder.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base(@"Data Source=.;Initial Catalog=BeeOrder;Persist Security Info=True;User ID=aa;Password=111")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }
        public DbSet<Models.Place> Places { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            base.OnModelCreating(modelBuilder);
        }
    }
}
