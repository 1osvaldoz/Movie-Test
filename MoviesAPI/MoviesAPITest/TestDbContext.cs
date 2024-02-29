using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB;
using MoviesAPI.DB.Models;
using MoviesAPI.Enums;

namespace NotificationsAPITest
{
    public class TestDbContext : MoviessDBContext
    {
        public TestDbContext(DbContextOptions<MoviessDBContext> options) : base(options)
        {
        }

        public ModelBuilder ModelBuilder { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    Id = 1,
                    Name = "UserTest1",
                    PhoneNumber = "6622445566",
                    Email = "userTest1@gmail.com",
                },
                new User
                {
                    Id = 2,
                    Name = "UserTest2",
                    PhoneNumber = "6621112233",
                    Email = "userTest2@gmail.com",
                }
                ,
                new User
                {
                    Id = 3,
                    Name = "UserTest3",
                    PhoneNumber = "6623778899",
                    Email = "userTest3@gmail.com",
                }
            );

            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Horror"
                },
                new Category
                {
                    Id = 2,
                    Name = "Action"
                }
                ,
                new Category
                {
                    Id = 3,
                    Name = "Romance"
                },
                new Category
                {
                    Id = 4,
                    Name = "Comedy"
                }
                ,
                new Category
                {
                    Id = 5,
                    Name = "Adventure"
                }
            );
            modelBuilder.Entity<Movie>().HasData
           (
                new Movie
                {
                    Id = 1,
                    Name = "Batman Dark Knight Rises",
                    Description = @"The film earned much more than the original 2005 film, but underperformed compared to its direct predecessor which remains the highest grossing film centered around the Batman character. The finale to the trilogy sold 12 million tickets less than the 1989 Warner Brothers film directed by Tim Burton.[1] It has been speculated the Aurora tragedy and the lack of added publicity value from Heath Ledger's death were significant factors.",
                    Duration = "2h 45m",
                    imageUrl = "https://musicart.xboxlive.com/7/5ab02f00-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Toc Toc",
                    Description = "Story follows two young girls who show up unexpectedly at the home of a married man where they seduce him and wreak havoc on his perfect life",
                    Duration = "1h 36m",
                    imageUrl = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiiyMKthmq5XNk2eExRbJbr-LtMPhipQozRrTe8tiF2QNkzOhWJG38s4W39OZjdLbK5i9T_xpWJpbrJqocMkCtc-wuz2i41MVgFv3oETxJJ_BeU6UfTAVHiq28Ut478VEt-GeDJj3GMcUM/s1600/toc+toc.jpg"
                },
                new Movie
                {
                    Id = 3,
                    Name = "Hitch",
                    Description = @"Alex ""Hitch"" Hitchens is a legendary – and deliberately anonymous – New York City ""date doctor"" who, for a fee, has helped countless men woo the women of their dreams. While coaching Albert, a meek accountant who is smitten with glamorous celebrity Allegra Cole, Hitch finally meets his match in the the gorgeous, whip-smart Sara Melas, a gossip columnist who follows Allegra's every move. The ultimate professional bachelor, Hitch suddenly finds himself falling deliriously in love with Sara, whose biggest scoop could very well be the unmasking of Manhattan's most famous date doctor.",
                    Duration = "1h 58m",
                    imageUrl = "https://es.web.img3.acsta.net/medias/nmedia/18/89/75/30/20065236.jpg"
                },
                new Movie
                {
                    Id = 4,
                    Name = "Doctor Strange in the Multiverse of Madness",
                    Description = "Story of the talented neurosurgeon Doctor Stephen Strange, who, after a tragic car accident, must put ego aside and learn the secrets of a hidden world of mysticism and alternate dimensions.\r\n",
                    Duration = "2h 6m",
                    imageUrl = "https://static.cinepolis.com/resources/mx/movies/posters/414x603/39033-562654-20220503052138.jpg"

                },
                new Movie
                {
                    Id = 5,
                    Name = "The Modern Ocean",
                    Description = "Script delved into the intricacies of naval trade and the conflicts that arise in pursuit of valuable commodities, all while maintaining a deeply human core",
                    Duration = "1h 48m",
                    imageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1592369990i/54132675.jpg"
                }
          );
            modelBuilder.Entity<Actor>().HasData
             (
                 new Actor
                 {
                     Id = 1,
                     Name = "Christian Bale"
                 },
                 new Actor
                 {
                     Id = 2,
                     Name = "Keanu Reeves"
                 }
                 ,
                 new Actor
                 {
                     Id = 3,
                     Name = "Scarlett Johansson"
                 },
                  new Actor
                  {
                      Id = 4,
                      Name = "Benedict Cumberbatch"
                  }
                 ,
                 new Actor
                 {
                     Id = 5,
                     Name = "Ana de Armas"
                 },
                 new Actor
                 {
                     Id = 6,
                     Name = "Will Smith"
                 },
                  new Actor
                  {
                      Id = 7,
                      Name = "Ethan Hawke"
                  }
                 ,
                 new Actor
                 {
                     Id = 8,
                     Name = "Anne Hathaway"
                 },
                 new Actor
                 {
                     Id = 9,
                     Name = "Elizabeth Olsen"
                 },
                   new Actor
                   {
                       Id = 10,
                       Name = "Eva Mendes"
                   }
             );





            modelBuilder.Entity<MovieActors>()
                .HasData
            (
                new MovieActors
                {
                    Id = 1,
                    ActorId = 1,
                    MovieId = 1,
                    characterName = "Bruce Wayne"
                },
                new MovieActors
                {
                    Id = 2,
                    ActorId = 8,
                    MovieId = 1,
                    characterName = "Catwoman"
                },
                new MovieActors
                {
                    Id = 3,
                    ActorId = 2,
                    MovieId = 2,
                    characterName = "Evan Webber"
                },
                new MovieActors
                {
                    Id = 4,
                    ActorId = 5,
                    MovieId = 2,
                    characterName = "Bel"
                },

                new MovieActors
                {
                    Id = 5,
                    ActorId = 6,
                    MovieId = 3,
                    characterName = "Alex Hitch"
                },
                new MovieActors
                {
                    Id = 6,
                    ActorId = 10,
                    MovieId = 3,
                    characterName = "Sara Melas"
                },
                  new MovieActors
                  {
                      Id = 7,
                      ActorId = 4,
                      MovieId = 4,
                      characterName = "Dr Strange"
                  },
                new MovieActors
                {
                    Id = 8,
                    ActorId = 9,
                    MovieId = 4,
                    characterName = "Wanda Maximoff"
                },
                new MovieActors
                {
                    Id = 9,
                    ActorId = 5,
                    MovieId = 5,
                    characterName = "Evan Webber"
                },
                new MovieActors
                {
                    Id = 10,
                    ActorId = 2,
                    MovieId = 5,
                    characterName = "Jhon Jhonson"
                },
                new MovieActors
                {
                    Id = 11,
                    ActorId = 8,
                    MovieId = 5,
                    characterName = "Margot Stevenson"
                }
            );

            modelBuilder.Entity<MovieCategories>().HasData
           (
               new MovieCategories
               {
                   Id = 1,
                   movieId = 1,
                   categoryId = 2
               },
               new MovieCategories
               {
                   Id = 2,
                   movieId = 2,
                   categoryId = 1
               },
               new MovieCategories
               {
                   Id = 3,
                   movieId = 2,
                   categoryId = 4
               },
               new MovieCategories
               {
                   Id = 4,
                   movieId = 3,
                   categoryId = 3
               },
               new MovieCategories
               {
                   Id = 5,
                   movieId = 3,
                   categoryId = 4
               },
               new MovieCategories
               {
                   Id = 6,
                   movieId = 4,
                   categoryId = 1
               },
                new MovieCategories
                {
                    Id = 7,
                    movieId = 4,
                    categoryId = 2
                },
               new MovieCategories
               {
                   Id = 8,
                   movieId = 5,
                   categoryId = 1
               }
           );
        }
    }
}