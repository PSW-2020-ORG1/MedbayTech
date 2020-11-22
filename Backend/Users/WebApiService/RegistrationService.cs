using Backend.Users.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
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

    }
}
