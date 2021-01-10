using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Infrastructure.Service
{
    public class RegistrationTokenService
    {
        public static string GenerateGuidToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
