using MoviesAPI.DB.Interface;
using MoviesAPI.DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MoviesAPI.DB.Repositories
{
    public class GenericRepository<T> : IGenericReadOnlyRepository<T>, IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private DbSet<T> entities;

        public GenericRepository(DbContext context)
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

        public void Insert(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity, string excludedProperties = "")
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var attachedEntity = entities.Attach(entity);
            attachedEntity.State = EntityState.Modified;

            foreach (var excludedProperty in excludedProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                attachedEntity.Property(excludedProperty).IsModified = false;
            }
        }
        public void AddOrUpdate(T entity, string excludedProperties = "")
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var pastEntity = GetById(entity.Id);
            if (pastEntity == null)
            {
                entities.Add(entity);
            }
            else
            {
                _context.Entry(pastEntity).State = EntityState.Detached;
                pastEntity = entity;
                var attachedEntity = entities.Attach(pastEntity);
                attachedEntity.State = EntityState.Modified;

                foreach (var excludedProperty in excludedProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    attachedEntity.Property(excludedProperty).IsModified = false;
                }
            }
        }
        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);

            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    entities.Attach(entity);
                }
                entities.Remove(entity);
            }
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