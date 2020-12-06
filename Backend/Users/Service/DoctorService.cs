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
            List<Doctor> allDoctors = GetAll().ToList();
            List<Doctor> doctors = new List<Doctor>();

            foreach(Doctor doctorIt in allDoctors)
            {
                List<Specialization> specializations = doctorIt.Specializations;
                foreach(Specialization specializationIt in specializations)
                {
                    if (specializationIt.Id == specializationId)
                        doctors.Add(doctorIt);
                }
            }
            return doctors;
        }
    }
}
