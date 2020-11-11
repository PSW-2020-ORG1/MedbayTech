using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class AppointmentNotFound : System.Exception
    {
        public AppointmentNotFound()
        {

        }
        public AppointmentNotFound(string message) : base(message)
        {

        }

        public AppointmentNotFound(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
