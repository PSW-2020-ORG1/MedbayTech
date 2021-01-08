using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel.DTO;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleEquipmentRealocationIfRoomIsntEmpty.xaml
    /// </summary>
    public partial class ScheduleEquipmentRealocationIfRoomIsntEmpty : Page
    {
        private MainPage page;
        private List<AppointmentRealocation> appointmentRealocations;
        private ScheduleEquipmentRealocation back_page;
        private HospitalEquipment hospitalEquipment;

        private int FromRoomId;
        private int ToRoomId;
        private int EquipmentTypeId;
        private DateTime DateTime;

        public ScheduleEquipmentRealocationIfRoomIsntEmpty(MainPage page, ScheduleEquipmentRealocation scheduleEquipmentRealocation, int fromRoomId, int toRoomId, int equipmentTypeId, DateTime dateTime)
        {
            InitializeComponent();
            this.page = page;
            FromRoomId = fromRoomId;
            ToRoomId = toRoomId;
            EquipmentTypeId = equipmentTypeId;
            DateTime = dateTime;
            back_page = scheduleEquipmentRealocation;
            SearchDataBaseForSuggestions();
        }

        private async void SearchDataBaseForSuggestions()
        {
            await GetHospitalEquipmentId(EquipmentTypeId);
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO()
            {
                appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.AlternativeAppointments,
                FromRoomId = FromRoomId,
                ToRoomId = ToRoomId,
                StartInterval = DateTime,
                HospitalEquipmentId = hospitalEquipment.Id 
            };
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
        }

        private async Task GetHospitalEquipmentId(int equipmentTypeId)
        {
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO()
            { 
                RoomId = FromRoomId, 
                EquipmentTypeId = EquipmentTypeId
            };
            await HttpRequestToHospitalEquipmentController(appointmentRealocationDTO);
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

        private async Task HttpRequestToAppointmentRealocationController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointmentrealocation/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            if(appointmentRealocationDTO.appointmentRealocationSearchOrSchedule != AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation)
            {
                appointmentRealocations = new List<AppointmentRealocation>(JsonConvert.DeserializeObject<List<AppointmentRealocation>>(responseBody));
                dataGridAppointments.ItemsSource = appointmentRealocations;
            }
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            page.MainFrame.Content = back_page;
        }

        private async void ButtonScheduleAppointment(object sender, RoutedEventArgs e)
        {
            AppointmentRealocation appointmentRealocation = (AppointmentRealocation)dataGridAppointments.SelectedItem;
            if (appointmentRealocation == null)
            {
                MessageBox.Show("You didn't select appointment for realocation!");
                return;
            }
            appointmentRealocation.RoomId = FromRoomId;
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO()
            {
                appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation,
                appointmentRealocation = appointmentRealocation
            };
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            appointmentRealocation.RoomId = ToRoomId;
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            MessageBox.Show("Appointment for realocation is succesfully scheduled!");
            page.MainFrame.Content = new ScheduleEquipmentRealocation(page);
        }
    }
}
