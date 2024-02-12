namespace NotificationsAPI.Dtos
{
    public class NotificationPostDTO
    {
        public int userId { get; set; }
        public int categoryId { get; set; }
        public string messageText { get; set; }
    }
}
