namespace NotificationsAPI.DB.Models
{
    public class UserChannel:BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int NotificationTypeId { get; set; }
        public virtual NotificationType NotificationType { get; set; }
    }
}
