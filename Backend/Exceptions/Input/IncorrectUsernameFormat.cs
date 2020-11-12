using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class IncorrectUsernameFormat : System.Exception
    {
        public IncorrectUsernameFormat()
        {

        }

        public IncorrectUsernameFormat(string message) : base(message)
        {

        }

        public IncorrectUsernameFormat(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
