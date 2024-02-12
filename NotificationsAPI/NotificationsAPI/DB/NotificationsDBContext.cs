using NotificationsAPI.DB.Models;
using Microsoft.EntityFrameworkCore;
using NotificationsAPI.Enums;

namespace NotificationsAPI.DB
{
    public class NotificationsDBContext : DbContext
    {
        public NotificationsDBContext(DbContextOptions<NotificationsDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
            //optionsBuilder.UseInMemoryDatabase
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<NotificationLog> NotificationLog { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UserChannel> UserChannels { get; set; }
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
                    Name = "User1",
                    PhoneNumber = "1234567890",
                    Email = "user1@gmail.com",
                },
                new User
                {
                    Id = 2,
                    Name = "User2", PhoneNumber = "0987654321",
                    Email = "user2@gmail.com",
                }
                ,
                new User
                {
                    Id = 3,
                    Name = "User3",
                    PhoneNumber = "4561327890",
                    Email = "user3@gmail.com",
                }
            );

            modelBuilder.Entity<UserCategory>().HasData
            (
                new UserCategory
                {
                    Id = 1,
                   UserId = 1,
                   CategoryId=(int)CategoryEnum.SPORTS
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