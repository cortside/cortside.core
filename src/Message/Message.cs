using System;
using System.Collections;

namespace Spring2.Core.Message {
 
    /// <summary>
    /// Abstract base class for messages.
    /// </summary>
    public abstract class Message : ApplicationException {

	private Object[] properties = new Object[0];
	private String key = String.Empty;

	protected Message(String key, params Object[] properties) : base(key) {
	    this.key = key;
	    this.properties = properties;
	}

	protected Message(String key, Exception innerException, params Object[] properties) : base(key, innerException) {
	    this.key = key;
	    this.properties = properties;
	}

	public String Key {
	    get {
		return this.key;
	    }
	}

	public Object[] Properties {
	    get {
		return this.properties;
	    }
	}
    }
}
