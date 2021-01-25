using GraphicEditor.ViewModel;
using MedbayTech.Rooms.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for MostViewedInventory.xaml
    /// </summary>
    public partial class MostViewedInventory : Window
    {
        private List<Medication> medications;
        private List<HospitalEquipment> hospitalEquipments;

        public MostViewedInventory(Room room)
        {
            InitializeComponent();
            this.DataContext = room;
            if (room.RoomType == RoomType.StorageRoom)
            {
                SearchDataBaseForMedication(room.Id);
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomMedication(medications);
            }
            else
            {
                hospitalEquipments = SearchDataBaseForHospitalEquipment(room.Id);
                frameDataGrid.Content = new AdditionalInformationAuxiliaryRoomEquipment(hospitalEquipments);
            }
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

        private List<HospitalEquipment> SearchDataBaseForHospitalEquipment(int roomId)
        {
            List<HospitalEquipment> hospitalEquipments = new List<HospitalEquipment>();
            HttpClient httpClient = new HttpClient();
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

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
