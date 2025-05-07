using Newtonsoft.Json;
using OfficeEquipment.Data.Models;
using OfficeEquipment.Repository.Infrastructure;
using System.Collections.Generic;

namespace OfficeEquipment.Service
{
    public abstract class ApiService<TEntity> where TEntity : BaseModel
    {
        private readonly IRepository<TEntity> repository;

        public ApiService(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public List<TEntity> Entities
        {
            get
            {
                return (List<TEntity>)repository.GetAll();
            }
        }

        public void Reset()
        {
            Entities.ForEach(x =>
            {
                Delete(x.Id);
            });
        }

        public int Create(string model)
        {
            return repository.Create(JsonConvert.DeserializeObject<TEntity>(model)).Id;
        }

        public void Update(int id)
        {
            var item = repository.GetById(id);
            repository.Update(item);
        }

        public void Delete(int id)
        {
            var item = repository.GetById(id);
            repository.Delete(item);
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
