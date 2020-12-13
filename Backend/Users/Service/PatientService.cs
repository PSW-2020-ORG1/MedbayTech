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
        private const int daysInMonth = 30;
        private const int numberOfCancelableAppointments = 4;
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

            if (patient != null)
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

            patients.ForEach(p => canceledAppointments = appointmentRepository.GetCanceledAppointments());
            patients.ForEach(p => 
                {
                    if (CheckIfPatientBlockable(canceledAppointments))
                    {
                        blockablePatients.Add(p);
                    }
                });

            return blockablePatients;
        }

        private bool CheckIfPatientBlockable(List<Appointment> canceledAppointments)
        {
            if (canceledAppointments.Count < numberOfCancelableAppointments)
                return false;
            
            canceledAppointments.Sort((x, y) => DateTime.Compare(x.CancelationDate, y.CancelationDate));
            bool dayDifference = DayDifference(canceledAppointments);

            return dayDifference;
        }

        private bool DayDifference(List<Appointment> canceledAppointments)
        {
            int index = canceledAppointments.Count - numberOfCancelableAppointments;
            Appointment fourthAppointment = canceledAppointments.ElementAt(index);
            Appointment lastAppointment = canceledAppointments.Last();
            double dayDifference = (lastAppointment.CancelationDate - fourthAppointment.CancelationDate).TotalDays;

            if (dayDifference <= daysInMonth)
                return true;

            return false;
        }
    }
}
