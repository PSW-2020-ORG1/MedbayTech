using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Examinations.Exceptions
{
    public  class ValidationException : SystemException
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }
    }
}
