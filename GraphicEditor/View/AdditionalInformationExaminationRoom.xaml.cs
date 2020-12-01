using Model.Rooms;
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
        public AdditionalInformationExaminationRoom(int roomId)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/View/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            room = searchDataBaseForRoom(roomId);
            doctor = searchDataBaseForDoctor(room.Id);
            this.DataContext = room;
            if(doctor != null)
            {
                textBoxDoctor.Text = doctor.Name + " " + doctor.Surname;
            }
        }
        private Room searchDataBaseForRoom(int roomId)
        {
            room = new Room();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/1")
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
            var task = httpClient.GetAsync("http://localhost:53109/api/doctor/" + roomId + "/1")
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
        private void Save_Click(object sender, RoutedEventArgs e)
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
