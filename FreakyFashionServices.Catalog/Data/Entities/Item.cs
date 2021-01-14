using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Data.Entities
{
    public class Item
    {
        public Item(int id, string name, string articleNumber, string description, decimal price, int availableStock)
        {
            Id = id;
            Name = name;
            ArticleNumber = articleNumber;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableStock { get; set; }
    }
}
