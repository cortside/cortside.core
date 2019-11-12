using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// DateTimeType generic collection
    /// </summary>
	[Serializable]
    public class DateTimeTypeList : System.Collections.CollectionBase, ISerializable {
	
	public static readonly DateTimeTypeList UNSET = new DateTimeTypeList(true);
	public static readonly DateTimeTypeList DEFAULT = new DateTimeTypeList(true);

	private Boolean immutable = false;
	
	private DateTimeTypeList (Boolean immutable) {
	    this.immutable = immutable;
	}

	public DateTimeTypeList() {
	}

	// Indexer implementation.
	public DateTimeType this[int index] {
	    get { return (DateTimeType) List[index]; }
	    set { 
		if (!immutable) {
		    List[index] = value;
		} else {
		    throw new System.Data.ReadOnlyException();
		}
	    }
	}

	public void Add(DateTimeType value) {
	    if (!immutable) {
		List.Add(value);
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public Boolean Contains(DateTimeType value) {
	    return List.Contains(value);
	}
	
	public Int32 IndexOf(DateTimeType value) {
	    return List.IndexOf(value);
	}
	
	public void Insert(Int32 index, DateTimeType value) {
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

	public void Remove(DateTimeType value) {
	    if (!immutable) {
		List.Remove(value); 
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public void AddRange(System.Collections.IList list) {
	    foreach(Object o in list) {
		if (o is DateTimeType) {
		    Add((DateTimeType)o);
		} else {
		    throw new System.InvalidCastException("object in list could not be cast to DateTimeType");
		}
	    }
	}
	
	public Boolean IsDefault {
	    get { return Object.ReferenceEquals(this, DEFAULT); }
	}

	public Boolean IsUnset {
	    get { return Object.ReferenceEquals(this, UNSET); }
	}
	
	public Boolean IsValid {
	    get {
		return !(IsDefault || IsUnset);
	    }
	}
 
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        DateTimeTypeList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
			for(int i = 0;i < listCount; i++) {
				List.Add((DateTimeType)info.GetValue("v" + i.ToString(), typeof(DateTimeType)));
			}
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DateTimeTypeList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DateTimeTypeList_UNSET));
            } else {
                info.SetType(typeof(DateTimeTypeList));
                info.AddValue("immutable", immutable);
				info.AddValue("listCount", List.Count);
				for(int i = 0;i < List.Count; i++) {
					info.AddValue("v" + i.ToString(), List[i]);
				}
            }
        }

    }

    [Serializable]
    public class DateTimeTypeList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTimeTypeList.DEFAULT;
        }
    }

    [Serializable]
    public class DateTimeTypeList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTimeTypeList.UNSET;
        }
    }
}
