using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Appointment.Domain.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string msg) : base(msg)
        {

        }
    }
}
