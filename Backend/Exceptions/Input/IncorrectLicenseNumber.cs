using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class IncorrectLicenseNumber : System.Exception
    {
        public IncorrectLicenseNumber()
        {

        }

        public IncorrectLicenseNumber(string message) : base(message)
        {

        }

        public IncorrectLicenseNumber(string message, System.Exception inner) : base(message, inner)
        {

        }

    }
}
