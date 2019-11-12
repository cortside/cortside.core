using System;
using System.Collections;

namespace Spring2.Core.Types {

    [Serializable]
    public abstract class EnumDataType : DataType {

	[System.CLSCompliant(false)]
	protected String code;
	[System.CLSCompliant(false)]
	protected String name;
	
	protected override Object Value {
	    get { return code; }
	}
	
	public String Code {
	    get { 
		if (IsDefault) {
		    return DEFAULT;
		} else if (IsUnset) {
		    return UNSET;
		} else {
		    return code;
		}
	    }
	}

	public String Name {
	    get { return ToString(); }
	}

	public override String ToString() {
	    if (IsDefault) {
		return DEFAULT;
	    } else if (IsUnset) {
		return UNSET;
	    } else {
		return name;
	    }
	}

	public override String Display() {
	    if (!IsValid) {
		return String.Empty;
	    } else {
		return ToString();
	    }
	}

	public override Boolean Equals(Object o) {
	    return ReferenceEquals(this, o);
	}

	public override int GetHashCode() {
	    return code == null ? 0 : code.GetHashCode();
	}
    }
}
