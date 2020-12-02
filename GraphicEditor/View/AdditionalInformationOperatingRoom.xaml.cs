using Model.Rooms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
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
    /// Interaction logic for AdditionalInformationOperatingRoom.xaml
    /// </summary>
    public partial class AdditionalInformationOperatingRoom : Window
    {
        private Room room;
        public AdditionalInformationOperatingRoom(int roomId)
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/View/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            searchDataBase(roomId);
            this.DataContext = room;
            
        }
        private Room searchDataBase(int roomId)
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //todo
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            result.Wait();
            MessageBox.Show("Saved to database!");
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
