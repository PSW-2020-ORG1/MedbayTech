using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class NoMedicalRecord : System.Exception
    {
        public NoMedicalRecord()
        {

        }
        public NoMedicalRecord(string message) : base(message)
        {

        }

        public NoMedicalRecord(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
