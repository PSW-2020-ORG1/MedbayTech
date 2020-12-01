using Backend.Rooms.Service;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Users.Repository;

namespace Backend.Users.Service
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return _doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId);
        }
        public Doctor UpdateDoctorDataBase(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
            return doctor;
        }
    }
}
