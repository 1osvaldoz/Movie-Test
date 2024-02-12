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
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
		private readonly GenericUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly UserRepository _userRepository;

        public LoginController(NotificationsDBContext dbContext, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = new GenericUnitOfWork(dbContext);
			_userRepository = new UserRepository(dbContext);
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO DoLogin)
        {
            try
            {

                var us = _userRepository.Autenticate(DoLogin);
                HttpContext.Response.StatusCode = 200;

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim("UserId", us.Id.ToString())
            };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

                var sessionToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Json(new { Token = sessionToken });

            }
            catch (Exception e)
            {
                HttpContext.Response.StatusCode = 400;
                return Json(e.Message);


            }
        }
    }
}
