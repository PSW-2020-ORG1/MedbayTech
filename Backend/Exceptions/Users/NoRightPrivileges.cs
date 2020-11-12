using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class NoRightPrivileges : System.Exception
    {
        public NoRightPrivileges()
        {

        }
        public NoRightPrivileges(string message) : base(message)
        {

        }

        public NoRightPrivileges(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
