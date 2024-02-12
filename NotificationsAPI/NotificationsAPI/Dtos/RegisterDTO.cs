using NotificationsAPI.DB.Models;

namespace NotificationsAPI.Dtos
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; } = "";
        public int? ProfileId { get; set; }
    }
}
