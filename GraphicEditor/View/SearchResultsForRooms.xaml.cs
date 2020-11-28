using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicEditor
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
            List<Room> rooms = Services.getService().roomService.GetRoomsByRoomLabel(textBoxSearch.ToLower().Trim());
            if(rooms.Count != 0)
            {
                dataGridRoom.ItemsSource = rooms;
                return;
            }
            rooms = Services.getService().roomService.GetRoomsByRoomUse(textBoxSearch.ToLower().Trim());
            if(rooms.Count !=0)
            {
                dataGridRoom.ItemsSource = rooms;
                return;
            }
            MessageBox.Show("No results found!");
        }
        public static string Id;
        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            
            Room room = (Room)dataGridRoom.SelectedItem;
            //MessageBox.Show("To be implemented!");
            if(room.Department.Floor == 0 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FloorPlan(page);
                page.comboBoxH1.SelectedIndex = 0;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 1;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 2;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            if (room.Department.Floor == 0 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FloorPlan(page);
                page.comboBoxH2.SelectedIndex = 0;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 1;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 2;
                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }

        }
    }
}
