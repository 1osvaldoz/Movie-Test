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
    public class LoginTest
    {
        UserRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NotificationsDBContext>()
                              .UseInMemoryDatabase(databaseName: "TestDB")
                              .Options;
            NotificationsDBContext _context = new TestDbContext(options);
            _context.Database.EnsureCreated();
            _userRepository = new UserRepository(_context);
        }

        [Test]
        public void LoginAuthenticateSuccess()
        {
            var newLoginDTO = new LoginDTO { email = "userTest1@gmail.com" };
            var result = _userRepository.Autenticate(newLoginDTO);
            Assert.AreNotEqual(null,result);
        }
        [Test]
        public void LoginAuthenticateFail()
        {
            var newLoginDTO = new LoginDTO { email = "userTest123@gmail.com" };
            try
            {
                var result = _userRepository.Autenticate(newLoginDTO);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }

        }
    }
}