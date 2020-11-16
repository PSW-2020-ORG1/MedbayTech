using Model.Rooms;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class DoctorSqlRepository : MySqlrepository<Doctor, string>,
        IDoctorRepository
    {
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            return GetAll().ToList().Where(d => d.IsMySpecialization(specialization));
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
