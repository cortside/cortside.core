using System;

namespace Cortside.Core.Util {
    /// <summary>
    /// Summary description for DateUtil.
    /// </summary>
    public class DateUtil {

        /// <summary>
        /// Return the last day of the year/month represented by the mmyy date string.
        /// </summary>
        /// <param name="mmyy"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromCreditCardDate(String mmyy) {
            if (mmyy.Length != 4) {
                throw new ArgumentOutOfRangeException("CreditCardDate string is expected to be a 4 character string in the format of mmyy");
            }
            Int32 mm = Int32.Parse(mmyy.Substring(0, 2));
            Int32 yy = Int32.Parse(mmyy.Substring(2, 2));

            return ToDateTimeFromCreditCardDate(mm, yy);
        }

        /// <summary>
        /// Return the last day of the year/month represented by the mmyy date string.
        /// </summary>
        /// <param name="mm"></param>
        /// <param name="yy"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromCreditCardDate(Int32 mm, Int32 yy) {
            if (yy < 100) {
                yy += 2000;
            }
            if (mm < 1 || mm > 12 || yy < 2000 || yy > 2020) {
                throw new ArgumentOutOfRangeException("Month or year not in valid range.  Month is expected to be between 1 and 12 and year is expected to be between 2000 and 2020 or 00 and 20.");
            }

            Int32 dd = 1;
            if (mm < 12) {
                mm += 1;
            } else {
                mm = 1;
                yy += 1;
            }

            DateTime dt = new DateTime(yy, mm, dd);
            return dt.AddDays(-1);
        }

    }
}
