using FreakyFashionServices.Order.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IHttpClientFactory clientFactory;
        private readonly ApplicationDbContext context;

        public OrderController(IHttpClientFactory clientFactory, ApplicationDbContext context)
        {
            this.clientFactory = clientFactory;
            this.context = context;
        }

        // POST /api/order
        [HttpPost]
        public async Task<IActionResult> CompleteOrder(string customerId, string firstName, string lastName) // FUNKAR ENDAST MED INSKICK FRÅN PARAMS, INTE BODY
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:63316/api/basket/" + customerId);

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedBasket = await response.Content.ReadAsStringAsync();

            var order = new Data.Entities.Order(
                    customerId: customerId,
                    orderId: DateTime.Now.ToString(),
                    firstName: firstName,
                    lastName: lastName,
                    basket: serializedBasket
                );

            context.Add(order);
            context.SaveChanges();

            return Ok(order.OrderId);
        }
    }
}
