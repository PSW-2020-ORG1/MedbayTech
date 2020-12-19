using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicEditor
{
    /// <summary>
    /// Interaction logic for AdditionalInformationExaminationRoom.xaml
    /// </summary>
    public partial class AdditionalInformationExaminationRoom : Window
    {
        private Room room;
        private Doctor doctor;
        private List<Appointment> appointments;
        public AdditionalInformationExaminationRoom(int roomId)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/Icons/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            room = searchDataBaseForRoom(roomId);
            doctor = searchDataBaseForDoctor(room.Id);
            appointments = searchDataBaseForAppointments(room.Id.ToString());
            this.DataContext = room;
            if(doctor != null)
            {
                textBoxDoctor.Text = doctor.Name + " " + doctor.Surname;
            }
            dataGridAppointments.ItemsSource = appointments;
        }
        private Room searchDataBaseForRoom(int roomId)
        {
            room = new Room();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
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
        private Doctor searchDataBaseForDoctor(int roomId)
        {
            doctor = new Doctor();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/doctor/" + roomId + "/ByExaminationRoom")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    doctor = JsonConvert.DeserializeObject<Doctor>(jsonString.Result);
                });
            task.Wait();
            return doctor;
        }

        private List<Appointment> searchDataBaseForAppointments(string roomId)
        {
            appointments = new List<Appointment>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/appointment/" + roomId + "/ByRoom")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    appointments = JsonConvert.DeserializeObject<List<Appointment>>(jsonString.Result);
                });
            task.Wait();
            return appointments;
        }
        private void SaveDoctorAndRoom(Room room, Doctor doctor)
        {
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            result.Wait();
            string jsonDoctor = JsonConvert.SerializeObject(doctor);
            content = new StringContent(jsonDoctor, Encoding.UTF8, "application/json");
            result = httpClient.PostAsync("http://localhost:53109/api/doctor/", content);
            result.Wait();
            MessageBox.Show("Saved to database!");
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (doctor == null) return;
            doctor.PlaceOfBirth.State = null;
            SaveDoctorAndRoom(room, doctor);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
