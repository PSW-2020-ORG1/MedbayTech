using System;

namespace MedbayTech.Appointment.Application.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string msg) : base(msg)
        {

        }
    }
}
