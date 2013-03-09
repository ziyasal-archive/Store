using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WPFArch.Data.CodeFirst.Infrastructure;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public class EntityRepository<TEntityType> : RepositoryBase where TEntityType : class
    {
        private readonly IDbSet<TEntityType> _dbset;

        public IEnumerable<TEntityType> All
        {
            get { return _dbset.ToList(); }
        }
        public EntityRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            _dbset = DataContext.Set<TEntityType>();
        }

        public virtual void Insert(TEntityType entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(TEntityType entity)
        {
            _dbset.Remove(entity);
        }



        public virtual IEnumerable<TEntityType> GetMany(Func<TEntityType, bool> where)
        {
            return _dbset.Where(where).ToList();
        }
        public TEntityType Get(Func<TEntityType, Boolean> where)
        {
            return _dbset.Where(where).FirstOrDefault();
        }


        public IQueryable<TEntityType> AllIncluding(params Expression<Func<TEntityType, object>>[] includeProperties)
        {
            IQueryable<TEntityType> query = _dbset;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual TEntityType Find(int id)
        {
            return _dbset.Find(id);
        }

        public virtual void Update(TEntityType entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }
    }
}