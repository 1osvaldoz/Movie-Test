namespace MoviesAPI.Dtos
{
    public class MoviePostDTO
    {
        public string searchText { get; set; }
        public List<CategoriesDTO> categories { get; set; }
    }
}
