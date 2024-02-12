using NotificationsAPI.DB;
using NotificationsAPI.DB.Data;
using NotificationsAPI.DB.Repositories;
using NotificationsAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotificationsAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(NotificationsDBContext dbContext)
        {
			_userRepository = new UserRepository(dbContext);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCategoryChannelsByUser()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserId").FirstOrDefault().Value);
            return Json(_userRepository.GetCategoryChannelsByUser(userId));
        }
    }
}
