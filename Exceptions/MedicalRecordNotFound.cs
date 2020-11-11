using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Exceptions
{
    public class MedicalRecordNotFound : System.Exception
    {
        public MedicalRecordNotFound()
        {

        }
        public MedicalRecordNotFound(string message) : base(message)
        {

        }

        public MedicalRecordNotFound(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
