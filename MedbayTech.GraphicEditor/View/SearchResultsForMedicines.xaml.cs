
using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View.Building1;
using MedbayTech.GraphicEditor.View.Building2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MedbayTech.GraphicEditor
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
            var task = httpClient.GetAsync("http://localhost:56764/api/medication/" + textBoxSearch + "/ByNameOrId")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    medications = JsonConvert.DeserializeObject<List<Medication>>(jsonString.Result);
                });
            task.Wait();
            List<Room> rooms = new List<Room>();
            var task2 = httpClient.GetAsync("http://localhost:60304/api/room/")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task2.Wait();

            medications.ForEach(m => m.Room = rooms.FirstOrDefault(r => m.RoomId != 0 && r.Id == m.RoomId));
            dataGridMedicate.ItemsSource = medications;
            if(medications.Count == 0) MessageBox.Show("No results found!");
        }
        public static string Id;

        private void ButtonShowOnMap(object sender, RoutedEventArgs e)
        {
            Medication medication = (Medication)dataGridMedicate.SelectedItem;
            if (medication == null)
            {
                MessageBox.Show("Anything selected!");
                return;
            }
            CheckHospital(medication.Room);
        }

        public void CheckHospital(Room medicationRoom)
        {
            if (medicationRoom.Department.Hospital.Id == 2)
            {
                CheckFloorForFirstHospital(medicationRoom);
            }
            else
            {
                CheckFloorForSecondHospital(medicationRoom);
            }
        }

        private void CheckFloorForFirstHospital(Room medicationRoom)
        {
            if (medicationRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building1GroundFloorPlan(page);
            }
            else if (medicationRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
            }
            SelectComboBoxesForFirstHospital(medicationRoom);
        }

        private void CheckFloorForSecondHospital(Room medicationRoom)
        {
            if (medicationRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building2GroundFloorPlan(page);
            }
            else if (medicationRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
            }
            SelectComboBoxesForSecondHospital(medicationRoom);
        }
        private void SelectComboBoxesForFirstHospital(Room medicationRoom)
        {
            Id = medicationRoom.Id.ToString();
            page.comboBoxH1.SelectedIndex = medicationRoom.Department.Floor;
            page.comboBoxHospital1.SelectedIndex = medicationRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
        private void SelectComboBoxesForSecondHospital(Room medicationRoom)
        {
            Id = medicationRoom.Id.ToString();
            page.comboBoxH2.SelectedIndex = medicationRoom.Department.Floor;
            page.comboBoxHospital2.SelectedIndex = medicationRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
    }
}
