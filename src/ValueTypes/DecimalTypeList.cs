using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    /// <summary>
    /// DecimalType generic collection
    /// </summary>
    [Serializable]
    public class DecimalTypeList : System.Collections.CollectionBase, ISerializable {

        public static readonly DecimalTypeList UNSET = new DecimalTypeList(true);
        public static readonly DecimalTypeList DEFAULT = new DecimalTypeList(true);

        private readonly Boolean immutable = false;

        private DecimalTypeList(Boolean immutable) {
            this.immutable = immutable;
        }

        public DecimalTypeList() {
        }

        // Indexer implementation.
        public DecimalType this[int index] {
            get { return (DecimalType)List[index]; }
            set {
                if (!immutable) {
                    List[index] = value;
                } else {
                    throw new System.Data.ReadOnlyException();
                }
            }
        }

        public void Add(DecimalType value) {
            if (!immutable) {
                List.Add(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public Boolean Contains(DecimalType value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(DecimalType value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, DecimalType value) {
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

        public void Remove(DecimalType value) {
            if (!immutable) {
                List.Remove(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is DecimalType) {
                    Add((DecimalType)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to DecimalType");
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
        DecimalTypeList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
            for (int i = 0; i < listCount; i++) {
                List.Add((DecimalType)info.GetValue("v" + i.ToString(), typeof(DecimalType)));
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DecimalTypeList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DecimalTypeList_UNSET));
            } else {
                info.SetType(typeof(DecimalTypeList));
                info.AddValue("immutable", immutable);
                info.AddValue("listCount", List.Count);
                for (int i = 0; i < List.Count; i++) {
                    info.AddValue("v" + i.ToString(), List[i]);
                }
            }
        }

    }

    [Serializable]
    public class DecimalTypeList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DecimalTypeList.DEFAULT;
        }
    }

    [Serializable]
    public class DecimalTypeList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DecimalTypeList.UNSET;
        }
    }
}
