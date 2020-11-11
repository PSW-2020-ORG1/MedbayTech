using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.IncorrectEmailAddress
{
    public class RoomHasAppointmentsScheduled : System.Exception
    {
        public RoomHasAppointmentsScheduled()
        {

        }

        public RoomHasAppointmentsScheduled(string message) : base(message)
        {

        }

        public RoomHasAppointmentsScheduled(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
