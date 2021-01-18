using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View;
using MedbayTech.GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel.DTO;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MedbayTech.GraphicEditor
{
    /// <summary>
    /// Interaction logic for AdditionalInformationPatientRoom.xaml
    /// </summary>
    public partial class AdditionalInformationPatientRoom : Window
    {
        private MainPage page;
        private Room room;
        private ObservableCollection<AppointmentRealocation> appointmentRealocations;
        public AdditionalInformationPatientRoom(int roomId, MainPage page)
        {
            InitializeComponent();
            this.page = page;
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/Icons/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            SearchDataBase(roomId);
            this.DataContext = room;
            textBoxOccupiedBeds.Text = (room.BedsCapacity - room.BedsFree).ToString();
            appointmentRealocations = new ObservableCollection<AppointmentRealocation>(SearchDataBaseForAppointmentRealocation(roomId));
            this.dataGridAppointmentRealocation.ItemsSource = appointmentRealocations;
        }
        private List<AppointmentRealocation> SearchDataBaseForAppointmentRealocation(int roomId)
        {
            List<AppointmentRealocation> appointmentRealocations = new List<AppointmentRealocation>();
            HttpClient httpClient = new HttpClient();
            // var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
            var task = httpClient.GetAsync("http://localhost:8083/api/appointmentrealocation/" + roomId)
               .ContinueWith((taskWithResponse) =>
               {
                   var response = taskWithResponse.Result;
                   var jsonString = response.Content.ReadAsStringAsync();
                   jsonString.Wait();
                   appointmentRealocations = new List<AppointmentRealocation>(JsonConvert.DeserializeObject<List<AppointmentRealocation>>(jsonString.Result));
               });
            task.Wait();
            return appointmentRealocations;
        }
        private Room SearchDataBase(int roomId)
        {
            room = new Room();
            HttpClient httpClient = new HttpClient();
            //var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
             var task = httpClient.GetAsync("http://localhost:60304/api/room/" + roomId + "/ByRoomId")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    room = JsonConvert.DeserializeObject<Room>(jsonString.Result);
                });
            task.Wait();
            return room;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom,Encoding.UTF8,"application/json");
            //var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            var result = httpClient.PostAsync("http://localhost:60304/api/room/", content);
            result.Wait();
            MessageBox.Show("Saved to database!");
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonScheduleRenovation(object sender, RoutedEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                ScheduleRenovation scheduleRenovation = new ScheduleRenovation(room);
                scheduleRenovation.ShowDialog();
                appointmentRealocations = new ObservableCollection<AppointmentRealocation>(SearchDataBaseForAppointmentRealocation(room.Id));
                dataGridAppointmentRealocation.ItemsSource = appointmentRealocations;
            }
            else
            {
                MessageBox.Show("You don't have permission for scheduling appointments for renovation!");
            }
        }

        private async Task HttpRequestToAppointmentRealocationController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointmentrealocation/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }

        private async void ButtonCancelRealocation(object sender, RoutedEventArgs e)
        {
            AppointmentRealocation appointmentRealocation = (AppointmentRealocation)dataGridAppointmentRealocation.SelectedItem;
            if (appointmentRealocation == null)
            {
                MessageBox.Show("You didn't select any realocation appointment!");
                return;
            }
            appointmentRealocation.IsCanceled = true;
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.UpdateRealocation, appointmentRealocation = appointmentRealocation };
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            appointmentRealocations.Remove(appointmentRealocation);
        }
    }
}
