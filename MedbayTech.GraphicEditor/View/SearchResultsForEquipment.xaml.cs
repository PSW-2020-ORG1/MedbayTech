
using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View.Building1;
using MedbayTech.GraphicEditor.View.Building2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MedbayTech.GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchResaultsForEquipment.xaml
    /// </summary>
    public partial class SearchResultsForEquipment : Page
    {
        public SearchResultsForEquipment()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResultsForEquipment(MainPage mainPage, string textBoxSearch)
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
            List<HospitalEquipment> hospitalEquipment = new List<HospitalEquipment>();
            if(textBoxSearch.Trim().Equals(""))
            {
                dataGridEquipment.ItemsSource = hospitalEquipment;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
           // var task = httpClient.GetAsync("http://localhost:53109/api/hospitalequipment/" + textBoxSearch)
            var task = httpClient.GetAsync("http://localhost:60304/api/hospitalequipment/" + textBoxSearch)
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    Console.WriteLine(jsonString.Result);
                    hospitalEquipment = JsonConvert.DeserializeObject<List<HospitalEquipment>>(jsonString.Result);
                });
            task.Wait();
            dataGridEquipment.ItemsSource = hospitalEquipment;
            if (hospitalEquipment.Count == 0) MessageBox.Show("No results found!");
        }
        public static string Id;
        private void ButtonShowOnMap(object sender, RoutedEventArgs e)
        {
            HospitalEquipment hospitalEquipment = (HospitalEquipment)dataGridEquipment.SelectedItem;
            if (hospitalEquipment == null)
            {
                MessageBox.Show("Anything selected!");
                return;
            }
            CheckHospital(hospitalEquipment.Room);
        }

        public void CheckHospital(Room equipmentRoom)
        {
            if (equipmentRoom.Department.Hospital.Id == 2)
            {
                CheckFloorForFirstHospital(equipmentRoom);
            }
            else
            {
                CheckFloorForSecondHospital(equipmentRoom);
            }
        }

        private void CheckFloorForFirstHospital(Room equipmentRoom)
        {
            if (equipmentRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building1GroundFloorPlan(page);
            }
            else if (equipmentRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
            }
            SelectComboBoxesForFirstHospital(equipmentRoom);

        }

        private void CheckFloorForSecondHospital(Room equipmentRoom)
        {
            if (equipmentRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building2GroundFloorPlan(page);
            }
            else if (equipmentRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
            }
            SelectComboBoxesForSecondHospital(equipmentRoom);
        }
        private void SelectComboBoxesForFirstHospital(Room equipmentRoom)
        {
            Id = equipmentRoom.Id.ToString();
            page.comboBoxH1.SelectedIndex = equipmentRoom.Department.Floor;
            page.comboBoxHospital1.SelectedIndex = equipmentRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
        private void SelectComboBoxesForSecondHospital(Room equipmentRoom)
        {
            Id = equipmentRoom.Id.ToString();
            page.comboBoxH2.SelectedIndex = equipmentRoom.Department.Floor;
            page.comboBoxHospital2.SelectedIndex = equipmentRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
    }
}
