using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service
{
    public class PatientService : IPatientService
    {
        private IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
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
    }
}
