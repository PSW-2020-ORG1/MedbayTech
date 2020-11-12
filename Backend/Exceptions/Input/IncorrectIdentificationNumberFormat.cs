using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class IncorrectIdentificationNumberFormat : System.Exception
    {
        public IncorrectIdentificationNumberFormat()
        {

        }

        public IncorrectIdentificationNumberFormat(string message) : base(message)
        {

        }

        public IncorrectIdentificationNumberFormat(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
