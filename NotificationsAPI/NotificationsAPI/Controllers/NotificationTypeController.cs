using NotificationsAPI.DB;
using NotificationsAPI.DB.Models;
using NotificationsAPI.DB.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationsAPI.DB.Interface;

namespace NotificationsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationTypeController : Controller
    {
		private readonly IGenericReadOnlyRepository<NotificationType> _NotificationTypeRepository;

        public NotificationTypeController(NotificationsDBContext dbContext)
        {
            _NotificationTypeRepository = new GenericReadOnlyRepository<NotificationType>(dbContext);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public IActionResult getTypeNotifications()
        {
            var list= _NotificationTypeRepository.GetAll().ToList();
            return Json(_NotificationTypeRepository.GetAll());
        }       
    }
}
