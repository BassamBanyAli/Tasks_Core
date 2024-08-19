using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1_Core.Models;

namespace Task1_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ValuesController(MyDbContext db)
        {

        _db = db; 
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCat(int id)
        {
            var category = _db.Categories.Find(id);
            return Ok(category);
        }

    }
}
