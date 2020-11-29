using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Exceptions
{
    public class RegistrationException : ValidationException
    {
        public RegistrationException() { }

        public RegistrationException(string message) : base(message) { }
    }
}
