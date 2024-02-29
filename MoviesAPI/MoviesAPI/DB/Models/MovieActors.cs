namespace MoviesAPI.DB.Models
{
    public class MovieActors:BaseEntity
    {
      
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public string characterName { get;set; }

    }
}
