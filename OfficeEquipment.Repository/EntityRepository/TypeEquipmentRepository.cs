using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Repository.Infrastructure;

namespace OfficeEquipment.Repository.EntityRepository
{
    public class TypeEquipmentRepository : DbRepository<TypeEquipment>, ITypeEquipmentRepository
    {
        public TypeEquipmentRepository(IDbFactory databaseFactory)
            : base(databaseFactory)
        { }
    }

    public interface ITypeEquipmentRepository : IRepository<TypeEquipment>
    { }
}
