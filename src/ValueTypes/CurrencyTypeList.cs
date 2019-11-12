using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// CurrencyType generic collection
    /// </summary>
	[Serializable]
    public class CurrencyTypeList : System.Collections.CollectionBase, ISerializable {
	
	public static readonly CurrencyTypeList UNSET = new CurrencyTypeList(true);
	public static readonly CurrencyTypeList DEFAULT = new CurrencyTypeList(true);

	private Boolean immutable = false;
	
	private CurrencyTypeList (Boolean immutable) {
	    this.immutable = immutable;
	}

	public CurrencyTypeList() {
	}

	// Indexer implementation.
	public CurrencyType this[int index] {
	    get { return (CurrencyType) List[index]; }
	    set { 
		if (!immutable) {
		    List[index] = value;
		} else {
		    throw new System.Data.ReadOnlyException();
		}
	    }
	}

	public void Add(CurrencyType value) {
	    if (!immutable) {
		List.Add(value);
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public Boolean Contains(CurrencyType value) {
	    return List.Contains(value);
	}
	
	public Int32 IndexOf(CurrencyType value) {
	    return List.IndexOf(value);
	}
	
	public void Insert(Int32 index, CurrencyType value) {
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

	public void Remove(CurrencyType value) {
	    if (!immutable) {
		List.Remove(value); 
	    } else {
		throw new System.Data.ReadOnlyException();
	    }
	}

	public void AddRange(System.Collections.IList list) {
	    foreach(Object o in list) {
		if (o is CurrencyType) {
		    Add((CurrencyType)o);
		} else {
		    throw new System.InvalidCastException("object in list could not be cast to CurrencyType");
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
        CurrencyTypeList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
			for(int i = 0;i < listCount; i++) {
				List.Add((CurrencyType)info.GetValue("v" + i.ToString(), typeof(CurrencyType)));
			}
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(CurrencyTypeList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(CurrencyTypeList_UNSET));
            } else {
                info.SetType(typeof(CurrencyTypeList));
                info.AddValue("immutable", immutable);
				info.AddValue("listCount", List.Count);
				for(int i = 0;i < List.Count; i++) {
					info.AddValue("v" + i.ToString(), List[i]);
				}
            }
        }

    }

    [Serializable]
    public class CurrencyTypeList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyTypeList.DEFAULT;
        }
    }

    [Serializable]
    public class CurrencyTypeList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyTypeList.UNSET;
        }
    }
}
