using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Model
{
    public class SystemAdministrator : RegisteredUser
    {
        public SystemAdministrator(string id, string username, string password, string name, string surname, DateTime dateOfBirth, string email, string phone, City city) 
            : base(id, username, password, name, surname, dateOfBirth, email, phone, city) { }

        public SystemAdministrator() { }
    }
}
