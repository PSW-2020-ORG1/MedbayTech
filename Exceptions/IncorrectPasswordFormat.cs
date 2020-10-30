using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class IncorrectPasswordFormat : System.Exception
    {
        public IncorrectPasswordFormat()
        {

        }

        public IncorrectPasswordFormat(string message) : base(message)
        {

        }

        public IncorrectPasswordFormat(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
