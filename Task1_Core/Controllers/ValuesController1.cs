using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1_Core.Models;

namespace Task1_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private readonly MyDbContext _db;
        public ValuesController1(MyDbContext db)
        {

            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetCat(int id)
        {
            var product = _db.Products
      .Include(p => p.Category)
      .FirstOrDefault(p => p.ProductId == id);
            return Ok(product);
        }

    }
}
    

