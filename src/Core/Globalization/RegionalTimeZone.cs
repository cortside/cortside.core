using System;
using System.Collections;
using System.Globalization;

namespace Cortside.Core.Globalization {

    /*
     * TODO:
     * 
     * support friendly standard and daylight names
     * need a GetUtcOffset for universal time
     */

    /// <summary>
    /// 
    /// </summary>
    public class RegionalTimeZone : TimeZone {

        private static readonly IList OPTIONS = new ArrayList();

        // Military/NATO time zones, whole hour offset, no daylight time
        public static readonly RegionalTimeZone Y = new RegionalTimeZone("Y", "Yankee", null, new TimeSpan(-12, 0, 0));
        public static readonly RegionalTimeZone X = new RegionalTimeZone("X", "Xray", null, new TimeSpan(-11, 0, 0));
        public static readonly RegionalTimeZone W = new RegionalTimeZone("W", "Wiskey", null, new TimeSpan(-10, 0, 0));
        public static readonly RegionalTimeZone V = new RegionalTimeZone("V", "Victor", null, new TimeSpan(-9, 0, 0));
        public static readonly RegionalTimeZone U = new RegionalTimeZone("U", "Uniform", null, new TimeSpan(-8, 0, 0));
        public static readonly RegionalTimeZone T = new RegionalTimeZone("T", "Tango", null, new TimeSpan(-7, 0, 0));
        public static readonly RegionalTimeZone S = new RegionalTimeZone("S", "Sierra", null, new TimeSpan(-6, 0, 0));
        public static readonly RegionalTimeZone R = new RegionalTimeZone("R", "Romeo", null, new TimeSpan(-5, 0, 0));
        public static readonly RegionalTimeZone Q = new RegionalTimeZone("Q", "Quebec", null, new TimeSpan(-4, 0, 0));
        public static readonly RegionalTimeZone P = new RegionalTimeZone("P", "Papa", null, new TimeSpan(-3, 0, 0));
        public static readonly RegionalTimeZone O = new RegionalTimeZone("O", "Oscar", null, new TimeSpan(-2, 0, 0));
        public static readonly RegionalTimeZone N = new RegionalTimeZone("N", "November", null, new TimeSpan(-1, 0, 0));
        public static readonly RegionalTimeZone Z = new RegionalTimeZone("Z", "Zulu", null, TimeSpan.Zero);
        public static readonly RegionalTimeZone A = new RegionalTimeZone("A", "Alpha", null, new TimeSpan(1, 0, 0));
        public static readonly RegionalTimeZone B = new RegionalTimeZone("B", "Bravo", null, new TimeSpan(2, 0, 0));
        public static readonly RegionalTimeZone C = new RegionalTimeZone("C", "Charlie", null, new TimeSpan(3, 0, 0));
        public static readonly RegionalTimeZone D = new RegionalTimeZone("D", "Delta", null, new TimeSpan(4, 0, 0));
        public static readonly RegionalTimeZone E = new RegionalTimeZone("E", "Echo", null, new TimeSpan(5, 0, 0));
        public static readonly RegionalTimeZone F = new RegionalTimeZone("F", "Foxtrot", null, new TimeSpan(6, 0, 0));
        public static readonly RegionalTimeZone G = new RegionalTimeZone("G", "Golf", null, new TimeSpan(7, 0, 0));
        public static readonly RegionalTimeZone H = new RegionalTimeZone("H", "Hotel", null, new TimeSpan(8, 0, 0));
        public static readonly RegionalTimeZone I = new RegionalTimeZone("I", "Indio", null, new TimeSpan(9, 0, 0));
        public static readonly RegionalTimeZone K = new RegionalTimeZone("K", "Kilo", null, new TimeSpan(10, 0, 0));
        public static readonly RegionalTimeZone L = new RegionalTimeZone("L", "Lima", null, new TimeSpan(11, 0, 0));
        public static readonly RegionalTimeZone M = new RegionalTimeZone("M", "Mike", null, new TimeSpan(12, 0, 0));

        // Time zones that use North American daylight time rules
        public static readonly RegionalTimeZone V_US = new RegionalTimeZone("V-US", "US Alaska Standard Time", DaylightTimeRule.UNITED_STATES, new TimeSpan(-9, 0, 0));
        public static readonly RegionalTimeZone U_US = new RegionalTimeZone("U-US", "US Pacific Standard Time", DaylightTimeRule.UNITED_STATES, new TimeSpan(-8, 0, 0));
        public static readonly RegionalTimeZone T_US = new RegionalTimeZone("T-US", "US Mountain Standard Time", DaylightTimeRule.UNITED_STATES, new TimeSpan(-7, 0, 0));
        public static readonly RegionalTimeZone S_US = new RegionalTimeZone("S-US", "US Central Standard Time", DaylightTimeRule.UNITED_STATES, new TimeSpan(-6, 0, 0));
        public static readonly RegionalTimeZone R_US = new RegionalTimeZone("R-US", "US Eastern Standard Time", DaylightTimeRule.UNITED_STATES, new TimeSpan(-5, 0, 0));

        // Time zones that use EU daylight time rules
        public static readonly RegionalTimeZone Z_EU = new RegionalTimeZone("Z-EU", "Greenwich Mean Time", DaylightTimeRule.EUROPE, TimeSpan.Zero);
        public static readonly RegionalTimeZone A_EU = new RegionalTimeZone("A-EU", "Europe Central Time", DaylightTimeRule.EUROPE, new TimeSpan(1, 0, 0));
        public static readonly RegionalTimeZone B_EU = new RegionalTimeZone("B-EU", "Europe Eastern Time", DaylightTimeRule.EUROPE, new TimeSpan(2, 0, 0));

        // Common known timezone abbreviations
        public static readonly RegionalTimeZone AKST = V_US;
        public static readonly RegionalTimeZone PST = U_US;
        public static readonly RegionalTimeZone MST = T_US;
        public static readonly RegionalTimeZone CST = S_US;
        public static readonly RegionalTimeZone EST = R_US;
        public static readonly RegionalTimeZone GMT = Z_EU;
        public static readonly RegionalTimeZone CET = A_EU;
        public static readonly RegionalTimeZone EET = B_EU;

        protected String code;
        protected String name;
        protected IDaylightTimeRule daylightTimeRule;
        protected TimeSpan utcOffset;

        /// <summary>
        /// Constructor to create the limited number of TimeZone instances
        /// </summary>
        /// <param name="code">shorthand for the database</param>
        /// <param name="name">friendly, descriptive name</param>
        /// <param name="daylightTimeRule">period of time that is "daylight savings time"</param>
        /// <param name="utcOffset">hours offset from UTC</param>
        private RegionalTimeZone(String code, String name, IDaylightTimeRule daylightTimeRule, TimeSpan utcOffset) {
            this.code = code;
            this.name = name;
            this.daylightTimeRule = daylightTimeRule;
            this.utcOffset = utcOffset;
            OPTIONS.Add(this);
        }

        /// <summary>
        /// Returns the intialized instance for the corresponding TimeZone.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static RegionalTimeZone GetInstance(String code) {
            // check for common abbreviations first (one that are defined above)
            if (code.Equals("AKST")) {
                return AKST;
            } else if (code.Equals("PST")) {
                return PST;
            } else if (code.Equals("MST")) {
                return MST;
            } else if (code.Equals("CST")) {
                return CST;
            } else if (code.Equals("EST")) {
                return EST;
            } else if (code.Equals("GMT")) {
                return GMT;
            } else if (code.Equals("CET")) {
                return CET;
            } else if (code.Equals("EET")) {
                return EET;
            }

            foreach (RegionalTimeZone t in OPTIONS) {
                if (t.Code.Equals(code)) {
                    return t;
                }
            }

            throw new ArgumentOutOfRangeException("code", code, code + " is not a valid time zone");
        }

        /// <summary>
        /// The code used to get a particular TimeZone instance
        /// </summary>
        public String Code {
            get { return code; }
        }

        /// <summary>
        /// Name of TimeZone
        /// </summary>
        public String Name {
            get { return name; }
        }

        /// <summary>
        /// Standard time name
        /// </summary>
        public override String StandardName {
            get { return name; }
        }

        /// <summary>
        /// Daylight time name, empty string if daylight time is not observed
        /// </summary>
        public override String DaylightName {
            get { return daylightTimeRule == null ? String.Empty : name; }
        }

        /// <summary>
        /// UTC offset for the specified time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override TimeSpan GetUtcOffset(DateTime time) {
            if (IsDaylightSavingTime(time)) {
                return utcOffset.Add(new TimeSpan(1, 0, 0));
            } else {
                return utcOffset;
            }
        }

        /// <summary>
        /// DaylightTime for the specified year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public override DaylightTime GetDaylightChanges(Int32 year) {
            if (daylightTimeRule == null) {
                return null;
            } else {
                return daylightTimeRule.GetDaylightTime(year, utcOffset);
            }
        }

        /// <summary>
        /// Is the date specified within the daylight time.  Returns false if daylight time is not observed.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override Boolean IsDaylightSavingTime(DateTime time) {
            if (daylightTimeRule == null) {
                return false;
            }

            DaylightTime daylight = GetDaylightChanges(time.Year);
            if (time >= daylight.Start && time < daylight.End) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the local time that corresponds to the specified coordinated universal time (UTC)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override DateTime ToLocalTime(DateTime time) {
            return time.Add(GetUtcOffset(time));
        }

        /// <summary>
        /// Convert local time of another time zone to local time
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timezone"></param>
        /// <returns></returns>
        public virtual DateTime ToLocalTime(DateTime time, TimeZone timezone) {
            TimeSpan tp = GetUtcOffset(time);
            time = timezone.ToUniversalTime(time);
            return time.Add(tp);
        }

        /// <summary>
        /// Returns the coordinated universal time (UTC) that corresponds to the specified local time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override DateTime ToUniversalTime(DateTime time) {
            return time.Subtract(GetUtcOffset(time));
        }

        /// <summary>
        /// The complete list of possible TimeZone instances
        /// </summary>
        public static IList Options {
            get { return OPTIONS; }
        }

        public override Boolean Equals(Object o) {
            if (this == o) {
                return true;
            } else if (code == null || !(o is RegionalTimeZone)) {
                return false;
            } else {
                return code.Equals(((RegionalTimeZone)o).code);
            }
        }

        public override int GetHashCode() {
            return code == null ? 0 : code.GetHashCode();
        }

        public override String ToString() {
            return name;
        }

    }
}
