using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Exceptions.Schedules
{
    public class IncorrectSurnameFormat : System.Exception
    {
        public IncorrectSurnameFormat()
        {

        }

        public IncorrectSurnameFormat(string message) : base(message)
        {

        }

        public IncorrectSurnameFormat(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
