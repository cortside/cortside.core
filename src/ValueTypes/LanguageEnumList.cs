using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// LanguageEnum generic collection
    /// </summary>
    [Serializable]
    public class LanguageEnumList : System.Collections.CollectionBase, ISerializable {

        public static readonly LanguageEnumList UNSET = new LanguageEnumList(true);

        public static readonly LanguageEnumList DEFAULT = new LanguageEnumList(true);

        private readonly Boolean immutable = false;

        private LanguageEnumList(Boolean immutable) {
            this.immutable = immutable;
        }

        public LanguageEnumList() {
        }

        // Indexer implementation.

        public LanguageEnum this[int index] {
            get { return (LanguageEnum)List[index]; }
            set {
                if (!immutable) {
                    List[index] = value;
                } else {
                    throw new System.Data.ReadOnlyException();
                }
            }
        }

        public void Add(LanguageEnum value) {
            if (!immutable) {
                List.Add(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public Boolean Contains(LanguageEnum value) {
            return List.Contains(value);
        }

        public Int32 IndexOf(LanguageEnum value) {
            return List.IndexOf(value);
        }

        public void Insert(Int32 index, LanguageEnum value) {
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

        public void Remove(LanguageEnum value) {
            if (!immutable) {
                List.Remove(value);
            } else {
                throw new System.Data.ReadOnlyException();
            }
        }

        public void AddRange(System.Collections.IList list) {
            foreach (Object o in list) {
                if (o is LanguageEnum) {
                    Add((LanguageEnum)o);
                } else {
                    throw new System.InvalidCastException("object in list could not be cast to LanguageEnum");
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
        LanguageEnumList(SerializationInfo info, StreamingContext context) {
            immutable = (Boolean)info.GetValue("immutable", typeof(Boolean));
            int listCount = (int)info.GetValue("listCount", typeof(int));
            for (int i = 0; i < listCount; i++) {
                List.Add((LanguageEnum)info.GetValue("v" + i.ToString(), typeof(LanguageEnum)));
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(LanguageEnumList_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(LanguageEnumList_UNSET));
            } else {
                info.SetType(typeof(LanguageEnumList));
                info.AddValue("immutable", immutable);
                info.AddValue("listCount", List.Count);
                for (int i = 0; i < List.Count; i++) {
                    info.AddValue("v" + i.ToString(), List[i]);
                }
            }
        }

    }

    [Serializable]
    public class LanguageEnumList_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnumList.DEFAULT;
        }
    }

    [Serializable]
    public class LanguageEnumList_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnumList.UNSET;
        }
    }
}
