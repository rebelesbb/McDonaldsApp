﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McApp.domain.validators
{
    internal class ValidationException : Exception
    {
        public ValidationException() { }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(string message, Exception inner)
            : base(message, inner) { }
    }
}
