using OfficeEquipment.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeEquipment.DbRepository.Models
{
    public partial class TypeEquipment : BaseModel
    {
        public TypeEquipment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }

    public class TypeEquipmentView : BaseViewModel
    {
        private TypeEquipment typeEquipment;
        public override BaseModel InnerModel { get { return typeEquipment; } }

        public TypeEquipmentView()
        {
            typeEquipment = new TypeEquipment();
        }

        public TypeEquipmentView(TypeEquipment typeEquipment)
        {
            this.typeEquipment = typeEquipment;
        }

        public virtual int Id
        {
            get { return typeEquipment.Id; }
            set
            {
                typeEquipment.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public virtual string Code
        {
            get { return typeEquipment.Code; }
            set
            {
                typeEquipment.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public virtual string Name
        {
            get { return typeEquipment.Name; }
            set
            {
                typeEquipment.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public virtual string Kind
        {
            get { return typeEquipment.Kind; }
            set
            {
                typeEquipment.Kind = value;
                OnPropertyChanged("Kind");
            }
        }
    }
}