using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Basket.Dto
{
    public class ItemDto
    {
        //public ItemDto(int productId, string productName, int unitPrice, int quantity)
        //{
        //    ProductId = productId;
        //    ProductName = productName;
        //    UnitPrice = unitPrice;
        //    Quantity = quantity;
        //}

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
