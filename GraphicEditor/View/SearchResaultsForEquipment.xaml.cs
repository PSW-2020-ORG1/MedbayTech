using Model.Rooms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            List<HospitalEquipment> hospitalEquipment = new List<HospitalEquipment>();
            if(textBoxSearch.Trim().Equals(""))
            {
                dataGridEquipment.ItemsSource = hospitalEquipment;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/hospitalequipment/" + textBoxSearch)
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    hospitalEquipment = JsonConvert.DeserializeObject<List<HospitalEquipment>>(jsonString.Result);
                });
            task.Wait();
            dataGridEquipment.ItemsSource = hospitalEquipment;
            if (hospitalEquipment.Count == 0) MessageBox.Show("No results found!");
        }

        private void buttonShownOnMap(object sender, RoutedEventArgs e)
        {
            HospitalEquipment hospitalEquipment = (HospitalEquipment)dataGridEquipment.SelectedItem;
            MessageBox.Show("To be implemented!");
        }
    }
}
