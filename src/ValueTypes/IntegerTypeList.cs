using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// IntegerType generic collection
    /// </summary>
    [Serializable]
    public class IntegerTypeList : System.Collections.CollectionBase, ISerializable {

        public static readonly IntegerTypeList UNSET = new IntegerTypeList(true);
        public static readonly IntegerTypeList DEFAULT = new IntegerTypeList(true);

        private readonly Boolean immutable = false;

        private IntegerTypeList(Boolean immutable) {
            this.immutable = immutable;
        }

        public IntegerTypeList() {
        }

        // Indexer implementation.
        public IntegerType this[int index] {
            get { return (IntegerType)List[index]; }
            set {
                if (!immutable) {
                    List[index] = value;
                } else {
                    throw new System.Data.ReadOnlyException();
                }
            }
        }

        public void Add(IntegerType value) {
            if (!immutable) {
                List.Add(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public Boolean Contains(IntegerType value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(IntegerType value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, IntegerType value) {
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

        public void Remove(IntegerType value) {
            if (!immutable) {
                List.Remove(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is IntegerType) {
                    Add((IntegerType)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to IntegerType");
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
        IntegerTypeList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
            for (int i = 0; i < listCount; i++) {
                List.Add((IntegerType)info.GetValue("v" + i.ToString(), typeof(IntegerType)));
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(IntegerTypeList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(IntegerTypeList_UNSET));
            } else {
                info.SetType(typeof(IntegerTypeList));
                info.AddValue("immutable", immutable);
                info.AddValue("listCount", List.Count);
                for (int i = 0; i < List.Count; i++) {
                    info.AddValue("v" + i.ToString(), List[i]);
                }
            }
        }

    }

    [Serializable]
    public class IntegerTypeList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IntegerTypeList.DEFAULT;
        }
    }

    [Serializable]
    public class IntegerTypeList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IntegerTypeList.UNSET;
        }
    }
}
