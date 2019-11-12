using System;

namespace Spring2.Core.Message {
 
    public class MissingRequiredFieldError : Message {

	String fieldName = String.Empty;

	public MissingRequiredFieldError(String fieldName) : base(String.Format("{0} is required.", fieldName)) {
	    this.fieldName = fieldName;
	}

	public MissingRequiredFieldError(String fieldName, String isrequired) : base(String.Format("{0}", fieldName)) {
	    this.fieldName = fieldName;
	}

	public String FieldName {
	    get {
		return this.fieldName;
	    }
	}
    }
}
