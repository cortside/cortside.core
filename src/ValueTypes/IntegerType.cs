using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct IntegerType : System.IComparable, System.IFormattable, IDataType, ISerializable {
        private System.Int32 myValue;
        private TypeState myState;

        public static readonly IntegerType ZERO = new IntegerType(0);

        public const int MaxValue = System.Int32.MaxValue;
        public const int MinValue = System.Int32.MinValue;

        public static readonly IntegerType DEFAULT = new IntegerType(TypeState.DEFAULT);
        public static readonly IntegerType UNSET = new IntegerType(TypeState.UNSET);

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
        private IntegerType(TypeState state) {
            myValue = 0;
            myState = state;
        }

        //should this stay private?
        private IntegerType(IntegerType value) {
            myValue = value.myValue;
            myState = value.myState;
        }

        public IntegerType(byte value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public IntegerType(short value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public IntegerType(int value) {
            myValue = value;
            myState = TypeState.VALID;
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

        public static IntegerType Parse(System.String from) {
            if (from == null) {
                throw new InvalidArgumentException("parseString");
            }

            return Parse(from, NumberStyles.Currency, null);

            //	    IntegerType parsedInt32;
            //
            //	    parsedInt32.myValue = System.Int32.Parse(parseString);
            //	    parsedInt32.myState = TypeState.VALID;
            //
            //	    return parsedInt32;
        }

        public static IntegerType Parse(System.String parseString, System.Globalization.NumberStyles style) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            IntegerType parsedInt32;

            parsedInt32.myValue = System.Int32.Parse(parseString, style);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        public static IntegerType Parse(System.String parseString, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            IntegerType parsedInt32;

            parsedInt32.myValue = System.Int32.Parse(parseString, formatProvider);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        public static IntegerType Parse(System.String parseString, System.Globalization.NumberStyles style, System.IFormatProvider formatProvider) {
            if (parseString == null) {
                throw new InvalidArgumentException("parseString");
            }

            IntegerType parsedInt32;
            parsedInt32.myValue = System.Int32.Parse(parseString, style, formatProvider);
            parsedInt32.myState = TypeState.VALID;

            return parsedInt32;
        }

        #endregion

        #region To<XX> methods
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

        public int ToInt32() {
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

        public Decimal ToDecimal(System.IFormatProvider formatProvider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return System.Convert.ToDecimal(myValue);
        }
        #endregion

        #region Cast operators
        #region byte
        public static implicit operator IntegerType(byte castFrom) {
            IntegerType returnType = new IntegerType(castFrom);

            return returnType;
        }

        public static explicit operator byte(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (byte)castFrom.myValue;
        }

        public static explicit operator Int32(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        #endregion

        #region short
        public static explicit operator short(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return (short)castFrom.myValue;
        }

        public static implicit operator IntegerType(short castFrom) {
            IntegerType returnType = new IntegerType(castFrom);

            return returnType;
        }
        #endregion

        #region int
        //	public static implicit operator int(IntegerType castFrom) {
        //	    if (!castFrom.IsValid) {
        //		throw new InvalidStateException(castFrom.myState);
        //	    }
        //
        //	    return castFrom.myValue;
        //	}

        public static implicit operator IntegerType(int castFrom) {
            IntegerType returnType = new IntegerType(castFrom);

            return returnType;
        }
        #endregion

        #region long
        public static implicit operator long(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }
        //	public static explicit operator IntegerType(long castFrom) {
        //	    IntegerType returnType = new IntegerType(castFrom);
        //
        //	    return returnType;
        //	}
        #endregion

        #region Decimal	and DecimalType
        public static explicit operator Decimal(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return castFrom.myValue;
        }

        public static explicit operator IntegerType(Decimal castFrom) {
            IntegerType returnType = new IntegerType(Convert.ToInt32(castFrom));

            return returnType;
        }

        public static explicit operator DecimalType(IntegerType castFrom) {
            if (!castFrom.IsValid) {
                throw new InvalidStateException(castFrom.myState);
            }

            return new DecimalType(castFrom.myValue);
        }

        public static explicit operator IntegerType(DecimalType castFrom) {
            IntegerType returnType = new IntegerType(Convert.ToInt32(castFrom));

            return returnType;
        }
        #endregion
        #endregion

        #region Equality operators and methods
        public static int Compare(IntegerType leftHand, IntegerType rightHand) {
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
        public static bool operator ==(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator ==(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue == rightHand;
        }

        public static bool operator !=(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue != rightHand;
        }
        #endregion
        #endregion

        #region < and > operators
        public static bool operator <(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator >(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator <(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue < rightHand;
        }

        public static bool operator >(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue > rightHand;
        }
        #endregion

        #region <= and >= operators
        public static bool operator <=(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >=(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }

        public static bool operator <=(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue <= rightHand;
        }

        public static bool operator >=(IntegerType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue >= rightHand;
        }
        #endregion

        #region Addition operators and methods
        public static IntegerType Add(IntegerType augend, IntegerType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            IntegerType result = new IntegerType(augend.myValue + addend.myValue);

            return result;
        }

        public static IntegerType operator +(IntegerType augend, IntegerType addend) {
            if (!augend.IsValid || !addend.IsValid) {
                throw new InvalidStateException(augend.myState, addend.myState);
            }

            IntegerType result = new IntegerType(augend.myValue + addend.myValue);

            return result;
        }

        public static IntegerType operator +(IntegerType augend, int addend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            IntegerType result = new IntegerType(augend.myValue + addend);

            return result;
        }

        public static IntegerType operator ++(IntegerType augend) {
            if (!augend.IsValid) {
                throw new InvalidStateException(augend.myState);
            }

            IntegerType result = new IntegerType(augend.myValue + 1);

            return result;
        }

        //	public static IntegerType operator ++(int augend) {
        //	    IntegerType result = new IntegerType(augend + 1);

        //	    return result;
        //	}
        #endregion

        #region Subtraction operators and methods
        public static IntegerType operator -(IntegerType minuend, IntegerType subtrahend) {
            if (!minuend.IsValid || !subtrahend.IsValid) {
                throw new InvalidStateException(minuend.myState, subtrahend.myState);
            }

            IntegerType result = new IntegerType(minuend.myValue - subtrahend.myValue);

            return result;
        }

        public static IntegerType operator -(IntegerType minuend, int subtrahend) {
            if (!minuend.IsValid) {
                throw new InvalidStateException(minuend.myState);
            }

            IntegerType result = new IntegerType(minuend.myValue - subtrahend);

            return result;
        }

        public static IntegerType operator --(IntegerType subtrahend) {
            if (!subtrahend.IsValid) {
                throw new InvalidStateException(subtrahend.myState);
            }

            IntegerType result = new IntegerType(subtrahend.myValue - 1);

            return result;
        }

        //	public static IntegerType operator --(int subtrahend) {
        //	    IntegerType result = new IntegerType(subtrahend - 1);

        //	    return result;
        //	}

        #endregion

        #region Mutliplication operators and methods
        public static IntegerType Multiply(IntegerType multiplier, IntegerType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            IntegerType result = new IntegerType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static IntegerType operator *(IntegerType multiplier, IntegerType multiplicand) {
            if (!multiplier.IsValid || !multiplicand.IsValid) {
                throw new InvalidStateException(multiplier.myState, multiplicand.myState);
            }

            IntegerType result = new IntegerType(multiplier.myValue * multiplicand.myValue);

            return result;
        }

        public static IntegerType operator *(IntegerType multiplier, int multiplicand) {
            if (!multiplier.IsValid) {
                throw new InvalidStateException(multiplier.myState);
            }

            IntegerType result = new IntegerType(multiplier.myValue * multiplicand);

            return result;
        }
        #endregion

        #region Division operators and methods
        public static IntegerType Divide(IntegerType dividend, IntegerType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static IntegerType operator /(IntegerType dividend, IntegerType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue / divisor.myValue);

            return result;
        }

        public static IntegerType operator /(IntegerType dividend, int divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue / divisor);

            return result;
        }
        #endregion

        #region Modulus operators and methods
        public static IntegerType Remainder(IntegerType dividend, IntegerType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static IntegerType operator %(IntegerType dividend, IntegerType divisor) {
            if (!dividend.IsValid || !divisor.IsValid) {
                throw new InvalidStateException(dividend.myState, divisor.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue % divisor.myValue);

            return result;
        }

        public static IntegerType operator %(IntegerType dividend, int divisor) {
            if (!dividend.IsValid) {
                throw new InvalidStateException(dividend.myState);
            }

            IntegerType result = new IntegerType(dividend.myValue % divisor);

            return result;
        }
        #endregion

        #region IComparable method

        public Int32 CompareTo(Object o) {
            if (!(o is IntegerType)) {
                throw new ArgumentException("Argument must be an instance of IntegerType");
            }

            IntegerType that = (IntegerType)o;

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
            if (value is IntegerType) {
                return Compare(this, (IntegerType)value) == 0;
            }

            return false;
        }

        public static bool Equals(IntegerType leftHand, IntegerType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public TypeCode GetTypeCode() {
            return TypeCode.Int32;
        }
        #endregion

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        IntegerType(SerializationInfo info, StreamingContext context) {
            myValue = (System.Int32)info.GetValue("myValue", typeof(System.Int32));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(IntegerType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(IntegerType_UNSET));
            } else {
                info.SetType(typeof(IntegerType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct IntegerType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IntegerType.DEFAULT;
        }
    }

    [Serializable]
    public struct IntegerType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IntegerType.UNSET;
        }
    }
}
