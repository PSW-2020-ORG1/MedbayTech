using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Users;

namespace Backend.Users.WebApiController
{
    public class WebRegistrationController
    {
        private PatientSqlRepository patientRepository = new PatientSqlRepository(new MySqlContext());
        private RegistrationService registrationService;

        public WebRegistrationController()
        {
            this.registrationService = new RegistrationService(patientRepository);
        }

        public Patient Register(Patient patient)
        {
            return registrationService.Register(patient);
        }

        public bool ExistsById(string id)
        {
            return registrationService.ExistsById(id);
        }

        public Patient SetImagePath(string path, string id)
        {
            return registrationService.SetImagePath(path, id);
        }
        public Patient GetFirstPatient()
        {
            return registrationService.GetFirstPatient();
        }

        public Patient GetUserById(string id)
        {
            return registrationService.GetUserById(id);
        }

        public bool PatientExists(string id, string username)
        {
            return registrationService.PatientExists(id, username);
        }
        public Patient ActivateAccount(string userId, string token)
        {
            return registrationService.ActivateAccount(userId, token);
        }
    }
}
