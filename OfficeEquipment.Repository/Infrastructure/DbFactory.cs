using OfficeEquipment.Data.Configuration;
using System;

namespace OfficeEquipment.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        OfficeEquipmentContext Get();
    }

    public class DbFactory : Disposable, IDbFactory
    {
        private OfficeEquipmentContext dataContext;

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }

        public OfficeEquipmentContext Get()
        {
            return dataContext ?? (dataContext = new OfficeEquipmentContext());
        }
    }
}
