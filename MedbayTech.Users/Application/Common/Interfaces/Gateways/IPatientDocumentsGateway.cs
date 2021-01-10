using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Common.Interfaces.Gateways
{
    public interface IPatientDocumentsGateway
    { 
        void SaveMedicalRecord(MedicalRecord medicalRecord);
    }
}
