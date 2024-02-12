using NotificationsAPI.DB;
using NotificationsAPI.DB.Models;
using NotificationsAPI.DB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationsAPI.DB.Interface;

namespace NotificationsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
		private readonly CategoryRepository _CategoryRepository;

        public CategoryController(NotificationsDBContext dbContext)
        {
            _CategoryRepository = new CategoryRepository(dbContext);
        }
        [HttpGet]
        public IActionResult getCategories()
        {
            var userId =Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserId").FirstOrDefault().Value);
            return Json(_CategoryRepository.getCategoryByUser(userId));
        }       
    }
}
