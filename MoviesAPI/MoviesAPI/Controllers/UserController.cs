using MoviesAPI.DB;
using MoviesAPI.DB.Data;
using MoviesAPI.DB.Repositories;
using MoviesAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly CategoryRepository _categoryRepository;

        public UserController(MoviessDBContext dbContext)
        {
            _categoryRepository = new CategoryRepository(dbContext);
        }
       
    }
}
