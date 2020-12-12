using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IPatientService
    {
        Patient UpdateStatus(string patientId);
        List<Patient> GetPatientsThatShouldBeBlocked();
    }
}
