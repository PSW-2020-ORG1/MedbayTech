using GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel;
using MedbayTech.GraphicEditor.ViewModel.DTO;
using MedbayTech.GraphicEditor.ViewModel.Enums;
using MedbayTech.Rooms.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleRenovationListOfAvailableAppointments.xaml
    /// </summary>
    public partial class ScheduleRenovationListOfAvailableAppointments : Window
    {
        private ScheduleRenovation scheduleRenovation;
        private List<AppointmentRealocation> appointmentRealocations;

        public ScheduleRenovationListOfAvailableAppointments(ScheduleRenovation scheduleRenovation)
        {
            InitializeComponent();
            this.scheduleRenovation = scheduleRenovation;
            SearchForAvailableAppointments();
        }

        private async void SearchForAvailableAppointments()
        {
            Tuple<DateTime, DateTime> time = ParseDateAndTime();
            DateTime beginningTime = time.Item1;
            DateTime endTime = time.Item2;
            AppointmentRealocationDTO appointmentRealocationDTO;
            if (scheduleRenovation.comboBoxRenovationType.SelectedIndex == 1)
            {
                Room room = (Room)scheduleRenovation.dataGridRoom.SelectedItem;
                appointmentRealocationDTO = new AppointmentRealocationDTO() { FromRoomId = scheduleRenovation.room.Id, ToRoomId = room.Id, appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.AlternativeAppointments, StartInterval = beginningTime, EndInterval = endTime };
            }
            else appointmentRealocationDTO = new AppointmentRealocationDTO() { RoomId = scheduleRenovation.room.Id, appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ByRoomAndDateTime, StartInterval = beginningTime, EndInterval = endTime };

            await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
        }

        private Tuple<DateTime, DateTime> ParseDateAndTime()
        {
            DateTime startDateTime;
            if (!DateTime.TryParseExact(scheduleRenovation.textBoxFrom.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime))
            {
                MessageBox.Show("Start date is not valid!");
                return null;
            }
            DateTime endDateTime;
            if (!DateTime.TryParseExact(scheduleRenovation.textBoxTo.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime))
            {
                MessageBox.Show("End date is not valid!");
                return null;
            }
            return Tuple.Create(startDateTime, endDateTime);
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void ButtonSchedule(object sender, RoutedEventArgs e)
        {
            AppointmentRealocation appointmentRealocation = (AppointmentRealocation)dataGridAppointment.SelectedItem;
            if (appointmentRealocation == null)
            {
                MessageBox.Show("You didn't select any appointment for renovation!");
                return;
            }
            if (scheduleRenovation.comboBoxRenovationType.SelectedIndex == 0)
            {
                appointmentRealocation = AppointmentRealocationForMaintenance(appointmentRealocation);
                AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocation = appointmentRealocation, appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation };
                await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            }
            else if (scheduleRenovation.comboBoxRenovationType.SelectedIndex == 1)
            {
                appointmentRealocation = AppointmentRealocationForMerging(appointmentRealocation);
                AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocation = appointmentRealocation, appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation };
                await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
                Room room = (Room)scheduleRenovation.dataGridRoom.SelectedItem;
                appointmentRealocationDTO.appointmentRealocation.RoomId = room.Id;
                await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            }
            else
            {
                appointmentRealocation = AppointmentRealocationForSeparating(appointmentRealocation);
                AppointmentRealocationDTO appointmentRealocationDTO = new AppointmentRealocationDTO() { appointmentRealocation = appointmentRealocation, appointmentRealocationSearchOrSchedule = AppointmentRealocationSearchOrSchedule.ScheduleRealocationOrRenovation };
                await HttpRequestToAppointmentRealocationController(appointmentRealocationDTO);
            }
            MessageBox.Show("Renovation is successfuly scheduled!");
            this.Close();
        }

        private AppointmentRealocation AppointmentRealocationForMaintenance(AppointmentRealocation appointmentRealocation)
        {
            appointmentRealocation.AppointmentRealocationType = AppointmentRealocationType.RenovationMaintenance;
            appointmentRealocation.Description = scheduleRenovation.textBoxDescription.Text.Trim();
            appointmentRealocation.RoomOneType = scheduleRenovation.room.RoomType;
            appointmentRealocation.RoomOneUse = scheduleRenovation.room.RoomUse;
            appointmentRealocation.RoomOneLabel = scheduleRenovation.room.RoomLabel;
            appointmentRealocation.RoomTwoType = scheduleRenovation.room.RoomType;
            appointmentRealocation.RoomTwoUse = scheduleRenovation.room.RoomUse;
            appointmentRealocation.RoomTwoLabel = scheduleRenovation.room.RoomLabel;
            return appointmentRealocation;
        }

        private AppointmentRealocation AppointmentRealocationForMerging(AppointmentRealocation appointmentRealocation)
        {
            appointmentRealocation.AppointmentRealocationType = AppointmentRealocationType.RenovationMerging;
            appointmentRealocation.Description = scheduleRenovation.textBoxDescription.Text.Trim();
            appointmentRealocation.RoomOneType = (RoomType)scheduleRenovation.comboBoxRoomType.SelectedIndex;
            appointmentRealocation.RoomOneUse = scheduleRenovation.textBoxRoomUse.Text.Trim();
            appointmentRealocation.RoomOneLabel = scheduleRenovation.room.RoomLabel;
            appointmentRealocation.RoomTwoType = ((Room)scheduleRenovation.dataGridRoom.SelectedItem).RoomType;
            appointmentRealocation.RoomTwoUse = ((Room)scheduleRenovation.dataGridRoom.SelectedItem).RoomUse;
            appointmentRealocation.RoomTwoLabel = ((Room)scheduleRenovation.dataGridRoom.SelectedItem).RoomLabel;
            return appointmentRealocation;
        }

        private AppointmentRealocation AppointmentRealocationForSeparating(AppointmentRealocation appointmentRealocation)
        {
            appointmentRealocation.AppointmentRealocationType = AppointmentRealocationType.RenovationSeparating;
            appointmentRealocation.Description = scheduleRenovation.textBoxDescription.Text.Trim();
            appointmentRealocation.RoomOneType = (RoomType)scheduleRenovation.comboBoxRoomTypeMergingRoom1.SelectedIndex;
            appointmentRealocation.RoomOneUse = scheduleRenovation.textBoxRoom1Use.Text.Trim();
            appointmentRealocation.RoomOneLabel = scheduleRenovation.room.RoomLabel + ".1";
            appointmentRealocation.RoomTwoType = (RoomType)scheduleRenovation.comboBoxRoomTypeMergingRoom2.SelectedIndex;
            appointmentRealocation.RoomTwoUse = scheduleRenovation.textBoxRoom2Use.Text.Trim();
            appointmentRealocation.RoomTwoLabel = scheduleRenovation.room.RoomLabel + ".2";
            return appointmentRealocation;
        }

        private async Task HttpRequestToAppointmentRealocationController(AppointmentRealocationDTO appointmentRealocationDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentRealocationDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointmentrealocation/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ByRoomAndDateTime)
            {
                appointmentRealocations = new List<AppointmentRealocation>(JsonConvert.DeserializeObject<List<AppointmentRealocation>>(responseBody));
                dataGridAppointment.ItemsSource = appointmentRealocations;
            }
            else if (appointmentRealocationDTO.appointmentRealocationSearchOrSchedule == AppointmentRealocationSearchOrSchedule.ByTwoRooms)
            {
                appointmentRealocations = new List<AppointmentRealocation>(JsonConvert.DeserializeObject<List<AppointmentRealocation>>(responseBody));
                dataGridAppointment.ItemsSource = appointmentRealocations;
            }
        }
    }
}
