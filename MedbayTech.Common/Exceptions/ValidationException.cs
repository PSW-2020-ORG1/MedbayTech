﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Common.Exceptions
{
    public class ValidationException : SystemException
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }
    }
}
