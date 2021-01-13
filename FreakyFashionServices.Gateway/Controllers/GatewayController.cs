using FreakyFashionServices.Gateway.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:51443/price/" + productDto.Count());

            request.Headers.Add("Accept", "application/json");

            response = await client.SendAsync(request);

            var serializedPrice = await response.Content.ReadAsStringAsync();

            var priceDto = JsonSerializer.Deserialize<IEnumerable<PriceDto>>(serializedPrice, serializeOptions);

            foreach (var item in priceDto)
            {
                var product = productDto.FirstOrDefault(x => x.Id == item.ArticleNumber);

                product.Price = item.Price;
            }

            return productDto;
        }

        // PUT gateway/id
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToBasket(string id, string items)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:63316/api/basket/" + id);

            request.Headers.Add("Accept", "application/json");

            request.Content = new StringContent(items);

            var client = clientFactory.CreateClient();

            await client.SendAsync(request);

            return NoContent();  // 204 No Content
        }
    }
}
