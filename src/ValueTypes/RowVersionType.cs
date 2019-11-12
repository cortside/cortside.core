using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {
    /// <summary>
    /// RowVersion type for the Timestamp values in SQL Server.
    /// </summary>
    /// 
	[Serializable]
    public struct RowVersionType : IDataType, ISerializable {
	private byte[]    myValue;
	private TypeState myState;

	public static readonly RowVersionType DEFAULT = new RowVersionType(TypeState.DEFAULT);
	public static readonly RowVersionType UNSET   = new RowVersionType(TypeState.UNSET);

	#region State management
	public bool IsValid {
	    get {return myState == TypeState.VALID;}
	}

	public bool IsDefault {
	    get {return myState == TypeState.DEFAULT;}
	}

	public bool IsUnset {
	    get {return myState == TypeState.UNSET;}
	}

	#endregion

	#region Constructors
	private RowVersionType(TypeState state) {
	    myValue = null;
	    myState = state;
	}

	public RowVersionType(byte[] value) {
	    myValue = value;
	    myState = TypeState.VALID;
	}
	#endregion

	//legacy
	public static RowVersionType NewInstance(byte[] value) {
	    return new RowVersionType(value);
	}

	public byte[] DBValue {
	    get {
		if (myState != TypeState.VALID) {
		    throw new InvalidValueException(myState);
		}

		return myValue;
	    }

	    set {
		myValue = value;
		myState = TypeState.VALID;
	    }
	}

	public override String ToString() {
	    return IsValid ? this.myValue.ToString() : myState.ToString();
	}

	public String Display() {
	    return IsValid ? ToString() : String.Empty;
	}

 
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        RowVersionType(SerializationInfo info, StreamingContext context) {
            myValue = (byte[])info.GetValue("myValue", typeof(byte[]));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(RowVersionType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(RowVersionType_UNSET));
            } else {
                info.SetType(typeof(RowVersionType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct RowVersionType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return RowVersionType.DEFAULT;
        }
    }

    [Serializable]
    public struct RowVersionType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return RowVersionType.UNSET;
        }
    }
}

