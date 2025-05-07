using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OfficeEquipment.Repository.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
