using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Repository.EntityRepository;
using OfficeEquipment.Repository.Infrastructure;

namespace OfficeEquipment.Service.EntityService
{
    public class EquipmentService : ApiService<Equipment>, IEquipmentService
    {
        public EquipmentService(IEquipmentRepository repository) : base(repository)
        { }
    }

    public interface IEquipmentService : IService<Equipment>
    { }
}
