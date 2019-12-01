namespace BeeOrder.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeeOrder.Models.OrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeeOrder.Models.OrderContext context)
        {

            context.Places.AddOrUpdate(
              p => p.Name,
              new Models.Place { Name = "ãÇÑíæ" },
              new Models.Place { Name = "ÓÈæäÌ ÈæÈ" },
              new Models.Place { Name = "ÕäÏæíÔ ÝÑíÔ" },
              new Models.Place { Name = "ÍáæíÇÊ ÝÑíÔ" }
            );
            context.SaveChanges();

            context.Items.AddOrUpdate(
              p => new { p.Name, p.Place },
              new Models.Item { Name = "ÕäÏæíÔÉ ÈØÇØÇ", Price = 250, Place = "ÓÈæäÌ ÈæÈ" },
              new Models.Item { Name = "ÈØÇØÇ ÝÑíÊ", Price = 250, Place = "ÓÈæäÌ ÈæÈ" },
              new Models.Item { Name = "ÝØíÑÉ ÌÈäÉ", Price = 50, Place = "ãÇÑíæ" },
              new Models.Item { Name = "ÝØíÑÉ ÔÇæÑãÇ", Price = 150, Place = "ãÇÑíæ" },
              new Models.Item { Name = "ÕäÏæíÔÉ ÔíÔ", Price = 400, Place = "ÕäÏæíÔ ÝÑíÔ" },
              new Models.Item { Name = "ÕäÏæíÔÉ ãßÓíßÇäæ", Price = 400, Place = "ÕäÏæíÔ ÝÑíÔ" },
              new Models.Item { Name = "ÕäÏæíÔÉ ÔÇæÑãÇ", Price = 600, Place = "ÓÈæäÌ ÈæÈ" },
              new Models.Item { Name = "åãÈÑÛÑ", Price = 500, Place = "ÇáÓäÏÈÇÏ" },
              new Models.Item { Name = "ÔÈÒ ÈÑÛÑ", Price = 600, Place = "ÇáÓäÏÈÇÏ" },
              new Models.Item { Name = "ÈØÇØÇ ÝÑíÊ", Price = 200, Place = "ÇáÓäÏÈÇÏ" },
              new Models.Item { Name = "ßæáÇ ãÇÓÊÑ", Price = 100, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "ÞåæÉ ÇßÓÈÑíÓ", Price = 75, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "ÒåæÑÇÊ", Price = 75, Place = "ÇáÈÇÑæÏí", ItemType = ItemType.Drink },
              new Models.Item { Name = "ÓÍáÈ", Price = 150, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "ßæáÇ Êäß", Price = 250, Place = "", ItemType = ItemType.Drink }
            );
            context.SaveChanges();

            context.Users.AddOrUpdate(
              p => p.UserName,
              new Models.User { Name = "Noor Haj Husin", UserName = "NoorHajHusin", Password = "123" },
              new Models.User { Name = "Bassel Summaq", UserName = "BasselSummaq", Password = "123" },
              new Models.User { Name = "Obada Dawara", UserName = "ObadaDawara", Password = "123" },
              new Models.User { Name = "Amar Addas", UserName = "AmarAddas", Password = "123" },
              new Models.User { Name = "Yaman Kalaji", UserName = "YamanKalaji", Password = "123" },
              new Models.User { Name = "Fatih Kadoura", UserName = "FatihKadoura", Password = "123" },
              new Models.User { Name = "Bilal Omar", UserName = "BilalOmar", Password = "123" }
            );
            context.SaveChanges();
        }
    }
}
