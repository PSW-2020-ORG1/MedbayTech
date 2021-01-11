using MedbayTech.Common.Repository;
using System.Collections.Generic;
using MedbayTech.Users.Domain.Entites;


namespace MedbayTech.Users.Application.Common.Interfaces.Persistance
{
    public interface IDoctorRepository : IRepository<Doctor, string>
    {
        //public List<Doctor> GetDoctorsFromDepartment(Department department);
        public List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization);

    }
}
