using MoviesAPI.DB.Models;
using MoviesAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB.Interface;
using System.Linq;

namespace MoviesAPI.DB.Repositories
{
    public class MoviesRepository : GenericRepository<Movie>
    {
        private readonly DbContext _context;
        private DbSet<Movie> entities;
        private readonly IGenericRepository<Movie> _GenericMovieRepository;
        private readonly IGenericReadOnlyRepository<MovieCategories> _GenericUMovieCategoriesRepository;
        private readonly IGenericReadOnlyRepository<MovieActors> _GenericUMovieActorRepository;

        public MoviesRepository(DbContext context) : base(context)
        {
            try
            {
                entities = context.Set<Movie>();
                _context = context;
                _GenericMovieRepository = new GenericRepository<Movie>(context);
                _GenericUMovieCategoriesRepository = new GenericReadOnlyRepository<MovieCategories>(context);
                _GenericUMovieActorRepository = new GenericReadOnlyRepository<MovieActors>(context);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public List<MovieDTO> GetMovies(MoviePostDTO filters)
        {
            List<MovieDTO> result = new List<MovieDTO>();
            List<int> moviesId= new List<int>();
            var categoryMovies = _GenericUMovieCategoriesRepository.Where(x => filters.categories.Select(z => z.value).Contains(x.categoryId), "Category").Select(x => x.movieId).ToList();
            moviesId.AddRange(categoryMovies);
            if (filters.searchText != "")
            {
                moviesId.AddRange(_GenericUMovieCategoriesRepository.Where(x =>  x.Category.Name.Contains(filters.searchText, StringComparison.OrdinalIgnoreCase) && categoryMovies.Contains(x.movieId), "Category").Select(x => x.movieId).ToList());
                moviesId.AddRange(_GenericUMovieActorRepository.Where(x => x.Actor.Name.Contains(filters.searchText, StringComparison.OrdinalIgnoreCase) &&  categoryMovies.Contains(x.MovieId), "Actor").Select(x => x.MovieId).Distinct().ToList());
                moviesId.AddRange(_GenericMovieRepository.Where(x => x.Name.Contains(filters.searchText, StringComparison.OrdinalIgnoreCase) && categoryMovies.Contains(x.Id)).Select(x => x.Id).ToList());
            }
            result = _GenericMovieRepository.Where(x => moviesId.Distinct().Contains(x.Id)).Select(x=>new MovieDTO
            {
                Name = x.Name,
                ReleaseDate = x.ReleaseDate,
                Description = x.Description,
                Duration = x.Duration,
                imageUrl = x.imageUrl,
                actors= _GenericUMovieActorRepository.Where(z=>z.MovieId==x.Id,"Actor").ToList()
            }).ToList();
 
            return result;
        }
    }
}
