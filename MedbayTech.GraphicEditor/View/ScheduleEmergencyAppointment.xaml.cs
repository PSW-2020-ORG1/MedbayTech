using GraphicEditor.ViewModel;
using GraphicEditor.ViewModel.DTO;
using GraphicEditor.ViewModel.Enums;
using MedbayTech.Common.Domain.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedbayTech.GraphicEditor.View
{
    /// <summary>
    /// Interaction logic for ScheduleEmergencyAppointment.xaml
    /// </summary>
    public partial class ScheduleEmergencyAppointment : Page
    {
        private MainPage page;
        private static int hourInterval = 3;
        private List<Doctor> doctors;
        private List<Patient> patients;
        private List<EquipmentType> hospitalEquipments;
        private List<Appointment> appointments;
        private Tuple<List<Appointment>, List<int>> tuplePostPoneTime;

        public ScheduleEmergencyAppointment(MainPage page)
        {
            InitializeComponent();
            this.page = page;
            SearchDataBaseForDoctor();
            comboBoxDoctor.ItemsSource = doctors;
            SearchDataBaseForPatients();
            comboBoxPatient.ItemsSource = patients;
            SearchDataBaseForHospitalEquipment();
            comboBoxEquipment.ItemsSource = hospitalEquipments;
        }

        private void ButtonFindAppointments(object sender, RoutedEventArgs e)
        {
            if (comboBoxDoctor.SelectedIndex == -1 || comboBoxPatient.SelectedIndex == -1)
            {
                MessageBox.Show("You didn't select doctor or patient!");
                return;
            }
            Doctor doctor = (Doctor)comboBoxDoctor.SelectedItem;
            Patient patient = (Patient)comboBoxPatient.SelectedItem;
            EquipmentType equipmentType = (EquipmentType)comboBoxEquipment.SelectedItem;
            AppointmentFilterDTO appointmentFilterDTO;
            if (equipmentType == null) appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.EmergencyAppointment, DoctorId = doctor.Id, StartInterval = DateTime.Now, EndInterval = DateTime.Now.AddHours(hourInterval), SpecializationId = doctor.SpecializationId, HospitalEquipmentId = -1 };
            else appointmentFilterDTO = new AppointmentFilterDTO() { appointmentFilterCriteria = AppointmentFilterCriteria.EmergencyAppointment, DoctorId = doctor.Id, StartInterval = DateTime.Now, EndInterval = DateTime.Now.AddHours(hourInterval), SpecializationId = doctor.SpecializationId, HospitalEquipmentId = equipmentType.Id };
            HttpRequestToAppointmentFilterController(appointmentFilterDTO);

        }

        private void ButtonScheduleExamination(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridAppointment.SelectedItem;
            if(appointment == null)
            {
                MessageBox.Show("You didn't select appointment!");
                return;
            }
            Patient patient = (Patient)comboBoxPatient.SelectedItem;
            if (patient == null)
            {
                MessageBox.Show("You didn't select patient!");
                return;
            }
            //MedicalRecord medicalRecord = SearchDataBaseForMedicalRecord(patient.Id);
            //appointment.MedicalRecord.Id = medicalRecord.Id;
            appointment.PatientId = patient.Id;
            appointment.Doctor = (Doctor)comboBoxDoctor.SelectedItem;
            appointment.Room = null;
            if(listViewPostPoneTime.ItemsSource == null)
            {
                AppointmentFilterDTO appointmentFilterDTO = new AppointmentFilterDTO() { appointmentSearchOrSchedule = AppointmentSearchOrSchedule.ScheduleAppointment, appointment = appointment };
                SaveAndUpdateDataBase(appointmentFilterDTO);
                MessageBox.Show("Appointment is scheduled!");
            }
            else
            {
                Appointment appointmentForRescheduling = CreateNewAppointment(appointment, (double)listViewPostPoneTime.SelectedItem);
                AppointmentFilterDTO appointmentFilterDTO = new AppointmentFilterDTO() { appointmentSearchOrSchedule = AppointmentSearchOrSchedule.ScheduleAppointment, appointment = appointmentForRescheduling };
                SaveAndUpdateDataBase(appointmentFilterDTO);
                appointmentFilterDTO.appointment = appointment;
                appointmentFilterDTO.appointmentSearchOrSchedule = AppointmentSearchOrSchedule.UpdateAppointment;
                SaveAndUpdateDataBase(appointmentFilterDTO);
                MessageBox.Show("Appointment is moved and emergency appointment is scheduled!");
            }
            
            dataGridAppointment.ItemsSource = null;
        }

        private Appointment CreateNewAppointment(Appointment appointment, double time)
        {
            time = time * 60;
            Appointment newAppointment = new Appointment()
            {
                //Start = appointment.Start.AddMinutes(time - 30),
                //End = appointment.End.AddMinutes(time),
                CancelationDate = appointment.CancelationDate,
                TypeOfAppointment = appointment.TypeOfAppointment,
                ShortDescription = appointment.ShortDescription,
                Urgent = appointment.Urgent,
                Deleted = appointment.Deleted,
                Finished = appointment.Finished,
                RoomId = appointment.RoomId,
                MedicalRecord = appointment.MedicalRecord,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId
            };
            newAppointment.Period.StartTime = appointment.Period.StartTime.AddMinutes(time - 30);
            newAppointment.Period.EndTime = appointment.Period.EndTime.AddMinutes(time);
            MessageBox.Show("Start: " + newAppointment.Period.StartTime.ToString() + " End: " + newAppointment.Period.EndTime.ToString());
            return newAppointment;
        }

        private List<Doctor> SearchDataBaseForDoctor()
        {
            doctors = new List<Doctor>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:8081/api/doctor" + "/getAllDoctors")
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

        private List<Patient> SearchDataBaseForPatients()
        {
            patients = new List<Patient>();
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:8081/api/user" + "/getAllPatients")
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString.Result);
                });
            task.Wait();
            return patients;
        }

        private List<EquipmentType> SearchDataBaseForHospitalEquipment()
        {
            hospitalEquipments = new List<EquipmentType>();
            HttpClient httpClient = new HttpClient();
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

        private async void HttpRequestToAppointmentFilterController(AppointmentFilterDTO appointmentFilterDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointmentfilter/", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            if(appointmentFilterDTO.appointmentFilterCriteria == AppointmentFilterCriteria.ReschedulingAppointment)
            {
                tuplePostPoneTime = (JsonConvert.DeserializeObject<Tuple<List<Appointment>, List<int>>>(responseBody));
                Dictionary<Appointment,double> dictionary = SortDictionary();
                dataGridAppointment.ItemsSource = dictionary.Keys;
                listViewPostPoneTime.ItemsSource = dictionary.Values;
            }
            else
            {
                appointments = new List<Appointment>(JsonConvert.DeserializeObject<List<Appointment>>(responseBody));
                dataGridAppointment.ItemsSource = appointments;
                listViewPostPoneTime.ItemsSource = null;
                if (appointments.Count == 0)
                {
                    appointmentFilterDTO.appointmentFilterCriteria = AppointmentFilterCriteria.ReschedulingAppointment;
                    HttpRequestToAppointmentFilterController(appointmentFilterDTO);
                }
            }
        }

        private MedicalRecord SearchDataBaseForMedicalRecord(string patientId)
        {
            MedicalRecord medicalRecord = new MedicalRecord();
            /*
            HttpClient httpClient = new HttpClient();
            var task = httpClient.GetAsync("http://localhost:53109/api/medicalrecord/" + patientId)
                .ContinueWith((taskWithResponse) =>
                {
                    var response = taskWithResponse.Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    medicalRecord = JsonConvert.DeserializeObject<MedicalRecord>(jsonString.Result);
                });
            task.Wait();*/
            return medicalRecord;
        }

        private async void SaveAndUpdateDataBase(AppointmentFilterDTO appointmentFilterDTO)
        {
            string jsonSearchAppointmentsDTO = JsonConvert.SerializeObject(appointmentFilterDTO);
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonSearchAppointmentsDTO, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8083/api/appointment/apointmentsBySearchOrSchedule", content);
            response.EnsureSuccessStatusCode();
        }

        private Dictionary<Appointment, double> SortDictionary()
        {
            Dictionary<Appointment, double> dictionary = new Dictionary<Appointment, double>();
            for (int i = 0; i < tuplePostPoneTime.Item1.Count; i++)
            {
                dictionary.Add(tuplePostPoneTime.Item1[i], tuplePostPoneTime.Item2[i]);
            }
            List<KeyValuePair<Appointment, double>> myList = dictionary.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            Dictionary<Appointment, double> newDictionary = new Dictionary<Appointment, double>();
            foreach(KeyValuePair<Appointment,double> kvp in myList)
            {
                newDictionary.Add(kvp.Key, ((kvp.Value+30)*1.0)/60);
            }
            return newDictionary;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            listViewPostPoneTime.SelectedIndex = dataGridAppointment.SelectedIndex;
        }

        private void ButtonAddNewPatient(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.ShowDialog();
            SearchDataBaseForPatients();
            comboBoxPatient.ItemsSource = patients;
        }
    }
}
