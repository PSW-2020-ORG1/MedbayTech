
using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.View.Building1;
using MedbayTech.GraphicEditor.View.Building2;
using MedbayTech.GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel.DTO;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleEquipmentRealocation.xaml
    /// </summary>
    public partial class ScheduleEquipmentRealocation : Page
    {
        public static string Id;
        private MainPage page;
        private bool roomAvailability;
        private HospitalEquipment hospitalEquipment;
        private List<EquipmentType> hospitalEquipments;

        public ScheduleEquipmentRealocation(MainPage page)
        {
            InitializeComponent();
            this.page = page;
            SearchDataBaseForHospitalEquipment();
            comboBoxEquipment.ItemsSource = hospitalEquipments;
        }

        private void SearchDataBase(string textBoxSearch)
        {
            List<Room> rooms = new List<Room>();
            if (textBoxSearch.Trim().Equals(""))
            {
                dataGridTo.ItemsSource = rooms;
                MessageBox.Show("No results found!");
                return;
            }
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/room/" + textBoxSearch + "/ByRoomLabelorRoomUse")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task.Wait();
            dataGridTo.ItemsSource = rooms;
            if (rooms.Count == 0) MessageBox.Show("No results found!");
        }

        private List<EquipmentType> SearchDataBaseForHospitalEquipment()
        {
            hospitalEquipments = new List<EquipmentType>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/equipmenttype/" + "empty")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    hospitalEquipments = JsonConvert.DeserializeObject<List<EquipmentType>>(jsonString.Result);
                });
            task.Wait();
            return hospitalEquipments;
        }

        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            SearchDataBase(textBoxSearch.Text);
        }

        private async void ButtonScheduleRealocation(object sender, RoutedEventArgs e)
        {
            Room fromRoom = (Room)dataGridFrom.SelectedItem;
            Room toRoom = (Room)dataGridTo.SelectedItem;
            EquipmentType equipmentType = (EquipmentType)comboBoxEquipment.SelectedItem;
            if(fromRoom == null || toRoom == null)
            {
                MessageBox.Show("You didn't select initial room or destination room!");
                return;
            }
            if(fromRoom.Id == toRoom.Id)
            {
                MessageBox.Show("You selected the same rooms!");
                return;
            }
            DateTime dateTime;
            if (!DateTime.TryParseExact(textBoxFrom.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                MessageBox.Show("Date and time are not valid!");
                return;
            }
            if(dateTime < DateTime.Now)
            {
                MessageBox.Show("Date and time are not valid!");
                return;
            }
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.CheckIsRoomAvailable, RoomId = fromRoom.Id, StartInterval = dateTime};
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            if(!roomAvailability)
            {
                ShowOnMap(fromRoom);
                MessageBox.Show("[FROM] Room with label " + fromRoom.RoomLabel + " and ID=" + fromRoom.Id + " isn't available at selected time!\nProgram will try to calculate best options for you...");
                await HttpRequestToHospitalEquipmentController(appointmentRealocationDTO);
                page.MainFrame.Content = new ScheduleEquipmentRealocationIfRoomIsntEmpty(page, this, fromRoom.Id,toRoom.Id,equipmentType.Id, dateTime);
                return;
            }
            appointmentRealocationDTO.RoomId = toRoom.Id;
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            if (!roomAvailability)
            {
                ShowOnMap(toRoom);
                MessageBox.Show("[TO] Room with label " + toRoom.RoomLabel + " and ID=" + toRoom.Id + " isn't available at selected time!\nProgram will try to calculate best options for you...");
                await HttpRequestToHospitalEquipmentController(appointmentRealocationDTO);
                page.MainFrame.Content = new ScheduleEquipmentRealocationIfRoomIsntEmpty(page, this, fromRoom.Id, toRoom.Id, equipmentType.Id,dateTime);
                return;
            }
            appointmentRealocationDTO.appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation;
            appointmentRealocationDTO.RoomId = fromRoom.Id;
            appointmentRealocationDTO.EquipmentTypeId = equipmentType.Id;
            await HttpRequestToHospitalEquipmentController(appointmentRealocationDTO);
            appointmentRealocationDTO.appointmentRealocation = CreateRealocation(fromRoom.Id, dateTime,hospitalEquipment.Id);
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            appointmentRealocationDTO.appointmentRealocation = CreateRealocation(toRoom.Id, dateTime,hospitalEquipment.Id);
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            MessageBox.Show("Appointment for realocation is succesfully scheduled!");
        }

        private AppointmentRealocation CreateRealocation(int roomId, DateTime dateTime, int hospitalEquipmentId)
        {
            return new AppointmentRealocation()
            {
                Start = dateTime,
                End = dateTime.AddMinutes(30),
                Deleted = false,
                Finished = false,
                RoomId = roomId,
                HospitalEquipmentId = hospitalEquipmentId
            };
        }

        private async Task HttpRequestToAppointmentRealocationController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointmentrealocation/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            if(appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.CheckIsRoomAvailable)
            {
                bool isRoomAvailable = (JsonConvert.DeserializeObject<bool>(responseBody));
                roomAvailability = isRoomAvailable;
            }
        }

        private async Task HttpRequestToHospitalEquipmentController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/hospitalequipment/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            hospitalEquipment = (JsonConvert.DeserializeObject<HospitalEquipment>(responseBody));
        }

        private void ComboBoxEquipmentChanged(object sender, SelectionChangedEventArgs e)
        {
            EquipmentType equipmentType = (EquipmentType)comboBoxEquipment.SelectedItem;
            List<Room> rooms = new List<Room>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/room/" + equipmentType.Id + "/ByEquipment")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(jsonString.Result);
                });
            task.Wait();
            dataGridFrom.ItemsSource = rooms;
        }

        private void ShowOnMap(Room room)
        {
            CheckHospital(room);
        }

        public void CheckHospital(Room appointmentRoom)
        {
            if (appointmentRoom.Department.Hospital.Id == 1)
            {
                CheckFloorForFirstHospital(appointmentRoom);
            }
            else
            {
                CheckFloorForSecondHospital(appointmentRoom);
            }
        }

        private void CheckFloorForFirstHospital(Room appointmentRoom)
        {
            if (appointmentRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building1GroundFloorPlan(page);
            }
            else if (appointmentRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
            }
            SelectComboBoxesForFirstHospital(appointmentRoom);

        }

        private void CheckFloorForSecondHospital(Room appointmentRoom)
        {
            if (appointmentRoom.Department.Floor == 0)
            {
                page.MainFrame.Content = new Building2GroundFloorPlan(page);
            }
            else if (appointmentRoom.Department.Floor == 1)
            {
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
            }
            else
            {
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
            }
            SelectComboBoxesForSecondHospital(appointmentRoom);
        }

        private void SelectComboBoxesForFirstHospital(Room appointmentRoom)
        {
            Id = appointmentRoom.Id.ToString();
            page.comboBoxH1.SelectedIndex = appointmentRoom.Department.Floor;
            page.comboBoxHospital1.SelectedIndex = appointmentRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
        }
        private void SelectComboBoxesForSecondHospital(Room appointmentRoom)
        {
            Id = appointmentRoom.Id.ToString();
            page.comboBoxH2.SelectedIndex = appointmentRoom.Department.Floor;
            page.comboBoxHospital2.SelectedIndex = appointmentRoom.Department.Floor;
            page.SetActiveUserControl(page.legenda);
            TransitionAnimation();
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
    }
}
