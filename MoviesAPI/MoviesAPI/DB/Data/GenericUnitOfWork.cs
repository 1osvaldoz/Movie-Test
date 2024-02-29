using MoviesAPI.DB.Interface;
using MoviesAPI.DB.Models;
using MoviesAPI.DB.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.DB.Data
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

