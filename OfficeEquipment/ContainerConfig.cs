using Autofac;
using OfficeEquipment.Repository.EntityRepository;
using OfficeEquipment.Repository.Infrastructure;
using OfficeEquipment.Service.EntityService;

namespace OfficeEquipment
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationRun>().As<IApplicationRun>();
            builder.RegisterType<TypeEquipmentService>().As<ITypeEquipmentService>();
            builder.RegisterType<EquipmentService>().As<IEquipmentService>();
            builder.RegisterType<TypeEquipmentRepository>().As<ITypeEquipmentRepository>();
            builder.RegisterType<EquipmentRepository>().As<IEquipmentRepository>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            return builder.Build();
        }
    }
}
