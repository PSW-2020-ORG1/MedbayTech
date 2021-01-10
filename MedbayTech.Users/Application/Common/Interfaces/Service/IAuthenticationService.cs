using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.DTO;

namespace MedbayTech.Users.Application.Common.Interfaces.Service
{
    public interface IAuthenticationService
    {
        AuthenticatedUserDTO Authenticate(string username, string password);
    }
}
