using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
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
        public bool UpdateStatus(string patientId, bool status)
        {
            return patientRepository.UpdateStatus(patientId, status);
        }
    }
}
