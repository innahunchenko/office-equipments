using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Repository.EntityRepository;
using OfficeEquipment.Repository.Infrastructure;

namespace OfficeEquipment.Service.EntityService
{
    public class TypeEquipmentService : ApiService<TypeEquipment>, ITypeEquipmentService
    {
        public TypeEquipmentService(ITypeEquipmentRepository repository) : base(repository)
        {
        }
    }

    public interface ITypeEquipmentService : IService<TypeEquipment>
    { }
}
