using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// IdType generic collection
    /// </summary>
    [Serializable]
    public class IdTypeList : System.Collections.CollectionBase, ISerializable {

	public static readonly IdTypeList UNSET = new IdTypeList(true);
	public static readonly IdTypeList DEFAULT = new IdTypeList(true);

	private Boolean immutable = false;

	private IdTypeList(Boolean immutable) {
	    this.immutable = immutable;
	}

	public IdTypeList() {
	}

	// Indexer implementation.
	public IdType this[int index] {
	    get {
		return (IdType)List[index];
	    }
	    set {
		if (!immutable) {
		    List[index] = value;
		} else {
		    throw new System.Data.ReadOnlyException();
		}
	    }
	}

	public void Add(IdType value) {
	    if (!immutable) {
		List.Add(value);
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public Boolean Contains(IdType value) {
	    return List.Contains(value);
	}

	public Int32 IndexOf(IdType value) {
	    return List.IndexOf(value);
	}

	public void Insert(Int32 index, IdType value) {
	    if (!immutable) {
		List.Insert(index, value);
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public void Remove(int index) {
	    if (!immutable) {
		if (index > Count - 1 || index < 0) {
		    throw new IndexOutOfRangeException();
		} else {
		    List.RemoveAt(index);
		}
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public void Remove(IdType value) {
	    if (!immutable) {
		List.Remove(value);
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public void AddRange(System.Collections.IList list) {
	    foreach (Object o in list) {
		if (o is IdType) {
		    Add((IdType)o);
		} else {
		    throw new System.InvalidCastException("object in list could not be cast to IdType");
		}
	    }
	}

	public Boolean IsDefault {
	    get {
		return Object.ReferenceEquals(this, DEFAULT);
	    }
	}

	public Boolean IsUnset {
	    get {
		return Object.ReferenceEquals(this, UNSET);
	    }
	}

	public Boolean IsValid {
	    get {
		return !(IsDefault || IsUnset);
	    }
	}

	[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	IdTypeList(SerializationInfo info, StreamingContext context) {
	    immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
	    int listCount = (int)info.GetValue("listCount", typeof(int));
	    for (int i = 0; i < listCount; i++) {
		List.Add((IdType)info.GetValue("v" + i.ToString(), typeof(IdType)));
	    }
	}

	[SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
	    if (this.Equals(DEFAULT)) {
		info.SetType(typeof(IdTypeList_DEFAULT));
	    } else if (this.Equals(UNSET)) {
		info.SetType(typeof(IdTypeList_UNSET));
	    } else {
		info.SetType(typeof(IdTypeList));
		info.AddValue("immutable", immutable);
		info.AddValue("listCount", List.Count);
		for (int i = 0; i < List.Count; i++) {
		    info.AddValue("v" + i.ToString(), List[i]);
		}
	    }
	}


	public StringType ToDelimitedStringType() {
	    return ToDelimitedStringType(",");
	}

	public StringType ToDelimitedStringType(String delimiter) {
	    System.Text.StringBuilder sb = new System.Text.StringBuilder();

	    for (int index = 0; index < this.List.Count; index++) {
		sb.Append(this.List[index].ToString());
		if (index != this.List.Count - 1) {
		    sb.Append(delimiter);
		}
	    }
	    return new StringType(sb.ToString());
	}
    }

    [Serializable]
    public class IdTypeList_DEFAULT : IObjectReference {
	public object GetRealObject(StreamingContext context) {
	    return IdTypeList.DEFAULT;
	}
    }

    [Serializable]
    public class IdTypeList_UNSET : IObjectReference {
	public object GetRealObject(StreamingContext context) {
	    return IdTypeList.UNSET;
	}
    }
}
