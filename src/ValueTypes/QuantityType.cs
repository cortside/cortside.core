using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    [Serializable]
    public struct QuantityType : IComparable, IDataType, ISerializable {
        DecimalType myValue;

        public static readonly QuantityType DEFAULT = new QuantityType(TypeState.DEFAULT);
        public static readonly QuantityType UNSET = new QuantityType(TypeState.UNSET);

        #region State management
        public bool IsValid {
            get { return myValue.IsValid; }
        }

        public bool IsDefault {
            get { return myValue.IsDefault; }
        }

        public bool IsUnset {
            get { return myValue.IsUnset; }
        }

        #endregion

        #region Constructors
        private QuantityType(TypeState state) {
            if (state == TypeState.DEFAULT) {
                myValue = DecimalType.DEFAULT;
            } else if (state == TypeState.UNSET) {
                myValue = DecimalType.UNSET;
            } else {
                myValue = new DecimalType(0);
            }
        }

        public QuantityType(IntegerType value) {
            myValue = (DecimalType)value;
        }

        public QuantityType(Int32 value) {
            myValue = value;
        }

        public QuantityType(Decimal value) {
            myValue = value;
        }

        public QuantityType(Double value) {
            myValue = value;
        }
        #endregion

        #region Parse and ToString()
        public static QuantityType Parse(String value) {
            if (value == null) {
                return UNSET;
            }

            return new QuantityType(Decimal.Parse(value));
        }

        //what should we do for ToString here?
        public override string ToString() {
            return myValue.ToString();
        }

        public string Display() {
            return myValue.ToString();
        }
        #endregion

        #region Equality operators and methods
        public static int Compare(QuantityType leftHand, QuantityType rightHand) {
            return DecimalType.Compare(leftHand.myValue, rightHand.myValue);
        }

        public static bool operator ==(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator <(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator <=(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator >=(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }
        #endregion

        #region Object Support, IComparable and other stuff
        int IComparable.CompareTo(Object value) {
            if (!(value is QuantityType)) {
                throw new InvalidTypeException("QuantityType");
            }

            if (value == null) {
                throw new InvalidArgumentException("value");
            }

            QuantityType compareTo = (QuantityType)value;

            return Compare(this, compareTo);
        }

        public int CompareTo(QuantityType value) {
            return Compare(this, value);
        }

        public override bool Equals(Object value) {
            if (value is QuantityType) {
                return Compare(this, (QuantityType)value) == 0;
            }

            return false;
        }

        public static bool Equals(QuantityType leftHand, QuantityType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }
        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Decimal;
        }
        #endregion

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        QuantityType(SerializationInfo info, StreamingContext context) {
            myValue = new DecimalType((Decimal)(info.GetValue("myValue", typeof(Decimal))));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(QuantityType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(QuantityType_UNSET));
            } else {
                info.SetType(typeof(QuantityType));
                info.AddValue("myValue", myValue.ToDecimal());
            }
        }

    }

    [Serializable]
    public struct QuantityType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return QuantityType.DEFAULT;
        }
    }

    [Serializable]
    public struct QuantityType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return QuantityType.UNSET;
        }
    }
}
