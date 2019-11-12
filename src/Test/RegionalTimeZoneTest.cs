using System;
using System.Collections;
using System.Globalization;
using Xunit;
using Spring2.Core.Globalization;
using Spring2.Core.Types;

namespace Spring2.Core.Test {


    public class RegionalTimeZoneTest {

	[Fact]
	public void ParseSystemTimeFromLocalTime1() {
	    DateTime date = new DateTime(2006, 4, 1, 20, 0, 0);
	    Assert.Equal(date, ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.R_US, "en-US"));

	    date = new DateTime(2006, 4, 2, 2, 0, 0);
	    Assert.Equal(date, ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.R_US, "en-US"));

	    date = new DateTime(2006, 4, 1, 21, 0, 0);
	    Assert.Equal(date, ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.R_US, "en-US"));
	}

	[Fact]
	public void ParseSystemTimeFromLocalTime_BehindLocal() {
	    DateTime date = new DateTime(2006, 4, 1, 20, 0, 0);
	    Assert.Equal(date.AddHours(2), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.T_US, "en-US"));

	    date = new DateTime(2006, 4, 2, 2, 0, 0);
	    Assert.Equal(date.AddHours(2), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.T_US, "en-US"));

	    date = new DateTime(2006, 4, 1, 21, 0, 0);
	    Assert.Equal(date.AddHours(2), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.R_US, RegionalTimeZone.T_US, "en-US"));
	}

	[Fact]
	public void ParseSystemTimeFromLocalTime_AheadOfLocal() {
	    DateTime date = new DateTime(2006, 4, 1, 20, 0, 0);
	    Assert.Equal(date.AddHours(-1), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.S_US, RegionalTimeZone.R_US, "en-US"));

	    date = new DateTime(2006, 4, 2, 2, 0, 0);
	    Assert.Equal(date.AddHours(-1), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.S_US, RegionalTimeZone.R_US, "en-US"));

	    date = new DateTime(2006, 4, 1, 21, 0, 0);
	    Assert.Equal(date.AddHours(-1), ParseSystemTimeFromLocalTime(date.ToString(), RegionalTimeZone.S_US, RegionalTimeZone.R_US, "en-US"));
	}

	private DateTime ParseSystemTimeFromLocalTime(String datetime, RegionalTimeZone systemTimeZone, RegionalTimeZone localTimeZone, String cultureCode) {
	    CultureInfo culture = new CultureInfo(cultureCode);
	    DateTimeFormatInfo format = DateTimeFormatInfo.GetInstance(culture);
	    DateTime localTime = DateTime.Parse(datetime, format);
	    DateTime systemTime = systemTimeZone.ToLocalTime(localTime, localTimeZone);
	    return systemTime;
	}
    	
	[Fact]
	public void GetInstanceForAllOptions() {
	    ArrayList timeZones = new ArrayList();
	    timeZones.AddRange(RegionalTimeZone.Options);
	    timeZones.Add(RegionalTimeZone.AKST);
	    timeZones.Add(RegionalTimeZone.EST);
	    timeZones.Add(RegionalTimeZone.CST);
	    timeZones.Add(RegionalTimeZone.MST);
	    timeZones.Add(RegionalTimeZone.PST);
	    timeZones.Add(RegionalTimeZone.GMT);
	    timeZones.Add(RegionalTimeZone.CET);
	    timeZones.Add(RegionalTimeZone.EET);
    		
	    foreach(RegionalTimeZone timeZone in timeZones) {
		RegionalTimeZone tz = RegionalTimeZone.GetInstance(timeZone.Code);
		Assert.Equal(timeZone, tz);
	    	Assert.Equal(tz.ToString(), tz.Name);
	    }
	}
    	
    	[Fact]
	public void GetInstanceForAKST() {
    	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("AKST");
    	    Assert.Equal(RegionalTimeZone.V_US, tz);
    	}

	[Fact]
	public void GetInstanceForEST() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("EST");
	    Assert.Equal(RegionalTimeZone.R_US, tz);
	}

	[Fact]
	public void GetInstanceForCST() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("CST");
	    Assert.Equal(RegionalTimeZone.S_US, tz);
	}
    
	[Fact]
	public void GetInstanceForMST() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("MST");
	    Assert.Equal(RegionalTimeZone.T_US, tz);
	}
    
	[Fact]
	public void GetInstanceForPST() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("PST");
	    Assert.Equal(RegionalTimeZone.U_US, tz);
	}
    
	[Fact]
	public void GetInstanceForGMT() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("GMT");
	    Assert.Equal(RegionalTimeZone.Z_EU, tz);
	}
    
	[Fact]
	public void GetInstanceForCET() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("CET");
	    Assert.Equal(RegionalTimeZone.A_EU, tz);
	}
    
	[Fact]
	public void GetInstanceForEET() {
	    RegionalTimeZone tz = RegionalTimeZone.GetInstance("EET");
	    Assert.Equal(RegionalTimeZone.B_EU, tz);
	}
    	
	[Fact]
	public void GetInstanceForUnknown() {
	    try {
		RegionalTimeZone tz = RegionalTimeZone.GetInstance("foo");
		Assert.True(false, "");
	    } catch (ArgumentOutOfRangeException) {
	    	// this is expected
	    }
	}
    	
    	[Fact]
	public void GetDaylightChangesForNoDaylightTimeRule() {
    	    Assert.Null(RegionalTimeZone.Z.GetDaylightChanges(DateTime.Today.Year));
    	}

	[Fact]
	public void IsNotDaylightSavingsTimeForNoDaylightTimeRule() {
	    Assert.False(RegionalTimeZone.Z.IsDaylightSavingTime(DateTime.Now));
	}
    	
    	[Fact]
	public void DaylightName() {
    	    Assert.Equal(RegionalTimeZone.PST.StandardName, RegionalTimeZone.PST.DaylightName);
    	    Assert.Equal(String.Empty, RegionalTimeZone.Z.DaylightName);
    	}
    	
    	[Fact]
	public void HashcodeIsSameAsCodesHashCode() {
    	    Assert.Equal(RegionalTimeZone.Z.Code.GetHashCode(), RegionalTimeZone.Z.GetHashCode());
    	}
    	
    	[Fact]
	public void SameInstanceEquals() {
    	    Assert.True(RegionalTimeZone.Z.Equals(RegionalTimeZone.Z));	
    	}
    	
	[Fact]
	public void DifferentInstancesDoNotEqual() {
	    Assert.False(RegionalTimeZone.Z.Equals(RegionalTimeZone.Y));	
	}

	[Fact]
	public void DaylightTimeRuleDoesNotEqualRegionalTimeZone() {
	    Assert.False(RegionalTimeZone.Z.Equals(DaylightTimeRule.UNITED_STATES));	
	}
    }
}
