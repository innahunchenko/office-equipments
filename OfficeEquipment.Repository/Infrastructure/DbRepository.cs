using Microsoft.EntityFrameworkCore;
using OfficeEquipment.Data.Configuration;
using OfficeEquipment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OfficeEquipment.Repository.Infrastructure
{
    public abstract class DbRepository<TEntity> where TEntity : class, new()
    {
        private OfficeEquipmentContext dataContext;
        private readonly DbSet<TEntity> dbset;
        protected DbRepository(IDbFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<TEntity>();
        }

        protected IDbFactory DatabaseFactory { get; private set; }

        protected OfficeEquipmentContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
        public virtual TEntity Create(TEntity entity)
        {            
            dbset.Add(entity);
            dataContext.SaveChanges();
            return entity;
        }
        public virtual void Update(TEntity entity)
        {
            var entry = dataContext.Entry(entity);
            entry.State = EntityState.Modified;
            dataContext.SaveChanges();
        }
        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
            dataContext.SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
    }
}