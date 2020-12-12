using Model.Rooms;
using Model.Users;
using Repository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    // TODO(Jovan): Implement
    class UserSqlRepository : MySqlrepository<RegisteredUser, string>,
        IUserRepository
    {
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return (IEnumerable<Doctor>) context.Doctors.ToList();
        }

        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            return (IEnumerable<Doctor>) context.Doctors.ToList().Where(d => d.IsMySpecialization(specialization));
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return (IEnumerable<Employee>)context.Employees.ToList();
        }

        public IEnumerable<Manager> GetAllManagers()
        {
            return (IEnumerable<Manager>)context.Managers.ToList();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return (IEnumerable<Patient>)context.Patients.ToList();
        }

        public IEnumerable<Secretary> GetAllSecretaries()
        {
            return (IEnumerable<Secretary>)context.Secretaries.ToList();
        }

        public RegisteredUser GetByUsername(string username)
        {
            return context.RegisteredUsers.ToList().FirstOrDefault(ru => ru.Username.Equals(username));
        }

        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department)
        {
            return context.Doctors.ToList().Where(d => d.DepartmentId.Equals(department.Id));
        }
    }
}
