﻿using Model;
using Model.Rooms;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class DoctorSqlRepository : MySqlrepository<Doctor, string>, IDoctorRepository
    {

        private MySqlContext _context;

        public DoctorSqlRepository(MySqlContext context) : base(context) {}
    
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
           return null;
        }

        public Doctor GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(d => d.Username.Equals(username));
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department)
        {
            return GetAll().ToList().Where(d => d.DepartmentId.Equals(department.Id));
        }
    }
}
