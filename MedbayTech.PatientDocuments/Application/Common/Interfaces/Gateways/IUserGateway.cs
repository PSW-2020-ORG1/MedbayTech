using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using MedbayTech.PatientDocuments.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        Patient GetPatientBy(string id);
        Doctor GetDoctorBy(string id);
        string GetUsersDomain();
    }
}
