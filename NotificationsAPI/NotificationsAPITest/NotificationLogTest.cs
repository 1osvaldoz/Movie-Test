using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB.Repositories;
using NotificationsAPI.DB;
using NotificationsAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NotificationsAPITest
{
    internal class NotificationLogTest
    {
        NotificationLogRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NotificationsDBContext>()
                              .UseInMemoryDatabase(databaseName: "TestDB")
                              .Options;
            NotificationsDBContext _context = new TestDbContext(options);
            _context.Database.EnsureCreated();
            _userRepository = new NotificationLogRepository(_context);
        }

        [Test]
        public void createNotificationUser1()
        {
            NotificationPostDTO notificationPostDTO= new NotificationPostDTO
            {
                userId=1,
                categoryId=1,
                messageText="test 1"
            };

            _userRepository.createNotificationLog(notificationPostDTO);
            var result=_userRepository.getNotificationLog(notificationPostDTO.userId);
            Assert.AreEqual(3, result.Count);
        }
        [Test]
        public void createNotificationUser2()
        {
            NotificationPostDTO notificationPostDTO = new NotificationPostDTO
            {
                userId = 2,
                categoryId = 1,
                messageText = "test 1"
            };

            _userRepository.createNotificationLog(notificationPostDTO);
            var result = _userRepository.getNotificationLog(notificationPostDTO.userId);
            Assert.AreEqual(2, result.Count);
        }
        [Test]
        public void createNotificationUser3()
        {
            NotificationPostDTO notificationPostDTO = new NotificationPostDTO
            {
                userId = 3,
                categoryId = 1,
                messageText = "test 1"
            };

            _userRepository.createNotificationLog(notificationPostDTO);
            var result = _userRepository.getNotificationLog(notificationPostDTO.userId);
            Assert.AreEqual(1, result.Count);
        }
    }
}