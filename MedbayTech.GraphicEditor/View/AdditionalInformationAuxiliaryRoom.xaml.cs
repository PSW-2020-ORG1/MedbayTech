
using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View;
using MedbayTech.GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel.DTO;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using MedbayTech.Rooms.Domain;
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
    /// Interaction logic for AdditionalInformationAuxiliaryRoom.xaml
    /// </summary>
    public partial class AdditionalInformationAuxiliaryRoom : Window
    {
        private Room room;
        private List<Medication> medications;
        private List<HospitalEquipment> hospitalEquipments;
        private ObservableCollection<AppointmentRealocation> appointmentRealocations;
        public AdditionalInformationAuxiliaryRoom(int roomId)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/Icons/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            SearchDataBase(roomId);
            this.DataContext = room;
            appointmentRealocations = new ObservableCollection<AppointmentRealocation>(SearchDataBaseForAppointmentRealocation(roomId));
            this.dataGridAppointmentRealocation.ItemsSource = appointmentRealocations;
            if (room.RoomType == RoomType.AuxiliaryRoom)
            {
                hospitalEquipments = SearchDataBaseForHospitalEquipment(roomId);
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomEquipment(hospitalEquipments);
            }
            else
            {
                SearchDataBaseForMedication(room.Id);
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomMedication(medications);
            }
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
        private List<HospitalEquipment> SearchDataBaseForHospitalEquipment(int roomId)
        {
            List<HospitalEquipment> hospitalEquipments = new List<HospitalEquipment>();
            HttpClient httpClient = new HttpClient();
            // var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
            var task = httpClient.GetAsync("http://localhost:60304/api/hospitalequipment/getAllHospitalEquipments/" + roomId)
               .ContinueWith((taskWithResponse) =>
               {
                   var response = taskWithResponse.Result;
                   var jsonString = response.Content.ReadAsStringAsync();
                   jsonString.Wait();
                   hospitalEquipments = new List<HospitalEquipment>(JsonConvert.DeserializeObject<List<HospitalEquipment>>(jsonString.Result));
               });
            task.Wait();
            return hospitalEquipments;
        }

        private Room SearchDataBase(int roomId)
        {
            room = new Room();
            HttpClient httpClient = new HttpClient();
           // var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
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
        private List<Medication> SearchDataBaseForMedication(int roomId)
        {
            medications = new List<Medication>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:56764/api/medication/" + roomId + "/ByRoomId")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    medications = JsonConvert.DeserializeObject<List<Medication>>(jsonString.Result);
                });
            task.Wait();
            return medications;
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            //var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            var result = httpClient.PostAsync("http://localhost:60304/api/room/", content);
            result.Wait();
            if (medications != null)
            {
                foreach(Medication m in medications)
                {
                    string jsonMedication = JsonConvert.SerializeObject(m);
                    HttpClient httpClientMedication = new HttpClient();
                    content = new StringContent(jsonMedication, Encoding.UTF8, "application/json");
                    result = httpClientMedication.PostAsync("http://localhost:56764/api/medication/", content);
                    result.Wait();
                }
            }
            MessageBox.Show("Saved to database!");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonScheduleRenovation(object sender, RoutedEventArgs e)
        {
            ScheduleRenovation scheduleRenovation = new ScheduleRenovation(room);
            scheduleRenovation.ShowDialog();
            SearchDataBaseForAppointmentRealocation(room.Id);
        }

        private async void ButtonCancelAppointmentRealocation(object sender, RoutedEventArgs e)
        {
            AppointmentRealocation appointmentRealocation = (AppointmentRealocation)dataGridAppointmentRealocation.SelectedItem;
            if(appointmentRealocation == null)
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
