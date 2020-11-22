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
    }
}
