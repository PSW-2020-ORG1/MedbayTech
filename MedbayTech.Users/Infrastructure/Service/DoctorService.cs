using MedbayTech.Repository;
using MedbayTech.Users.Application.Common.Interfaces.Persistance;
using MedbayTech.Users.Application.Common.Interfaces.Service;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class DoctorService : SqlRepository<Doctor, string>, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }

        public Doctor GetDoctorByRoomExaminationRoom(int roomId)
        {
            return _doctorRepository.GetAll().ToList().Find(p => p.ExaminationRoomId == roomId); 
        }

    }
}
