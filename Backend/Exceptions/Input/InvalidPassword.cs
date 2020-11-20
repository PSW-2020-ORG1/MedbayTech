using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class InvalidPassword : System.Exception
    {
        public InvalidPassword()
        {

        }

        public InvalidPassword(string message) : base(message)
        {

        }

        public InvalidPassword(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
