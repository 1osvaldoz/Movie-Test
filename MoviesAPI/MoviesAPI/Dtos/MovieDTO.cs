using MoviesAPI.DB.Models;

namespace MoviesAPI.Dtos
{
    public class MovieDTO:Movie
    {
        public List<MovieActors> actors {  get; set; }
    }
}
