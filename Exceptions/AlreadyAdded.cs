using System;
using System.Collections.Generic;
using System.Text;

namespace ZdravoKorporacija.Exceptions
{
    public class AlreadyAdded : System.Exception
    {
        public AlreadyAdded()
        {

        }

        public AlreadyAdded(string message) : base(message)
        {

        }

        public AlreadyAdded(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
