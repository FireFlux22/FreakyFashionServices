using FreakyFashionServices.ProductPrice.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {        
        // GET: api/price
        [HttpGet]
        public IEnumerable<PriceDto> Get(string products)
        {
            var productList = products.Split(',').ToList();

            var response = new List<PriceDto>();

            Random random = new Random();

            foreach (var item in productList)
            {
                if (String.IsNullOrEmpty(item)) continue;

                response.Add(new PriceDto() { 
                    ArticleNumber = item, 
                    Price = random.Next(1000) });
            }

            return response;
        }
    }
}
