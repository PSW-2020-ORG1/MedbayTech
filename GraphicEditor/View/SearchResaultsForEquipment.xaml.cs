using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchResaultsForEquipment.xaml
    /// </summary>
    public partial class SearchResaultsForEquipment : Page
    {
        public SearchResaultsForEquipment()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResaultsForEquipment(MainPage mainPage, string textBoxSearch)
        {
            InitializeComponent();
            page = mainPage;
            searchDataBase(textBoxSearch);
        }
        private void searchDataBase(string textBoxSearch)
        {
            List<HospitalEquipment> hospitalEquipments = Services.getService().hospitalEquipmentService.GetHospitalEquipmentsByName(textBoxSearch.ToLower().Trim());
            if (hospitalEquipments.Count != 0)
            {
                dataGridEquipment.ItemsSource = hospitalEquipments;
                return;
            }
            int id;
            if(Int32.TryParse(textBoxSearch, out id))
            {
                hospitalEquipments = Services.getService().hospitalEquipmentService.GetHospitalEquipmentsById(id);
                if (hospitalEquipments.Count != 0)
                {
                    dataGridEquipment.ItemsSource = hospitalEquipments;
                    return;
                }
            }
            MessageBox.Show("No results found!");
        }

        private void buttonShownOnMap(object sender, RoutedEventArgs e)
        {
            HospitalEquipment hospitalEquipment = (HospitalEquipment)dataGridEquipment.SelectedItem;
            MessageBox.Show("To be implemented!");
        }
    }
}
