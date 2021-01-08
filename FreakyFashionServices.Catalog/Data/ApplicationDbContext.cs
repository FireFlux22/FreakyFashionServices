using FreakyFashionServices.Catalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FreakyFashionServices.Catalog.Data
{
    public class ApplicationDbContext : DbContext
    {

        // Nuget Packages:
        // Microsoft.EntityFrameworkCore.SqlServer
        // Microsoft.EntityFrameworkCore.Tools

        public DbSet<Item> Item { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var items = new List<Item>
            {
                new Item (
                    id: 1,
                    name: "Black pants",
                    description: "Lorem ipsum dolor",
                    price: 499,
                    availableStock: 4),
                new Item (
                    id: 2,
                    name: "Red dress",
                    description: "Trouble on two legs",
                    price: 899,
                    availableStock: 2),
                new Item (
                    id: 3,
                    name: "Cowboy hat",
                    description: "Howdy, partner!",
                    price: 250,
                    availableStock: 10)
            };

            items.ForEach(x => modelBuilder.Entity<Item>().HasData(x));

        }
    }
}
