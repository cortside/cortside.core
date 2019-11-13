using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct DecimalType : IFormattable, IComparable, IConvertible, IDataType, ISerializable {

        private Decimal myValue;
        private TypeState myState;

        // TODO: how should these be cased?
        public static readonly DecimalType ZERO = new DecimalType(Decimal.Zero, TypeState.VALID);

        public static readonly DecimalType ONE = new DecimalType(Decimal.One, TypeState.VALID);

        public static readonly DecimalType MINUSONE = new DecimalType(Decimal.MinusOne, TypeState.VALID);

        public static readonly DecimalType MAXVALUE = new DecimalType(Decimal.MaxValue, TypeState.VALID);

        public static readonly DecimalType MINVALUE = new DecimalType(Decimal.MinValue, TypeState.VALID);

        public static readonly DecimalType DEFAULT = new DecimalType(0, TypeState.DEFAULT);
        public static readonly DecimalType UNSET = new DecimalType(0, TypeState.UNSET);

        #region State management
        public bool IsValid {
            get { return myState == TypeState.VALID; }
        }

        public bool IsDefault {
            get { return myState == TypeState.DEFAULT; }
        }

        public bool IsUnset {
            get { return myState == TypeState.UNSET; }
        }

        #endregion

        #region Constructors
        public DecimalType(byte value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(short value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(int value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(long value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(float value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(double value) {
            myValue = new decimal(value);
            myState = TypeState.VALID;
        }

        public DecimalType(Decimal value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public DecimalType(int[] bits) {
            myValue = new decimal(bits);
            myState = TypeState.VALID;
        }

        public DecimalType(int lo, int mid, int hi, bool isNegative, byte scale) {
            myValue = new decimal(lo, mid, hi, isNegative, scale);
            myState = TypeState.VALID;
        }

        //	public DecimalType(CurrencyType value) {
        ////	    myValue = value.
        //	}

        private DecimalType(decimal value, TypeState state) {
            myValue = value;
            myState = state;
        }
        #endregion

        #region Cast operators
        public static explicit operator Decimal(DecimalType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static implicit operator DecimalType(Decimal castFrom) {
            return new DecimalType(castFrom, TypeState.VALID);
        }

        public static implicit operator DecimalType(Double castFrom) {
            return new DecimalType(Convert.ToDecimal(castFrom), TypeState.VALID);
        }

        #endregion

        #region General math methods
        public static DecimalType Negate(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            DecimalType result = new DecimalType(Decimal.Negate(value.myValue), TypeState.VALID);
            return result;
        }

        //min/max aren't decimal methods but might be handy
        public static DecimalType Max(DecimalType leftHand, DecimalType rightHand) {
            if (Compare(leftHand, rightHand) >= 0) {
                return leftHand;
            }

            return rightHand;
        }

        public static DecimalType Min(DecimalType leftHand, DecimalType rightHand) {
            if (Compare(leftHand, rightHand) < 0) {
                return leftHand;
            }

            return rightHand;
        }

        public static DecimalType Round(DecimalType value, int decimals) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            DecimalType result = new DecimalType(Decimal.Round(value.myValue, decimals), TypeState.VALID);
            return result;
        }

        public static DecimalType Floor(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            DecimalType result = new DecimalType(Decimal.Floor(value.myValue), TypeState.VALID);
            return result;
        }

        public static DecimalType Truncate(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            DecimalType result = new DecimalType(Decimal.Truncate(value.myValue), TypeState.VALID);
            return result;
        }

        #endregion

        #region ToString and Parsing

        public override String ToString() {
            return IsValid ? this.myValue.ToString() : myState.ToString();
        }

        public String ToString(String format) {
            return IsValid ? this.myValue.ToString(format) : myState.ToString();
        }

        public String ToString(IFormatProvider provider) {
            return IsValid ? this.myValue.ToString(provider) : myState.ToString();
        }

        public String ToString(String format, IFormatProvider provider) {
            return IsValid ? this.myValue.ToString(format, provider) : myState.ToString();
        }

        public String Display() {
            return IsValid ? ToString() : String.Empty;
        }

        public String Display(String format) {
            return IsValid ? ToString(format) : String.Empty;
        }

        public String Display(IFormatProvider provider) {
            return IsValid ? ToString(provider) : String.Empty;
        }

        public String Display(String format, IFormatProvider provider) {
            return IsValid ? ToString(format, provider) : String.Empty;
        }

        public static DecimalType Parse(String from) {
            return Parse(from, NumberStyles.Number, null);
        }

        public static DecimalType Parse(String from, NumberStyles style) {
            return Parse(from, style, null);
        }

        public static DecimalType Parse(String from, IFormatProvider provider) {
            DecimalType result;
            result.myValue = Decimal.Parse(from, provider);
            result.myState = TypeState.VALID;

            return result;
        }

        public static DecimalType Parse(String from, NumberStyles style, IFormatProvider provider) {
            DecimalType result;
            result.myValue = Decimal.Parse(from, style, provider);
            result.myState = TypeState.VALID;

            return result;
        }

        #endregion

        #region To<type> conversion methods
        public static byte ToByte(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToByte(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "byte");
            }
        }

        [CLSCompliant(false)]
        public static sbyte ToSByte(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToSByte(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "sbyte");
            }
        }

        public static short ToInt16(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToInt16(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "short");
            }
        }

        [CLSCompliant(false)]
        public static ushort ToUInt16(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToUInt16(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "ushort");
            }
        }

        public static int ToInt32(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToInt32(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "int");
            }
        }

        [CLSCompliant(false)]
        public static uint ToUInt32(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToUInt32(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "uint");
            }
        }

        public static long ToInt64(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToInt64(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "long");
            }
        }

        [CLSCompliant(false)]
        public static ulong ToUInt64(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToUInt64(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "ulong");
            }
        }

        public static double ToDouble(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToDouble(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "double");
            }
        }

        public static float ToSingle(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            try {
                return Decimal.ToSingle(value.myValue);
            } catch (OverflowException) {
                throw new ValueOverflowException("DecimalType", "float");
            }
        }

        #endregion

        #region Conversion Operators

        public static implicit operator DecimalType(byte value) {
            return new DecimalType(value);
        }

        [CLSCompliant(false)]
        public static implicit operator DecimalType(sbyte value) {
            return new DecimalType(value);
        }

        public static implicit operator DecimalType(short value) {
            return new DecimalType(value);
        }

        [CLSCompliant(false)]
        public static implicit operator DecimalType(ushort value) {
            return new DecimalType(value);
        }

        public static implicit operator DecimalType(char value) {
            return new DecimalType(value);
        }

        public static implicit operator DecimalType(int value) {
            return new DecimalType(value);
        }

        [CLSCompliant(false)]
        public static implicit operator DecimalType(uint value) {
            return new DecimalType(value);
        }

        public static implicit operator DecimalType(long value) {
            return new DecimalType(value);
        }

        //        [CLSCompliant(false)]
        //        public static implicit operator DecimalType(ulong value) {
        //            return new DecimalType(value);
        //        }

        public static explicit operator DecimalType(float value) {
            return new DecimalType(value);
        }

        public static explicit operator byte(DecimalType value) {
            return ToByte(value);
        }

        [CLSCompliant(false)]
        public static explicit operator sbyte(DecimalType value) {
            return ToSByte(value);
        }

        public static explicit operator char(DecimalType value) {
            return (char)ToUInt16(value);
        }

        public static explicit operator short(DecimalType value) {
            return ToInt16(value);
        }

        [CLSCompliant(false)]
        public static explicit operator ushort(DecimalType value) {
            return ToUInt16(value);
        }

        public static explicit operator int(DecimalType value) {
            return ToInt32(value);
        }

        [CLSCompliant(false)]
        public static explicit operator uint(DecimalType value) {
            return ToUInt32(value);
        }

        public static explicit operator long(DecimalType value) {
            return ToInt64(value);
        }

        [CLSCompliant(false)]
        public static explicit operator ulong(DecimalType value) {
            return ToUInt64(value);
        }

        public static explicit operator float(DecimalType value) {
            return ToSingle(value);
        }

        public static explicit operator double(DecimalType value) {
            return ToDouble(value);
        }

        #endregion

        #region Addition operators and methods

        public static DecimalType Add(DecimalType augend, DecimalType addend) {
            if (augend.myState != TypeState.VALID || addend.myState != TypeState.VALID) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            DecimalType result;

            result.myValue = decimal.Add(augend.myValue, addend.myValue);
            result.myState = TypeState.VALID;
            return result;
        }

        public static DecimalType operator ++(DecimalType augend) {
            return Add(augend, ONE);
        }

        public static DecimalType operator +(DecimalType augend, DecimalType addend) {
            return Add(augend, addend);
        }

        public static DecimalType operator +(DecimalType augend) {
            return augend;
        }

        #endregion

        #region Subtraction operators and methods

        public static DecimalType Subtract(DecimalType minuend, DecimalType subtrahend) {
            if (minuend.myState != TypeState.VALID || subtrahend.myState != TypeState.VALID) {
                throw new InvalidStateException(minuend.myState, subtrahend.myState);
            }

            DecimalType result = new DecimalType(Decimal.Subtract(minuend.myValue, subtrahend.myValue), TypeState.VALID);

            return result;
        }

        public static DecimalType operator --(DecimalType minuend) {
            return Subtract(minuend, ONE);
        }

        public static DecimalType operator -(DecimalType minuend, DecimalType subtrahend) {
            return Subtract(minuend, subtrahend);
        }

        #endregion

        #region Multiplication operators and methods

        public static DecimalType Multiply(DecimalType multiplier, DecimalType multiplicand) {
            if (multiplier.myState != TypeState.VALID || multiplicand.myState != TypeState.VALID) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            DecimalType quotient = new DecimalType(Decimal.Multiply(multiplier.myValue, multiplicand.myValue), TypeState.VALID);

            return quotient;
        }

        public static DecimalType operator *(DecimalType multiplier, DecimalType multiplicand) {
            return Multiply(multiplier, multiplicand);
        }

        #endregion

        #region Division operators and methods

        public static DecimalType Divide(DecimalType dividend, DecimalType divisor) {
            if (dividend.myState != TypeState.VALID || divisor.myState != TypeState.VALID) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            DecimalType quotient = new DecimalType(Decimal.Divide(dividend.myValue, divisor.myValue), TypeState.VALID);

            return quotient;
        }

        public static DecimalType operator /(DecimalType dividend, DecimalType divisor) {
            return Divide(dividend, divisor);
        }

        #endregion

        #region Modulus operators and methods

        public static DecimalType Remainder(DecimalType dividend, DecimalType divisor) {
            if (dividend.myState != TypeState.VALID || divisor.myState != TypeState.VALID) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            DecimalType remainder;
            remainder.myValue = decimal.Remainder(dividend.myValue, divisor.myValue);
            remainder.myState = TypeState.VALID;

            return remainder;
        }

        public static DecimalType operator %(DecimalType dividend, DecimalType divisor) {
            return Remainder(dividend, divisor);
        }

        #endregion

        #region Equality operators and methods
        public static int Compare(DecimalType leftHand, DecimalType rightHand) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                if (leftHand.myValue < rightHand.myValue) {
                    return -1;
                }

                if (leftHand.myValue == rightHand.myValue) {
                    return 0;
                }

                if (leftHand.myValue > rightHand.myValue) {
                    return 1;
                }
            }

            if (leftHand.myState == TypeState.UNSET) {
                if (rightHand.myState == TypeState.DEFAULT || rightHand.myState == TypeState.VALID) {
                    return -1;
                }

                if (rightHand.myState == TypeState.UNSET) {
                    return 0;
                }
            }

            if (leftHand.myState == TypeState.DEFAULT) {
                if (rightHand.myState == TypeState.DEFAULT) {
                    return 0;
                }

                if (rightHand.myState == TypeState.UNSET) {
                    return -1;
                }

                return -1;
            }

            if (leftHand.myState == TypeState.VALID) {
                return 1;
            }

            //should this throw an exception?
            return 0;
        }

        public static bool operator ==(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator <(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator <=(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator >=(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }

        #endregion

        #region IConvertible and other conversions

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            return Convert.ToBoolean(this);
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            throw new InvalidTypeCastException("Decimal", "Char");
        }

        //[CLSCompliant(false)]
        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(this);
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            return Convert.ToByte(this);
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(this);
        }

        //[CLSCompliant(false)]
        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(this);
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(this);
        }

        //[CLSCompliant(false)]
        uint IConvertible.ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(this);
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(this);
        }

        //[CLSCompliant(false)]
        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(this);
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(this);
        }

        public double ToDouble() {
            return DecimalType.ToDouble(this);
        }

        public Int32 ToInt32() {
            return DecimalType.ToInt32(this);
        }

        public double ToInt64() {
            return DecimalType.ToInt64(this);
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            return Convert.ToDouble(this);
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider) {
            Decimal d = Convert.ToDecimal(this.myValue);
            return d;
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            throw new InvalidTypeCastException("Decimal", "DateTime");
        }

        Object IConvertible.ToType(Type type, IFormatProvider provider) {
            return null;
            //            return Convert.DefaultToType((IConvertible)this, type, provider);
        }

        #endregion

        #region Object Support and other stuff
        int IComparable.CompareTo(Object value) {
            if (!(value is DecimalType)) {
                throw new InvalidTypeException("DecimalType");
            }

            if (value == null) {
                throw new InvalidArgumentException("value");
            }

            DecimalType compareTo = (DecimalType)value;

            return Compare(this, compareTo);
        }

        public int CompareTo(DecimalType that) {
            //	    if (!(o is DecimalType)) {
            //		throw new ArgumentException("Argument must be an instance of DecimalType");
            //	    }
            //
            //	    DecimalType that = (DecimalType)o;

            if (this.myState == TypeState.DEFAULT) {
                if (that.myState == TypeState.DEFAULT) {
                    return 0;
                } else {
                    return -1;
                }
            }

            if (this.myState == TypeState.UNSET) {
                if (that.myState == TypeState.UNSET) {
                    return 0;
                } else if (that.myState == TypeState.DEFAULT) {
                    return 1;
                } else {
                    return -1;
                }
            }

            if (that.myState != TypeState.VALID) {
                return 1;
            }

            if (this.IsValid && that.IsValid) {
                return myValue.CompareTo(that.myValue);
            }

            //return Compare(that);
            return Compare(this, that);
        }

        public override bool Equals(Object value) {
            if (value is DecimalType) {
                return Compare(this, (DecimalType)value) == 0;
            }

            return false;
        }

        public static bool Equals(DecimalType leftHand, DecimalType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }
        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public static int[] GetBits(DecimalType value) {
            if (value.myState != TypeState.VALID) {
                throw new InvalidStateException(value.myState);
            }

            return decimal.GetBits(value.myValue);
            //	    return new int[] {value.myValue.lo, value.myValue.mid, value.myValue.hi, value.myValue.flags};
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Decimal;
        }

        #endregion

        public Decimal ToDecimal() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue;
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        DecimalType(SerializationInfo info, StreamingContext context) {
            myValue = (Decimal)info.GetValue("myValue", typeof(Decimal));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DecimalType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DecimalType_UNSET));
            } else {
                info.SetType(typeof(DecimalType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct DecimalType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DecimalType.DEFAULT;
        }
    }

    [Serializable]
    public struct DecimalType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DecimalType.UNSET;
        }
    }
}
