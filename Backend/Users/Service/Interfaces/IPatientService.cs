using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    interface IPatientService
    {
        bool UpdateStatus(string patientId);
    }
}
