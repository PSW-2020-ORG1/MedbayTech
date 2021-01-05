using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
