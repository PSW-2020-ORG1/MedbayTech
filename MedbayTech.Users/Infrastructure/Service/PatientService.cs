using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Model.Users;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public IEnumerable<Patient> GetAll()
        {
            return  _patientRepository.GetAll();
        }

        public List<Patient> GetPatientsThatShouldBeBlocked()
        {
            /*List<Patient> patients = _patientRepository.GetAll().Where(patient => !patient.Blocked).ToList();
            List<Patient> blockablePatients = new List<Patient>();
            List<Appointment> canceledAppointments = new List<Appointment>();

            foreach (Patient p in patients)
            {
                canceledAppointments = _appointmentRepository.GetCanceledAppointmentsByPatient(p.Id);
                if (CheckIfPatientBlockable(canceledAppointments))
                {
                    blockablePatients.Add(p);
                }
            }

            return blockablePatients;*/
            return new List<Patient>();
        }

        public Patient UpdateStatus(string patientId)
        {
            throw new NotImplementedException();
        }
    }
}
