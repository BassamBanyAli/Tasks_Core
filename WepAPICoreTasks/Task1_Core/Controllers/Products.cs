using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1_Core.Models;

namespace Task1_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly MyDbContext _db;
        public Products(MyDbContext db)
        {

            _db = db;
        }
        [HttpGet]
        public IActionResult getAllProducts()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("GetProductById")]
        public IActionResult GetProductById( [FromQuery] int?id)
        {


            if (id <= 0)
            {
                return BadRequest("ID parameter is required.");
            }
            var product = _db.Products
      .Include(p => p.Category).Where(p => p.ProductId == id)
      .FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("GetProductByName")]
        public IActionResult GetProductByName([FromQuery] string? Name)
        {
            {

                if (string.IsNullOrWhiteSpace(Name))
                {
                    return BadRequest("Name parameter is required.");
                }
                var product = _db.Products
          .Include(p => p.Category).Where(p => p.ProductName == Name)
          .FirstOrDefault();
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);

            }
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteItem( [FromQuery] int? id)
        {


            if (id <= 0)
            {
        return BadRequest("ID parameter is required.");
    }

            var Product = _db.Products.Find(id);

            if (Product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(Product);
            _db.SaveChanges();
            return NoContent();
        }


   

    [HttpGet("{id1}/{Price}")]
        public IActionResult GetCatPrice(int id1,int Price)
        {
            var products = _db.Products.Where(c=>c.CategoryId==id1&&c.Price>100).Count();
            return Ok(products);
        }

    }

}
    

