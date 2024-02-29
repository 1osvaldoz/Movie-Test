using MoviesAPI.DB;
using MoviesAPI.DB.Models;
using MoviesAPI.DB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DB.Interface;

namespace MoviesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : Controller
    {
		private readonly CategoryRepository _CategoryRepository;

        public CategoryController(MoviessDBContext dbContext)
        {
            _CategoryRepository = new CategoryRepository(dbContext);
        }
        [HttpGet]
        public IActionResult getCategories()
        {
            return Json(_CategoryRepository.getCategories());
        }       
    }
}
