using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.IncorrectEmailAddress
{
    public class GuestAccount : System.Exception
    {
        public GuestAccount()
        {

        }
        public GuestAccount(string message) : base(message)
        {

        }

        public GuestAccount(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
