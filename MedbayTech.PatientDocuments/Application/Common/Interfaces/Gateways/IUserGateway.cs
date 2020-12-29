using MedbayTech.PatientDocuments.Domain.Entities.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.PatientDocuments.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        Patient GetPatientBy(string id);
        string GetUsersDomain();
    }
}
