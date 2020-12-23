using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using Model.Users;
using System;
using System.Collections.Generic;
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
        private IPatientRepository _patientRepository;

        private const int daysInMonth = 30;
        private const int numberOfCancelableAppointments = 4;
        private IAppointmentRepository _appointmentRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientService(IPatientRepository patientRepository, IAppointmentRepository appointmentRepository)
        {
            this._patientRepository = patientRepository;
            this._appointmentRepository = appointmentRepository;
        }
        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }
        public Patient UpdateStatus(string patientId)
        {
            Patient patient = _patientRepository.GetById(patientId);

            if (patient != null)
            {
                patient.Blocked = true;
                _patientRepository.Update(patient);
                return patient;
            }

            return null;
        }

        public List<Patient> GetMaliciousPatients()
        {
            List<Patient> patients = GetPatientsThatShouldBeBlocked();
            return patients.Where(p => p.ShouldBeBlocked).ToList();
        }

        public List<Patient> GetPatientsThatShouldBeBlocked()
        {
            List<Patient> patients = _patientRepository.GetAll().Where(patient => !patient.Blocked).ToList();
            List<Patient> blockablePatients = new List<Patient>();
            List<Appointment> canceledAppointments = new List<Appointment>();

            foreach(Patient p in patients)
            {
                canceledAppointments = _appointmentRepository.GetCanceledAppointmentsByPatient(p.Id);
                if (CheckIfPatientBlockable(canceledAppointments))
                {
                    p.ShouldBeBlocked = true;
                    blockablePatients.Add(p);
                    _patientRepository.Update(p);
                }
            }

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
            double dayDifference = (DateTime.Now - fourthAppointment.CancelationDate).TotalDays;

            if (dayDifference <= daysInMonth)
                return true;

            return false;
        }
    }
}
