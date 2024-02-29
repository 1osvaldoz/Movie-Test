using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB.Repositories;
using MoviesAPI.DB;
using MoviesAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NotificationsAPITest
{
    internal class MovieTest
    {
        MoviesRepository _movieRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MoviessDBContext>()
                              .UseInMemoryDatabase(databaseName: "TestDB")
                              .Options;
            MoviessDBContext _context = new TestDbContext(options);
            _context.Database.EnsureCreated();
            _movieRepository = new MoviesRepository(_context);
        }

        [Test]
        public void getMovieRomance()
        {
            MoviePostDTO moviePost = new MoviePostDTO
            {
                categories = new List<CategoriesDTO>{ new CategoriesDTO
                {
                    value=3,
                    label=""
                }},
                searchText = ""
            };

            var result=_movieRepository.GetMovies(moviePost);
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void getMovieKeanuReeves()
        {
            MoviePostDTO moviePost = new MoviePostDTO
            {
                categories = new List<CategoriesDTO>(),
                searchText = "Keanu Reeves"
            };

            var result = _movieRepository.GetMovies(moviePost);
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void getMovieBatman()
        {
            MoviePostDTO moviePost = new MoviePostDTO
            {
                categories = new List<CategoriesDTO>(),
                searchText = "Batman"
            };

            var result = _movieRepository.GetMovies(moviePost);
            Assert.AreEqual(1, result.Count);
        }
    }
}