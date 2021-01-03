using Backend.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IWorkDayService
    {
        List<WorkDay> GetByDoctorId(string id);
        WorkDay GetByDoctorIdAndDate(string id, DateTime date);
    }
}
