using MoviesAPI.DB.Models;
using MoviesAPI.Dtos;

namespace MoviesAPI.DB.Data
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<User, CategoriesDTO>().ReverseMap();
        }
    }
}
