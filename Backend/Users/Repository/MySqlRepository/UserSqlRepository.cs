using Model.Rooms;
using Model.Users;
using Repository;
using Repository.UserRepository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Users.Repository.MySqlRepository
{
    // TODO(Jovan): Implement
    public class UserSqlRepository : MySqlrepository<RegisteredUser, string>,
        IUserRepository
    {
        public List<Doctor> GetAllDoctors()
        {
            return context.Doctors.ToList();
        }

        public List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
            //return (IEnumerable<Doctor>) context.Doctors.ToList().Where(d => d.IsMySpecialization(specialization));
            return null;
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public List<Manager> GetAllManagers()
        {
            return context.Managers.ToList();
        }

        public List<Patient> GetAllPatients()
        {
            return context.Patients.ToList();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return context.Secretaries.ToList();
        }

        public RegisteredUser GetByUsername(string username)
        {
            return context.RegisteredUsers.ToList().FirstOrDefault(ru => ru.Username.Equals(username));
        }

        public List<Doctor> GetDoctorsFromDepartment(Department department)
        {
            return context.Doctors.ToList().Where(d => d.DepartmentId.Equals(department.Id)).ToList();
        }
    }
}