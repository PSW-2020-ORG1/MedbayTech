using Backend.Medications.Model;
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
    /// Interaction logic for SearchResultsForMedicines.xaml
    /// </summary>
    public partial class SearchResultsForMedicines : Page
    {
        public SearchResultsForMedicines()
        {
            InitializeComponent();
      
        }
        MainPage page;
        public SearchResultsForMedicines(MainPage mainPage, string textBoxSearch)
        {
            InitializeComponent();
            page = mainPage;
            searchDataBase(textBoxSearch);

        }

        private void searchDataBase(string textBoxSearch)
        {
            List<Medication> medications = Services.getService().medicationService.GetAllMedicationsByName(textBoxSearch.ToLower().Trim());
            if (medications.Count != 0)
            {
                dataGridMedicate.ItemsSource = medications;
                return;
            }
           /* 
            * TO BE IMPLEMENTED 
            medications = Services.getService().medicationService.GetAllMedicationsById(textBoxSearch.ToLower().Trim());
            if (medications.Count != 0)
            {
                dataGridMedicate.ItemsSource = medications;
                return;
            }
            */
            MessageBox.Show("No results found!");
        }
        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To be implemented!");
        }
    }
}
