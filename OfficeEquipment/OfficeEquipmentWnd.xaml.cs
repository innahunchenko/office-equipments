using OfficeEquipment.Data.Models;
using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Service.ObservableCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OfficeEquipmentWnd : Window
    {
        BaseCollection<TypeEquipmentView> typeEquipments;
        BaseCollection<EquipmentView> equipments;
        TypeEquipmentWnd typeEquipmentWnd;
        EquipmentWnd equipmentWnd;
        bool isSearchPanelVisibility = false;
        string[] typeEquipmentHeaders = new string[] { "ID", "Code", "Name", "Category" };
        string[] equipmentHeaders = new string[] { "ID", "Code", "Name", "Quantity", "Price" };
        public OfficeEquipmentWnd()
        {
            InitializeComponent();
            typeEquipmentHeaders.Select((t, i) => new { title = t, index = i }).ToList().ForEach(x => gridTypeEquipment.Columns[x.index].Header = x.title);
            equipmentHeaders.Select((t, i) => new { title = t, index = i }).ToList().ForEach(x => gridEquipment.Columns[x.index].Header = x.title);
        }

        public OfficeEquipmentWnd(BaseCollection<TypeEquipmentView> typeEquipments, BaseCollection<EquipmentView> equipments)
            : this()
        {
            this.typeEquipments = typeEquipments;
            this.equipments = equipments;
            gridTypeEquipment.ItemsSource = typeEquipments;
        }

        private void gridTypeEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridEquipment.ItemsSource = this.GetEquipmentsBySelectIdType();
        }

        private void rowTypeEquipment_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridTypeEquipment.SelectedIndex == -1)
                return;

            typeEquipmentWnd = new TypeEquipmentWnd(typeEquipments, ((TypeEquipmentView)gridTypeEquipment.SelectedItem).Id);
            typeEquipmentWnd.ShowDialog();
        }

        private void btnInsertTypeEquipment_Click(object sender, RoutedEventArgs e)
        {
            typeEquipmentWnd = new TypeEquipmentWnd(typeEquipments);
            typeEquipmentWnd.ShowDialog();
        }

        private void btnUpdateTypeEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.rowTypeEquipment_DoubleClick(null, null);
        }

        private void btnDelTypeEquipment_Click(object sender, RoutedEventArgs e)
        {
            typeEquipments.Remove((TypeEquipmentView)gridTypeEquipment.SelectedItem);
            gridTypeEquipment.Items.Refresh();
            gridTypeEquipment.ItemsSource = typeEquipments;
        }

        private void btnFindByIdTypeEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.ShowFindPanel(searchPanelTypeEquipment, gridTypeEquipment, typeEquipments);
        }

        private void btnInsertEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (gridTypeEquipment.SelectedItem == null)
                return;
                
            equipmentWnd = new EquipmentWnd(equipments, ((TypeEquipmentView)gridTypeEquipment.SelectedItem).Id);
            equipmentWnd.ShowDialog();
            gridEquipment.ItemsSource = this.GetEquipmentsBySelectIdType();
        }

        private void rowEquipment_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridEquipment.SelectedIndex == -1)
                return;

            equipmentWnd = new EquipmentWnd(equipments, null, ((EquipmentView)gridEquipment.SelectedItem).Id);
            equipmentWnd.ShowDialog();
        }

        private void btnUpdateEquipment_Click(object sender, RoutedEventArgs e)
        {
            rowEquipment_DoubleClick(null, null);
        }

        private void btnDelEquipment_Click(object sender, RoutedEventArgs e)
        {
            equipments.Remove((EquipmentView)gridEquipment.SelectedItem);
            gridEquipment.Items.Refresh();
        }

        private void btnFindByIdEquipment_Click(object sender, RoutedEventArgs e)
        {
            this.ShowFindPanel(searchPanelEquipment, gridEquipment, this.GetEquipmentsBySelectIdType());
        }

        private void btSearchTypeEquipment_Click(object sender, RoutedEventArgs e)
        {
            var listSearch = this.SearchEntityFromCollectionByIdFromTextBox(tbSearchTypeEquipment, typeEquipments);
            if (listSearch == null)
                return;
            gridTypeEquipment.ItemsSource = new List<TypeEquipmentView> { listSearch };
        }

        private void btSearchEquipment_Click(object sender, RoutedEventArgs e)
        {
            var listSearch = this.SearchEntityFromCollectionByIdFromTextBox(tbSearchEquipment, this.GetEquipmentsBySelectIdType());
            if (listSearch == null)
                return;
            gridEquipment.ItemsSource = new List<EquipmentView> { listSearch };
        }

        public List<EquipmentView> GetEquipmentsBySelectIdType()
        {
            if (gridTypeEquipment.SelectedItem == null)
                return null;

            var item = gridTypeEquipment.SelectedItem as TypeEquipmentView;
            return equipments.Where(x => ((Equipment)x.InnerModel).TypeEquipmentId == item.Id).ToList();
        }

        public void ShowFindPanel<T>(DockPanel searchDockPanel, DataGrid dataGrid, IEnumerable<T> itemSource) where T: BaseViewModel
        {
            if (!isSearchPanelVisibility)
            {
                searchDockPanel.Visibility = Visibility.Visible;
                isSearchPanelVisibility = true;
            }
            else
            {
                searchDockPanel.Visibility = Visibility.Collapsed;
                isSearchPanelVisibility = false;
                dataGrid.ItemsSource = itemSource;
            }
        }

        public T SearchEntityFromCollectionByIdFromTextBox<T>(TextBox textBox, IEnumerable<T> collection) where T: BaseViewModel
        {
            try
            {
                int id = Int32.Parse(textBox.Text);
                return collection.Where(x => x.InnerModel.Id == id).First();
            }
            catch
            {
                return null;
            }
        }
    }
}