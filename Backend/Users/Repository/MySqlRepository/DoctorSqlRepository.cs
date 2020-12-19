using Model;
using Model.Rooms;
using Model.Users;
using Repository;
using System.Collections.Generic;
using System.Linq;
namespace Backend.Users.Repository.MySqlRepository
{
    public class DoctorSqlRepository : MySqlrepository<Doctor, string>, IDoctorRepository
    {
        public DoctorSqlRepository(MedbayTechDbContext context) : base(context) {}

        public List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization)
        {
           return GetAll().ToList().Where(d => d.SpecializationId == specialization.Id).ToList();
           
        }
        public Doctor GetByUsername(string username)
        {
            return GetAll().ToList().FirstOrDefault(d => d.Username.Equals(username));
        }
        public List<Doctor> GetDoctorsFromDepartment(Department department)
        {
            return GetAll().ToList().Where(d => d.DepartmentId.Equals(department.Id)).ToList();
        }
    }
}
