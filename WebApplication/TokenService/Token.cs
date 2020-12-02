using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.TokenService
{
    public class Token
    {
        public static string GenerateGuidToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
