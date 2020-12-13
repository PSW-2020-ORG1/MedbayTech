using Backend.Rooms.Service;
using Backend.Users.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;

        }
        public IEnumerable<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }
        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId);
        }
        public Doctor UpdateDoctorDataBase(Doctor doctor)
        {
            doctorRepository.Update(doctor);
            return doctor;
        }
        public IEnumerable<Doctor> GetDoctorsBy(int specializationId)
        {
            return GetAll().Where(d => d.SpecializationId == specializationId);
        }

        public Doctor GetDoctorBy(string id)
        {
            return doctorRepository.GetObject(id);
        }
    }
}
