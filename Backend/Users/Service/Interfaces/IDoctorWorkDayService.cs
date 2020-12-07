using Backend.Users.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IDoctorWorkDayService
    {
        IEnumerable<DoctorWorkDay> GetAll();
    }
}
