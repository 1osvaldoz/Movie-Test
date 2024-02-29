using MoviesAPI.DB.Models;
using MoviesAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB.Interface;

namespace MoviesAPI.DB.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly DbContext _context;
        private DbSet<User> entities;
        private readonly IGenericReadOnlyRepository<MovieActors> _GenericUserCategoryRepository;
        private readonly IGenericReadOnlyRepository<MovieCategories> _GenericUserChannelRepository;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<User>();
            _GenericUserCategoryRepository = new GenericReadOnlyRepository<MovieActors>(context);
            _GenericUserChannelRepository = new GenericReadOnlyRepository<MovieCategories>(context);
        }

        public User Autenticate(LoginDTO loginDTO)
        {
            try
            {
                User objUser = (from us in entities
                                where us.Email == loginDTO.email
                                select
                                us).FirstOrDefault();
                if (objUser != null)
                {
                    return objUser;
                }
                else
                {
                    throw new Exception(@"Invalid Email. Please verify your information!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
