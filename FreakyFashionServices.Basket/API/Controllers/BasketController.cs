using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FreakyFashionServices.Basket.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using FreakyFashionServices.Basket.Dto;

namespace FreakyFashionServices.Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private readonly IDistributedCache cache;

        public BasketController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        // PUT api/basket/id
        [HttpPut("{id}")]
        public async Task CreateOrReplaceBasket(string id, List<ItemDto> items)
        {
            await cache.SetRecordAsync(id, items);

        }

        // GET api/basket/id
        [HttpGet("{id}")]
        public async Task<List<ItemDto>> GetBasketById(string id)
        {
            var basket = await cache.GetRecordAsync<List<ItemDto>>(id);

            return basket;
        }
    }
}
