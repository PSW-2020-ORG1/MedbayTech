using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class CantFindAppointment : System.Exception
    {
        public CantFindAppointment()
        {

        }
        public CantFindAppointment(string message) : base(message)
        {

        }

        public CantFindAppointment(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
