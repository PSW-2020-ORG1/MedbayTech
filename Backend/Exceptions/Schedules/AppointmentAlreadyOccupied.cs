using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    class AppointmentAlreadyOccupied : Exception
    {
        public AppointmentAlreadyOccupied()
        {

        }

        public AppointmentAlreadyOccupied(string message) : base(message)
        {

        }

        public AppointmentAlreadyOccupied(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
