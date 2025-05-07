using OfficeEquipment.Data.Models;

namespace OfficeEquipment.DbRepository.Models
{
    public partial class Equipment : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal? Price { get; set; }
        public int TypeEquipmentId { get; set; }

        public virtual TypeEquipment TypeEquipment { get; set; }
    }

    public class EquipmentView : BaseViewModel
    {
        private Equipment equipment;
        public override BaseModel InnerModel { get { return equipment; } }

        public EquipmentView()
        {
            equipment = new Equipment();
        }

        public EquipmentView(Equipment equipment)
        {
            this.equipment = equipment;
        }

        public override int Id
        {
            get { return equipment.Id; }
            set
            {
                equipment.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public virtual string Code
        {
            get { return equipment.Code; }
            set
            {
                equipment.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public virtual string Name
        {
            get { return equipment.Name; }
            set
            {
                equipment.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public virtual int Amount
        {
            get { return equipment.Amount; }
            set
            {
                equipment.Amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public virtual decimal? Price
        {
            get { return equipment.Price; }
            set
            {
                equipment.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public virtual int TypeEquipmentId
        {
            get { return equipment.TypeEquipmentId; }
            set
            {
                equipment.TypeEquipmentId = value;
                OnPropertyChanged("TypeEquipmentId");
            }
        }
    }
}
