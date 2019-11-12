using System;
using System.Globalization;

namespace Spring2.Core.Globalization {

    public interface IDaylightTimeRule {
	/// <summary>
	/// Get the DaylightTime for the year specified, adjusted by UTC offset if required (by a RegionalTimeZone)
	/// </summary>
	/// <param name="year"></param>
	/// <param name="utcOffset"></param>
	/// <returns></returns>
	DaylightTime GetDaylightTime(Int32 year, TimeSpan utcOffset);
    	
    	String Name {
    	    get;
    	}
    }
}