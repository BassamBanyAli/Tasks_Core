using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1_Core.Models;

namespace Task1_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        private readonly MyDbContext _db;

        public Categories(MyDbContext db)
        {

            _db = db;
        }
        [HttpGet]
        public IActionResult getAllCategories()
        {
            var categories = _db.Categories.ToList();
            if (categories.Any()) 
            return Ok(categories);
            return NoContent();
        }
        [HttpGet("GetCategoryByName/{Name}")]
        public IActionResult GetCategoryByName(string Name)
        {

            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest("Name parameter is required.");
            }
            var category = _db.Categories.Where(c => c.CategoryName == Name).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }


        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {


            if (id <= 0)
            {
                return BadRequest("ID parameter is required.");
            }
            var category = _db.Categories.Find(id);
            if (category == null) { 
            return NotFound();
            }
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {



            if (id <= 0)
            {
                return BadRequest("ID parameter is required.");
            }

            var category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound(); 
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
            return NoContent(); // Return the deleted category or a success message
        }


    }
}
