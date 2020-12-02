using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebDoctorController
    {
        private DoctorSqlRepository doctorRepository = new DoctorSqlRepository(new MySqlContext());
        private DoctorService doctorService;

        public WebDoctorController()
        {
            this.doctorService = new DoctorService(doctorRepository);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return doctorService.GetAll();
        }
    }
}
