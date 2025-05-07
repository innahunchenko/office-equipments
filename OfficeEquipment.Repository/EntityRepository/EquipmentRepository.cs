using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Repository.Infrastructure;

namespace OfficeEquipment.Repository.EntityRepository
{
    public class EquipmentRepository : DbRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        { }
    }

    public interface IEquipmentRepository : IRepository<Equipment>
    { }
}
