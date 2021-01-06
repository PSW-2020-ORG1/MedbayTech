using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;


namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient UpdateStatus(string patientId);

        List<Patient> GetPatientsThatShouldBeBlocked();
        Patient GetPatientBy(string id);
       // bool CheckIfPatientBlockable(List<Appointment> canceledAppointments);
    }
}
