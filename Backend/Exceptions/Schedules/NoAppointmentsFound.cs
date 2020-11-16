using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    class NoAppointmentsFound : Exception
    {

        public NoAppointmentsFound()
        {

        }
        public NoAppointmentsFound(string message) : base(message)
        {

        }

        public NoAppointmentsFound(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
