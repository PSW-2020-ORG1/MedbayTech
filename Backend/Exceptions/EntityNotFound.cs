using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.SIMS.Exceptions
{
    public class EntityNotFound : System.Exception
    {
        public EntityNotFound()
        {

        }

        public EntityNotFound(string message) : base(message)
        {

        }

        public EntityNotFound(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
