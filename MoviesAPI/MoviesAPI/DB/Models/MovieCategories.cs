namespace MoviesAPI.DB.Models
{
    public class MovieCategories:BaseEntity
    {
        public int movieId { get; set; }
        public virtual Movie movie { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
