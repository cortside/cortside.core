using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// LocaleEnum generic collection
    /// </summary>
    [Serializable]
    public class LocaleEnumList : System.Collections.CollectionBase, ISerializable {

        public static readonly LocaleEnumList UNSET = new LocaleEnumList(true);

        public static readonly LocaleEnumList DEFAULT = new LocaleEnumList(true);

        private readonly Boolean immutable = false;

        private LocaleEnumList(Boolean immutable) {
            this.immutable = immutable;
        }

        public LocaleEnumList() {
        }

        // Indexer implementation.

        public LocaleEnum this[int index] {
            get { return (LocaleEnum)List[index]; }
            set {
                if (!immutable) {
                    List[index] = value;
                } else {
                    throw new System.Data.ReadOnlyException();
                }
            }
        }

        public void Add(LocaleEnum value) {
            if (!immutable) {
                List.Add(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public Boolean Contains(LocaleEnum value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(LocaleEnum value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, LocaleEnum value) {
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

        public void Remove(LocaleEnum value) {
            if (!immutable) {
                List.Remove(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is LocaleEnum) {
                    Add((LocaleEnum)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to LocaleEnum");
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
        LocaleEnumList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
            for (int i = 0; i < listCount; i++) {
                List.Add((LocaleEnum)info.GetValue("v" + i.ToString(), typeof(LocaleEnum)));
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(LocaleEnumList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(LocaleEnumList_UNSET));
            } else {
                info.SetType(typeof(LocaleEnumList));
                info.AddValue("immutable", immutable);
                info.AddValue("listCount", List.Count);
                for (int i = 0; i < List.Count; i++) {
                    info.AddValue("v" + i.ToString(), List[i]);
                }
            }
        }

    }

    [Serializable]
    public class LocaleEnumList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LocaleEnumList.DEFAULT;
        }
    }

    [Serializable]
    public class LocaleEnumList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LocaleEnumList.UNSET;
        }
    }
}
