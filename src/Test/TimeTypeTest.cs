using System;

using Xunit;
using Spring2.Core.Types;

namespace Spring2.Core.Test {


    public class TimeTypeTest {

	[Fact]
	public void CreateInstanceFromTimeSpan() {
	    TimeSpan span = new TimeSpan(1, 1, 1);
	    TimeType time = new TimeType(span);
	    Assert.Equal(span.Ticks, time.Ticks);
	}

	[Fact]
	public void CreateInstanceFromHoursMinutesSeconds() {
	    TimeSpan span = new TimeSpan(1, 1, 1);
	    TimeType time = new TimeType(span.Hours,  span.Minutes, span.Seconds);
	    Assert.Equal(span.Ticks, time.Ticks);
	}

	[Fact]
	public void CreateInstanceFromTicks() {
	    TimeSpan span = new TimeSpan(1, 1, 1);
	    TimeType time = new TimeType(span.Ticks);
	    Assert.Equal(span.Ticks, time.Ticks);
	}

	[Fact]
	public void AddToTimeType() {
	    TimeType time = new TimeType(1, 1, 1);
	    time = time.Add(new TimeType(1, 1, 1));
	    Assert.Equal(new TimeType(2, 2, 2), time);
	}

	[Fact]
	public void ShouldGetExceptionWhenAddingInValidValue() {
	    TimeType time = new TimeType(2,2,2);
	    try {
		time.Add(TimeType.DEFAULT);
		Assert.True(false, "Should not allow add of invalid time");
	    } catch (InvalidStateException) {
		//Expected
	    }
	}

	[Fact]
	public void SubtractTimeType() {
	    TimeType time = new TimeType(2, 2, 2);
	    time = time.Subtract(new TimeType(1, 1, 1));
	    Assert.Equal(new TimeType(1, 1, 1), time);
	}

	[Fact]
	public void ShouldGetExceptionWhenSubtractingInValidValue() {
	    TimeType time = new TimeType(2,2,2);
	    try {
		time.Subtract(TimeType.DEFAULT);
		Assert.True(false, "Should not allow subtract of invalid time");
	    } catch (InvalidStateException) {
		//Expected
	    }
	}

	[Fact]
	public void ShouldBeAbleToConvertBackToTimeSpan() {
	    TimeSpan span = new TimeSpan(3, 3, 3);
	    TimeType time = new TimeType(span);
	    Assert.Equal(span, time.ToTimeSpan());
	}

	[Fact]
	public void ShouldBeAbleToParseTimeIn24HourFormat() {
	    TimeType time = TimeType.Parse("16:07");
	    Assert.Equal(new TimeType(16, 7, 0), time);
	}

	[Fact]
	public void ShouldBeAbleToParseTimesWithAMorPM() {
	    TimeType time = TimeType.Parse("3:09 PM");
	    Assert.Equal(new TimeType(15, 9, 0), time);
	}

	[Fact]
	public void ShouldNotAllowTimeTypeLargerThen24Hours() {
	    try {
		TimeType time = new TimeType(24, 0, 1);
		Assert.True(false, "Should not have allowed creation of TimeType greater then 24 hours");
	    } catch (ArgumentOutOfRangeException) {
		//Expected
	    }
	}

	[Fact]
	public void ShouldNotAllowParseOfNewTimeTypeLargerThen24Hours() {
	    try {
		TimeType time = TimeType.Parse("24:00:01");
		Assert.True(false, "Should not have allowed creation of TimeType greater then 24 hours");
	    } catch (FormatException) {
		//Expected
	    }
	}

	[Fact]
	public void ShouldBeAbleToParseFromTimeSpanDotToString() {
	    TimeSpan span = new TimeSpan(23, 9, 0);
	    TimeType time = TimeType.Parse(span.ToString());
	    Assert.Equal(new TimeType(23, 9, 0), time);
	}

    }
}
