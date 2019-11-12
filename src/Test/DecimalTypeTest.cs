using System;
using System.Globalization;
using Xunit;
using Spring2.Core.Types;

namespace Spring2.Core.Test {


    public class DecimalTypeTest {

	[Fact]
	public void Format() {
	    Assert.Equal("3.00", new DecimalType(3).ToString("F2"));
	    Assert.Equal("6.60%", new DecimalType(0.066).ToString("P2"));
	}
    	
	[Fact]
	public void ToStringTest() {
	    DecimalType currency = new DecimalType(1.45);
	    Assert.Equal("1.45", currency.ToString());
	}

	[Fact]
	public void ParseWithFormatProvider() {
	    CultureInfo culture = new CultureInfo("en-GB");
	    DecimalType currency = new DecimalType(5);
	    String s = currency.ToString(culture.NumberFormat);
	    Assert.Equal("5", s);
	    DecimalType c2 = DecimalType.Parse(s, culture.NumberFormat);
	    Assert.Equal(currency, c2);
	}

	#region Double
	[Fact]
	public void ImplicitConvertionFromDouble() {
	    Double doubleDollars = 12.34;
	    DecimalType dollars = doubleDollars;
	    Assert.Equal(new DecimalType(doubleDollars), dollars);
	    Assert.Equal(doubleDollars, dollars.ToDouble());    		
	}

	[Fact]
	public void MultiplyByDouble() {
	    Double doubleDollars = 12.34;
	    DecimalType dollars1 = 100;
	    DecimalType dollars2 = dollars1 * doubleDollars;
	    Assert.Equal(new DecimalType(1234), dollars2);
	    Assert.Equal(1234D, dollars2.ToDouble());    		
	}
    	
	[Fact]
	public void MultiplyAssignmentByDouble() {
	    Double doubleDollars = 12.34;
	    DecimalType dollars = 100;
	    dollars *= doubleDollars;
	    Assert.Equal(new DecimalType(1234), dollars);
	    Assert.Equal(1234D, dollars.ToDouble());    		
	}
	#endregion
    	
	#region Decimal
	[Fact]
	public void ImplicitConvertionFromDecimal() {
	    Decimal doubleDollars = 12.34M;
	    DecimalType dollars = doubleDollars;
	    Assert.Equal(new DecimalType(doubleDollars), dollars);
	    Assert.Equal(Convert.ToDouble(doubleDollars), dollars.ToDouble());    		
	}

	[Fact]
	public void MultiplyByDecimal() {
	    Decimal doubleDollars = 12.34M;
	    DecimalType dollars1 = 100;
	    DecimalType dollars2 = dollars1 * doubleDollars;
	    Assert.Equal(new DecimalType(1234), dollars2);
	    Assert.Equal(Convert.ToDouble(1234M), dollars2.ToDouble());    		
	}
    	
	[Fact]
	public void MultiplyAssignmentByDecimal() {
	    Decimal doubleDollars = 12.34M;
	    DecimalType dollars = 100;
	    dollars *= doubleDollars;
	    Assert.Equal(new DecimalType(1234), dollars);
	    Assert.Equal(Convert.ToDouble(1234M), dollars.ToDouble());    		
	}
	#endregion
    	
	#region Int32
	[Fact]
	public void ImplicitConvertionFromInt32() {
	    Int32 doubleDollars = 12;
	    DecimalType dollars = doubleDollars;
	    Assert.Equal(new DecimalType(doubleDollars), dollars);
	    Assert.Equal(doubleDollars, dollars.ToDouble());    		
	}

	[Fact]
	public void MultiplyByInt32() {
	    Int32 doubleDollars = 12;
	    DecimalType dollars1 = 100;
	    DecimalType dollars2 = dollars1 * doubleDollars;
	    Assert.Equal(new DecimalType(1200), dollars2);
	    Assert.Equal(1200, dollars2.ToInt32());    		
	}
    	
	[Fact]
	public void MultiplyAssignmentByInt32() {
	    Int32 doubleDollars = 12;
	    DecimalType dollars = 100;
	    dollars *= doubleDollars;
	    Assert.Equal(new DecimalType(1200), dollars);
	    Assert.Equal(1200, dollars.ToInt32());    		
	}

	[Fact]
	public void ToInt32ShouldReturnAnInt32() {
	    DecimalType newDecimal = 100;
	    Int32 integer = newDecimal.ToInt32();
	    Assert.Equal(100, integer);
	}
	#endregion

	#region Int64
	[Fact]
	public void ImplicitConvertionFromInt64() {
	    Int64 doubleDollars = 12;
	    DecimalType dollars = doubleDollars;
	    Assert.Equal(new DecimalType(doubleDollars), dollars);
	    Assert.Equal(doubleDollars, dollars.ToDouble());    		
	}

	[Fact]
	public void MultiplyByInt64() {
	    Int64 doubleDollars = 12;
	    DecimalType dollars1 = 100;
	    DecimalType dollars2 = dollars1 * doubleDollars;
	    Assert.Equal(new DecimalType(1200), dollars2);
	    Assert.Equal(1200, dollars2.ToInt64());    		
	}
    	
	[Fact]
	public void MultiplyAssignmentByInt64() {
	    Int64 doubleDollars = 12;
	    DecimalType dollars = 100;
	    dollars *= doubleDollars;
	    Assert.Equal(new DecimalType(1200), dollars);
	    Assert.Equal(1200, dollars.ToInt64());    		
	}
	#endregion
    	
    }
}
