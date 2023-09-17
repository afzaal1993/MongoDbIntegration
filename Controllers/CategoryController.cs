using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbIntegration.Models;
using MongoDbIntegration.Repositories;

namespace MongoDbIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Category category)
        {
            await _category.CreateAsync(category);

            return Ok(category);
        }
    }
}
