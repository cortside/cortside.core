using System;

namespace Cortside.Core.Util {
    public static class StringExtensions {

        /// <summary>
        /// Returns the first few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Left(this string s, int length) {
            length = Math.Max(length, 0);

            if (s.Length > length) {
                return s.Substring(0, length);
            } else {
                return s;
            }
        }

        /// <summary>
        /// Returns the last few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Right(this string s, int length) {
            length = Math.Max(length, 0);

            if (s.Length > length) {
                return s.Substring(s.Length - length, length);
            } else {
                return s;
            }
        }
    }
}
