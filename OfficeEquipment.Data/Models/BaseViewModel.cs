using System.ComponentModel;

namespace OfficeEquipment.Data.Models
{
    public abstract class BaseModel
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual int Id { get; set; }

        public virtual BaseModel InnerModel { get; }

        protected void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
