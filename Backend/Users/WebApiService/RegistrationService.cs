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
            if(!ExistsById(patient.Id))
            {
                return patientRepository.Create(patient);
            }

            return null;
        } 

        public bool ExistsById(string id)
        {
            return patientRepository.ExistsById(id);
        }

        public Patient ExistsByUsername(string username)
        {
            List<Patient> patients = patientRepository.GetAll().ToList();
            bool exists = patients.Any(patient => patient.Username != null && patient.Username.Equals(username));
            if(exists)
            {
                return patients.FirstOrDefault(patient => patient.Username.Equals(username));
            }
            return null;
        }

    }
}
