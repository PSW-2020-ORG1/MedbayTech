using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class AppointmentAlreadyScheduled : System.Exception
    {
        public AppointmentAlreadyScheduled()
        {

        }
        public AppointmentAlreadyScheduled(string message) : base(message)
        {

        }

        public AppointmentAlreadyScheduled(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
