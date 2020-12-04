using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class RegistrationService : IRegistrationService
    {
        IPatientRepository _patientRepository;

        public RegistrationService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Register(Patient patient)
        {
            if (!PatientExists(patient.Id, patient.Username))
            {
                return _patientRepository.Create(patient);
            }

            return null;
        }

        public bool PatientExists(string id, string username)
        {
            List<Patient> patients = _patientRepository.GetAll().ToList();
            return patients.Any(patient => patient.Username != null && patient.Username.Equals(username) || patient.Id.Equals(id));
        }
        public bool ExistsById(string id)
        {
            return _patientRepository.ExistsById(id);
        }

        public Patient ExistsByUsername(string username)
        {
            List<Patient> patients = _patientRepository.GetAll().ToList();
            bool exists = patients.Any(patient => patient.Username != null && patient.Username.Equals(username));
            if (exists)
            {
                return patients.FirstOrDefault(patient => patient.Username.Equals(username));
            }
            return null;
        }

        public Patient SetImagePath(string path, string id)
        {
            bool exists = ExistsById(id);
            if(exists)
            {
                Patient patient = GetUserById(id);
                patient.ProfileImage = path;
                _patientRepository.Update(patient);
                return patient;
            }
            return null;
        }

        public Patient ActivateAccount(string userId, string token)
        {
            Patient patient = CheckToken(userId, token);
            if (patient == null) return patient;

            return ChangeAccountState(patient, true);

        }

        public Patient CheckToken(string userId, string token)
        {
            if (!ExistsById(userId)) return null;

            Patient _patient = GetUserById(userId);
            string userToken = _patient.Token;

            if (!token.Equals(userToken)) return null;

            _patient.Confirmed = true;
            _patientRepository.Update(_patient);

            return _patient;
        }

        public Patient ChangeAccountState(Patient patient, bool state)
        {
            patient.Confirmed = state;
            return _patientRepository.Update(patient);
        }
        public Patient GetFirstPatient()
        {
            return _patientRepository.GetAll().FirstOrDefault();
        }

        public Patient GetUserById(string id)
        {
            return _patientRepository.GetById(id);
        }

    }
}
