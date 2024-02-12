﻿using NotificationsAPI.DB.Models;
using System.Linq.Expressions;

namespace NotificationsAPI.DB.Interface
{
    public interface IGenericReadOnlyRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(string includeProperties = "");
        T GetById(int id, string includeProperties = "");
        IList<T> Where(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
    }
}