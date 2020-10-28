using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
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
