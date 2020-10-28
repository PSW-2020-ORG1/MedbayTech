using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class IncorrectInsuranceNumber : System.Exception
    {
        public IncorrectInsuranceNumber()
        {

        }

        public IncorrectInsuranceNumber(string message) : base(message)
        {

        }

        public IncorrectInsuranceNumber(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
