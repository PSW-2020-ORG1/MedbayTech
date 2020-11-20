using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class BedAlreadyOccupied : SystemException
    {
        public BedAlreadyOccupied()
        {

        }

        public BedAlreadyOccupied(string message) : base(message)
        {

        }

        public BedAlreadyOccupied(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
