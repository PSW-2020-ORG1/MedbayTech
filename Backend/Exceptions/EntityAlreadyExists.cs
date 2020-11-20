using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.SIMS.Exceptions
{
    public class EntityAlreadyExists : System.Exception
    {
        public EntityAlreadyExists()
        {

        }
        public EntityAlreadyExists(string message) : base(message)
        {

        }

        public EntityAlreadyExists(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
