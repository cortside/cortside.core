using System;
using System.Collections;
using System.Globalization;

namespace Cortside.Core.Globalization {

    /// <summary>
    /// Represents the rules that are used to determine the actual DaylightTime for a given year
    /// </summary>
    public class DaylightTimeRule : IDaylightTimeRule {

        /// <summary>
        /// Daylight savings rules for the United States, which changed rules effective 2007
        /// </summary>
        public static readonly IDaylightTimeRule UNITED_STATES = new XmlDaylightTimeRule("United States");

        /// <summary>
        /// Daylight savings rules for North America, but in 2007 the United States and parts of Canada have changed their rules and have been seperated as UNITED_STATES.
        /// </summary>
        public static readonly IDaylightTimeRule NORTH_AMERICA = new DaylightTimeRule("North America", WeekOfMonth.First, DayOfWeek.Sunday, 4, WeekOfMonth.Last, DayOfWeek.Sunday, 10, 2, false, new TimeSpan(1, 0, 0));

        /// <summary>
        /// Daylight savings rules for Europe
        /// </summary>
        public static readonly IDaylightTimeRule EUROPE = new DaylightTimeRule("Europe", WeekOfMonth.Last, DayOfWeek.Sunday, 3, WeekOfMonth.Last, DayOfWeek.Sunday, 10, 1, true, new TimeSpan(1, 0, 0));

        private readonly WeekOfMonth startWeekOfMonth;
        private readonly DayOfWeek startDayOfWeek;
        //private Int32 startDay;
        private readonly Int32 startMonth;

        private readonly WeekOfMonth endWeekOfMonth;
        private readonly DayOfWeek endDayOfWeek;
        //private Int32 endDay;
        private readonly Int32 endMonth;

        private readonly Int32 hourOfDay;
        private readonly Boolean utcHourOfDay = false;
        private TimeSpan delta = TimeSpan.Zero;
        private readonly String name;

        private readonly Hashtable years = new Hashtable();

        private DaylightTimeRule(String name, WeekOfMonth startWeekOfMonth, DayOfWeek startDayOfWeek, Int32 startMonth, WeekOfMonth endWeekOfMonth, DayOfWeek endDayOfWeek, Int32 endMonth, Int32 hourOfDay, Boolean utcHourOfDay, TimeSpan delta) {
            this.name = name;
            this.startWeekOfMonth = startWeekOfMonth;
            this.startDayOfWeek = startDayOfWeek;
            this.startMonth = startMonth;

            this.endWeekOfMonth = endWeekOfMonth;
            this.endDayOfWeek = endDayOfWeek;
            this.endMonth = endMonth;

            this.hourOfDay = hourOfDay;
            this.utcHourOfDay = utcHourOfDay;

            this.delta = delta;
        }

        // <summary>
        // Creates an instance of DaylightTimeRule based on static start and end dates (i.e. Iran)
        // </summary>
        //private DaylightTimeRule(Int32 startDay, Int32 startMonth, Int32 endDay, Int32 endMonth, Int32 hourOfDay, Boolean utcHourOfDay, TimeSpan delta) {
        //    this.startDay = startDay;
        //    this.startMonth = startMonth;
        //    this.endDay = endDay;
        //    this.endMonth = endMonth;
        //    this.hourOfDay = hourOfDay;
        //    this.utcHourOfDay = utcHourOfDay;
        //    this.delta = delta;
        //}

        /// <summary>
        /// Get the DaylightTime for the year specified, adjusted by UTC offset if required (by a RegionalTimeZone)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="utcOffset"></param>
        /// <returns></returns>
        public DaylightTime GetDaylightTime(Int32 year, TimeSpan utcOffset) {
            DaylightTime daylight = (DaylightTime)years[year];

            // if not already cached, figure it out
            if (daylight == null) {
                DateTime start = CalculateTime(year, startWeekOfMonth, startDayOfWeek, startMonth);
                DateTime end = CalculateTime(year, endWeekOfMonth, endDayOfWeek, endMonth);
                daylight = new DaylightTime(start, end, delta);
                years[year] = daylight;
            }

            // if change hour is based on a UTC hour, offset by UTC offset
            if (utcHourOfDay) {
                return new DaylightTime(daylight.Start.Subtract(utcOffset), daylight.End.Subtract(utcOffset), daylight.Delta);
            } else {
                return daylight;
            }

        }

        public string Name {
            get { return name; }
        }

        private DateTime CalculateTime(Int32 year, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, Int32 month) {
            DateTime time = new DateTime(year, month, 1, hourOfDay, 0, 0, 0);

            Boolean found = false;
            Int32 occurrence = 0;
            DateTime last = time;
            while (!found && time.Month == month) {
                if (time.DayOfWeek == dayOfWeek) {
                    occurrence += 1;
                    last = time;
                }
                if (occurrence == (Int32)weekOfMonth) {
                    return time;
                }
                time = time.AddDays(1);
            }

            if (weekOfMonth.Equals(WeekOfMonth.Last)) {
                return last;
            }

            // could not find the correct occurrence
            throw new ArgumentOutOfRangeException("weekOfMonth", "Could not find the correct occurrence");
        }
    }
}
