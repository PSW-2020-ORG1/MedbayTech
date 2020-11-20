using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class IncorrectNameFormat : System.Exception
    {
        public IncorrectNameFormat()
        {

        }

        public IncorrectNameFormat(string message) : base(message)
        {

        }

        public IncorrectNameFormat(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
