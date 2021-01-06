using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.DTO
{
    public class AuthenticatedUserDTO
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }

    }
}
