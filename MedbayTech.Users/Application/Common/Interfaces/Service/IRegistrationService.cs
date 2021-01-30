using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IRegistrationService
    {
        Patient Register(Patient patient);
        bool PatientExists(string id, string username);
        bool ExistsById(string id);
        Patient ExistsByUsername(string username);
        Patient SetImagePath(string path, string id);
        Patient ActivateAccount(string userId, string token);
        Patient CheckToken(string userId, string token);
        Patient ChangeAccountState(Patient patient, bool state);
        Patient GetFirstPatient();
        Patient GetUserById(string id);
    }
}
