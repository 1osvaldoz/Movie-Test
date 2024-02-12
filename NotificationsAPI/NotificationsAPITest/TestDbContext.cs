using Microsoft.EntityFrameworkCore;
using NotificationsAPI.DB;
using NotificationsAPI.DB.Models;
using NotificationsAPI.Enums;

namespace NotificationsAPITest
{
    public class TestDbContext : NotificationsDBContext
    {
        public TestDbContext(DbContextOptions<NotificationsDBContext> options) : base(options)
        {
        }

        public ModelBuilder ModelBuilder { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
           (
               new Category
               {
                   Id = 1,
                   Name = "Sport"
               },
               new Category
               {
                   Id = 2,
                   Name = "Finance"
               }
               ,
               new Category
               {
                   Id = 3,
                   Name = "Movies"
               }
           );

            modelBuilder.Entity<NotificationType>().HasData
            (
                new NotificationType
                {
                    Id = 1,
                    Name = "SMS"
                },
                new NotificationType
                {
                    Id = 2,
                    Name = "EMAIL"
                }
                ,
                new NotificationType
                {
                    Id = 3,
                    Name = "PUSH NOTIFICATION"
                }
            );

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

            modelBuilder.Entity<UserCategory>().HasData
            (
                new UserCategory
                {
                    Id = 1,
                    UserId = 1,
                    CategoryId = (int)CategoryEnum.SPORTS
                },
                new UserCategory
                {
                    Id = 2,
                    UserId = 1,
                    CategoryId = (int)CategoryEnum.MOVIES
                },
                new UserCategory
                {
                    Id = 3,
                    UserId = 1,
                    CategoryId = (int)CategoryEnum.FINCANCE
                },
                new UserCategory
                {
                    Id = 4,
                    UserId = 2,
                    CategoryId = (int)CategoryEnum.MOVIES
                },
                new UserCategory
                {
                    Id = 5,
                    UserId = 3,
                    CategoryId = (int)CategoryEnum.SPORTS
                },
                new UserCategory
                {
                    Id = 6,
                    UserId = 3,
                    CategoryId = (int)CategoryEnum.FINCANCE
                }
            );

            modelBuilder.Entity<UserChannel>().HasData
           (
               new UserChannel
               {
                   Id = 1,
                   UserId = 1,
                   NotificationTypeId = (int)NotificationTypeEnum.SMS
               },
               new UserChannel
               {
                   Id = 2,
                   UserId = 1,
                   NotificationTypeId = (int)NotificationTypeEnum.EMAIL
               },
               new UserChannel
               {
                   Id = 3,
                   UserId = 1,
                   NotificationTypeId = (int)NotificationTypeEnum.PUSHNOTIFICATION
               },
               new UserChannel
               {
                   Id = 4,
                   UserId = 2,
                   NotificationTypeId = (int)NotificationTypeEnum.EMAIL
               },
               new UserChannel
               {
                   Id = 5,
                   UserId = 2,
                   NotificationTypeId = (int)NotificationTypeEnum.PUSHNOTIFICATION
               },
               new UserChannel
               {
                   Id = 6,
                   UserId = 3,
                   NotificationTypeId = (int)NotificationTypeEnum.SMS
               }
           );

        }
    }
}