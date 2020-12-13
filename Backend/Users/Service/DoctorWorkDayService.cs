using Backend.Users.Model;
using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service
{
    public class DoctorWorkDayService : IDoctorWorkDayService
    {
        IDoctorWorkDayRepository _doctorWorkDayRepository;

        public DoctorWorkDayService(IDoctorWorkDayRepository doctorWorkDayRepository)
        {
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }
        public IEnumerable<DoctorWorkDay> GetAll()
        {
            return _doctorWorkDayRepository.GetAll();
        }
    }
}
