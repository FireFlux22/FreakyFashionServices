using FreakyFashionServices.Catalog.Data;
using FreakyFashionServices.Catalog.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashionServices.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/catalog/[controller]")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ItemsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET /api/catalog/items
        [HttpGet]
        public IEnumerable<Item> GetAll()
        {
            var items = context.Item.ToList();

            return items;
        }

        // GET /api/catalog/items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetById(int id)
        {
            var item = context.Item.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound(); // 404 Not Found
            }

            return item;
        }
    }
}
