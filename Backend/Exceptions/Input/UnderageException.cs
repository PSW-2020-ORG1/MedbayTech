using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class UnderageException : System.Exception
    {
        public UnderageException()
        {

        }

        public UnderageException(string message) : base(message)
        {

        }

        public UnderageException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
