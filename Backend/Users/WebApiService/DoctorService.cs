using Backend.Users.Repository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class DoctorService
    {
        private IDoctorRepository dotorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.dotorRepository = doctorRepository;

        }

        public IEnumerable<Doctor> GetAll()
        {
            return dotorRepository.GetAll();
        }
    }
}
