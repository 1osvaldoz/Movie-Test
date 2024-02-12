using NotificationsAPI.DB;
using NotificationsAPI.DB.Models;
using NotificationsAPI.DB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationsAPI.DB.Interface;
using NotificationsAPI.Dtos;

namespace NotificationsAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class NotificationLogController : Controller
    {
		private readonly NotificationLogRepository _NotificationLogRepository;

        public NotificationLogController(NotificationsDBContext dbContext)
        {
            _NotificationLogRepository = new NotificationLogRepository(dbContext);
        }
        [HttpPost]
        public IActionResult postNotificationsLog([FromBody]NotificationPostDTO rawNotificationLog)
        {
            var userIdStr = HttpContext.User.Claims.Where(p => p.Type == "UserId").FirstOrDefault().Value;
            rawNotificationLog.userId = Convert.ToInt32(userIdStr);
            _NotificationLogRepository.createNotificationLog(rawNotificationLog);
            return Ok();
        }
        [HttpGet]
        public IActionResult getNotificationsLog()
        {
            var userId =Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserId").FirstOrDefault().Value);
            
            return Json(_NotificationLogRepository.getNotificationLog(userId));
        }
    }
}
        