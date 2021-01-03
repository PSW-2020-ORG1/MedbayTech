using Backend.Users.Model;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Model.Users;
using System;
using System.Collections.Generic;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class WorkDayService : IWorkDayService
    {

        private readonly IWorkDayRepository _workDayRepository;

        public List<WorkDay> GetAll()
        {
            return _workDayRepository.GetAll();
        }

        public List<WorkDay> GetByDoctorId(string id)
        {
            return _workDayRepository.GetByDoctorId(id);
        }

        public WorkDay GetByDoctorIdAndDate(string id, DateTime date)
        {
            return _workDayRepository.GetByDoctorIdAndDate(id, date);
        }
    }
}
