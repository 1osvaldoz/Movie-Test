using NotificationsAPI.DB.Models;
using NotificationsAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB.Interface;

namespace NotificationsAPI.DB.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly DbContext _context;
        private DbSet<User> entities;
        private readonly IGenericReadOnlyRepository<UserCategory> _GenericUserCategoryRepository;
        private readonly IGenericReadOnlyRepository<UserChannel> _GenericUserChannelRepository;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<User>();
            _GenericUserCategoryRepository = new GenericReadOnlyRepository<UserCategory>(context);
            _GenericUserChannelRepository = new GenericReadOnlyRepository<UserChannel>(context);
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
        public CategoryChannelsUsers GetCategoryChannelsByUser(int userId)
        {
            var newCategoryChannelsUser= new CategoryChannelsUsers();
            newCategoryChannelsUser.categories= _GenericUserCategoryRepository.Where(x=>x.UserId==userId,"Category").Select(x=>x.Category.Name).ToList();
            newCategoryChannelsUser.channels= _GenericUserChannelRepository.Where(x=>x.UserId==userId, "NotificationType").Select(x=>x.NotificationType.Name).ToList();
            return newCategoryChannelsUser;
        }
    }
}
