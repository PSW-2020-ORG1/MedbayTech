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
        public List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }
        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId);
        }
        public Doctor UpdateDoctorDataBase(Doctor doctor)
        {
            Doctor doctor_update = doctorRepository.GetAll().ToList().Find(d => d.Id == doctor.Id);
            doctor_update.UpdateDoctor(doctor);
            return doctorRepository.Update(doctor_update);
        }
        public List<Doctor> GetDoctorsBy(int specializationId)
        {
            return GetAll().Where(d => d.SpecializationId == specializationId).ToList();
        }

        public Doctor GetDoctorBy(string id)
        {
            return doctorRepository.GetObject(id);
        }
    }
}
