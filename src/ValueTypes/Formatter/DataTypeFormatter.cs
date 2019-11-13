using System;

namespace Cortside.Core.Types.Formatter {

    /// <summary>
    /// Summary description for DataTypeFormatter.
    /// </summary>
    public class DataTypeFormatter {

        /// <summary>
        /// formats a DataType to a string using ToString() or an empty string if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public String FormatDefault(IDataType val) {
            return val.IsValid ? val.ToString() : String.Empty;
        }

        /// <summary>
        /// format a currency type using format string or blank if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String FormatDefault(DecimalType val, String format) {
            return val.IsValid ? val.ToString(format) : String.Empty;
        }

        /// <summary>
        /// format a currency type using format string or return specified string if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        /// <param name="stringIfNotValid"></param>
        /// <returns></returns>
        public String FormatDefault(DecimalType val, String format, String stringIfNotValid) {
            return val.IsValid ? val.ToString(format) : stringIfNotValid;
        }

        /// <summary>
        /// format a currency type using format string or blank if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String FormatDefault(IntegerType val, String format) {
            return val.IsValid ? val.ToString(format) : String.Empty;
        }

        /// <summary>
        /// format a currency type using format string or blank if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public String FormatDefault(DateType val, String format) {
            return val.IsValid ? val.ToString(format) : String.Empty;
        }

        /// <summary>
        /// formats a DateType to the short date pattern or an empty string if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public String FormatDateDefault(DateType val) {
            return val.IsValid ? val.ToString("d") : String.Empty;
        }

        /// <summary>
        /// formats a DateType to the short time pattern or an empty string if not valid
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public String FormatTimeDefault(DateType val) {
            return val.IsValid ? val.ToString("t") : String.Empty;
        }

        /// <summary>
        /// Truncates a given string up to given length
        /// </summary>
        /// <param name="val" type="string"></param>
        /// <param name="length" type="int"></param>
        /// <returns></returns>
        public String TruncateString(String val, Int32 length) {
            if ((val.Length > length) && (length >= 0)) {
                val = val.Substring(0, length);
            }
            return val;
        }
    }
}
