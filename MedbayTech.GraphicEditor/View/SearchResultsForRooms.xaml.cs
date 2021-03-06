
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View.Building1;
using MedbayTech.GraphicEditor.View.Building2;

namespace MedbayTech.GraphicEditor
{
    /// <summary>
    /// Interaction logic for SearchResultsForRooms.xaml
    /// </summary>
    public partial class SearchResultsForRooms : Page
    {
        public SearchResultsForRooms()
        {
            InitializeComponent();
        }
        MainPage page;
        public SearchResultsForRooms(MainPage mainPage)
        {
            InitializeComponent();
            page = mainPage;
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
        public SearchResultsForRooms(MainPage mainPage, string textBoxSearch)
        {
            InitializeComponent();
            page = mainPage;
            searchDataBase(textBoxSearch);
        }
        private void searchDataBase(string textBoxSearch)
        {
            List<Room> rooms = new List<Room>();
            if(textBoxSearch.Trim().Equals(""))
            {
                dataGridRoom.ItemsSource = rooms;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
            //var task = httpClient.GetAsync("http://localhost:53109/api/room/" + textBoxSearch + "/ByRoomLabelorRoomUse")
            var task = httpClient.GetAsync("http://localhost:60304/api/room/" + textBoxSearch + "/ByRoomLabelorRoomUse")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task.Wait();
            dataGridRoom.ItemsSource = rooms;
            if(rooms.Count == 0) MessageBox.Show("No results found!");
        }
        public static string Id;
        private void ButtonShowOnMap(object sender, RoutedEventArgs e)
        {
            Room room = (Room)dataGridRoom.SelectedItem;
            if (room == null)
            {
                MessageBox.Show("Anything selected!");
                return;
            }
            CheckHospital(room);
        }

        public void CheckHospital(Room room)
        {
            if (room.Department.Hospital.Id == 2)
            {
                CheckFloorForFirstHospital(room);
            }
            else
            {
                CheckFloorForSecondHospital(room);
            }
        }

        private void CheckFloorForFirstHospital(Room room)
        {
            if (room.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building1GroundFloorPlan(page);
            }
            else if (room.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
            }
            SelectComboBoxesForFirstHospital(room);
        }

        private void CheckFloorForSecondHospital(Room room)
        {
            if (room.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building2GroundFloorPlan(page);

            }
            else if (room.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building2FirstFloorPlan(page);

            }
            else
            {
                page.MainFrame.Content = new Building2SecondFloorPlan(page);

            }
            SelectComboBoxesForSecondHospital(room);
        }
        private void SelectComboBoxesForFirstHospital(Room room)
        {
            Id = room.Id.ToString();
            page.comboBoxH1.SelectedIndex = room.Department.Floor;
            page.comboBoxHospital1.SelectedIndex = room.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
        private void SelectComboBoxesForSecondHospital(Room room)
        {
            Id = room.Id.ToString();
            page.comboBoxH2.SelectedIndex = room.Department.Floor;
            page.comboBoxHospital2.SelectedIndex = room.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
    }
}
