﻿using MedbayTech.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Common.Interfaces.Persistance
{
    public interface IWorkDayRepository : IRepository<WorkDay, int>
    {
        List<WorkDay> GetByDoctorId(string id);
        WorkDay GetByDoctorIdAndDate(string id, DateTime date);
    }
}
