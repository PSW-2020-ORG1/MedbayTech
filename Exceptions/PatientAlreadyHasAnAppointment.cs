using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class PatientAlreadyHasAnAppointment : System.Exception
    {
        public PatientAlreadyHasAnAppointment()
        {

        }
        public PatientAlreadyHasAnAppointment(string message) : base(message)
        {

        }

        public PatientAlreadyHasAnAppointment(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
