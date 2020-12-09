using Backend.Utils.DTO;
using GraphicEditor.View.Building1;
using GraphicEditor.View.Building2;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicEditor.View
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
            searchDataBaseForDoctor();
            comboBoxDoctor.ItemsSource = doctors;
            searchDataBaseForHospitalEquipment();
            comboBoxEquipment.ItemsSource = hospitalEquipments;
        }

        private List<Doctor> searchDataBaseForDoctor()
        {
            doctors = new List<Doctor>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/doctor/" + "empty" + "/2")
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

        private List<EquipmentType> searchDataBaseForHospitalEquipment()
        {
            hospitalEquipments = new List<EquipmentType>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/equipmenttype/" + "empty" + "/0")
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

        private void searchDataBaseForAppointment(Doctor doctor, EquipmentType hospitalEquipment, DateTime startTime, DateTime endTime)
        {
            SearchAppointmentsDTO searchAppointmentsDTO;
            if ((bool)radioButtonDoctor.IsChecked)
            {
                if (hospitalEquipment == null)
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 1, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentController(searchAppointmentsDTO);
                }
                else
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 4, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(searchAppointmentsDTO);
                }
            }
            else if ((bool)radioButtonInterval.IsChecked)
            {
                if (hospitalEquipment == null)
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 2, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(searchAppointmentsDTO);
                }
                else
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 5, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(searchAppointmentsDTO);
                }
            }
            else
            {
                if (hospitalEquipment == null)
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 0, DoctorId = doctor.Id, HospitalEquipmentId = -1, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentController(searchAppointmentsDTO);
                }
                else
                {
                    searchAppointmentsDTO = new SearchAppointmentsDTO() { operation = 3, DoctorId = doctor.Id, HospitalEquipmentId = hospitalEquipment.Id, StartInterval = startTime, EndInterval = endTime };
                    HttpRequestToAppointmentFilterController(searchAppointmentsDTO);
                }
            }

            
        }

        private async void HttpRequestToAppointmentFilterController(SearchAppointmentsDTO searchAppointmentsDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(searchAppointmentsDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointmentfilter/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            appointments = new List<Appointment>(JsonConvert.DeserializeObject<List<Appointment>>(responseBody));
            dataGridAppointment.ItemsSource = appointments;
        }

        private async void HttpRequestToAppointmentController(SearchAppointmentsDTO searchAppointmentsDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(searchAppointmentsDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointment/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            appointments = new List<Appointment>(JsonConvert.DeserializeObject<List<Appointment>>(responseBody));
            dataGridAppointment.ItemsSource = appointments;
        }

        private Tuple<DateTime, DateTime> parseDateAndTime()
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

        private void buttonSearchForAvailableAppointments(object sender, RoutedEventArgs e)
        {
            if (comboBoxDoctor.SelectedItem == null || textBoxFrom.Text.Equals("") || textBoxTo.Text.Equals(""))
            {
                MessageBox.Show("You didn't select doctor or didn't select time interval!");
                return;
            }
            Tuple<DateTime, DateTime> time = parseDateAndTime();
            if (time == null) return;
            DateTime beginningTime = time.Item1;
            DateTime endTime = time.Item2;
            Doctor doctor = (Doctor)comboBoxDoctor.SelectedItem;
            EquipmentType hospitalEquipment = (EquipmentType)comboBoxEquipment.SelectedItem;
            dataGridAppointment.ItemsSource = null;
            searchDataBaseForAppointment(doctor, hospitalEquipment, beginningTime, endTime);
        }

        private void buttonScheduleExamination(object sender, RoutedEventArgs e)
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
        private void buttonShowOnMap(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridAppointment.SelectedItem;
            if (appointment == null)
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }
            Room room = appointment.Room;
            if (room == null)
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }
            if (room.Department.Floor == 0 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FloorPlan(page);
                page.comboBoxH1.SelectedIndex = 0;
                page.comboBoxHospital1.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1FirstFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 1;
                page.comboBoxHospital1.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 1)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building1SecondFloorPlan(page);
                page.comboBoxH1.SelectedIndex = 2;
                page.comboBoxHospital1.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            if (room.Department.Floor == 0 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FloorPlan(page);
                page.comboBoxH2.SelectedIndex = 0;
                page.comboBoxHospital2.SelectedIndex = 0;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 1 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2FirstFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 1;
                page.comboBoxHospital2.SelectedIndex = 1;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
            else if (room.Department.Floor == 2 && room.Department.Hospital.Id == 2)
            {
                Id = room.Id.ToString();
                page.MainFrame.Content = new Building2SecondFloorPlan(page);
                page.comboBoxH2.SelectedIndex = 2;
                page.comboBoxHospital2.SelectedIndex = 2;

                page.SetActiveUserControl(page.legenda);
                TransitionAnimation();
            }
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
