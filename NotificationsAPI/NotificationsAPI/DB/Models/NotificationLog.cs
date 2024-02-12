namespace NotificationsAPI.DB.Models
{
    public class NotificationLog:BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool Sent { get; set; }=false;
        public bool Delivered { get; set; } = false;
        public bool Read { get; set; } = false;
        public DateTime Date { get; set; }= DateTime.UtcNow;
        public string Message { get; set; }
    }
}
