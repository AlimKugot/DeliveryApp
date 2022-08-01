using InterviewSolution.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace InterviewSolution.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql("Host=database;Port=5432;Database=interview_order;Username=alim;Password=simple_password");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Order order1 = new Order
            {
                Id = 1,
                CityRecipient = "Moscow",
                AddressRecipient = "st. Lenina",
                CitySender = "Orenburg",
                AddressSender = "st. Velkanskaya",
                CargoWeight = 2.05f,
                ReceiptDateTime = new DateTime(2022, 06, 21, 12, 00, 00, DateTimeKind.Utc)
            };
            Order order2 = new Order
            {
                Id = 2,
                CityRecipient = "Los-Santos",
                AddressRecipient = "st. Woosh",
                CitySender = "Berlin",
                AddressSender = "st. Ocean Gateway",
                CargoWeight = 25.15f,
                ReceiptDateTime = new DateTime(2016, 6, 29, 16, 43, 00, DateTimeKind.Utc)
            };
            Order order3 = new Order
            {
                Id = 3,
                CityRecipient = "New-York",
                AddressRecipient = "Wall street",
                CitySender = "Paris",
                AddressSender = "Avenue Victor Hugo",
                CargoWeight = 300.00f,
                ReceiptDateTime = new DateTime(2020, 3, 15, 14, 33, 52, DateTimeKind.Utc)
            };


            modelBuilder.Entity<Order>().HasData(order1);
            modelBuilder.Entity<Order>().HasData(order2);
            modelBuilder.Entity<Order>().HasData(order3);
        }
    }
}
