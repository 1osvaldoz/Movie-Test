using NotificationsAPI.DB.Interface;
using NotificationsAPI.DB.Models;
using NotificationsAPI.DB.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NotificationsAPI.DB.Data
{
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private readonly DbContext _dbContext;

        public GenericUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GenericRepository<T> GetRepositoryInstance<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}

