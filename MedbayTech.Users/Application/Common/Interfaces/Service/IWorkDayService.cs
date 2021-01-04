using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IWorkDayService
    {
        List<WorkDay> GetByDoctorId(string id);
        WorkDay GetByDoctorIdAndDate(string id, DateTime date);
    }
}
