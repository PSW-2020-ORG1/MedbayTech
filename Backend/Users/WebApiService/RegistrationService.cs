using Backend.Users.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class RegistrationService
    {
        IPatientRepository patientRepository;

        public RegistrationService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public Patient Register(Patient patient)
        {
            if (!PatientExists(patient.Id, patient.Username))
            {
                return patientRepository.Create(patient);
            }

            return null;
        }

        public bool PatientExists(string id, string username)
        {
            List<Patient> patients = patientRepository.GetAll().ToList();
            return patients.Any(patient => patient.Username != null && patient.Username.Equals(username) || patient.Id.Equals(id));
        }
        public bool ExistsById(string id)
        {
            return patientRepository.ExistsById(id);
        }

        public Patient ExistsByUsername(string username)
        {
            List<Patient> patients = patientRepository.GetAll().ToList();
            bool exists = patients.Any(patient => patient.Username != null && patient.Username.Equals(username));
            if (exists)
            {
                return patients.FirstOrDefault(patient => patient.Username.Equals(username));
            }
            return null;
        }

        internal Patient SetImagePath(string path, string id)
        {
            bool exists = ExistsById(id);
            if(exists)
            {
                Patient patient = GetUserById(id);
                patient.ProfileImage = path;
                patientRepository.Update(patient);
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

        private Patient CheckToken(string userId, string token)
        {
            if (!ExistsById(userId)) return null;

            Patient _patient = GetUserById(userId);
            string userToken = _patient.Token;

            if (!token.Equals(userToken)) return null;

            _patient.Confirmed = true;
            patientRepository.Update(_patient);

            return _patient;
        }

        private Patient ChangeAccountState(Patient patient, bool state)
        {
            patient.Confirmed = state;
            return patientRepository.Update(patient);
        }
        public Patient GetFirstPatient()
        {
            return patientRepository.GetAll().FirstOrDefault();
        }

        public Patient GetUserById(string id)
        {
            return patientRepository.GetById(id);
        }

    }
}
