using System;
using System.Globalization;
using System.Text;
using System.Configuration;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    /// <summary>
    /// Data type for wrapping phone numbers. 
    /// </summary>
	[Serializable]
    public class PhoneNumberType : DataType, IComparable, IDataType, ISerializable {

	public static readonly new PhoneNumberType DEFAULT = new PhoneNumberType();
	public static readonly new PhoneNumberType UNSET = new PhoneNumberType();

	private String countryCode = String.Empty;
	private String areaCode = String.Empty;
	private String exchange = String.Empty;
	private String number = String.Empty;
	private String extension = String.Empty;

	//Hard coded Defaults
	private const string DEFAULT_PHONE_NUMBER_FORMAT = "({0}) {1}-{2}";
	private const string DEFAULT_EXTENSION_FORMAT = "x{0}";
	private const string DEFAULT_LOCAL_PHONE_FORMAT = "{1}-{2}";

	//DBValue formats
	private const string DBVALUE_PHONE_FORMAT = "{0}{1}{2}";
	private const string DBVALUE_EXTENSION_FORMAT = "x{0}";
	private const string DBVALUE_LOCAL_PHONE_FORMAT = "{1}{2}";

	private const string PHONE_NUMBER_FORMAT_OVERRIDE_KEY = "PhoneNumberDisplayFormat";
	private const string EXTENSION_FORMAT_OVERRIDE_KEY = "PhoneNumberExtensionDisplayFormat";


	public static PhoneNumberType Parse(String phoneNumberString) {
	    String parsedCountryCode = String.Empty;
	    String parsedAreaCode = String.Empty;
	    String parsedExchange = String.Empty;
	    String parsedNumber = String.Empty;
	    String parsedExtension = String.Empty;


	    //cut off the number 1 if it was entered at the beginning of the string
	    //if really a country code it should have a + in front of it - and '1' isn't even a supported country code since we are stripping country codes off U.S. numbers
	    if (phoneNumberString.Length > 7 && phoneNumberString.Substring(0,1) == "1"){
		phoneNumberString = phoneNumberString.Substring(1,phoneNumberString.Length - 1);
	    }

	    //find the country code (marked by a +) if any
	    Int32 countryCodeStartPosition = phoneNumberString.IndexOf("+");
	    if (countryCodeStartPosition >= 0){
		Int32 countryCodeEndPosition = phoneNumberString.IndexOf(" ", countryCodeStartPosition);
		if (countryCodeEndPosition == -1){
		    throw new System.ApplicationException("Country Codes must be followed by a space");
		}else{
		    String potentialCountryCode = phoneNumberString.Substring(countryCodeStartPosition, countryCodeEndPosition - countryCodeStartPosition);
		    //don't save a country code for U.S. numbers.
		    if (potentialCountryCode != "1"){
			parsedCountryCode = potentialCountryCode;
		    }
		}
	    }

	    //remove all non numeric characters except 'x' and '+' now that we have the country code figured out
	    phoneNumberString = RemoveNonNumeric( phoneNumberString.ToLower(), new Char[2] {'x', '+'});

	    //find the extension if there is one
	    Int32 extensionStartPosition = phoneNumberString.IndexOf("x");
	    if (extensionStartPosition >= 0){

		Int32 extensionEndPosition = phoneNumberString.IndexOf(" ", extensionStartPosition);
		if (extensionEndPosition == -1){
		    extensionEndPosition = phoneNumberString.Length -1; //if there is no space after the extension - it must go to the end of the phone number string
		}

		parsedExtension = phoneNumberString.Substring(extensionStartPosition, extensionEndPosition - extensionStartPosition + 1);
	    }

	    //anything between the countrycode and the extension (if there is one)
	    String phoneNumberGuts = phoneNumberString.Substring(parsedCountryCode.Length, phoneNumberString.Length - parsedCountryCode.Length - parsedExtension.Length);

	    if (phoneNumberGuts == String.Empty){
		return PhoneNumberType.UNSET;
	    }
	    if (parsedCountryCode == String.Empty){
		//parse out US numbers
		//check the length to see if there is an area code
		if (phoneNumberGuts.Length > 7){
		    parsedAreaCode = phoneNumberGuts.Substring(0,3);
		    parsedExchange = phoneNumberGuts.Substring(3,3);
		    parsedNumber = phoneNumberGuts.Substring(6);
		}else if (phoneNumberGuts.Length == 7){
		    //no area code
		    parsedExchange = phoneNumberGuts.Substring(0,3);
		    parsedNumber = phoneNumberGuts.Substring(3);
		}else{
		    //if the length is less than seven, leave the phone number blank rather than throw an exception - this is bad data anyway
		    //no area code
		    if (phoneNumberGuts.Length >=3) {
			parsedExchange = phoneNumberGuts.Substring(0,3);
			parsedNumber = phoneNumberGuts.Substring(3);
		    } else {
		    	parsedExchange = phoneNumberGuts;
		    }
		}
	    }else{
		//International number - so just throw it in the 'number' property
		parsedNumber = phoneNumberGuts;
	    }

	    //build and return the appropriate phone number object
	    //note: you don't have to remove the 'x' or '+' if they are part of the parsed strings.  The constructors being called will strip them off.
	    if (parsedCountryCode != String.Empty){
		//International number
		return new PhoneNumberType(parsedCountryCode.Replace("+", String.Empty), parsedNumber, parsedExtension); 
	    }else{
		//u.s. or local number
		return new PhoneNumberType(parsedAreaCode, parsedExchange, parsedNumber, parsedExtension);
	    }
	}

	public String CountryCode{
	    get{
		if (IsValid) {
		    return this.countryCode;
		} else {
		    throw new InvalidOperationException("UNSET and DEFAULT PhoneNumberTypes have no country code.");
		}
	    }   
	}

	public String AreaCode{
	    get{
		if (IsValid) {
		    return this.areaCode;
		} else {
		    throw new InvalidOperationException("UNSET and DEFAULT PhoneNumberTypes have no area code.");
		}
	    }   
	}

	public String Exchange{
	    get{
		if (IsValid) {
		    return this.exchange;
		} else {
		    throw new InvalidOperationException("UNSET and DEFAULT PhoneNumberTypes have no exchange.");
		}
	    }   
	}


	public String Number{
	    get{
		if (IsValid) {
		    return this.number;
		} else {
		    throw new InvalidOperationException("UNSET and DEFAULT PhoneNumberTypes have no number.");
		}
	    }   
	}

	public String Extension{
	    get{
		if (IsValid) {
		    return this.extension;
		} else {
		    throw new InvalidOperationException("UNSET and DEFAULT PhoneNumberTypes have no extension.");
		}
	    }   
	}
	
	protected PhoneNumberType() {}

	/// <summary>
	/// For U.S. phone numbers
	/// </summary>
	/// <param name="areaCode"></param>
	/// <param name="exchange"></param>
	/// <param name="number"></param>
	/// <param name="extension"></param>
	public PhoneNumberType(String areaCode, String exchange, String number, String extension) {
	    this.areaCode = RemoveNonNumeric(areaCode);
	    this.exchange = RemoveNonNumeric(exchange);
	    this.number = RemoveNonNumeric(number);
	    this.extension = RemoveNonNumeric(extension);
	}

	/// <summary>
	/// International numbers
	/// </summary>
	/// <param name="countryCode"></param>
	/// <param name="number"></param>
	/// <param name="extension"></param>
	public PhoneNumberType(String countryCode, String number, String extension) {
	    this.countryCode = RemoveNonNumeric(countryCode);
	    this.number = RemoveNonNumeric(number);
	    this.extension = RemoveNonNumeric(extension);
	}


	protected override Object Value {
	    get {
		return this.DBValue;
	    }
	}

	public override Boolean IsDefault {
	    get {
		return Object.ReferenceEquals(this, DEFAULT);
	    }
	}

	public override Boolean IsUnset {
	    get {
		return Object.ReferenceEquals(this, UNSET);
	    }
	}

	
	/// <summary>
	/// Uses the App.config 'PhoneNumberDisplayFormat' and 'PhoneNumberExtensionDisplayFormat' settings if they exist
	/// </summary>
	/// <returns>Formatted Phone Number String</returns>
	public override String ToString() {
	    String phoneNumberFormat;
	    String extensionFormat;
	    if (ConfigurationManager.AppSettings[PHONE_NUMBER_FORMAT_OVERRIDE_KEY] != null) {
		phoneNumberFormat = ConfigurationManager.AppSettings[PHONE_NUMBER_FORMAT_OVERRIDE_KEY];
	    }else{
		phoneNumberFormat = DEFAULT_PHONE_NUMBER_FORMAT;
	    }
	    if (ConfigurationManager.AppSettings[EXTENSION_FORMAT_OVERRIDE_KEY] != null) {
		extensionFormat = ConfigurationManager.AppSettings[EXTENSION_FORMAT_OVERRIDE_KEY];
	    }else{
		extensionFormat = DEFAULT_EXTENSION_FORMAT;
	    }
	    return ToString(phoneNumberFormat, extensionFormat);
	}




	/// <summary>
	/// /// <summary>
	/// 0 = Area Code
	/// 1 = Exchange
	/// 2 = Number
	/// Uses the App.config 'PhoneNumberExtensionDisplayFormat' setting if it exists
	/// </summary>
	/// </summary>
	/// <param name="phoneNumberFormat"></param>
	/// <returns>Formatted Phone Number string </returns>
	public override String ToString(String phoneNumberFormat) {
	    String extensionFormat;
	    if (ConfigurationManager.AppSettings[EXTENSION_FORMAT_OVERRIDE_KEY] != null) {
		extensionFormat = ConfigurationManager.AppSettings[EXTENSION_FORMAT_OVERRIDE_KEY];
	    }else{
		extensionFormat = DEFAULT_EXTENSION_FORMAT;
	    }
	    return ToString(phoneNumberFormat, extensionFormat);

	}

	/// <summary>
	/// 0 = Area Code
	/// 1 = Exchange
	/// 2 = Number
	/// 0 = Extension
	/// </summary>
	/// <param name="phoneNumberFormat"></param>
	/// <param name="extensionFormat"></param>
	/// <returns>Formatted Phone Number string</returns>
	public String ToString(String phoneNumberFormat, String extensionFormat){
	    if (!IsValid) {
		return base.ToString();
	    }

	    String formattedPhoneNumber = String.Empty;
	    //append the country code if it exists

	    //if the number is international
	    if (countryCode != String.Empty){
		//right now there can be no formatting - just spit out the 'number' portion
		formattedPhoneNumber = "+" + countryCode + " " + number;
	    }else{
		//U.S. number
		//if the area code exists then use the format provided
		if (areaCode != String.Empty){
		    formattedPhoneNumber = String.Format(phoneNumberFormat, areaCode, exchange, number);
		}else{
		    //if there was no area code then use the provided format as long as it was provided and not defaulted to the internal default
		    if (phoneNumberFormat != DEFAULT_PHONE_NUMBER_FORMAT){
			formattedPhoneNumber = String.Format(phoneNumberFormat, areaCode, exchange, number);
		    }else{
			//so, they didn't specify a format and there was no areacode.  Lets use our hard-coded local number format 
			formattedPhoneNumber = String.Format(DEFAULT_LOCAL_PHONE_FORMAT, areaCode, exchange, number);
		    }
		}
	    }

	    //append the extension if it exists
	    if (extension != String.Empty){
		formattedPhoneNumber += " " + String.Format(extensionFormat, extension);
	    }

	    return formattedPhoneNumber;
	}
	    

	public Int32 CompareTo(Object o) {

	    PhoneNumberType that = o as PhoneNumberType;
	    if (that == null) {
		throw new ArgumentException("Argument must be an instance of IntegerType");
	    }

	    if (this.IsValid && that.IsValid) {
		return this.Value.ToString().CompareTo(that.Value);
	    }
	    
	    return Compare(that);
	}


	
	/// <summary>
	/// Removes all non-numeric digits from a string
	/// Use this while formatting a phone number to pass into a search function as a string match against PhoneNumberType database data
	/// </summary>
	/// <param name="messyString"></param>
	/// <returns></returns>
	public static StringType RemoveNonNumeric(StringType messyString){
	    if (messyString.IsValid){
		return RemoveNonNumeric(messyString.ToString(), new char[0] {});
		//		return StringType.Parse(RemoveNonNumeric(messyString.ToString(), new char[0] {}));
	    }else{
		return messyString;
	    }

	}

	/// <summary>
	/// Removes all non-numeric digits from a string
	/// </summary>
	/// <param name="messyString"></param>
	/// <returns></returns>
	private static String RemoveNonNumeric(String messyString){
	    return RemoveNonNumeric(messyString, new char[0] {});

	}

	/// <summary>
	/// Removes all non-numeric digits from a string except specified characters
	/// </summary>
	/// <param name="messyString"></param>
	/// <param name="except"></param>
	/// <returns></returns>
	private static String RemoveNonNumeric(String messyString, char[] except){
	    char[] digits = messyString.ToCharArray();
	    StringBuilder cleanString = new StringBuilder();
	    foreach(char c in digits) {
		if (Char.IsDigit(c)) {
		    cleanString.Append(c);
		}else{
		    //make sure you don't strip off any of the characters meant to be ignored
		    foreach (Char e in except){
			if (e == c){
			    cleanString.Append(c);
			    break;
			}
		    }
		}
	    }
	    return cleanString.ToString();
	}

	public override Object DBValue { 
	    get {
		if (IsValid) {
		    String formattedPhoneNumber = String.Empty;
		    //append the country code if it exists

		    //if the number is international
		    if (countryCode != String.Empty){
			//right now there can be no formatting - just spit out the 'number' portion
			formattedPhoneNumber = "+" + countryCode + " " + number;
		    }else{
			//U.S. number
			//if the area code exists then use the format provided
			if (areaCode != String.Empty){
			    formattedPhoneNumber = String.Format(DBVALUE_PHONE_FORMAT, areaCode, exchange, number);
			}else{
			    //use our hard-coded local number format 
			    formattedPhoneNumber = String.Format(DBVALUE_LOCAL_PHONE_FORMAT, areaCode, exchange, number);
			}
			
		    }

		    //append the extension if it exists
		    if (extension != String.Empty){
			formattedPhoneNumber += " " + String.Format(DBVALUE_EXTENSION_FORMAT, extension);
		    }

		    return formattedPhoneNumber;
		} else {
		    return DBNull.Value;
		}
	    }
	}
 
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        PhoneNumberType(SerializationInfo info, StreamingContext context) {
			countryCode = (String)info.GetValue("countryCode", typeof(String));
			areaCode = (String)info.GetValue("areaCode", typeof(String));
			exchange = (String)info.GetValue("exchange", typeof(String));
			number = (String)info.GetValue("number", typeof(String));
			extension = (String)info.GetValue("extension", typeof(String));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(PhoneNumberType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(PhoneNumberType_UNSET));
            } else {
                info.SetType(typeof(PhoneNumberType));
				info.AddValue("countryCode", countryCode);
				info.AddValue("areaCode", areaCode);
				info.AddValue("exchange", exchange);
				info.AddValue("number", number);
				info.AddValue("extension", extension);
            }
        }

    }

    [Serializable]
    public class PhoneNumberType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return PhoneNumberType.DEFAULT;
        }
    }

    [Serializable]
    public class PhoneNumberType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return PhoneNumberType.UNSET;
        }
    }
}
