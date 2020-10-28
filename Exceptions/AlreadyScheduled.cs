using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class AlreadyScheduled : System.Exception
    {
        public AlreadyScheduled()
        {

        }
        public AlreadyScheduled(string message) : base(message)
        {

        }

        public AlreadyScheduled(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
