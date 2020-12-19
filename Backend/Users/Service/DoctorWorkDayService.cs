using Backend.Users.Model;
using Backend.Users.Repository;
using Backend.Users.Service.Interfaces;
using System.Collections.Generic;

namespace Backend.Users.Service
{
    public class DoctorWorkDayService : IDoctorWorkDayService
    {
        IDoctorWorkDayRepository _doctorWorkDayRepository;

        public DoctorWorkDayService(IDoctorWorkDayRepository doctorWorkDayRepository)
        {
            _doctorWorkDayRepository = doctorWorkDayRepository;
        }
        public List<DoctorWorkDay> GetAll()
        {
            return _doctorWorkDayRepository.GetAll();
        }
    }
}
