using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Calendar = System.Globalization.Calendar;

namespace Cortside.Core.Types {

    [Serializable(), StructLayout(LayoutKind.Auto)]
    public struct DateType : IComparable, IFormattable, IConvertible, IDataType, ISerializable {
        private DateTime myValue;
        private TypeState myState;

        public static readonly DateType MinValue = new DateType(DateTime.MinValue.Date);
        public static readonly DateType MaxValue = new DateType(DateTime.MaxValue.Date);

        public static readonly DateType DEFAULT = new DateType(TypeState.DEFAULT);
        public static readonly DateType UNSET = new DateType(TypeState.UNSET);

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
        private DateType(TypeState state) {
            myState = state;
            myValue = new DateTime();
        }

        public DateType(DateTime newTime) {
            myValue = newTime.Date;
            myState = TypeState.VALID;
        }

        // TODO: why use ticks here?  what about truncation to just the date?
        public DateType(DateTimeType newTime) {
            myValue = new DateTime(newTime.Date.Ticks);
            myState = TypeState.VALID;
        }

        // TODO: what about the truncation to just a date?
        public DateType(long ticks) {
            myValue = new DateTime(ticks);
            myState = TypeState.VALID;
        }

        public DateType(int year, int month, int day) {
            myValue = new DateTime(year, month, day);
            myState = TypeState.VALID;
        }

        // TODO: truncation to just a date?
        public DateType(int year, int month, int day, Calendar calendar) {
            myValue = new DateTime(year, month, day, calendar);
            myState = TypeState.VALID;
        }
        #endregion

        #region Cast operators
        public static explicit operator DateType(DateTimeType value) {
            return new DateType(value);
        }

        public static explicit operator DateTimeType(DateType value) {
            return new DateTimeType(value.myValue.Date);
        }

        public static explicit operator DateType(DateTime value) {
            return new DateType(value);
        }

        public static explicit operator DateTime(DateType value) {
            return value.myValue.Date;
        }
        #endregion

        #region Comparison methods
        public static int Compare(DateType leftHand, DateType rightHand) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                if (leftHand.myValue.Ticks < rightHand.myValue.Ticks) {
                    return -1;
                }

                if (leftHand.myValue.Ticks == rightHand.myValue.Ticks) {
                    return 0;
                }

                if (leftHand.myValue.Ticks > rightHand.myValue.Ticks) {
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

            //should this throw an exception?
            return 0;
        }

        public int CompareTo(Object o) {
            //            if (value == null) {
            //		return 1;
            //	    }
            //
            //	    if (!(value is DateType)) {
            //		throw new InvalidArgumentException("DateType.CompareTo(object) - object must be of type DateType");
            //	    }
            //
            //	    DateType dtValue = (DateType) value;
            //
            //	    if (myValue.Ticks > dtValue.myValue.Ticks) {
            //		return 1;
            //	    }
            //
            //	    if (myValue.Ticks < dtValue.myValue.Ticks) {
            //		return -1;
            //	    }
            //
            //            return 0;

            if (!(o is DateType)) {
                throw new ArgumentException("Argument must be an instance of DateType");
            }

            DateType that = (DateType)o;

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
        #endregion

        #region Various methods for extracting parts of a DateType (Date, Now, etc..)
        public static int DaysInMonth(int year, int month) {
            return DateTime.DaysInMonth(year, month);
        }

        public DateType Date {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return new DateType(myValue.Date);
            }
        }

        public int Day {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Day;
            }
        }

        public DayOfWeek DayOfWeek {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.DayOfWeek;
            }
        }

        public int DayOfYear {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.DayOfYear;
            }
        }

        public int Month {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Month;
            }
        }

        public static DateType Now {
            get {
                return new DateType(DateTime.Now.Date);
            }
        }

        public static DateType UtcNow {
            get {
                return new DateType(DateTime.Now.ToUniversalTime().Date);
            }
        }

        public long Ticks {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Date.Ticks;
            }
        }

        public static DateType Today {
            get {
                return new DateType(DateTime.Today.Date);
            }
        }

        public int Year {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Year;
            }
        }

        public static bool IsLeapYear(int year) {
            return DateTime.IsLeapYear(year);
        }
        #endregion

        #region ParseMethods
        public static DateType Parse(String s) {
            return new DateType(DateTime.Parse(s).Date);
        }

        public static DateType Parse(String s, IFormatProvider provider) {
            return new DateType(DateTime.Parse(s, provider).Date);
        }

        public static DateType Parse(String s, IFormatProvider provider, DateTimeStyles styles) {
            return new DateType(DateTime.Parse(s, provider, styles).Date);
        }

        public static DateType ParseExact(String s, String format, IFormatProvider provider) {
            return new DateType(DateTime.ParseExact(s, format, provider).Date);
        }

        public static DateType ParseExact(String s, String format, IFormatProvider provider, DateTimeStyles style) {
            return new DateType(DateTime.ParseExact(s, format, provider, style).Date);
        }

        public static DateType ParseExact(String s, String[] formats, IFormatProvider provider, DateTimeStyles style) {
            return new DateType(DateTime.ParseExact(s, formats, provider, style).Date);
        }
        #endregion

        #region To/From DateTimeType methods
        public DateTimeType ToDateTimeType() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateTimeType(myValue.Date);
        }

        public static DateType FromDateTimeType(DateTimeType value) {
            if (!value.IsValid) {
                throw new InvalidStateException(value.ToString());
            }

            return new DateType(value.Date);
        }
        #endregion

        #region ToOADate and FromOADate methods
        public double ToOADate() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToOADate();
        }

        public static DateType FromOADate(double value) {
            return new DateType(DateTime.FromOADate(value).Date);
        }

        #endregion

        #region ToStringXX methods
        public String ToLongDateString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToLongDateString();
        }

        public String ToShortDateString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToShortDateString();
        }

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

        //Display methods
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

        public String DisplayLongDate() {
            return IsValid ? ToLongDateString() : String.Empty;
        }

        public String DisplayShortDate() {
            return IsValid ? ToShortDateString() : String.Empty;
        }

        #endregion

        #region Addition and Subtraction operators and methods
        #region Subtraction operators and methods
        public TimeSpan Subtract(DateType value) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.Subtract(value.myValue);
        }

        public DateType Subtract(TimeSpan value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateType(myValue - value);
        }

        public static DateType operator -(DateType dateToSubtractFrom, TimeSpan timeToSubtract) {
            if (!dateToSubtractFrom.IsValid) {
                throw new InvalidStateException(dateToSubtractFrom.myState);
            }

            return new DateType(dateToSubtractFrom.myValue.Ticks - timeToSubtract.Ticks);
        }

        public static TimeSpan operator -(DateType leftHand, DateType rightHand) {
            if (!leftHand.IsValid || !rightHand.IsValid) {
                throw new InvalidStateException(leftHand.myState, rightHand.myState);
            }

            return new TimeSpan(leftHand.Ticks - rightHand.Ticks);
        }
        #endregion

        #region Addition operators and methods
        public static DateType operator +(DateType dateToAddTo, TimeSpan timeToAdd) {
            if (!dateToAddTo.IsValid) {
                throw new InvalidStateException(dateToAddTo.myState);
            }

            DateTime result = new DateTime(dateToAddTo.Ticks + timeToAdd.Ticks);
            return new DateType(result.Date);
        }

        public DateType Add(TimeSpan value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTime result = new DateTime(Ticks + value.Ticks);
            return new DateType(result.Date);
        }

        public DateType AddDays(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateType(myValue.AddDays(value).Date);
        }

        public DateType AddMonths(int months) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateType(myValue.AddMonths(months).Date);
        }

        public DateType AddTicks(long value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateType(myValue.AddTicks(value).Date);
        }

        public DateType AddYears(int value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateType(myValue.AddYears(value).Date);
        }
        #endregion

        #endregion

        #region Equality operators and methods

        //what should we do here?
        //if params not valid do we fail?
        //or return false?
        public static bool Equals(DateType leftHand, DateType rightHand) {
            if (!leftHand.IsValid || !rightHand.IsValid) {
                throw new InvalidStateException(leftHand.myState, rightHand.myState);
            }

            return leftHand.myValue.Date.Ticks == rightHand.myValue.Date.Ticks;
        }

        public static bool operator ==(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator <(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator <=(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator >=(DateType leftHand, DateType rightHand) {
            return Compare(leftHand, rightHand) >= 0;
        }
        #endregion

        #region GetDateTimeFormats methods
        public String[] GetDateTimeFormats() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetDateTimeFormats();
        }

        public String[] GetDateTimeFormats(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetDateTimeFormats(provider);
        }

        public String[] GetDateTimeFormats(char format) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetDateTimeFormats(format);
        }

        public String[] GetDateTimeFormats(char format, IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetDateTimeFormats(format, provider);
        }

        public TypeCode GetTypeCode() {
            return TypeCode.DateTime;
        }
        #endregion

        #region IConvertible methods
        bool IConvertible.ToBoolean(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Boolean");
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Char");
        }

        //[CLSCompliant(false)]
        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "SByte");
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Byte");
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Int16");
        }

        //[CLSCompliant(false)]
        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "UInt16");
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Int32");
        }

        //[CLSCompliant(false)]
        uint IConvertible.ToUInt32(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "UInt32");
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Int64");
        }

        //[CLSCompliant(false)]
        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "UInt64");
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Single");
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Double");
        }

        Decimal IConvertible.ToDecimal(IFormatProvider provider) {
            throw new InvalidTypeCastException("DateType", "Decimal");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue;
        }

        //what do we do here?
        Object IConvertible.ToType(Type type, IFormatProvider provider) {
            return null;
            //            return Convert.DefaultToType((IConvertible)this, type, provider);
        }
        #endregion

        #region Object support methods
        public override int GetHashCode() {
            return IsValid ? myValue.GetHashCode() : 0;
        }

        public override bool Equals(Object value) {
            if (value is DateType) {
                //		if (!IsValid) {
                //		    throw new InvalidStateException(myState);
                //		}

                return myValue.Ticks == ((DateType)value).myValue.Ticks && myState == ((DateType)value).myState;
            }

            return false;
        }

        #endregion

        public DateType EndOfCurrentQuarter {
            get {
                DateTime result = EndOfPreviousQuarter.ToDate().AddMonths(3);
                result = result.AddDays(DateTime.DaysInMonth(result.Year, result.Month) - result.Day);
                return new DateType(result);
            }
        }

        public DateType EndOfPreviousQuarter {
            get {
                // Get to the correct month.
                DateTime result = ToDate().AddMonths(-1);
                result = result.AddMonths(-(result.Month % 3));

                // Go to the end of the month.
                result = result.AddDays(DateTime.DaysInMonth(result.Year, result.Month) - result.Day);

                return new DateType(result);
            }
        }

        public DateType FirstOfMonth {
            get {
                DateTime result = ToDate();
                return new DateType(new DateTime(result.Year, result.Month, 1));
            }
        }

        public DateType FirstOfYear {
            get {
                DateTime result = ToDate();
                return new DateType(new DateTime(result.Year, 1, 1));
            }
        }

        public DateType OneYearAgo {
            get {
                DateTime result = ToDate().AddMonths(-12);
                return new DateType(result);
            }
        }

        //	/// <summary>
        //	/// Get the date part only
        //	/// </summary>
        //	public DateType Date {
        //	    get {
        //		if (this.IsValid) {
        //		    return new DateType(new DateTime(ToDateTime().Year, ToDateTime().Month, ToDateTime().Day));
        //		} else {
        //		    return this;
        //		}
        //	    }
        //	}

        /// <summary>
        /// Get the date part only
        /// </summary>
        public DateTime ToDate() {
            return myValue.Date;
        }

        // TODO: realizing that this is would be a change in signature, is this really needed?
        public DateTime ToDateTime() {
            return myValue.Date;
        }

        //	public DateType AddDays(Double days) {
        //	    return new DateType(ToDateTime().AddDays(days));
        //	}

        public Boolean SameDayAs(DateType that) {
            return this.Date.Equals(that.Date);
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        DateType(SerializationInfo info, StreamingContext context) {
            myValue = (DateTime)info.GetValue("myValue", typeof(DateTime));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DateType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DateType_UNSET));
            } else {
                info.SetType(typeof(DateType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct DateType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateType.DEFAULT;
        }
    }

    [Serializable]
    public struct DateType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateType.UNSET;
        }
    }
}
