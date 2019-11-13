using System;

namespace Cortside.Core.Util {
    /// <summary>
    /// Summary description for ParseError.
    /// </summary>
    public class ParseError : ApplicationError {
        public ParseError(String propertyName) : base(propertyName) { }

        public ParseError(String propertyName, String message) : base(propertyName, message) { }

        public override String FormatMessage(String displayName) {
            return "The value entered for " + displayName + " is not valid.";
        }
    }
}
