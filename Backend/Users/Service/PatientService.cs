using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using Model.Schedule;
using Model.Users;
using Repository.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Service
{
    public class PatientService : IPatientService
    {
        private IPatientRepository patientRepository;
        private IAppointmentRepository appointmentRepository;

        public PatientService(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository)
        {
            this.patientRepository = patientRepository;
            this.appointmentRepository = appointmentRepository;
        }
        public Patient UpdateStatus(string patientId)
        {
            Patient patient = patientRepository.GetById(patientId);

            if (patient != null && !patient.Blocked)
            {
                patient.Blocked = true;
                patientRepository.Update(patient);
                return patient;
            }

            return null;
        }

        public List<Patient> GetPatientsThatShouldBeBlocked()
        {
            List<Patient> patients = patientRepository.GetAll().Where(patient => !patient.Blocked).ToList();
            List<Patient> blockablePatients = new List<Patient>();
            List<Appointment> canceledAppointments = new List<Appointment>();

            patients.ForEach(p => canceledAppointments = appointmentRepository.GetCanceledAppointmentsByPatientId(p.Id));
            patients.ForEach(p => 
                {
                    if (CheckIfPatientBlockable(canceledAppointments))
                    {
                        p.ShouldBeBlocked = true;
                        blockablePatients.Add(p);
                }});

            return blockablePatients;
        }

        private bool CheckIfPatientBlockable(List<Appointment> canceledAppointments)
        {
            if (canceledAppointments.Count <= 3)
                return false;
            
            canceledAppointments.Sort((x, y) => DateTime.Compare(x.CancelationDate, y.CancelationDate));
            bool dayDiffernce = DayDifference(canceledAppointments);
           
            return dayDiffernce;
        }

        private bool DayDifference(List<Appointment> canceledAppointments)
        {
            int index = canceledAppointments.Count - 3;
            Appointment fourthAppointment = canceledAppointments.ElementAt(index);
            Appointment lastAppointment = canceledAppointments.Last();
            double dayDifference = (lastAppointment.CancelationDate - fourthAppointment.CancelationDate).TotalDays;

            if (dayDifference <= 30)
                return true;

            return false;
        }
    }
}
