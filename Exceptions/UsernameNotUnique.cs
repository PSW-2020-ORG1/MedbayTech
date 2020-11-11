using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class UsernameNotUnique : System.Exception
    {
        public UsernameNotUnique()
        {

        }

        public UsernameNotUnique(string message) : base(message)
        {

        }

        public UsernameNotUnique(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
