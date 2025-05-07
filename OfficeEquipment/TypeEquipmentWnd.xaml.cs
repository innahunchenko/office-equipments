using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Service.ObservableCollections;
using System.Windows;

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for TypqEquipmentWnd.xaml
    /// </summary>
    public partial class TypeEquipmentWnd : Window
    {
        private int? id;
        BaseCollection<TypeEquipmentView> typeEquipments;
        public TypeEquipmentWnd()
        {
            InitializeComponent();
        }

        public TypeEquipmentWnd(BaseCollection<TypeEquipmentView> typeEquipments, int? id = null)
            : this()
        {
            this.id = id;
            this.typeEquipments = typeEquipments;
            if (id.HasValue)
            {
                foreach (var item in typeEquipments)
                {
                    if (item.Id == id)
                    {
                        mainGrid.DataContext = item;
                        break;
                    }
                }
            }
        }

        public TypeEquipmentView StoreTypeEquipment()
        {
            return new TypeEquipmentView()
            {
                Name = tbName.Text,
                Code = tbCode.Text,
                Kind = tbKind.Text
            };
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!id.HasValue)
            {
                typeEquipments.Add(this.StoreTypeEquipment());
            }

            typeEquipmentWnd.Close();
        }
    }
}
