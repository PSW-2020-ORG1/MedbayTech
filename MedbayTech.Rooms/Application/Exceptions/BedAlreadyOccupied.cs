

using System;

namespace MedbayTech.Rooms.Application
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
