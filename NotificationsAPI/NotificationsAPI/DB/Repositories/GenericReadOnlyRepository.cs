using NotificationsAPI.DB.Interface;
using NotificationsAPI.DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NotificationsAPI.DB.Repositories
{
    public class GenericReadOnlyRepository<T> : IGenericReadOnlyRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private DbSet<T> entities;

        public GenericReadOnlyRepository(DbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> GetAll(string includeProperties = "")
        {
            IQueryable<T> query = entities;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public async Task<IQueryable<T>> GetAllAsync(string includeProperties = "")
        {
            IQueryable<T> query = entities;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var result = await query.Include(includeProperty).ToListAsync();
                query = result.AsQueryable();
            }
            return query;
        }

        public T GetById(int id, string includeProperties = "")
        {
            IQueryable<T> query = entities;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(p => p.Id == id);
        }
        public IList<T> Where(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = entities.AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);//got to reaffect it.

            return query.Where(predicate).ToList();
        }
    }
}