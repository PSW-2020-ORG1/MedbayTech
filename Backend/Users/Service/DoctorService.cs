using Backend.Rooms.Service;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Service
{
    public class DoctorService : IDoctorService
    {
        private MySqlContext _context;

        public DoctorService(MySqlContext context)
        {
            _context = context;
        }

        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return _context.Doctors.ToList().Find(p => p.ExaminationRoomId == roomId);
        }
        public Doctor UpdateDoctorDataBase(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}
