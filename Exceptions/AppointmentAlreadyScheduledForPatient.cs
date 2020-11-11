using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class AppointmentAlreadyScheduledForPatient : System.Exception
    {
        public AppointmentAlreadyScheduledForPatient()
        {

        }
        public AppointmentAlreadyScheduledForPatient(string message) : base(message)
        {

        }

        public AppointmentAlreadyScheduledForPatient(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
