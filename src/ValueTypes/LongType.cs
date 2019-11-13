using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct LongType : System.IComparable, System.IFormattable, IDataType, ISerializable {
        private System.Int64 myValue;
        private TypeState myState;

        public const long MaxValue = System.Int64.MaxValue;
        public const long MinValue = System.Int64.MinValue;

        public static readonly LongType DEFAULT = new LongType(TypeState.DEFAULT);
        public static readonly LongType UNSET = new LongType(TypeState.UNSET);
        public static readonly LongType ZERO = new LongType(0L);

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
        public LongType(byte value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public LongType(short value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public LongType(int value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public LongType(long value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        private LongType(TypeState state) {
            myValue = 0;
            myState = state;
        }

        private LongType(LongType value) {
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

        public static LongType Parse(System.String parseString) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            LongType parsedInt64;

            parsedInt64.myValue = System.Int64.Parse(parseString);
            parsedInt64.myState = TypeState.VALID;

            return parsedInt64;
        }

        public static LongType Parse(System.String parseString, System.Globalization.NumberStyles style) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            LongType parsedInt64;

            parsedInt64.myValue = System.Int64.Parse(parseString, style);
            parsedInt64.myState = TypeState.VALID;

            return parsedInt64;
        }

        public static LongType Parse(System.String parseString, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            LongType parsedInt64;

            parsedInt64.myValue = System.Int64.Parse(parseString, formatProvider);
            parsedInt64.myState = TypeState.VALID;

            return parsedInt64;
        }

        public static LongType Parse(System.String parseString, System.Globalization.NumberStyles style, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            LongType parsedInt64;
            parsedInt64.myValue = System.Int64.Parse(parseString, style, formatProvider);
            parsedInt64.myState = TypeState.VALID;

            return parsedInt64;
        }

        #endregion

        #region To<XX> methods
        public bool ToBoolean(System.IFormatProvider formatProvider) {
            throw new NotImplementedException("System.IConvertible.ToBoolean");
        }

        public char ToChar(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToChar(myValue);
        }

        [System.CLSCompliant(false)]
        public sbyte ToSByte(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToSByte(myValue);
        }

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

        public long ToInt64() {
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

        public Decimal ToDecimal(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToDecimal(myValue);
        }
        #endregion

        #region Cast operators
        #region byte and sbyte
        public static explicit operator byte(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (byte)castFrom.myValue;
        }

        public static implicit operator LongType(byte castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }

        [System.CLSCompliant(false)]
        public static explicit operator sbyte(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (sbyte)castFrom.myValue;
        }

        [System.CLSCompliant(false)]
        public static implicit operator LongType(sbyte castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }
        #endregion

        #region short and ushort
        public static explicit operator short(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (short)castFrom.myValue;
        }

        public static implicit operator LongType(short castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }

        [System.CLSCompliant(false)]
        public static explicit operator ushort(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (ushort)castFrom.myValue;
        }

        [System.CLSCompliant(false)]
        public static implicit operator LongType(ushort castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }
        #endregion

        #region int and uint
        public static explicit operator int(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (int)castFrom.myValue;
        }

        public static implicit operator LongType(int castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }

        [System.CLSCompliant(false)]
        public static explicit operator uint(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (uint)castFrom.myValue;
        }

        [System.CLSCompliant(false)]
        public static implicit operator LongType(uint castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }
        #endregion

        #region long and ulong
        public static explicit operator long(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static implicit operator LongType(long castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }

        [System.CLSCompliant(false)]
        public static explicit operator ulong(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (ulong)castFrom.myValue;
        }

        [System.CLSCompliant(false)]
        public static implicit operator LongType(ulong castFrom) {
            LongType returnType = new LongType(castFrom);

            return returnType;
        }
        #endregion

        #region bool
        //these are way non standard
        //	public static explicit operator LongType(bool castFrom) {
        //	    LongType returnType = new LongType(castFrom);
        //
        //	    return returnType;
        //	}

        public static explicit operator bool(LongType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            //should it be 0=false, !0=true?
            if (castFrom.myValue < 0 || castFrom.myValue > 1) {
                throw new InvalidValueException("Converting from 'LongType' to 'bool', LongType value must be '1'(true) or '0'(false)");
            }

            return castFrom.myValue != 0 ? true : false;
        }
        #endregion
        #endregion

        #region Equality operators and methods
        public static int Compare(LongType leftHand, LongType rightHand) {
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

            if (rightHand.myState == TypeState.DEFAULT) {
                if (leftHand.myState == TypeState.DEFAULT) {
                    return 0;
                }

                if (leftHand.myState == TypeState.UNSET) {
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
        public static bool operator ==(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator ==(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue == rightHand;
        }

        public static bool operator !=(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue != rightHand;
        }
        #endregion
        #endregion

        #region < and > operators
        public static bool operator <(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator >(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator <(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue < rightHand;
        }

        public static bool operator >(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue > rightHand;
        }
        #endregion

        #region <= and >= operators
        public static bool operator <=(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >=(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }

        public static bool operator <=(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue <= rightHand;
        }

        public static bool operator >=(LongType leftHand, Int64 rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue >= rightHand;
        }
        #endregion

        #region Addition operators and methods
        public static LongType Add(LongType augend, LongType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            LongType result = new LongType(augend.myValue + addend.myValue);

            return result;
        }

        public static LongType operator +(LongType augend, LongType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            LongType result = new LongType(augend.myValue + addend.myValue);

            return result;
        }

        public static LongType operator +(LongType augend, long addend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            LongType result = new LongType(augend.myValue + addend);

            return result;
        }

        public static LongType operator ++(LongType augend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            LongType result = new LongType(augend.myValue + 1);

            return result;
        }

        //	public static LongType operator ++(LongType augend) {
        //	    LongType result = new LongType(augend.myValue + 1);
        //
        //	    return result;
        //	}
        #endregion

        #region Subtraction operators and methods
        public static LongType operator -(LongType minuend, LongType subtrahend) {
            if (!minuend.IsValid || !subtrahend.IsValid) {
                throw new InvalidStateException(minuend.myState, subtrahend.myState);
            }

            LongType result = new LongType(minuend.myValue - subtrahend.myValue);

            return result;
        }

        public static LongType operator -(LongType minuend, long subtrahend) {
            if (!minuend.IsValid) {
                throw new InvalidStateException(minuend.myState);
            }

            LongType result = new LongType(minuend.myValue - subtrahend);

            return result;
        }

        public static LongType operator --(LongType subtrahend) {
            if (!subtrahend.IsValid) {
                throw new InvalidStateException(subtrahend.myState);
            }

            LongType result = new LongType(subtrahend.myValue - 1);

            return result;
        }

        //	public static LongType operator --(long subtrahend) {
        //	    LongType result = new LongType(subtrahend - 1);
        //
        //	    return result;
        //	}

        #endregion

        #region Mutliplication operators and methods
        public static LongType Multiply(LongType multiplier, LongType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            LongType result = new LongType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static LongType operator *(LongType multiplier, LongType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            LongType result = new LongType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static LongType operator *(LongType multiplier, long multiplicand) {
            if (!multiplier.IsValid) {
                throw new InvalidStateException(multiplier.myState);
            }

            LongType result = new LongType(multiplier.myValue * multiplicand);

            return result;
        }
        #endregion

        #region Division operators and methods
        public static LongType Divide(LongType dividend, LongType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            LongType result = new LongType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static LongType operator /(LongType dividend, LongType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            LongType result = new LongType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static LongType operator /(LongType dividend, long divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            LongType result = new LongType(dividend.myValue / divisor);

            return result;
        }
        #endregion

        #region Modulus operators and methods
        public static LongType Remainder(LongType dividend, LongType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            LongType result = new LongType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static LongType operator %(LongType dividend, LongType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            LongType result = new LongType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static LongType operator %(LongType dividend, long divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            LongType result = new LongType(dividend.myValue % divisor);

            return result;
        }
        #endregion

        #region IComparable method

        public int CompareTo(Object o) {
            if (!(o is LongType)) {
                throw new ArgumentException("Argument must be an instance of LongType");
            }

            LongType that = (LongType)o;

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

        int IComparable.CompareTo(Object value) {
            return this.CompareTo(value);
        }

        #endregion

        #region Object support and other stuff
        public override bool Equals(Object value) {
            if (value is LongType) {
                return Compare(this, (LongType)value) == 0;
            }

            return false;
        }

        public static bool Equals(LongType leftHand, LongType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Int64;
        }
        #endregion

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        LongType(SerializationInfo info, StreamingContext context) {
            myValue = (System.Int64)info.GetValue("myValue", typeof(System.Int64));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(LongType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(LongType_UNSET));
            } else {
                info.SetType(typeof(LongType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct LongType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LongType.DEFAULT;
        }
    }

    [Serializable]
    public struct LongType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LongType.UNSET;
        }
    }
}
