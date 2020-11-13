using Model.Rooms;
using Model.Users;
using Repository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    // TODO(Jovan): Implement
    class UserSqlRepository : MySqlrepository<RegisteredUser, string>,
        IUserRepository
    {
        public IEnumerable<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> GetAllManagers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAllSecrateries()
        {
            throw new NotImplementedException();
        }

        public RegisteredUser GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
