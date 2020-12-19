using Backend.Medications.Model;
using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
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
using System.Windows.Media.Animation;
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
        private void TransitionAnimation()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            storyboard.Children.Add(doubleAnimation);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.OpacityProperty));
            Storyboard.SetTargetName(doubleAnimation, page.MainFrame.Name);
            storyboard.Begin(page);
        }

        private void searchDataBase(string textBoxSearch)
        {
            List<Medication> medications = new List<Medication>();
            if(textBoxSearch.Trim().Equals(""))
            {
                dataGridMedicate.ItemsSource = medications;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/medication/" + textBoxSearch + "/ByNameOrId")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    medications = JsonConvert.DeserializeObject<List<Medication>>(jsonString.Result);
                });
            task.Wait();
            dataGridMedicate.ItemsSource = medications;
            if(medications.Count == 0) MessageBox.Show("No results found!");
        }
        public static string Id;
        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            Medication medication = (Medication)dataGridMedicate.SelectedItem;
            if (medication == null)
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }
            Room medicationRoom = medication.Room;

            if (medicationRoom.Department.Floor == 0 && medicationRoom.Department.Hospital.Id == 1)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building1FloorPlan(page);
                page.comboBoxH1.SelectedIndex = 0;
                page.comboBoxHospital1.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (medicationRoom.Department.Floor == 1 && medicationRoom.Department.Hospital.Id == 1)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 1;
                page.comboBoxHospital1.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (medicationRoom.Department.Floor == 2 && medicationRoom.Department.Hospital.Id == 1)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 2;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            if (medicationRoom.Department.Floor == 0 && medicationRoom.Department.Hospital.Id == 2)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building2FloorPlan(page);
                page.comboBoxH2.SelectedIndex = 0;
                page.comboBoxHospital2.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (medicationRoom.Department.Floor == 1 && medicationRoom.Department.Hospital.Id == 2)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 1;
                page.comboBoxHospital2.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (medicationRoom.Department.Floor == 2 && medicationRoom.Department.Hospital.Id == 2)
            {
                Id = medicationRoom.Id.ToString();
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 2;
                page.comboBoxHospital2.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }


        }
    }
}
