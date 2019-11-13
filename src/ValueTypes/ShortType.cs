using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct ShortType : System.IComparable, System.IFormattable, IDataType, ISerializable {
        private System.Int16 myValue;
        private TypeState myState;

        public const short MaxValue = System.Int16.MaxValue;
        public const short MinValue = System.Int16.MinValue;

        public static readonly ShortType DEFAULT = new ShortType(TypeState.DEFAULT);
        public static readonly ShortType UNSET = new ShortType(TypeState.UNSET);

        #region	State management
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
        private ShortType(TypeState state) {
            myValue = 0;
            myState = state;
        }

        public ShortType(byte value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public ShortType(short value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        private ShortType(ShortType value) {
            myValue = value.myValue;
            myState = value.myState;
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

        public static ShortType Parse(System.String parseString) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            ShortType parsedInt32;

            parsedInt32.myValue = System.Int16.Parse(parseString);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        public static ShortType Parse(System.String parseString, System.Globalization.NumberStyles style) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            ShortType parsedInt32;

            parsedInt32.myValue = System.Int16.Parse(parseString, style);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        public static ShortType Parse(System.String parseString, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            ShortType parsedInt32;

            parsedInt32.myValue = System.Int16.Parse(parseString, formatProvider);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        public static ShortType Parse(System.String parseString, System.Globalization.NumberStyles style, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            ShortType parsedInt32;
            parsedInt32.myValue = System.Int16.Parse(parseString, style, formatProvider);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        #endregion

        #region ToXX conversion methods

        public byte ToByte(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToByte(myValue);
        }

        public short ToInt16(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToInt16(myValue);
        }

        public int ToInt32(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToInt32(myValue);
        }

        public long ToInt64(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue;
        }

        public float ToSingle(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToSingle(myValue);
        }

        public double ToDouble(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToDouble(myValue);
        }

        public decimal ToDecimal(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToDecimal(myValue);
        }
        #endregion

        #region Cast operators
        #region byte
        public static explicit operator byte(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (byte)castFrom.myValue;
        }

        public static implicit operator ShortType(byte castFrom) {
            ShortType returnType = new ShortType(castFrom);

            return returnType;
        }
        #endregion

        #region short
        public static implicit operator short(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static implicit operator ShortType(short castFrom) {
            ShortType returnType = new ShortType(castFrom);

            return returnType;
        }
        #endregion

        #region int
        public static implicit operator int(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static explicit operator ShortType(int castFrom) {
            ShortType returnType = new ShortType(castFrom);

            return returnType;
        }
        #endregion

        #region long
        public static implicit operator long(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static explicit operator ShortType(long castFrom) {
            ShortType returnType = new ShortType(castFrom);

            return returnType;
        }
        #endregion

        #region float
        public static explicit operator float(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static explicit operator ShortType(float castFrom) {
            ShortType returnType = new ShortType(Convert.ToInt16(castFrom));

            return returnType;
        }
        #endregion

        #region double
        public static explicit operator double(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static explicit operator ShortType(double castFrom) {
            ShortType returnType = new ShortType(Convert.ToInt16(castFrom));

            return returnType;
        }
        #endregion

        #region Decimal
        public static explicit operator Decimal(ShortType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static implicit operator ShortType(Decimal castFrom) {
            ShortType returnType = new ShortType(Convert.ToInt16(castFrom));

            return returnType;
        }
        #endregion
        #endregion

        #region Equality operators and methods
        public static int Compare(ShortType leftHand, ShortType rightHand) {
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
                    return 1;
                }

                return -1;
            }

            if (leftHand.myState == TypeState.VALID) {
                return 1;
            }

            //should this throw an exception?
            return 0;
        }

        #region Equality operators
        public static bool operator ==(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator ==(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue == rightHand;
        }

        public static bool operator !=(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue != rightHand;
        }
        #endregion
        #endregion

        #region < and > operators
        public static bool operator <(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator >(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator <(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue < rightHand;
        }

        public static bool operator >(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue > rightHand;
        }
        #endregion

        #region <= and >= operators
        public static bool operator <=(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >=(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }

        public static bool operator <=(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue <= rightHand;
        }

        public static bool operator >=(ShortType leftHand, short rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue >= rightHand;
        }
        #endregion

        #region Addition operators and methods
        public static ShortType Add(ShortType augend, ShortType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            ShortType result = new ShortType(augend.myValue + addend.myValue);

            return result;
        }

        public static ShortType operator +(ShortType augend, ShortType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            ShortType result = new ShortType(augend.myValue + addend.myValue);

            return result;
        }

        public static ShortType operator +(ShortType augend, short addend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            ShortType result = new ShortType(augend.myValue + addend);

            return result;
        }

        public static ShortType operator ++(ShortType augend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            ShortType result = new ShortType(augend.myValue + 1);

            return result;
        }

        //	public static ShortType operator ++(short augend) {
        //	    ShortType result = new ShortType(augend + 1);

        //	    return result;
        //	}
        #endregion

        #region Subtraction operators and methods
        public static ShortType operator -(ShortType minuend, ShortType subtrahend) {
            if (!minuend.IsValid || !subtrahend.IsValid) {
                throw new InvalidStateException(minuend.myState, subtrahend.myState);
            }

            ShortType result = new ShortType(minuend.myValue - subtrahend.myValue);

            return result;
        }

        public static ShortType operator -(ShortType minuend, short subtrahend) {
            if (!minuend.IsValid) {
                throw new InvalidStateException(minuend.myState);
            }

            ShortType result = new ShortType(minuend.myValue - subtrahend);

            return result;
        }

        public static ShortType operator --(ShortType subtrahend) {
            if (!subtrahend.IsValid) {
                throw new InvalidStateException(subtrahend.myState);
            }

            ShortType result = new ShortType(subtrahend.myValue - 1);

            return result;
        }

        //	public static ShortType operator --(short subtrahend) {
        //	    ShortType result = new ShortType(subtrahend - 1);

        //	    return result;
        //	}

        #endregion

        #region Mutliplication operators and methods
        public static ShortType Multiply(ShortType multiplier, ShortType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            ShortType result = new ShortType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static ShortType operator *(ShortType multiplier, ShortType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            ShortType result = new ShortType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static ShortType operator *(ShortType multiplier, short multiplicand) {
            if (!multiplier.IsValid) {
                throw new InvalidStateException(multiplier.myState);
            }

            ShortType result = new ShortType(multiplier.myValue * multiplicand);

            return result;
        }
        #endregion

        #region Division operators and methods
        public static ShortType Divide(ShortType dividend, ShortType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            ShortType result = new ShortType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static ShortType operator /(ShortType dividend, ShortType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            ShortType result = new ShortType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static ShortType operator /(ShortType dividend, short divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            ShortType result = new ShortType(dividend.myValue / divisor);

            return result;
        }
        #endregion

        #region Modulus operators and methods
        public static ShortType Remainder(ShortType dividend, ShortType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            ShortType result = new ShortType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static ShortType operator %(ShortType dividend, ShortType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            ShortType result = new ShortType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static ShortType operator %(ShortType dividend, short divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            ShortType result = new ShortType(dividend.myValue % divisor);

            return result;
        }
        #endregion

        #region IComparable method
        int IComparable.CompareTo(Object value) {
            if (!(value is ShortType)) {
                throw new InvalidTypeException("ShortType");
            }

            if (value == null) {
                throw new InvalidArgumentException("value");
            }

            ShortType compareTo = (ShortType)value;

            return Compare(this, compareTo);
        }
        #endregion

        #region Object support and other stuff
        public override bool Equals(Object value) {
            if (value is ShortType) {
                return Compare(this, (ShortType)value) == 0;
            }

            return false;
        }

        public static bool Equals(ShortType leftHand, ShortType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Int16;
        }
        #endregion

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        ShortType(SerializationInfo info, StreamingContext context) {
            myValue = (System.Int16)info.GetValue("myValue", typeof(System.Int16));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(ShortType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(ShortType_UNSET));
            } else {
                info.SetType(typeof(ShortType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct ShortType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return ShortType.DEFAULT;
        }
    }

    [Serializable]
    public struct ShortType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return ShortType.UNSET;
        }
    }
}
