using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return _doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId); 
        }

        public Doctor UpdateDoctorDataBase(Doctor doctor)
        {
            Doctor doctor_update = _doctorRepository.GetAll().ToList().Find(d => d.Id == doctor.Id);
            doctor_update.UpdateDoctor(doctor);
            return _doctorRepository.Update(doctor_update);
        }

        public Doctor GetDoctorBy(string id)
        {
            return _doctorRepository.GetBy(id);
        }
    }
}
