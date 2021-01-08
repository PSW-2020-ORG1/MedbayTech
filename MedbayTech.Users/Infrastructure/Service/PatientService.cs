using System;
using System.Collections.Generic;
using System.Linq;
using MedbayTech.Users.Application.Common.Interfaces.Gateways;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentGateway _appointmentGateway;

        private const int numberOfCancelableAppointments = 4;
        private const int daysInMonth = 30;

        public PatientService(IPatientRepository patientRepository, IAppointmentGateway appointmentGateway)
        {
            _patientRepository = patientRepository;
            _appointmentGateway = appointmentGateway;
        }
        public List<Patient> GetAll()
        {
            return  _patientRepository.GetAll();
        }

        public Patient GetPatientBy(string id)
        {
            return _patientRepository.GetBy(id);
        }
        public List<Patient> GetPatientsThatShouldBeBlocked()
        {
            List<Patient> patients = _patientRepository.GetAll().Where(patient => !patient.Blocked).ToList();
            List<Patient> blockablePatients = new List<Patient>();
            List<Appointment> appointments = _appointmentGateway.GetAll();
            List<Appointment> canceledAppointments = new List<Appointment>();

            foreach (Patient p in patients)
            {
                canceledAppointments = GetCanceledAppointments(p.Id, appointments);
                if (CheckIfPatientBlockable(canceledAppointments))
                {
                    blockablePatients.Add(p);
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
        public List<Appointment> GetCanceledAppointments(string patientId, List<Appointment> appointments)
        {
            List<Appointment> canceledAppointments = new List<Appointment>();
            foreach (Appointment appointmentIt in appointments)
            {
                if(appointmentIt.PatientId.Equals(patientId) && appointmentIt.CanceledByPatient)
                    canceledAppointments.Add(appointmentIt);
            }
            return canceledAppointments;
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
        public Patient UpdateStatus(string patientId)
        {
            Patient patient = _patientRepository.GetBy(patientId);

            if (patient != null)
            {
                patient.Blocked = true;
                _patientRepository.Update(patient);
                return patient;
            }

            return null;
        }
    }
}
