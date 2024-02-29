using MoviesAPI.DB.Models;
using MoviesAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB.Interface;

namespace MoviesAPI.DB.Repositories
{
    public class CategoryRepository : GenericRepository<Movie>
    {
        private readonly DbContext _context;
        private DbSet<Category> entities;
        private readonly IGenericReadOnlyRepository<Category> _GenericUserCategoryRepository;

        public CategoryRepository(DbContext context) : base(context)
        {
            try
            {
                entities = context.Set<Category>();
                _context = context;
                _GenericUserCategoryRepository = new GenericReadOnlyRepository<Category>(context);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        public List<Category> getCategories()
        {
            return _GenericUserCategoryRepository.GetAll().ToList();
        }
    }
}
