using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Model.Users;
using System.Collections.Generic;
using System.Linq;

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

        public Doctor GetDoctorBy(string id)
        {
            return _doctorRepository.GetBy(id);
        }

        public Doctor GetDoctorByExaminationRoom(int roomId)
        {
            return _doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId);
        }

        public List<Doctor> GetDoctorsBy(string specializationName)
        { 
            return GetAll().Where(d => d.Specialization.SpecializationName.ToLower().Equals(specializationName)).ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }
    }
}
