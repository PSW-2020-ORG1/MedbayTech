using Backend.Medications.Model;
using GraphicEditor.View;
using Model.Rooms;
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
    /// Interaction logic for AdditionalInformationAuxiliaryRoom.xaml
    /// </summary>
    public partial class AdditionalInformationAuxiliaryRoom : Window
    {
        private Room room;
        private List<Medication> medications;
        public AdditionalInformationAuxiliaryRoom(int roomId)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/Icons/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            searchDataBase(roomId);
            this.DataContext = room;
            if (room.RoomType == RoomType.AuxiliaryRoom)
            {
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomEquipment(room.HospitalEquipment);
            }
            else
            {
                searchDataBaseForMedication(room.Id);
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomMedication(medications);
            }
        }
        private Room searchDataBase(int roomId)
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
        private List<Medication> searchDataBaseForMedication(int roomId)
        {
            medications = new List<Medication>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/medication/" + roomId + "/ByRoomId")
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            result.Wait();
            if (medications != null)
            {
                foreach(Medication m in medications)
                {
                    string jsonMedication = JsonConvert.SerializeObject(m);
                    HttpClient httpClientMedication = new HttpClient();
                    content = new StringContent(jsonMedication, Encoding.UTF8, "application/json");
                    result = httpClientMedication.PostAsync("http://localhost:53109/api/medication/", content);
                    result.Wait();
                }
            }
            MessageBox.Show("Saved to database!");
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
