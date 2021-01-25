﻿using GraphicEditor.ViewModel;
using GraphicEditor.ViewModel.DTO;
using GraphicEditor.ViewModel.Enums;
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
    /// Interaction logic for AdditionalInformationOperatingRoom.xaml
    /// </summary>
    public partial class AdditionalInformationOperatingRoom : Window
    {
        private MainPage page;
        private Room room;
        private ObservableCollection<Appointment> appointments;
        private ObservableCollection<AppointmentForRoomManipulation> appointmentRealocations;
        public AdditionalInformationOperatingRoom(int roomId, MainPage page)
        {
            InitializeComponent();
            page = this.page;
            string path = Directory.GetCurrentDirectory();
            string new_path = path.Replace('\\', '/');
            string logo = new_path + "/Icons/WhiteLogo.png";
            imageLogo.Source = new BitmapImage(new Uri(@logo, UriKind.Absolute));
            SearchDataBase(roomId);
            this.DataContext = room;
            appointments = new ObservableCollection<Appointment>(SearchDataBaseForAppointments(roomId.ToString()));
            this.dataGridAppointments.ItemsSource = appointments;
            appointmentRealocations = new ObservableCollection<AppointmentForRoomManipulation>(SearchDataBaseForAppointmentRealocation(roomId));
            this.dataGridAppointmentRealocation.ItemsSource = appointmentRealocations;
            
        }
        private List<AppointmentForRoomManipulation> SearchDataBaseForAppointmentRealocation(int roomId)
        {
            List<AppointmentForRoomManipulation> appointmentRealocations = new List<AppointmentForRoomManipulation>();
            HttpClient httpClient = new HttpClient();
            // var task = httpClient.GetAsync("http://localhost:53109/api/room/" + roomId + "/ByRoomId")
            var task = httpClient.GetAsync("http://localhost:8083/api/appointmentforroommanipulation/" + roomId)
               .ContinueWith((taskWithResponse) =>
               {
                   var response = taskWithResponse.Result;
                   var jsonString = response.Content.ReadAsStringAsync();
                   jsonString.Wait();
                   appointmentRealocations = new List<AppointmentForRoomManipulation>(JsonConvert.DeserializeObject<List<AppointmentForRoomManipulation>>(jsonString.Result));
               });
            task.Wait();
            return appointmentRealocations;
        }

        private List<Appointment> SearchDataBaseForAppointments(string roomId)
        {
            List<Appointment> appointments = new List<Appointment>();
            HttpClient httpClient = new HttpClient();
            //var task = httpClient.GetAsync("http://localhost:53109/api/appointment/" + roomId + "/ByRoom")
            var task = httpClient.GetAsync("http://localhost:8083/api/appointment/" + roomId + "/ByRoom")
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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //todo
            string jsonRoom = JsonConvert.SerializeObject(room);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(jsonRoom, Encoding.UTF8, "application/json");
            //var result = httpClient.PostAsync("http://localhost:53109/api/room/", content);
            var result = httpClient.PostAsync("http://localhost:60304/api/room/", content);
            result.Wait();
            MessageBox.Show("Saved to database!");
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async Task HttpRequestToAppointmentRealocationController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointmentforroommanipulation/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        }

        private async void ButtonCancelRealocation(object sender, RoutedEventArgs e)
        {
            AppointmentForRoomManipulation appointmentRealocation = (AppointmentForRoomManipulation)dataGridAppointmentRealocation.SelectedItem;
            if (appointmentRealocation == null)
            {
                MessageBox.Show("You didn't select any realocation appointment!");
                return;
            }
            appointmentRealocation.IsCanceled = true;
            AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.UpdateRealocation, appointmentForRoomManipulation = appointmentRealocation };
            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            appointmentRealocations.Remove(appointmentRealocation);
        }

        private async void SaveAndUpdateDataBase(AppointmentFilterDTO appointmentFilterDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointment/apointmentsBySearchOrSchedule", content);
            response.EnsureSuccessStatusCode();
        }

        private void ButtonCancelOperation(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridAppointments.SelectedItem;
            if (appointment == null)
            {
                MessageBox.Show("You didn't select any operation appointment!");
                return;
            }
            appointment.CanceledByPatient = true;
            AppointmentFilterDTO appointmentFilterDTO = new AppointmentFilterDTO() { appointment = appointment, appointmentSearchOrSchedule = AppointmentSearchOrSchedule.UpdateAppointment };
            SaveAndUpdateDataBase(appointmentFilterDTO);
            appointments.Remove(appointment);
        }

        private void ButtonScheduleRenovation(object sender, RoutedEventArgs e)
        {
            if (page.getRestriction() == 0)
            {
                ScheduleRenovation scheduleRenovation = new ScheduleRenovation(room);
                scheduleRenovation.ShowDialog();
                appointmentRealocations = new ObservableCollection<AppointmentForRoomManipulation>(SearchDataBaseForAppointmentRealocation(room.Id));
                dataGridAppointmentRealocation.ItemsSource = appointmentRealocations;
            }
            else
            {
                MessageBox.Show("You don't have permission for scheduling appointments for renovation!");
            }
        }
    }
}
