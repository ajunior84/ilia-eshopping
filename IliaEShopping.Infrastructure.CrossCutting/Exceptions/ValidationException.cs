using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.CrossCutting.Exceptions
{
    public class ValidationException : Exception
    {
        #region "  Properties  "

        public object ExtraInfo { get; private set; }

        #endregion

        #region "  Constructors  "

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, object extraInfo) : base(message)
        {
            ExtraInfo = extraInfo;
        }

        #endregion
    }
}
