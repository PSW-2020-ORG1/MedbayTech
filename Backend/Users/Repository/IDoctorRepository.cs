using Model.Rooms;
using Model.Users;
using Repository;
using System.Collections.Generic;

namespace Backend.Users.Repository
{
    public interface IDoctorRepository : ICreate<Doctor>, IGetAll<Doctor>
    {
        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department);
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization);
        public Doctor GetByUsername(string username);
    }
}
