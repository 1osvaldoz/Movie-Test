using NotificationsAPI.DB.Models;
using NotificationsAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB.Interface;

namespace NotificationsAPI.DB.Repositories
{
    public class CategoryRepository : GenericRepository<NotificationLog>
    {
        private readonly DbContext _context;
        private DbSet<Category> entities;
        private readonly IGenericRepository<Category> _GenericNotificationLogRepository;
        private readonly IGenericReadOnlyRepository<UserCategory> _GenericUserCategoryRepository;

        public CategoryRepository(DbContext context) : base(context)
        {
            try
            {
                entities = context.Set<Category>();
                _context = context;
                _GenericNotificationLogRepository = new GenericRepository<Category>(context);
                _GenericUserCategoryRepository = new GenericReadOnlyRepository<UserCategory>(context);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        public List<Category> getCategoryByUser(int userId)
        {
            var newCategories = from notificationLog in _GenericUserCategoryRepository.Where(x => x.UserId == userId, "Category")
                                      select notificationLog.Category;
            return newCategories.ToList();
        }
        private string DateToString(DateTime date, string format)
        {
            return date.ToString(format);
        }
    }
}
