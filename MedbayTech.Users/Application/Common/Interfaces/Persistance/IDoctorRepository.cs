using MedbayTech.Common.Repository;
using Model.Users;
using System.Collections.Generic;

namespace MedbayTech.Users.Application.Common.Interfaces.Persistance
{
    public interface IDoctorRepository : IRepository<Doctor, string>
    {
        //public List<Doctor> GetDoctorsFromDepartment(Department department);
        public List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization);
       
    }
}
