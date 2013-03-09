using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public interface IRepository<TEntityType> where TEntityType : class
    {
        IEnumerable<TEntityType> GetMany(Func<TEntityType, bool> where);
        IQueryable<TEntityType> AllIncluding(params Expression<Func<TEntityType, object>>[] includeProperties);

        TEntityType Find(int id);
        TEntityType Get(Func<TEntityType, Boolean> where);

        void Insert(TEntityType entity);
        void Update(TEntityType products);
        void Delete(int id);
        void Delete(TEntityType entity);

        IEnumerable<TEntityType> All { get; }
    }
}
