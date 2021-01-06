using MedbayTech.Appointment.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MedbayTech.Appointment.Application.Gateways
{
    public interface IUserGateway
    {
        WorkDay GetWorkDayBy(string id, DateTime date);
        Doctor GetDoctorBy(string id);
        List<Doctor> GetDoctorsBy(string specializationName);
        Patient GetPatientBy(string id);
        List<Doctor> GetAllDoctors();
        string GetUsersDomain();
        
    }
}
