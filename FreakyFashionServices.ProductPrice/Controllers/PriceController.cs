using FreakyFashionServices.ProductPrice.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FreakyFashionServices.ProductPrice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {        
        // GET /price/{quantity}
        [HttpGet("{quantity}")]
        public IEnumerable<PriceDto> GetPrice(int quantity)
        {
            var random = new Random();

            var productPriceList = new List<PriceDto>();

            int id = 1;

            for (int i = 0; i < quantity; i++)
            {
                int price = random.Next(1000);

                var productPrice = new PriceDto
                {
                    Price = price,
                    ArticleNumber = id
                };

                id++; 

                productPriceList.Add(productPrice);

            }

            return productPriceList;

        }

        //// GET /api/productprice?products=ABC123,BCA321,AAA123,BBB123
        //[HttpGet("products={id}")]
        //public IEnumerable<PriceDto> Get(int id)
        //{
        //    var random = new Random();

        //    var productPriceList = new List<PriceDto>();

        //    //foreach (var product in id)
        //    //{
        //    //    int price = random.Next(1000);

        //    //    var productPrice = new PriceDto
        //    //    {
        //    //        Price = price,
        //    //        ArticleNumber = product
        //    //    };

        //    //    productPriceList.Add(productPrice);

        //    //}

        //    int price = random.Next(1000);

        //    var productPrice = new PriceDto
        //    {
        //        Price = price,
        //        ArticleNumber = id
        //    };

        //    productPriceList.Add(productPrice);

        //    return productPriceList;

        //}
    }
}
