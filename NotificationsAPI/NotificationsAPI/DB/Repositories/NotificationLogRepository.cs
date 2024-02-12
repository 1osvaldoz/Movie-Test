using NotificationsAPI.DB.Models;
using NotificationsAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB.Interface;

namespace NotificationsAPI.DB.Repositories
{
    public class NotificationLogRepository : GenericRepository<NotificationLog>
    {
        private readonly DbContext _context;
        private DbSet<NotificationLog> entities;
        private readonly IGenericRepository<NotificationLog> _GenericNotificationLogRepository;
        private readonly IGenericReadOnlyRepository<UserChannel> _GenericUserChannelRepository;

        public NotificationLogRepository(DbContext context) : base(context)
        {
            try
            {
                entities = context.Set<NotificationLog>();
                _context = context;
                _GenericNotificationLogRepository = new GenericRepository<NotificationLog>(context);
                _GenericUserChannelRepository = new GenericReadOnlyRepository<UserChannel>(context);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool createNotificationLog(NotificationPostDTO notificationPostDTO)
        {
            var newNotificationLogs = from notificationLog in _GenericUserChannelRepository.Where(x => x.UserId == notificationPostDTO.userId)
                                      select new NotificationLog
                                      {
                                          UserId = notificationPostDTO.userId,
                                          CategoryId = notificationPostDTO.categoryId,
                                          Message = notificationPostDTO.messageText,
                                          NotificationTypeId = notificationLog.NotificationTypeId
                                      };
            foreach (var notificationLog in newNotificationLogs)
            {
                _GenericNotificationLogRepository.AddOrUpdate(notificationLog);
            }
            _context.SaveChanges();
            var all = _GenericNotificationLogRepository.Where(x => 1 == 1);
            return true;
        }
        public List<NotificationGetDTO> getNotificationLog(int userId)
        {
            var newNotificationLogs = from notificationLog in _GenericNotificationLogRepository.Where(x => x.UserId == userId, "Category","NotificationType")
                                      select new NotificationGetDTO
                                      {
                                          CategoryName = notificationLog.Category.Name,
                                          ChannelName = notificationLog.NotificationType.Name,
                                          Message = notificationLog.Message,
                                          Date = DateToString(notificationLog.Date, "MMM dd yyyy hh:mm:ss"),
                                          DateTime= notificationLog.Date
                                      };
            return newNotificationLogs.OrderByDescending(x=>x.DateTime).ToList();
        }
        private string DateToString(DateTime date, string format)
        {
            return date.ToString(format).ToUpper();
        }
    }
}
