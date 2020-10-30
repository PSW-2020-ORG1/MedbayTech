using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.SIMS.Exceptions
{
    public class InvalidDate : SystemException
    {
        public InvalidDate()
        {

        }

        public InvalidDate(string message) : base(message)
        {

        }

        public InvalidDate(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
