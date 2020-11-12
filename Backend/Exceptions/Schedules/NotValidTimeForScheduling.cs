using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class NotValidTimeForScheduling : System.Exception
    {
        public NotValidTimeForScheduling()
        {

        }
        public NotValidTimeForScheduling(string message) : base(message)
        {

        }

        public NotValidTimeForScheduling(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
