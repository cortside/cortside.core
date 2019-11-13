using System;

namespace Spring2.Core.Util {
    /// <summary>
    /// Summary description for ParseError.
    /// </summary>
    public class ExceptionError : ApplicationError {
        //public ExceptionError(String propertyName) : base(propertyName) {}

        public ExceptionError(String message) : base(String.Empty, message) { }

        public override String FormatMessage(String displayName) {
            return base.Message;
        }
    }
}
