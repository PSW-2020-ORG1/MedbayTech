using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class IDNumberNotUnique : System.Exception
    {
        public IDNumberNotUnique()
        {

        }

        public IDNumberNotUnique(string message) : base(message)
        {

        }

        public IDNumberNotUnique(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
