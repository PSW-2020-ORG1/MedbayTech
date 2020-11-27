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
    /// Interaction logic for SearchResultsForRooms.xaml
    /// </summary>
    public partial class SearchResultsForRooms : Page
    {
        public SearchResultsForRooms()
        {
            InitializeComponent();
        }
        MainPage page;
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
            MessageBox.Show("Nema rezultata za unetu pretragu!");
        }

        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            Room room = (Room)dataGridRoom.SelectedItem;
            MessageBox.Show("Treba da se implementira!");
        }
    }
}
