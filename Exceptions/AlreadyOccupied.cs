using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class AlreadyOccupied : SystemException
    {
        public AlreadyOccupied()
        {

        }

        public AlreadyOccupied(string message) : base(message)
        {

        }

        public AlreadyOccupied(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
