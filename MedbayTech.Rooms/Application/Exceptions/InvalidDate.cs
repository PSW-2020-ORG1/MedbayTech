using System;

namespace MedbayTech.Rooms.Application
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
