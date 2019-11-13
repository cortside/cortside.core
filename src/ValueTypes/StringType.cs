using System;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    [Serializable]
    public struct StringType : IComparable, ICloneable, IEnumerable, IDataType, ISerializable {

        private string myValue;
        private TypeState myState;

        public static readonly StringType DEFAULT = new StringType(TypeState.DEFAULT);
        public static readonly StringType UNSET = new StringType(TypeState.UNSET);

        public static readonly StringType EMPTY = new StringType("");

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
        private StringType(TypeState state) {
            myState = state;
            myValue = "";
        }

        //    	[CLSCompliant(false)]
        //        unsafe public StringType(char *value) {
        //	    myState = TypeState.VALID;
        //	    myValue = new string(value);
        //	}
        //
        //	[CLSCompliant(false)]
        //        unsafe public StringType(char *value, int startIndex, int length) {
        //	    myState = TypeState.VALID;
        //	    myValue = new string(value, startIndex, length);
        //	}
        //    
        //    	[CLSCompliant(false)]
        //        unsafe public StringType(sbyte *value) {
        //	    myState = TypeState.VALID;
        //	    myValue = new string(value);
        //	}
        //
        //	unsafe public StringType(sbyte *value, int startIndex, int length) {
        //	    myState = TypeState.VALID;
        //	    myValue = new string(value, startIndex, length);
        //	}
        //
        //    	[CLSCompliant(false)]
        //        unsafe public StringType(sbyte *value, int startIndex, int length, Encoding enc) {
        //	    myState = TypeState.VALID;
        //	    myValue = new string(value, startIndex, length, enc);
        //	}

        public StringType(char[] value, int startIndex, int length) {
            myState = TypeState.VALID;
            myValue = new string(value, startIndex, length);
        }

        public StringType(char[] value) {
            myState = TypeState.VALID;
            myValue = new string(value);
        }

        public StringType(char c, int count) {
            myState = TypeState.VALID;
            myValue = new string(c, count);
        }

        public StringType(string value) {
            myState = TypeState.VALID;
            myValue = value;
        }

        //this might not be necessary
        private StringType(string value, TypeState state) {
            myValue = value;
            myState = state;
        }
        #endregion

        #region Cast operators
        public static implicit operator StringType(string value) {
            //should this be an exception?
            if (value == null) {
                return UNSET;
            }

            return new StringType(value);
        }

        public static implicit operator string(StringType value) {
            if (value == null || !value.IsValid) {
                return null;
            }

            return value.myValue;
        }
        #endregion

        #region Join methods
        public static StringType Join(StringType separator, StringType[] value) {
            if (value == null) {
                throw new InvalidArgumentException("value");
            }

            return Join(separator, value, 0, value.Length);
        }

        public static StringType Join(string separator, StringType[] value, int startIndex, int count) {
            string[] nativeValue = new string[value.Length];

            int index = 0;
            foreach (StringType item in value) {
                if (!item.IsValid) {
                    throw new InvalidStateException(item.myState);
                }

                nativeValue[index++] = item.myValue;
            }

            string joinedString = string.Join(separator, nativeValue, startIndex, count);

            return new StringType(joinedString);
        }
        #endregion

        #region Equality methods and operators
        public override bool Equals(Object obj) {
            if (!(obj is StringType)) {
                return false;
            }

            return StringType.Equals(this, (StringType)obj);
        }

        public bool Equals(StringType value) {
            return StringType.Equals(this, value);
        }

        public static bool Equals(StringType leftHand, StringType rightHand) {
            if ((Object)leftHand == (Object)rightHand) {
                return true;
            }

            if ((Object)leftHand == null || (Object)rightHand == null) {
                return false;
            }

            return leftHand.myValue == rightHand.myValue && leftHand.myState.Equals(rightHand.myState);
        }

        public static bool operator ==(StringType leftHand, StringType rightHand) {
            return StringType.Equals(leftHand, rightHand);
        }

        public static bool operator !=(StringType leftHand, StringType rightHand) {
            return !StringType.Equals(leftHand, rightHand);
        }

        //        public static bool operator == (StringType leftHand, StringType rightHand) {
        //           return !StringType.Equals(leftHand, rightHand);
        //        }
        #endregion

        #region [] operator and Length property
        public char this[int index] {
            get {
                if (!IsValid) {
                    throw new InvalidStateException(myState);
                }

                return myValue[index];
            }
        }

        /// <summary>
        /// Read only property to get the length of the underlying string.
        /// Returns -1 if the instance is not valid.
        /// </summary>
        public Int32 Length {
            get { return IsValid ? myValue.Length : -1; }
        }
        #endregion

        #region CopyTo and ToCharArray
        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            myValue.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public char[] ToCharArray() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToCharArray();
        }

        public char[] ToCharArray(int startIndex, int length) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.ToCharArray(startIndex, length);
        }
        #endregion

        public static StringType Parse(string value) {
            return new StringType(value);
        }

        internal StringType[] NativeToStringType(string[] nativeStrings) {
            StringType[] newStrings = new StringType[nativeStrings.Length];

            int index = 0;
            foreach (string value in nativeStrings) {
                newStrings[index++] = new StringType(value);
            }

            return newStrings;
        }

        #region Split methods
        public StringType[] Split(params char[] separator) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            string[] nativeStrings = myValue.Split(separator);

            StringType[] newStrings = NativeToStringType(nativeStrings);

            return newStrings;
        }

        public StringType[] Split(char[] separator, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            string[] nativeStrings = myValue.Split(separator, count);

            StringType[] newStrings = NativeToStringType(nativeStrings);

            return newStrings;
        }
        #endregion

        #region Substring methods
        public StringType Substring(int startIndex) {
            return this.Substring(startIndex, Length - startIndex);
        }

        public StringType Substring(int startIndex, int length) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.Substring(startIndex, length));
        }
        #endregion

        #region Trim methods
        public StringType Trim() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.Trim());
        }

        public StringType Trim(params char[] trimChars) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.Trim(trimChars));
        }

        public StringType TrimStart(params char[] trimChars) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.TrimStart(trimChars));
        }

        public StringType TrimEnd(params char[] trimChars) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.TrimEnd(trimChars));
        }
        #endregion

        #region Compare and CompareTo methods
        private static int CompareHelper(StringType leftHand, StringType rightHand) {
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

        public static int Compare(StringType leftHand, StringType rightHand) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, rightHand.myValue);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public static int Compare(StringType leftHand, StringType rightHand, bool ignoreCase) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, rightHand.myValue, ignoreCase);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public static int Compare(StringType leftHand, StringType rightHand, bool ignoreCase, CultureInfo culture) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, rightHand.myValue, ignoreCase, culture);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public static int Compare(StringType leftHand, int leftHandIndex, StringType rightHand, int rightHandIndex, int length) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, leftHandIndex, rightHand.myValue, rightHandIndex, length);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public static int Compare(StringType leftHand, int leftHandIndex, StringType rightHand, int rightHandIndex, int length, bool ignoreCase) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, leftHandIndex, rightHand.myValue, rightHandIndex, length, ignoreCase);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public static int Compare(StringType leftHand, int leftHandIndex, StringType rightHand, int rightHandIndex, int length, bool ignoreCase, CultureInfo culture) {
            if (leftHand.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
                return string.Compare(leftHand.myValue, leftHandIndex, rightHand.myValue, rightHandIndex, length, ignoreCase, culture);
            }

            return CompareHelper(leftHand, rightHand);
        }

        public int CompareTo(Object value) {
            if (!(value is StringType)) {
                throw new ArgumentException("Invalid arguement to CompareTo - value not of StringType");
            }
            return CompareTo((StringType)value);

            //	    StringType rightHand = (StringType) value;
            //
            //	    if (rightHand == null) {
            //		return 1;
            //	    }
            //
            //            if (!(value is StringType)) {
            //                throw new ArgumentException("Invalid arguement to CompareTo - value not of StringType");
            //            }
            //
            //	    if (this.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
            //		return string.Compare(myValue, rightHand.myValue);
            //	    }
            //
            //	    return CompareHelper(this, rightHand);
        }

        public int CompareTo(StringType that) {
            //	    if (rightHand == null) {
            //                return 1;
            //            }
            //
            //	    if (this.myState == TypeState.VALID && rightHand.myState == TypeState.VALID) {
            //		return myValue.CompareTo(rightHand.myValue);
            //	    }
            //
            //	    return CompareHelper(this, rightHand);

            //	    if (!(o is StringType)) {
            //		throw new ArgumentException("Argument must be an instance of StringType");
            //	    }
            //
            //	    StringType that = (StringType)o;

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
#if notsupported
	//i'm not sure this is correct
	//this tests the StringTypes, not the wrapped values
        public static int CompareOrdinal(StringType leftHand, StringType rightHand) {
	    if (leftHand == null || rightHand == null) {
                if ((Object) leftHand == (Object) rightHand) {
                    return 0;
                }

                return (leftHand == null) ? -1 : 1; //-1 if A is null, 1 if B is null.
            }
            
            return nativeCompareOrdinal(strA, strB, false);
        }
    
        public static int CompareOrdinal(String strA, int indexA, String strB, int indexB, int length) {
    		if (strA == null || strB == null) {
                if ((Object)strA==(Object)strB) { //they're both null;
                    return 0;
                }
    
                return (strA==null)? -1 : 1; //-1 if A is null, 1 if B is null.
            }
    
            return nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
        }
#endif

        #region StartsWith and EndsWith methods
        public bool StartsWith(StringType value) {
            if (value == null) {
                throw new ArgumentNullException("value");
            }

            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.StartsWith(value.myValue);
        }

        public bool EndsWith(StringType value) {
            if (value == null || value.myValue == null) {
                throw new ArgumentNullException("value");
            }

            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.EndsWith(value.myValue);
        }
        #endregion

        #region IndexOf, IndexOfAny, LastIndexOf and LastIndexOfAny methods
        public int IndexOf(char value) {
            return IndexOf(value, 0, this.Length);
        }

        public int IndexOf(char value, int startIndex) {
            return IndexOf(value, startIndex, this.Length - startIndex);
        }

        public int IndexOf(char value, int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.IndexOf(value, startIndex, count);
        }

        public int IndexOfAny(char[] anyOf) {
            return IndexOfAny(anyOf, 0, this.Length);
        }

        public int IndexOfAny(char[] anyOf, int startIndex) {
            return IndexOfAny(anyOf, startIndex, this.Length - startIndex);
        }

        public int IndexOfAny(char[] anyOf, int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.IndexOfAny(anyOf, startIndex, count);
        }

        public int IndexOf(StringType value) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.IndexOf(value.myValue);
        }

        public int IndexOf(StringType value, int startIndex) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.IndexOf(value.myValue, startIndex);
        }

        public int IndexOf(StringType value, int startIndex, int count) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return myValue.IndexOf(value.myValue, startIndex, count);
        }

        public int LastIndexOf(char value) {
            return LastIndexOf(value, this.Length - 1, this.Length);
        }

        public int LastIndexOf(char value, int startIndex) {
            return LastIndexOf(value, startIndex, startIndex + 1);
        }

        public int LastIndexOf(char value, int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.LastIndexOf(value, startIndex, count);
        }

        public int LastIndexOfAny(char[] anyOf) {
            return LastIndexOfAny(anyOf, this.Length - 1, this.Length);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex) {
            return LastIndexOfAny(anyOf, startIndex, startIndex + 1);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.LastIndexOfAny(anyOf, startIndex, count);
        }

        public int LastIndexOf(String value) {
            return LastIndexOf(value, this.Length - 1, this.Length);
        }

        public int LastIndexOf(String value, int startIndex) {
            return LastIndexOf(value, startIndex, startIndex + 1);
        }

        public int LastIndexOf(String value, int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.LastIndexOf(value, startIndex, count);
        }
        #endregion

        #region Padding methods
        public StringType PadLeft(int totalWidth) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.PadLeft(totalWidth));
        }

        public StringType PadLeft(int totalWidth, char paddingChar) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.PadLeft(totalWidth, paddingChar));
        }

        public StringType PadRight(int totalWidth) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.PadRight(totalWidth));
        }

        public StringType PadRight(int totalWidth, char paddingChar) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.PadRight(totalWidth, paddingChar));
        }
        #endregion

        #region ToLower and ToUpper methods
        public StringType ToLower() {
            return ToLower(CultureInfo.CurrentCulture);
        }

        public StringType ToLower(CultureInfo culture) {
            if (culture == null) {
                throw new ArgumentNullException("culture");
            }

            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.ToLower(culture));
        }

        public String ToUpper() {
            return ToUpper(CultureInfo.CurrentCulture);
        }

        public StringType ToUpper(CultureInfo culture) {
            if (culture == null) {
                throw new ArgumentNullException("culture");
            }

            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.ToUpper(culture));
        }
        #endregion

        #region ToString methods
        public override string ToString() {
            return IsValid ? this.myValue : myState.ToString();
        }

        public string Display() {
            return IsValid ? ToString() : String.Empty;
        }

        //        string IConvertible.ToString(IFormatProvider provider) {
        //            return this.myValue;
        //        }
        #endregion

        #region Insert, Replace and Remove methods
        public StringType Insert(int startIndex, StringType value) {
            if (!IsValid || !value.IsValid) {
                throw new InvalidStateException(myState, value.myState);
            }

            return new StringType(myValue.Insert(startIndex, value.myValue));
        }

        public StringType Replace(char oldChar, char newChar) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.Replace(oldChar, newChar));
        }

        public StringType Replace(StringType oldValue, StringType newValue) {
            if (!IsValid || !oldValue.IsValid || !newValue.IsValid) {
                throw new InvalidStateException(myState, oldValue.myState, newValue.myState);
            }

            return new StringType(myValue.Replace(oldValue, newValue));
        }

        public StringType Remove(int startIndex, int count) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return new StringType(myValue.Remove(startIndex, count));
        }
        #endregion

        #region Format methods
        public static StringType Format(String format, Object arg0) {
            return new StringType(Format(null, format, new Object[] { arg0 }), TypeState.VALID);
        }

        public static StringType Format(String format, Object arg0, Object arg1) {
            return new StringType(Format(null, format, new Object[] { arg0, arg1 }), TypeState.VALID);
        }

        public static StringType Format(String format, Object arg0, Object arg1, Object arg2) {
            return new StringType(Format(null, format, new Object[] { arg0, arg1, arg2 }), TypeState.VALID);
        }

        public static StringType Format(String format, params Object[] args) {
            return new StringType(Format(null, format, args), TypeState.VALID);
        }

        public static StringType Format(IFormatProvider provider, String format, params Object[] args) {
            return new StringType(string.Format(provider, format, args), TypeState.VALID);
        }
        #endregion

        #region Copy and Concat methods
        public static StringType Copy(StringType value) {
            if (value == null) {
                throw new ArgumentNullException("value");
            }

            if (!!value.IsValid) {
                throw new InvalidStateException(value.myState);
            }

            return new StringType(value.myValue);
        }

        public static StringType Concat(Object arg0) {
            if (arg0 == null) {
                return StringType.EMPTY;
            }

            return new StringType(arg0.ToString());
        }

        public static StringType Concat(Object arg0, Object arg1) {
            if (arg0 == null) {
                arg0 = StringType.EMPTY;
            }

            if (arg1 == null) {
                arg1 = StringType.EMPTY;
            }
            return new StringType(string.Concat(arg0.ToString(), arg1.ToString()));
        }

        public static StringType Concat(Object arg0, Object arg1, Object arg2) {
            if (arg0 == null) {
                arg0 = StringType.EMPTY;
            }

            if (arg1 == null) {
                arg1 = StringType.EMPTY;
            }

            if (arg2 == null) {
                arg2 = StringType.EMPTY;
            }

            return new StringType(string.Concat(arg0.ToString(), arg1.ToString(), arg2.ToString()));
        }

        [CLSCompliant(false)]
        public static StringType Concat(Object arg0, Object arg1, Object arg2, Object arg3, __arglist) {
            Object[] objArgs;
            int argCount;

            ArgIterator args = new ArgIterator(__arglist);

            //+4 to account for the 4 hard-coded arguments at the beginning of the list.
            argCount = args.GetRemainingCount() + 4;

            objArgs = new Object[argCount];

            //Handle the hard-coded arguments
            objArgs[0] = arg0;
            objArgs[1] = arg1;
            objArgs[2] = arg2;
            objArgs[3] = arg3;

            //Walk all of the args in the variable part of the argument list.
            for (int i = 4; i < argCount; i++) {
                objArgs[i] = TypedReference.ToObject(args.GetNextArg());
            }

            return new StringType(string.Concat(objArgs));
        }

        public static StringType Concat(params Object[] args) {
            return new StringType(string.Concat(args));
        }

        public static StringType Concat(String str0, String str1) {
            return new StringType(string.Concat(str0, str1));
        }

        public static StringType Concat(String str0, String str1, String str2) {
            return new StringType(string.Concat(str0, str1, str2));
        }

        public static StringType Concat(String str0, String str1, String str2, String str3) {
            return new StringType(string.Concat(str0, str1, str2, str3));
        }

        public static StringType Concat(params String[] values) {
            return new StringType(string.Concat(values));
        }
        #endregion

        #region Internment methods
        public static StringType Intern(String str) {
            if (str == null) {
                throw new ArgumentNullException("str");
            }

            return new StringType(String.Intern(str));
        }

        public static StringType IsInterned(String str) {
            if (str == null) {
                throw new ArgumentNullException("str");
            }
            return new StringType(String.IsInterned(str));
        }
        #endregion

        #region Object support methods
        //what to do here?? we aren't really a string
        public TypeCode GetTypeCode() {
            return TypeCode.String;
        }

        public override int GetHashCode() {
            return myValue.GetHashCode();
        }
        #endregion

        #region ICloneable method
        public Object Clone() {
            return this;
        }
        #endregion

        #region To<XX> conversion methods
        public bool ToBoolean(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToBoolean(myValue, provider);
        }

        public char ToChar(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToChar(myValue, provider);
        }

        public byte ToByte(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToByte(myValue, provider);
        }

        public short ToInt16(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToInt16(myValue, provider);
        }

        public int ToInt32(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToInt32(myValue, provider);
        }

        public long ToInt64(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToInt64(myValue, provider);
        }

        public float ToSingle(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToSingle(myValue, provider);
        }

        public double ToDouble(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToDouble(myValue, provider);
        }

        public Decimal ToDecimal(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToDecimal(myValue, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider) {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return Convert.ToDateTime(myValue, provider);
        }
        #endregion

        #region Enumerators and IEnumerable method
        public CharEnumerator GetEnumerator() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            if (!IsValid) {
                throw new InvalidStateException(myState);
            }

            return myValue.GetEnumerator();
        }
        #endregion

        public Boolean IsEmpty {
            get { return !IsValid || String.Empty.Equals(myValue.Trim()); }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        StringType(SerializationInfo info, StreamingContext context) {
            myValue = (System.String)info.GetValue("myValue", typeof(System.String));
            myState = (TypeState)info.GetValue("myState", typeof(TypeState));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(StringType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(StringType_UNSET));
            } else {
                info.SetType(typeof(StringType));
                info.AddValue("myValue", myValue);
                info.AddValue("myState", myState);
            }
        }

    }

    [Serializable]
    public struct StringType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return StringType.DEFAULT;
        }
    }

    [Serializable]
    public struct StringType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return StringType.UNSET;
        }
    }
}