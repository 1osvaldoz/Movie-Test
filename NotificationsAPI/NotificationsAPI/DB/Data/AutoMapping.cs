using NotificationsAPI.DB.Models;
using NotificationsAPI.Dtos;

namespace NotificationsAPI.DB.Data
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
        }
    }
}
