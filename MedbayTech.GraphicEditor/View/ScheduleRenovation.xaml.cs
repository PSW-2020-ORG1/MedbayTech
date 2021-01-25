using GraphicEditor.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleRenovation.xaml
    /// </summary>
    public partial class ScheduleRenovation : Window
    {
        public Room room;

        public ScheduleRenovation(Room room)
        {
            InitializeComponent();
            this.room = room;
            textBoxFrom.IsEnabled = false;
            textBoxTo.IsEnabled = false;
            textBoxDescription.IsEnabled = false;
            dockPanelMerging.IsEnabled = false;
            dockPanelSeparating.IsEnabled = false;
            buttonScheduleRenovation.IsEnabled = false;
            SearchForNeighbourRooms();
        }

        private List<Room> SearchForNeighbourRooms()
        {
            List<Room> rooms = new List<Room>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:60304/api/room/" + room.Id + "/ByRoomNumber")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task.Wait();
            dataGridRoom.ItemsSource = rooms;
            return rooms;
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboBoxRenovationType.SelectedIndex == 0)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = false;
                dockPanelSeparating.IsEnabled = false;
                buttonScheduleRenovation.IsEnabled = true;
            }
            else if(comboBoxRenovationType.SelectedIndex == 1)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = true;
                dockPanelSeparating.IsEnabled = false;
                buttonScheduleRenovation.IsEnabled = true;
            }
            else if (comboBoxRenovationType.SelectedIndex == 2)
            {
                textBoxFrom.IsEnabled = true;
                textBoxTo.IsEnabled = true;
                textBoxDescription.IsEnabled = true;
                dockPanelMerging.IsEnabled = false;
                dockPanelSeparating.IsEnabled = true;
                buttonScheduleRenovation.IsEnabled = true;
            }
        }

        private void ButtonScheduleRenovation(object sender, RoutedEventArgs e)
        {
            Tuple<DateTime, DateTime> time = ParseDateAndTime();
            if (time == null) return;
            DateTime beginningTime = time.Item1;
            DateTime endTime = time.Item2;
            if (beginningTime < DateTime.Now || beginningTime >= endTime)
            {
                MessageBox.Show("Entered start or end date is not valid!");
                return;
            }
            if (comboBoxRenovationType.SelectedIndex == 0 && IsUserEnteredAllInformationsForMaintenance())
            {
                ScheduleRenovationListOfAvailableAppointments schedule = new ScheduleRenovationListOfAvailableAppointments(this);
                schedule.ShowDialog();
                return;
            }
            else if (comboBoxRenovationType.SelectedIndex == 1 && IsUserEnteredAllInformationsForMerging())
            {
                ScheduleRenovationListOfAvailableAppointments schedule = new ScheduleRenovationListOfAvailableAppointments(this);
                schedule.ShowDialog();
                return;
            }
            else if (comboBoxRenovationType.SelectedIndex == 2 && IsUserEnteredAllInformationsForSeparating())
            {
                ScheduleRenovationListOfAvailableAppointments schedule = new ScheduleRenovationListOfAvailableAppointments(this);
                schedule.ShowDialog();
                return;
            }
            MessageBox.Show("Some informations are not valid!");
        }

        private bool IsUserEnteredAllInformationsForMaintenance()
        {
            if (textBoxDescription.Text.Trim().Equals("")) return false;
            return true;
        }

        private bool IsUserEnteredAllInformationsForMerging()
        {
            if (textBoxDescription.Text.Trim().Equals("")) return false;
            if (comboBoxRoomType.SelectedItem == null) return false;
            if (textBoxRoomUse.Text.Trim().Equals(" ")) return false;
            if (dataGridRoom.SelectedItem == null) return false;
            return true;
        }

        private bool IsUserEnteredAllInformationsForSeparating()
        {
            if (textBoxDescription.Text.Trim().Equals("")) return false;
            if (comboBoxRoomTypeMergingRoom1.SelectedItem == null) return false;
            if (comboBoxRoomTypeMergingRoom2.SelectedItem == null) return false;
            if (textBoxRoom1Use.Text.Trim().Equals("")) return false;
            if (textBoxRoom2Use.Text.Trim().Equals("")) return false;
            return true;
        }

        private Tuple<DateTime, DateTime> ParseDateAndTime()
        {
            DateTime startDateTime;
            if (!DateTime.TryParseExact(textBoxFrom.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime))
            {
                MessageBox.Show("Start date is not valid!");
                return null;
            }
            DateTime endDateTime;
            if (!DateTime.TryParseExact(textBoxTo.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime))
            {
                MessageBox.Show("End date is not valid!");
                return null;
            }
            return Tuple.Create(startDateTime, endDateTime);
        }
    }
}
