using GraphicEditor.ViewModel;
using GraphicEditor.ViewModel.DTO;
using GraphicEditor.ViewModel.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleAppointment.xaml
    /// </summary>
    public partial class ScheduleAppointment : Page
    {
        private MainPage page;
        private SearchAppointment searchAppointment;
        private List<Patient> patients;
        private Appointment appointment;
        public ScheduleAppointment(Appointment appointment, MainPage page, SearchAppointment searchAppointment)
        {
            InitializeComponent();
            this.page = page;
            this.searchAppointment = searchAppointment;
            this.appointment = appointment;
            searchDataBaseForPatients();
        }

        private List<Patient> searchDataBaseForPatients()
        {
            patients = new List<Patient>();
            HttpClient httpClient = new HttpClient();
            // var task = httpClient.GetAsync("http://localhost:53109/api/patient/" + "empty")
            var task = httpClient.GetAsync("http://localhost:8081/api/user/getAllPatients")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString.Result);
                });
            task.Wait();
            dataGridPatients.ItemsSource = patients;
            return patients;
        }

        private MedicalRecord searchDataBaseForMedicalRecord(string patientId)
        {
            MedicalRecord medicalRecord = new MedicalRecord();
            HttpClient httpClient = new HttpClient();
            //var task = httpClient.GetAsync("http://localhost:53109/api/medicalrecord/" + patientId)
            var task = httpClient.GetAsync("http://localhost:50577/api/medicalrecord/" + patientId)
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    medicalRecord = JsonConvert.DeserializeObject<MedicalRecord>(jsonString.Result);
                });
            task.Wait();
            return medicalRecord;
        }

        private async void SaveToDataBase()
        {
            AppointmentFilterDTO appointmentFilterDTO = new AppointmentFilterDTO() {appointmentSearchOrSchedule = AppointmentSearchOrSchedule.ScheduleAppointment, appointment = this.appointment };
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("http://localhost:53109/api/appointment/", content);
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointment/apointmentsBySearchOrSchedule", content);
            response.EnsureSuccessStatusCode();
        }

        private void buttonClose(object sender, RoutedEventArgs e)
        {
            page.MainFrame.Content = searchAppointment;
        }

        private void buttonScheduleAppointment(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)dataGridPatients.SelectedItem;
            if(patient == null)
            {
                MessageBox.Show("You didn't select patient!");
                return;
            }
           // MedicalRecord medicalRecord = searchDataBaseForMedicalRecord(patient.Id);
            //appointment.MedicalRecord.Id = medicalRecord.Id;
            Console.WriteLine("pat" + patient.ChosenDoctor.Id);
            //appointment.Doctor = patient.ChosenDoctor;
            appointment.DoctorId = appointment.Doctor.Id;
            SaveToDataBase();
            MessageBox.Show("Appointment is scheduled!");
            searchAppointment.dataGridAppointment.ItemsSource = null;
            page.MainFrame.Content = searchAppointment;
        }
    }
}
