using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbIntegration.Models;
using MongoDbIntegration.Repositories;
using System.Net;

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
        [ProducesResponseType(typeof(ApiResponse<Category>), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ApiResponse<Category>>> Create(Category category)
        {
            var response = await _category.CreateAsync(category);
            return Created("", response);
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<Category>>> GetById(string id)
        {
            var response = await _category.GetOneAsync(x => x.Id == id);
            if (response.Status)
                return Ok(response);
            else
                return NotFound(response);
        }
    }
}
