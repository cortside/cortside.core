using System;

namespace Cortside.Core.Types {

    /// <summary>
    /// Summary description for DataType.
    /// </summary>
    [Serializable()]
    public abstract class DataType : IDataType {

        protected const String DEFAULT = "DEFAULT";
        protected const String UNSET = "UNSET";

        protected abstract Object Value { get; }
        public virtual Object DBValue {
            get {
                if (IsValid) {
                    return Value;
                } else {
                    return DBNull.Value;
                }
            }
        }

        public abstract Boolean IsDefault { get; }
        public abstract Boolean IsUnset { get; }

        public Boolean IsValid {
            get {
                return !(IsDefault || IsUnset);
            }
        }

        public override String ToString() {
            if (IsDefault) {
                return DEFAULT;
            } else if (IsUnset) {
                return UNSET;
            } else {
                return Value.ToString();
            }
        }

        public virtual String ToString(String format) {
            return ToString();
        }

        public virtual String Display() {
            if (!IsValid) {
                return String.Empty;
            } else {
                return Value.ToString();
            }
        }

        public override Boolean Equals(Object o) {
            DataType that = o as DataType;
            if (that == null) {
                return false;
            }
            if (ReferenceEquals(this, that)) {
                return true;
            }
            if (!this.GetType().Equals(that.GetType())) {
                return false;
            }
            if (this.IsDefault || that.IsDefault) {
                return this.IsDefault && that.IsDefault;
            }
            if (this.IsUnset || that.IsUnset) {
                return this.IsUnset && that.IsUnset;
            }
            return this.Value.Equals(that.Value);
        }

        public override Int32 GetHashCode() {
            return Value == null ? 0 : Value.GetHashCode();
        }

        protected Int32 Compare(DataType that) {

            if (this.IsDefault) {
                return that.IsDefault ? 0 : -1;
            }
            if (that.IsDefault) {
                return 1;
            }
            if (this.IsUnset) {
                return that.IsUnset ? 0 : -1;
            }
            if (that.IsUnset) {
                return 1;
            }
            return 0;
        }
    }
}
