using MoviesAPI.DB.Models;
using MoviesAPI.DB.Repositories;

namespace MoviesAPI.DB.Interface
{
    public interface IGenericUnitOfWork
    {
        GenericRepository<T> GetRepositoryInstance<T>() where T : BaseEntity;
        void SaveChanges();
    }
}