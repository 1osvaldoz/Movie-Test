using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB;
using NotificationsAPI.DB.Repositories;
using NotificationsAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsAPITest
{
    public class CategoryTest
    {
        CategoryRepository _categoryRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NotificationsDBContext>()
                              .UseInMemoryDatabase(databaseName: "TestDB")
                              .Options;
            NotificationsDBContext _context = new TestDbContext(options);
            _context.Database.EnsureCreated();
            _categoryRepository = new CategoryRepository(_context);
        }

        [Test]
        public void CategoriesUser1()
        {
            var result = _categoryRepository.getCategoryByUser(1);
            Assert.AreEqual(3,result.Count);
        }
        [Test]
        public void CategoriesUser2()
        {
            var result = _categoryRepository.getCategoryByUser(2);
            Assert.AreEqual(1, result.Count);
        }
    }
}