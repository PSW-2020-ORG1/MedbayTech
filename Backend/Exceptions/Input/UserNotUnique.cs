using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class UserNotUnique : System.Exception
    {
        public UserNotUnique()
        {

        }

        public UserNotUnique(string message) : base(message)
        {

        }

        public UserNotUnique(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
