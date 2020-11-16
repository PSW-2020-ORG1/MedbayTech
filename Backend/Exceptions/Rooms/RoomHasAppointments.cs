using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class RoomHasAppointments : System.Exception
    {
        public RoomHasAppointments()
        {

        }

        public RoomHasAppointments(string message) : base(message)
        {

        }

        public RoomHasAppointments(string message, System.Exception inner) : base(message, inner)
        {

        }
    }

}