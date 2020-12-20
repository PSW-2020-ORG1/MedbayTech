using Backend.Users.Model;
using System.Collections.Generic;

namespace Backend.Users.Service.Interfaces
{
    public interface IDoctorWorkDayService
    {
        List<DoctorWorkDay> GetAll();
    }
}
