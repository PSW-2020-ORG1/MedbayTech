using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Common.Repository;
using MedbayTech.Common.Repository;
using MedbayTech.Users.Domain.Entites;



namespace MedbayTech.Users.Application.Common.Interfaces.Persistance
{
    public interface IPatientRepository : IRepository<Patient, string>
    {
        public Patient GetByUsername(string username);
    }
}
