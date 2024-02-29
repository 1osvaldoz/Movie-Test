using MoviesAPI.DB;
using MoviesAPI.DB.Models;
using MoviesAPI.DB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DB.Interface;
using MoviesAPI.Dtos;

namespace MoviesAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
		private readonly MoviesRepository _MoviesRepository;

        public MoviesController(MoviessDBContext dbContext)
        {
            _MoviesRepository = new MoviesRepository(dbContext);
        }
      
        [HttpPost]
        public IActionResult getMovies([FromBody] MoviePostDTO moviesFilters)
        {
            var userId =Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserId").FirstOrDefault().Value);
            var movies = _MoviesRepository.GetMovies(moviesFilters);
            return Json(movies);
        }
    }
}
        