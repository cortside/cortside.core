using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace Spring2.Core.Globalization {

    /// <summary>
    /// Represents the rules that are used to determine the actual DaylightTime for a given year
    /// </summary>
    public class XmlDaylightTimeRule : IDaylightTimeRule {

        public static readonly String RESOURCE_FILE_NAME = "Spring2.Core.Globalization.RegionalTimeZones.xml";

        private readonly String name = null;

        private readonly Hashtable years = new Hashtable();
        private ArrayList rules = new ArrayList();

        public XmlDaylightTimeRule(String name) {
            this.name = name;

            XmlDocument doc = new XmlDocument();
            doc.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream(RESOURCE_FILE_NAME));
            XmlNode node = doc.SelectSingleNode(String.Format("//DaylightTimeRule[@name=\"{0}\"]", name));

            if (node == null) {
                throw new ArgumentOutOfRangeException("name");
            }

            XmlNodeList ruleNodes = node.SelectNodes("rule");
            foreach (XmlNode ruleNode in ruleNodes) {
                DaylightTimeYearRule rule = new DaylightTimeYearRule();

                rule.name = ruleNode.Attributes["name"].Value;
                if (ruleNode.Attributes["startDate"] != null) {
                    rule.startDate = DateTime.Parse(ruleNode.Attributes["startDate"].Value);
                }
                if (ruleNode.Attributes["endDate"] != null) {
                    rule.endDate = DateTime.Parse(ruleNode.Attributes["endDate"].Value);
                }

                rule.startWeekOfMonth = GetWeekOfMonth(ruleNode.Attributes["startWeekOfMonth"].Value);
                rule.startDayOfWeek = GetDayOfWeek(ruleNode.Attributes["startDayOfWeek"].Value);
                rule.startMonth = Int32.Parse(ruleNode.Attributes["startMonth"].Value);
                rule.endWeekOfMonth = GetWeekOfMonth(ruleNode.Attributes["endWeekOfMonth"].Value);
                rule.endDayOfWeek = GetDayOfWeek(ruleNode.Attributes["endDayOfWeek"].Value);
                rule.endMonth = Int32.Parse(ruleNode.Attributes["endMonth"].Value);
                rule.hourOfDay = Int32.Parse(ruleNode.Attributes["hourOfDay"].Value);
                rule.utcHourOfDay = ruleNode.Attributes["utcHourOfDay"].Value == "1";
                rule.delta = new TimeSpan(0, Int32.Parse(ruleNode.Attributes["delta"].Value), 0);

                rules.Add(rule);
            }
        }

        public string Name {
            get { return name; }
        }

        private DayOfWeek GetDayOfWeek(string dayOfWeek) {
            switch (dayOfWeek) {
                case "Monday":
                    return DayOfWeek.Monday;
                case "Tuesday":
                    return DayOfWeek.Tuesday;
                case "Wednesday":
                    return DayOfWeek.Wednesday;
                case "Thursday":
                    return DayOfWeek.Thursday;
                case "Friday":
                    return DayOfWeek.Friday;
                case "Saturday":
                    return DayOfWeek.Saturday;
                case "Sunday":
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentOutOfRangeException("dayOfWeek");
            }
        }

        private WeekOfMonth GetWeekOfMonth(string weekOfMonth) {
            switch (weekOfMonth) {
                case "First":
                    return WeekOfMonth.First;
                case "Second":
                    return WeekOfMonth.Second;
                case "Third":
                    return WeekOfMonth.Third;
                case "Fourth":
                    return WeekOfMonth.Fourth;
                case "Fifth":
                    return WeekOfMonth.Fifth;
                case "Last":
                    return WeekOfMonth.Last;
                default:
                    throw new ArgumentOutOfRangeException("dayOfWeek");
            }
        }

        /// <summary>
        /// Get the DaylightTime for the year specified, adjusted by UTC offset if required (by a RegionalTimeZone)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="utcOffset"></param>
        /// <returns></returns>
        public DaylightTime GetDaylightTime(Int32 year, TimeSpan utcOffset) {
            DaylightTime daylight = (DaylightTime)years[year];
            DaylightTimeYearRule rule = GetDaylightTimeYearRule(year);

            // if not already cached, figure it out
            if (daylight == null) {
                DateTime start = CalculateTime(year, rule.startWeekOfMonth, rule.startDayOfWeek, rule.startMonth);
                DateTime end = CalculateTime(year, rule.endWeekOfMonth, rule.endDayOfWeek, rule.endMonth);
                daylight = new DaylightTime(start, end, rule.delta);
                years[year] = daylight;
            }

            // if change hour is based on a UTC hour, offset by UTC offset
            if (rule.utcHourOfDay) {
                return new DaylightTime(daylight.Start.Subtract(utcOffset), daylight.End.Subtract(utcOffset), daylight.Delta);
            } else {
                return daylight;
            }

        }

        private DaylightTimeYearRule GetDaylightTimeYearRule(int year) {
            DateTime date = new DateTime(year, 1, 1);
            foreach (DaylightTimeYearRule rule in rules) {
                if (date >= rule.startDate && date <= rule.endDate) {
                    return rule;
                }
            }

            throw new ArgumentOutOfRangeException("year");
        }

        private DateTime CalculateTime(Int32 year, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek, Int32 month) {
            DaylightTimeYearRule rule = GetDaylightTimeYearRule(year);
            DateTime time = new DateTime(year, month, 1, rule.hourOfDay, 0, 0, 0);

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

        internal class DaylightTimeYearRule {
            public String name;
            public DateTime startDate = new DateTime(1, 1, 1);
            public DateTime endDate = new DateTime(9999, 12, 31);

            public WeekOfMonth startWeekOfMonth;
            public DayOfWeek startDayOfWeek;
            //public Int32 startDay;
            public Int32 startMonth;

            public WeekOfMonth endWeekOfMonth;
            public DayOfWeek endDayOfWeek;
            //public Int32 endDay;
            public Int32 endMonth;

            public Int32 hourOfDay;
            public Boolean utcHourOfDay = false;
            public TimeSpan delta = TimeSpan.Zero;
        }
    }
}
