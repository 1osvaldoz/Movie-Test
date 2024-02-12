using NotificationsAPI.DB.Models;
using NotificationsAPI.DB.Repositories;

namespace NotificationsAPI.DB.Interface
{
    public interface IGenericUnitOfWork
    {
        GenericRepository<T> GetRepositoryInstance<T>() where T : BaseEntity;
        void SaveChanges();
    }
}