using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Users.Application.DTO
{
    public class AuthenticationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticationDTO() { }
        public AuthenticationDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
