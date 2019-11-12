using System;

using Spring2.Core.Message;

namespace Spring2.Core.Message {
 
    public class InvalidTypeFormatError : Message {

	String property = null;
	String value = null;

	public InvalidTypeFormatError(String property, String value) : base(String.Format("{1} is not a valid value for {0}.", property, value)) {
	    this.property = property;
	    this.value = value;
	}

	public String Property {
	    get {
		return this.property;
	    }
	}

	public String Value {
	    get {
		return this.value;
	    }
	}
    }
}
