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
              new Models.Place { Name = "�����" },
              new Models.Place { Name = "����� ���" },
              new Models.Place { Name = "������ ����" },
              new Models.Place { Name = "������ ����" }
            );
            context.SaveChanges();

            context.Items.AddOrUpdate(
              p => new { p.Name, p.Place },
              new Models.Item { Name = "������� �����", Price = 250, Place = "����� ���" },
              new Models.Item { Name = "����� ����", Price = 250, Place = "����� ���" },
              new Models.Item { Name = "����� ����", Price = 50, Place = "�����" },
              new Models.Item { Name = "����� ������", Price = 150, Place = "�����" },
              new Models.Item { Name = "������� ���", Price = 400, Place = "������ ����" },
              new Models.Item { Name = "������� ��������", Price = 400, Place = "������ ����" },
              new Models.Item { Name = "������� ������", Price = 600, Place = "����� ���" },
              new Models.Item { Name = "������", Price = 500, Place = "��������" },
              new Models.Item { Name = "��� ����", Price = 600, Place = "��������" },
              new Models.Item { Name = "����� ����", Price = 200, Place = "��������" },
              new Models.Item { Name = "���� �����", Price = 100, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "���� �������", Price = 75, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "������", Price = 75, Place = "��������", ItemType = ItemType.Drink },
              new Models.Item { Name = "����", Price = 150, Place = "", ItemType = ItemType.Drink },
              new Models.Item { Name = "���� ���", Price = 250, Place = "", ItemType = ItemType.Drink }
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
