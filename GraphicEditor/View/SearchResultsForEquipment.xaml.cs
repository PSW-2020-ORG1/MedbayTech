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
        public static string Id;
        private void buttonShownOnMap(object sender, RoutedEventArgs e)
        {

            HospitalEquipment equipment = (HospitalEquipment)dataGridEquipment.SelectedItem;

            if (equipment == null)
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }

            Room equipmentRoom = equipment.Room;

            if (equipmentRoom.Department.Floor == 0 && equipmentRoom.Department.Hospital.Id == 1)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building1FloorPlan(page);
                page.comboBoxH1.SelectedIndex = 0;
                page.comboBoxHospital1.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (equipmentRoom.Department.Floor == 1 && equipmentRoom.Department.Hospital.Id == 1)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 1;
                page.comboBoxHospital1.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (equipmentRoom.Department.Floor == 2 && equipmentRoom.Department.Hospital.Id == 1)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 2;
                page.comboBoxHospital1.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            if (equipmentRoom.Department.Floor == 0 && equipmentRoom.Department.Hospital.Id == 2)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building2FloorPlan(page);
                page.comboBoxH2.SelectedIndex = 0;
                page.comboBoxHospital2.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (equipmentRoom.Department.Floor == 1 && equipmentRoom.Department.Hospital.Id == 2)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 1;
                page.comboBoxHospital2.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (equipmentRoom.Department.Floor == 2 && equipmentRoom.Department.Hospital.Id == 2)
            {
                Id = equipmentRoom.Id.ToString();
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 2;
                page.comboBoxHospital2.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
        }

        private void TransitionAnimation()
        {
            //   throw new NotImplementedException();
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
    }
}
