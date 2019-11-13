using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Calendar = System.Globalization.Calendar;

namespace Cortside.Core.Types {

    [Serializable(), StructLayout(LayoutKind.Auto)]
    public struct DateTimeType : IComparable, IFormattable, IDataType, ISerializable {
        private DateTime myValue;
        private TypeState myState;

        public static readonly DateTimeType MINVALUE = new DateTimeType(DateTime.MinValue);
        public static readonly DateTimeType MAXVALUE = new DateTimeType(DateTime.MaxValue);

        public static readonly DateTimeType DEFAULT = new DateTimeType(TypeState.DEFAULT);
        public static readonly DateTimeType UNSET = new DateTimeType(TypeState.UNSET);

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
        private DateTimeType(TypeState state) {
            myState = state;
            myValue = new DateTime();
        }

        public DateTimeType(DateTime newTime) {
            myValue = newTime;
            myState = TypeState.VALID;
        }

        public DateTimeType(long ticks) {
            myValue = new DateTime(ticks);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day) {
            myValue = new DateTime(year, month, day);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day, Calendar calendar) {
            myValue = new DateTime(year, month, day, calendar);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day, int hour, int minute, int second) {
            myValue = new DateTime(year, month, day, hour, minute, second);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day, int hour, int minute, int second, Calendar calendar) {
            myValue = new DateTime(year, month, day, hour, minute, second, calendar);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            myValue = new DateTime(year, month, day, hour, minute, second, millisecond);
            myState = TypeState.VALID;
        }

        public DateTimeType(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) {
            myValue = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
            myState = TypeState.VALID;
        }
        #endregion

        #region Cast operators
        public static explicit operator DateType(DateTimeType value) {
            return new DateType(value.Date);
        }

        public static explicit operator DateTimeType(DateType value) {
            return value.ToDateTimeType();
        }

        public static explicit operator DateTime(DateTimeType value) {
            //should we state check this?
            return value.myValue;
        }

        public static explicit operator DateTimeType(DateTime value) {
            return new DateTimeType(value);
        }
        #endregion

        #region To/From DateType methods
        public DateType ToDateType() {
            return new DateType(myValue.Date);
        }

        public static DateTimeType FromDateType(DateType value) {
            return value.ToDateTimeType();
        }
        #endregion

        #region Comparison methods
        public static int Compare(DateTimeType leftHand, DateTimeType rightHand) {
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

            //should this throw an exception?
            return 0;
        }

        public int CompareTo(Object value) {
            if (value == null) {
                return 1;
            }

            if (!(value is DateTimeType)) {
                throw new InvalidArgumentException("DateTimeType.CompareTo(object) - object must be of type DateTimeType");
            }

            DateTimeType dtValue = (DateTimeType)value;

            if (myValue.Ticks > dtValue.myValue.Ticks) {
                return 1;
            }

            if (myValue.Ticks < dtValue.myValue.Ticks) {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Compares dates.  Assumes equal if the difference &lt; 2 minutes, otherwise like normal compare.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareNoSeconds(DateTimeType value) {
            TimeSpan span = this.myValue.Subtract(value.myValue);
            if (Math.Abs(span.Minutes) < 2) {
                return 0;
            }

            if (this.myValue.Ticks > value.myValue.Ticks) {
                return 1;
            }

            if (this.myValue.Ticks < value.myValue.Ticks) {
                return -1;
            }

            // Should never get here.
            return 0;
        }

        #endregion

        #region Various methods for extracting parts of a DateTimeType (Date, Now, etc..)
        public static int DaysInMonth(int year, int month) {
            return DateTime.DaysInMonth(year, month);
        }

        public DateTimeType Date {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return new DateTimeType(myValue.Date);
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

        public int Hour {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Hour;
            }
        }

        public int Millisecond {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Millisecond;
            }
        }

        public int Minute {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Minute;
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

        public static DateTimeType Now {
            get {
                DateTimeType now = new DateTimeType(DateTime.Now);
                return now;
            }
        }

        public static DateTimeType UtcNow {
            get {
                DateTimeType now = new DateTimeType(DateTime.Now.ToUniversalTime());
                return now;
            }
        }

        public int Second {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Second;
            }
        }

        public long Ticks {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.Ticks;
            }
        }

        public TimeSpan TimeOfDay {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue.TimeOfDay;
            }
        }

        public static DateTimeType Today {
            get {
                return new DateTimeType(DateTime.Today);
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
        public static DateTimeType Parse(String s) {
            return new DateTimeType(DateTime.Parse(s));
        }

        public static DateTimeType Parse(String s, IFormatProvider provider) {
            return new DateTimeType(DateTime.Parse(s, provider));
        }

        public static DateTimeType Parse(String s, IFormatProvider provider, DateTimeStyles styles) {
            return new DateTimeType(DateTime.Parse(s, provider, styles));
        }

        public static DateTimeType ParseExact(String s, String format, IFormatProvider provider) {
            return new DateTimeType(DateTime.ParseExact(s, format, provider));
        }

        public static DateTimeType ParseExact(String s, String format, IFormatProvider provider, DateTimeStyles style) {
            return new DateTimeType(DateTime.ParseExact(s, format, provider, style));
        }

        public static DateTimeType ParseExact(String s, String[] formats, IFormatProvider provider, DateTimeStyles style) {
            return new DateTimeType(DateTime.ParseExact(s, formats, provider, style));
        }
        #endregion

        #region To<OADate, FileTime, LocalTime, UniversalTime> and From<FileTime, OADate> methods
        public double ToOADate() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToOADate();
        }

        public long ToFileTime() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToFileTime();
        }

        public DateTimeType ToLocalTime() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateTimeType(TimeZone.CurrentTimeZone.ToLocalTime(myValue));
        }

        public DateTimeType ToUniversalTime() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateTimeType(myValue.ToUniversalTime());
        }

        public static DateTimeType FromFileTime(long fileTime) {
            if (fileTime < 0) {
                throw new InvalidArgumentException("DateTimeType.FromFileTime() - fileTime argument cannot be < 0");
            }

            DateTimeType result = new DateTimeType(DateTime.FromFileTime(fileTime));
            return result;
        }

        public static DateTimeType FromOADate(double value) {
            DateTimeType dt = new DateTimeType(DateTime.FromOADate(value));
            return dt;
        }

        #endregion

        #region ToStringXX methods
        public String ToLongDateString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToLongDateString();
        }

        public String ToLongTimeString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToLongTimeString();
        }

        public String ToShortDateString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToShortDateString();
        }

        public String ToShortTimeString() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToShortTimeString();
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

        #endregion

        #region Addition and Subtraction operators and methods
        public TimeSpan Subtract(DateTimeType value) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.Subtract(value.myValue);
        }

        public DateTimeType Subtract(TimeSpan value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new DateTimeType(myValue.Ticks - value.Ticks);
        }

        #region Addition operators and methods
        public static DateTimeType operator +(DateTimeType dateToAddTo, TimeSpan timeToAdd) {
            if (!dateToAddTo.IsValid) {
                throw new InvalidStateException(dateToAddTo.myState);
            }

            return new DateTimeType(dateToAddTo.myValue.Ticks + timeToAdd.Ticks);
        }

        public DateTimeType Add(TimeSpan value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            long newTicks = myValue.Ticks + value.Ticks;
            return new DateTimeType(newTicks);
        }

        public DateTimeType AddDays(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddDays(value));
            return newValue;
        }

        public DateTimeType AddHours(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddHours(value).Ticks);
            return newValue;
        }

        public DateTimeType AddMilliseconds(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddMilliseconds(value).Ticks);
            return newValue;
        }

        public DateTimeType AddMinutes(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddMinutes(value).Ticks);
            return newValue;
        }

        public DateTimeType AddMonths(int months) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddMonths(months));
            return newValue;
        }

        public DateTimeType AddSeconds(double value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddSeconds(value));
            return newValue;
        }

        public DateTimeType AddTicks(long value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddTicks(value).Ticks);
            return newValue;
        }

        public DateTimeType AddYears(int value) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            DateTimeType newValue = new DateTimeType(myValue.AddYears(value).Ticks);
            return newValue;
        }
        #endregion

        public static DateTimeType operator -(DateTimeType dateToSubtractFrom, TimeSpan timeToSubtract) {
            if (!dateToSubtractFrom.IsValid) {
                throw new InvalidStateException(dateToSubtractFrom.myState);
            }

            return new DateTimeType(dateToSubtractFrom.myValue.Ticks - timeToSubtract.Ticks);
        }

        public static TimeSpan operator -(DateTimeType leftHand, DateTimeType rightHand) {
            if (!leftHand.IsValid || !rightHand.IsValid) {
                throw new InvalidStateException(leftHand.myState, rightHand.myState);
            }

            return new TimeSpan(leftHand.Ticks - rightHand.Ticks);
        }
        #endregion

        #region Equality operators and methods

        //what should we do here?
        //if params not valid do we fail?
        //or return false?
        public static bool Equals(DateTimeType leftHand, DateTimeType rightHand) {
            if (!leftHand.IsValid || !rightHand.IsValid) {
                throw new InvalidStateException(leftHand.myState, rightHand.myState);
            }

            return leftHand.myValue.Ticks == rightHand.myValue.Ticks;
        }

        public static bool operator ==(DateTimeType leftHand, DateTimeType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(DateTimeType leftHand, DateTimeType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator <(DateTimeType leftHand, DateTimeType rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator <=(DateTimeType leftHand, DateTimeType rightHand) {
            return Compare(leftHand, rightHand) <= 0;
        }

        public static bool operator >(DateTimeType leftHand, DateTimeType rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator >=(DateTimeType leftHand, DateTimeType rightHand) {
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

        public DateTime ToDateTime() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue;
        }

        #region Object support methods
        public override int GetHashCode() {
            return IsValid ? myValue.GetHashCode() : 0;
        }

        public override bool Equals(Object value) {
            if (value is DateTimeType) {
                // TODO: I don't think this is needed
                //		if (!IsValid) {
                //		    throw new InvalidStateException(myState);
                //		}

                return myValue.Ticks == ((DateTimeType)value).myValue.Ticks && myState == ((DateTimeType)value).myState;
            }

            return false;
        }

        #endregion

        // TODO: should these date based methods be here as well as on DateType?
        public DateTimeType EndOfCurrentQuarter {
            get {
                DateTime result = EndOfPreviousQuarter.ToDate().AddMonths(3);
                result = result.AddDays(DateTime.DaysInMonth(result.Year, result.Month) - result.Day);
                return new DateTimeType(result);
            }
        }

        public DateTimeType EndOfPreviousQuarter {
            get {
                // Get to the correct month.
                DateTime result = ToDate().AddMonths(-1);
                result = result.AddMonths(-(result.Month % 3));

                // Go to the end of the month.
                result = result.AddDays(DateTime.DaysInMonth(result.Year, result.Month) - result.Day);

                return new DateTimeType(result);
            }
        }

        public DateTimeType FirstOfMonth {
            get {
                DateTime result = ToDate();
                return new DateTimeType(new DateTime(result.Year, result.Month, 1));
            }
        }
        public DateTimeType EndOfMonth {
            get {
                DateTime result = ToDate();
                return new DateTimeType(new DateTime(result.Year, result.Month, DaysInMonth(result.Year, result.Month)));
            }
        }

        public DateTimeType FirstOfYear {
            get {
                DateTime result = ToDate();
                return new DateTimeType(new DateTime(result.Year, 1, 1));
            }
        }

        public DateTimeType OneYearAgo {
            get {
                DateTime result = ToDate().AddMonths(-12);
                return new DateTimeType(result);
            }
        }

        /// <summary>
        /// Get the date part only
        /// </summary>
        public DateTime ToDate() {
            return myValue.Date;
        }

        public Boolean SameDayAs(DateTimeType that) {
            // TODO: what should happen for unset and default in this method?
            return this.myState == TypeState.VALID && that.myState == TypeState.VALID && this.Date.Equals(that.Date);
        }

        //this is used to indicate a default date value based on 1/1/1900
        private static DateTimeType theDefault1900 = DateTimeType.Parse("01/01/1900");

        public static DateTimeType Default1900 {
            get { return theDefault1900; }
        }

        /// <summary>
        /// Get the date part only, truncating the time
        /// </summary>
        public DateTimeType BeginningOfDay {
            get {
                if (this.IsValid) {
                    return new DateTimeType(new DateTime(ToDateTime().Year, ToDateTime().Month, ToDateTime().Day));
                } else {
                    return this;
                }
            }
        }

        /// <summary>
        /// Get the date with the very last millisecond of the day.
        /// Matches Sql Server granularity of milliseconds.
        /// </summary>
        public DateTimeType EndOfDay {
            get {
                if (this.IsValid) {
                    return new DateTimeType(new DateTime(ToDateTime().Year, ToDateTime().Month, ToDateTime().Day, 23, 59, 59, 997));
                } else {
                    return this;
                }
            }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        DateTimeType(SerializationInfo info, StreamingContext context) {
            myValue = (DateTime)info.GetValue("myValue", typeof(DateTime));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(DateTimeType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(DateTimeType_UNSET));
            } else {
                info.SetType(typeof(DateTimeType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct DateTimeType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTimeType.DEFAULT;
        }
    }

    [Serializable]
    public struct DateTimeType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return DateTimeType.UNSET;
        }
    }
}
