using System.Collections.Generic;

namespace OfficeEquipment.Service
{
    public interface IService<TEntity> where TEntity : class
    {
        int Create(string model);
        void Update(int id);
        void Delete(int id);
        void Reset();
        TEntity GetById(int id);
        List<TEntity> Entities { get; }
    }
}
