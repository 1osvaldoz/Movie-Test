using NotificationsAPI.DB.Interface;
using Newtonsoft.Json;

namespace NotificationsAPI.DB.Models
{
    public class BaseEntity : IEntity
    {
        [JsonProperty(Order = -20)]
        public int Id { get; set; }
      
    }
}
