using FreakyFashionServices.Gateway.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreakyFashionServices.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        // GET /gateway
        // Connects to api/catalog/items + api/price
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetProducts()
        {
            // GET item info
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57845/api/catalog/items");

            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var serializedProduct = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var productDto = JsonSerializer.Deserialize<IEnumerable<ItemDto>>(serializedProduct, serializeOptions);

            // Get random price

            var articleNumberList = "";

            foreach (var product in productDto)
            {
                articleNumberList += product.ArticleNumber + ",";
            }

            request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:51443/api/price" + "?products=" + articleNumberList);

            request.Headers.Add("Accept", "application/json");

            response = await client.SendAsync(request);

            var serializedPrice = await response.Content.ReadAsStringAsync();

            var priceDto = JsonSerializer.Deserialize<IEnumerable<PriceDto>>(serializedPrice, serializeOptions);

            foreach (var item in priceDto)
            {
                var product = productDto.FirstOrDefault(x => x.ArticleNumber == item.ArticleNumber);

                product.Price = item.Price;
            }

            return productDto;
        }

        // PUT gateway/id
        // Connects to api/basket/id
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToBasket(string id, List<BasketItemDto> items)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:63316/api/basket/" + id);

            request.Headers.Add("Accept", "application/json");

            var json = JsonSerializer.Serialize(items); // serialisera Basket

            request.Content = new StringContent(json, Encoding.UTF8, "application/json"); // lägg till Basket i body

            var client = clientFactory.CreateClient();

            await client.SendAsync(request);

            return NoContent();  // 204 No Content
        }


        // POST /gateway
        // Connects to /api/order
        [HttpPost]
        public async Task<IActionResult> CompleteOrder(CustomerDto customer)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:60543/api/order/");

            request.Headers.Add("Accept", "application/json");

            var json = JsonSerializer.Serialize(customer); 

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var orderId = await response.Content.ReadAsStringAsync();

            return Ok(orderId);
        }
    }
}
