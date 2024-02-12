namespace NotificationsAPI.Dtos
{
    public class NotificationGetDTO
    {
        public string CategoryName { get; set; }
        public string ChannelName { get; set; }
        public string Date { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }
}
