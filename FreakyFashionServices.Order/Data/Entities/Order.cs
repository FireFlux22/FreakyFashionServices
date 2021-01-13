using System.Collections.Generic;
using FreakyFashionServices.Order.Data.DTO;

namespace FreakyFashionServices.Order.Data.Entities
{
    public class Order
    {
        public Order(string customerId, string orderId, string firstName, string lastName, string basket)
        {
            CustomerId = customerId;
            OrderId = orderId;
            FirstName = firstName;
            LastName = lastName;
            Basket = basket;
        }

        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Basket { get; set; }
    }
}
