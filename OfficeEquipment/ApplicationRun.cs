using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Service.EntityService;
using OfficeEquipment.Service.ObservableCollections;

namespace OfficeEquipment
{
    class ApplicationRun : IApplicationRun
    {
        ITypeEquipmentService typeEquipmentService;
        IEquipmentService equipmentService;
        EntityCollection<TypeEquipmentView, TypeEquipment> typeEquipmentCollection;
        EntityCollection<EquipmentView, Equipment> equipmentCollection;

        public ApplicationRun(ITypeEquipmentService typeEquipmentService, IEquipmentService equipmentService)
        {
            this.typeEquipmentService = typeEquipmentService;
            this.equipmentService = equipmentService;
            this.typeEquipmentCollection = new EntityCollection<TypeEquipmentView, TypeEquipment>(typeEquipmentService);
            this.equipmentCollection = new EntityCollection<EquipmentView, Equipment>(equipmentService);
        }

        public void Run()
        {
            var mw = new OfficeEquipmentWnd(typeEquipmentCollection.Values, equipmentCollection.Values);
            mw.Show();
        }
    }

    public interface IApplicationRun
    {
        void Run();
    }
}