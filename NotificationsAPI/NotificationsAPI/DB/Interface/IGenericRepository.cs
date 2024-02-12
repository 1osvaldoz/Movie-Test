using NotificationsAPI.DB.Models;
using System.Linq.Expressions;

namespace NotificationsAPI.DB.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity, string excludedProperties = "");
        void AddOrUpdate(T entity, string excludedProperties = "");
        void Delete(int id);
        IList<T> Where(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
    }
}