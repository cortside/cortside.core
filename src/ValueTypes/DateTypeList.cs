using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    /// <summary>
    /// DateType generic collection
    /// </summary>
    [Serializable]
    public class DateTypeList : System.Collections.CollectionBase, ISerializable {

        public static readonly DateTypeList UNSET = new DateTypeList(true);
        public static readonly DateTypeList DEFAULT = new DateTypeList(true);

        private readonly Boolean immutable = false;

        private DateTypeList(Boolean immutable) {
            this.immutable = immutable;
        }

        public DateTypeList() {
        }

        // Indexer implementation.
        public DateType this[int index] {
            get { return (DateType)List[index]; }
            set {
                if (!immutable) {
                    List[index] = value;
                } else {
                    throw new System.Data.ReadOnlyException();
                }
            }
        }

        public void Add(DateType value) {
            if (!immutable) {
                List.Add(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public Boolean Contains(DateType value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(DateType value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, DateType value) {
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

        public void Remove(DateType value) {
            if (!immutable) {
                List.Remove(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is DateType) {
                    Add((DateType)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to DateType");
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
        DateTypeList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
            for (int i = 0; i < listCount; i++) {
                List.Add((DateType)info.GetValue("v" + i.ToString(), typeof(DateType)));
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DateTypeList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DateTypeList_UNSET));
            } else {
                info.SetType(typeof(DateTypeList));
                info.AddValue("immutable", immutable);
                info.AddValue("listCount", List.Count);
                for (int i = 0; i < List.Count; i++) {
                    info.AddValue("v" + i.ToString(), List[i]);
                }
            }
        }

    }

    [Serializable]
    public class DateTypeList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTypeList.DEFAULT;
        }
    }

    [Serializable]
    public class DateTypeList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTypeList.UNSET;
        }
    }
}
