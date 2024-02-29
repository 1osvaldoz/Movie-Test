namespace MoviesAPI.DB.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string imageUrl { get; set; }
    }
}
