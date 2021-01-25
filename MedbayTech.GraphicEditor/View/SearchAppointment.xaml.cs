
using GraphicEditor.ViewModel;
using GraphicEditor.ViewModel.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using GraphicEditor.ViewModel.Enums;
using MedbayTech.GraphicEditor.View.Building1;
using MedbayTech.GraphicEditor.View.Building2;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for SearchAppointment.xaml
    /// </summary>
    public partial class SearchAppointment : Page
    {
        private MainPage page;
        private List<Doctor> doctors;
        private List<Appointment> appointments;
        private List<EquipmentType> hospitalEquipments;

        public SearchAppointment(MainPage page)
        {
            InitializeComponent();
            this.page = page;
            SearchDataBaseForDoctor();
            comboBoxDoctor.ItemsSource = doctors;
            SearchDatabaseForEquipmentType();
            comboBoxEquipment.ItemsSource = hospitalEquipments;
        }

        private List<Doctor> SearchDataBaseForDoctor()
        {
            doctors = new List<Doctor>();
            HttpClient httpClient = new HttpClient();
           // var task = httpClient.GetAsync("http://localhost:53109/api/doctor/" + "empty" + "/All")
            var task = httpClient.GetAsync("http://localhost:8081/api/doctor/" + "empty" + "/All")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    doctors = JsonConvert.DeserializeObject<List<Doctor>>(jsonString.Result);
                });
            task.Wait();
            return doctors;
        }
        
        private List<EquipmentType> SearchDatabaseForEquipmentType()
        {
            hospitalEquipments = new List<EquipmentType>();
            HttpClient httpClient = new HttpClient();
            //var task = httpClient.GetAsync("http://localhost:53109/api/equipmenttype/" + "empty")
            var task = httpClient.GetAsync("http://localhost:60304/api/equipmenttype/" + "empty")
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

        private void SearchDatabaseForAppointment(Doctor doctor, EquipmentType hospitalEquipment, DateTime startTime, DateTime endTime)
        {
            AppointmentFilterDTO appointmentFilterDTO;
            if ((bool)radioButtonDoctor.IsChecked)
            {
                if (hospitalEquipment == null)
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentSearchOrSchedule = AppointmentSearchOrSchedule.ByDoctorPriority, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentController(appointmentFilterDTO);
                }
                else
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.BySpecialistDoctorPriority, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(appointmentFilterDTO);
                }
            }
            else if ((bool)radioButtonInterval.IsChecked)
            {
                if (hospitalEquipment == null)
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.ByTimeIntervalPriority, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(appointmentFilterDTO);
                }
                else
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.BySpecialistTimePriority, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(appointmentFilterDTO);
                }
            }
            else
            {
                if (hospitalEquipment == null)
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentSearchOrSchedule = AppointmentSearchOrSchedule.ByDoctorAndTimeInterval, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentController(appointmentFilterDTO);
                }
                else
                {
                    appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.BySpecialistNoPriority, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(appointmentFilterDTO);
                }
            }

            
        }

        private async void HttpRequestToAppointmentFilterController(AppointmentFilterDTO appointmentFilterDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointmentfilter/", content);
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointmentFilter", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<List<Appointment>>(responseBody);
            if ((bool)radioButtonInterval.IsChecked) appointments = FilterSpecialization(appointments);
            dataGridAppointment.ItemsSource = appointments;
        }

        private List<Appointment> FilterSpecialization(List<Appointment> appointments)
        {
            List<Appointment> appointmentsFilter = new List<Appointment>();
            Doctor doctor = (Doctor)comboBoxDoctor.SelectedItem;
            foreach (Appointment appointment in appointments)
            {
                
                if (appointment.Doctor.Specialization.Id == doctor.Specialization.Id) appointmentsFilter.Add(appointment);
            }
            return appointmentsFilter;
        }

        private async void HttpRequestToAppointmentController(AppointmentFilterDTO appointmentFilterDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            // HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointment", content);
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointment/apointmentsBySearchOrSchedule", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            appointments = JsonConvert.DeserializeObject<List<Appointment>>(responseBody);
            HttpRequestToAppointmentFilterController(new AppointmentFilterDTO { appointmentFilterCriteria = AppointmentFilterCriteria.AddRoomToAppointment, appointments = appointments });
            dataGridAppointment.ItemsSource = appointments;
        }

        private Tuple<DateTime, DateTime> ParseDateAndTime()
        {
            DateTime startDateTime;
            if (!DateTime.TryParseExact(textBoxFrom.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime))
            {
                MessageBox.Show("Start date is not valid!");
                return null;
            }
            DateTime endDateTime;
            if (!DateTime.TryParseExact(textBoxTo.Text, "dd.MM.yyyy - HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime))
            {
                MessageBox.Show("End date is not valid!");
                return null;
            }
            return Tuple.Create(startDateTime, endDateTime);
        }

        private void ButtonSearchForAvailableAppointments(object sender, RoutedEventArgs e)
        {
            if (comboBoxDoctor.SelectedItem == null || textBoxFrom.Text.Equals("") || textBoxTo.Text.Equals(""))
            {
                MessageBox.Show("You didn't select doctor or didn't select time interval!");
                return;
            }
            Tuple<DateTime, DateTime> time = ParseDateAndTime();
            if (time == null) return;
            DateTime beginningTime = time.Item1;
            DateTime endTime = time.Item2;
            Doctor doctor = (Doctor)comboBoxDoctor.SelectedItem;
            EquipmentType hospitalEquipment = (EquipmentType)comboBoxEquipment.SelectedItem;
            dataGridAppointment.ItemsSource = null;
            SearchDatabaseForAppointment(doctor, hospitalEquipment, beginningTime, endTime);
        }

        private void ButtonScheduleExamination(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridAppointment.SelectedItem;
            
            if (appointment == null)
            {
                MessageBox.Show("You didn't select appointment!");
                return;
            }
            ScheduleAppointment scheduleAppointment = new ScheduleAppointment(appointment, page, this);
            page.MainFrame.Content = scheduleAppointment;
        }

        public static string Id;
        private void ButtonShowOnMap(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridAppointment.SelectedItem;
            if (appointment == null)
            {
                MessageBox.Show("Anything selected!");
                return;
            }
            CheckHospital(appointment.Room);
        }

        public void CheckHospital(Room appointmentRoom)
        {
            if (appointmentRoom.Department.Hospital.Id == 2)
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
