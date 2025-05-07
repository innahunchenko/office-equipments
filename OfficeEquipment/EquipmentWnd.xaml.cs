using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Service.ObservableCollections;
using System.Linq;
using System.Windows;

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for EquipmentWnd.xaml
    /// </summary>
    public partial class EquipmentWnd
    {
        private int? id;
        int? typeId;
        BaseCollection<EquipmentView> equipments;
        public EquipmentWnd()
        {
            InitializeComponent();
        }

        public EquipmentWnd(BaseCollection<EquipmentView> equipments, int? typeId = null, int? id = null)
            : this()
        {
            this.id = id;
            this.equipments = equipments;
            this.typeId = typeId;

            if (id.HasValue)
            {
                mainGrid.DataContext = equipments.ToList().Where(x => x.Id == id).First();
            }
        }

        public EquipmentView StoreEquipment()
        {
            int amount = int.TryParse(tbAmount.Text, out amount) ? amount : 0;
            decimal price = decimal.TryParse(tbPrice.Text, out price) ? price : 0;
            return new EquipmentView()
            {
                Name = tbName.Text,
                Code = tbCode.Text,
                Amount = amount,
                Price = price,
                TypeEquipmentId = (int)typeId
        };
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!id.HasValue)
            {
                equipments.Add(this.StoreEquipment());
            }

            equipmentWnd.Close();
        }
    }
}
