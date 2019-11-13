using System;

namespace Spring2.Core.Util {
 
    /// <summary>
    /// Summary description for MissingRequiredFieldError.
    /// </summary>
    public class MissingRequiredFieldError : ApplicationError {

	public MissingRequiredFieldError(String propertyName) : base(propertyName) {}

	public override String FormatMessage(String displayName) {
	    return displayName + " is a required field.";
	}
    }
}
