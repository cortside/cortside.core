using System;
using Spring2.Core.Types;
using Xunit;

namespace Spring2.Core.Test {
    /// <summary>
    /// Summary description for DataTypeTest.
    /// </summary>
    public class DataTypeTest {

        [Fact]
        public void TestParse() {

            // Currency type tests.
            CurrencyType c1 = new CurrencyType(100);
            String s1 = c1.ToString();
            CurrencyType c2 = CurrencyType.Parse(s1);
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("100");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("$100");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("100.");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("$100.");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("$100.  ");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("   $100.  ");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("   $100.000  ");
            Assert.Equal(c1, c2);
            c2 = CurrencyType.Parse("   $ 100.000  ");
            Assert.Equal(c1, c2);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-CA");
            s1 = c1.ToString();
            c2 = CurrencyType.Parse(s1);
            Assert.Equal(c1, c2);

            // Integer type tests.
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            IntegerType integer1 = new IntegerType(3000);
            String IntegerString = integer1.ToString("N");
            IntegerType integer2 = IntegerType.Parse(IntegerString);
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse("3000");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse("3,000");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse("3000.");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse("3000.00");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse("3000.000");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse(" 3000 ");
            Assert.Equal(integer1, integer2);
            integer2 = IntegerType.Parse(" 3,000.000 ");
            Assert.Equal(integer1, integer2);

            // Id type tests.
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            IdType id1 = new IdType(3000);
            String idString = id1.ToString();
            IdType id2 = IdType.Parse(idString);
            Assert.Equal(id1, id2);
            id2 = IdType.Parse("3000");
            Assert.Equal(id1, id2);
            id2 = IdType.Parse(" 3000 ");
            Assert.Equal(id1, id2);

            // DateType tests.
            DateType date1 = new DateType(new DateTime(2001, 11, 1));
            String dateString = date1.ToString();
            DateType date2 = DateType.Parse(dateString);
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("11/01/01");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("11/01/2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("1 Nov 2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("1 November 2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("November 1, 2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("Nov, 2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("November, 2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("11-01-2001");
            Assert.Equal(date1, date2);
            date2 = DateType.Parse("11-01-01");
            Assert.Equal(date1, date2);

            //PhoneNumber tests
            //test the constructor
            PhoneNumberType phone1 = new PhoneNumberType("801", "825", "6264", String.Empty);
            //Assert.Equal("(801) 825-6264", phone1.ToString());
            //test the parse method
            PhoneNumberType phone2 = PhoneNumberType.Parse("8018256264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            phone2 = PhoneNumberType.Parse("(801)8256264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            phone2 = PhoneNumberType.Parse("(801)825-6264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            phone2 = PhoneNumberType.Parse("801.825.6264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            phone2 = PhoneNumberType.Parse("801 825 6264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            phone2 = PhoneNumberType.Parse("801.825.6264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            //test the international capabilities
            phone1 = new PhoneNumberType("34", "8256264", String.Empty);
            phone2 = PhoneNumberType.Parse("+34 8256-264");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            //test the extension capabilities
            phone1 = new PhoneNumberType("801", "825", "6264", "107");
            phone2 = PhoneNumberType.Parse("1-801-825-6264 extension 107");
            Assert.Equal(phone1.ToString(), phone2.ToString());
            //Assert.Equal("(801) 825-6264 x107", phone2.ToString());
            //test the dbvalue
            Assert.Equal("8018256264 x107", phone2.DBValue);
            phone2 = PhoneNumberType.Parse("+34 8256-264 ext. 107");
            Assert.Equal("+34 8256264 x107", phone2.DBValue);
            //test local number functionality
            phone2 = PhoneNumberType.Parse("825-6264");
            Assert.Equal("8256264", phone2.DBValue);
        }

        [Fact]
        public void TestEquals() {

            // BooleanType tests.
            Assert.Equal(BooleanType.UNSET, BooleanType.UNSET);
            Assert.Equal(BooleanType.DEFAULT, BooleanType.DEFAULT);
            Assert.Equal(BooleanType.TRUE, BooleanType.TRUE);
            Assert.Equal(BooleanType.FALSE, BooleanType.FALSE);

            Assert.True(!BooleanType.UNSET.Equals(BooleanType.DEFAULT));
            Assert.True(!BooleanType.UNSET.Equals(BooleanType.TRUE));
            Assert.True(!BooleanType.UNSET.Equals(BooleanType.FALSE));

            Assert.True(!BooleanType.DEFAULT.Equals(BooleanType.UNSET));
            Assert.True(!BooleanType.DEFAULT.Equals(BooleanType.TRUE));
            Assert.True(!BooleanType.DEFAULT.Equals(BooleanType.FALSE));

            Assert.True(!BooleanType.TRUE.Equals(BooleanType.UNSET));
            Assert.True(!BooleanType.TRUE.Equals(BooleanType.DEFAULT));
            Assert.True(!BooleanType.TRUE.Equals(BooleanType.FALSE));

            Assert.True(!BooleanType.FALSE.Equals(BooleanType.UNSET));
            Assert.True(!BooleanType.FALSE.Equals(BooleanType.DEFAULT));
            Assert.True(!BooleanType.FALSE.Equals(BooleanType.TRUE));

            Assert.True(!BooleanType.TRUE.Equals(null));
            Assert.True(!BooleanType.TRUE.Equals(new DateType()));

            // Currency type tests.
            CurrencyType c1 = new CurrencyType(100);
            CurrencyType c2 = new CurrencyType(100);
            CurrencyType c3 = new CurrencyType(50);

            Assert.Equal(CurrencyType.UNSET, CurrencyType.UNSET);
            Assert.Equal(CurrencyType.DEFAULT, CurrencyType.DEFAULT);
            Assert.True(!CurrencyType.UNSET.Equals(CurrencyType.DEFAULT));
            Assert.True(!CurrencyType.DEFAULT.Equals(CurrencyType.UNSET));

            Assert.True(!c1.Equals(CurrencyType.UNSET));
            Assert.True(!c1.Equals(CurrencyType.DEFAULT));
            Assert.True(!CurrencyType.UNSET.Equals(c1));
            Assert.True(!CurrencyType.DEFAULT.Equals(c1));
            Assert.Equal(c1, c1);
            Assert.Equal(c1, c2);
            Assert.Equal(c2, c1);
            Assert.True(!c1.Equals(c3));
            Assert.True(!c3.Equals(c1));

            Assert.True(!c1.Equals(null));

            // Quantity type tests.
            QuantityType q1 = new QuantityType(100);
            QuantityType q2 = new QuantityType(100);
            QuantityType q3 = new QuantityType(50);

            Assert.Equal(QuantityType.UNSET, QuantityType.UNSET);
            Assert.Equal(QuantityType.DEFAULT, QuantityType.DEFAULT);
            Assert.True(!QuantityType.UNSET.Equals(QuantityType.DEFAULT));
            Assert.True(!QuantityType.DEFAULT.Equals(QuantityType.UNSET));

            Assert.True(!q1.Equals(QuantityType.UNSET));
            Assert.True(!q1.Equals(QuantityType.DEFAULT));
            Assert.True(!QuantityType.UNSET.Equals(q1));
            Assert.True(!QuantityType.DEFAULT.Equals(q1));
            Assert.Equal(q1, q1);
            Assert.Equal(q1, q2);
            Assert.Equal(q2, q1);
            Assert.True(!q1.Equals(q3));
            Assert.True(!q3.Equals(q1));

            Assert.True(!q1.Equals(null));

            // Decimal type tests.
            DecimalType d1 = new DecimalType(100);
            DecimalType d2 = new DecimalType(100);
            DecimalType d3 = new DecimalType(50);

            Assert.Equal(DecimalType.UNSET, DecimalType.UNSET);
            Assert.Equal(DecimalType.DEFAULT, DecimalType.DEFAULT);
            Assert.True(!DecimalType.UNSET.Equals(DecimalType.DEFAULT));
            Assert.True(!DecimalType.DEFAULT.Equals(DecimalType.UNSET));

            Assert.True(!d1.Equals(DecimalType.UNSET));
            Assert.True(!d1.Equals(DecimalType.DEFAULT));
            Assert.True(!DecimalType.UNSET.Equals(d1));
            Assert.True(!DecimalType.DEFAULT.Equals(d1));
            Assert.Equal(d1, d1);
            Assert.Equal(d1, d2);
            Assert.Equal(d2, d1);
            Assert.True(!d1.Equals(d3));
            Assert.True(!d3.Equals(d1));

            Assert.True(!d1.Equals(null));

            // Compare decimal to currency.
            Assert.True(!CurrencyType.UNSET.Equals(DecimalType.UNSET));
            Assert.True(!CurrencyType.DEFAULT.Equals(DecimalType.DEFAULT));
            Assert.True(!c1.Equals(d1));

            // Compare decimal to quantity.
            Assert.True(!QuantityType.UNSET.Equals(DecimalType.UNSET));
            Assert.True(!QuantityType.DEFAULT.Equals(DecimalType.DEFAULT));
            Assert.True(!q1.Equals(d1));

            // Compare currency to quantity.
            Assert.True(!QuantityType.UNSET.Equals(CurrencyType.UNSET));
            Assert.True(!QuantityType.DEFAULT.Equals(CurrencyType.DEFAULT));
            Assert.True(!q1.Equals(c1));

            // Id type tests.
            IdType id1 = new IdType(100);
            IdType id2 = new IdType(100);
            IdType id3 = new IdType(50);

            Assert.Equal(IdType.UNSET, IdType.UNSET);
            Assert.Equal(IdType.DEFAULT, IdType.DEFAULT);
            Assert.True(!IdType.UNSET.Equals(IdType.DEFAULT));
            Assert.True(!IdType.DEFAULT.Equals(IdType.UNSET));

            Assert.True(!id1.Equals(IdType.UNSET));
            Assert.True(!id1.Equals(IdType.DEFAULT));
            Assert.True(!IdType.UNSET.Equals(id1));
            Assert.True(!IdType.DEFAULT.Equals(id1));
            Assert.Equal(id1, id1);
            Assert.Equal(id1, id2);
            Assert.Equal(id2, id1);
            Assert.True(!id1.Equals(id3));
            Assert.True(!id3.Equals(id1));

            Assert.True(!id1.Equals(null));

            // Integer type tests.
            IntegerType integer1 = new IntegerType(100);
            IntegerType integer2 = new IntegerType(100);
            IntegerType integer3 = new IntegerType(50);

            Assert.True(IntegerType.UNSET.Equals(IntegerType.UNSET));
            Assert.True(IntegerType.DEFAULT.Equals(IntegerType.DEFAULT));
            Assert.True(!IntegerType.UNSET.Equals(IntegerType.DEFAULT));
            Assert.True(!IntegerType.DEFAULT.Equals(IntegerType.UNSET));

            Assert.True(!integer1.Equals(IntegerType.UNSET));
            Assert.True(!integer1.Equals(IntegerType.DEFAULT));
            Assert.True(!IntegerType.UNSET.Equals(integer1));
            Assert.True(!IntegerType.DEFAULT.Equals(integer1));
            Assert.Equal(integer1, integer1);
            Assert.Equal(integer1, integer2);
            Assert.Equal(integer2, integer1);
            Assert.True(!integer1.Equals(integer3));
            Assert.True(!integer3.Equals(integer1));

            Assert.True(!integer1.Equals(null));

            // Compare Integer to id.
            Assert.True(!IntegerType.UNSET.Equals(IdType.UNSET));
            Assert.True(!IntegerType.DEFAULT.Equals(IdType.DEFAULT));
            Assert.True(!id1.Equals(integer1));

            // StringType tests.
            StringType s1 = StringType.Parse("foo");
            StringType s2 = StringType.Parse("foo");
            StringType s3 = StringType.Parse("bar");
            StringType s4 = StringType.Parse("");

            StringType unset1 = StringType.UNSET;
            StringType unset2 = StringType.UNSET;
            Assert.True(unset1 == unset2);

            StringType default1 = StringType.DEFAULT;
            StringType default2 = StringType.DEFAULT;
            Assert.True(default1 == default2);

            StringType empty1 = StringType.EMPTY;
            StringType empty2 = StringType.EMPTY;
            Assert.True(empty1 == empty2);

            Assert.True(!StringType.UNSET.Equals(StringType.DEFAULT));
            Assert.True(!StringType.DEFAULT.Equals(StringType.UNSET));
            Assert.True(!StringType.EMPTY.Equals(StringType.DEFAULT));
            Assert.True(!StringType.DEFAULT.Equals(StringType.EMPTY));
            Assert.True(!StringType.EMPTY.Equals(StringType.UNSET));
            Assert.True(!StringType.UNSET.Equals(StringType.EMPTY));

            Assert.Equal(s4, StringType.EMPTY);
            Assert.Equal(StringType.EMPTY, s4);
            Assert.True(!s1.Equals(StringType.UNSET));
            Assert.True(!s1.Equals(StringType.DEFAULT));
            Assert.True(!StringType.UNSET.Equals(s1));
            Assert.True(!StringType.DEFAULT.Equals(s1));
            Assert.Equal(s1, s1);
            Assert.Equal(s1, s2);
            Assert.Equal(s2, s1);
            Assert.True(!s1.Equals(s3));
            Assert.True(!s3.Equals(s1));

            Assert.True(!s1.Equals(null));

            // TODO: below this was all DateType before, I have changed to DateTimeType as that is what they now closely match
            // TODO: there should be tests for DateType as well as for TimeType too
            // DateType tests.
            DateTimeType date1 = new DateTimeType(new DateTime(20000));
            DateTimeType date2 = new DateTimeType(new DateTime(20000));
            DateTimeType date3 = new DateTimeType(new DateTime(10000));
            DateTimeType date4 = new DateTimeType(new DateTime(30000));

            Assert.Equal(DateTimeType.UNSET, DateTimeType.UNSET);
            Assert.Equal(DateTimeType.DEFAULT, DateTimeType.DEFAULT);
            Assert.True(!DateTimeType.UNSET.Equals(DateTimeType.DEFAULT));
            Assert.True(!DateTimeType.DEFAULT.Equals(DateTimeType.UNSET));

            Assert.True(!date1.Equals(DateTimeType.UNSET));
            Assert.True(!date1.Equals(DateTimeType.DEFAULT));
            Assert.True(!DateTimeType.UNSET.Equals(date1));
            Assert.True(!DateTimeType.DEFAULT.Equals(date1));
            Assert.Equal(date1, date1);
            Assert.Equal(date1, date2);
            Assert.Equal(date2, date1);
            Assert.True(!date1.Equals(date3));
            Assert.True(!date3.Equals(date1));
            Assert.True(!date1.Equals(date4));

            Assert.True(!date1.Equals(null));
        }

        [Fact]
        public void TestEnumEquals() {
            Assert.Equal(GenderType.FEMALE, GenderType.FEMALE);
            Assert.Equal(GenderType.MALE, GenderType.MALE);
            Assert.Equal(GenderType.DEFAULT, GenderType.DEFAULT);
            Assert.Equal(GenderType.UNSET, GenderType.UNSET);
            Assert.True(!GenderType.MALE.Equals(GenderType.FEMALE));
            Assert.True(!GenderType.FEMALE.Equals(GenderType.MALE));
        }

        [Fact]
        public void TestCompare() {
            IntegerType int1 = new IntegerType(10);
            IntegerType int2 = new IntegerType(20);
            IntegerType int3 = new IntegerType(30);
            Assert.True(int2.CompareTo(int1) > 0);
            Assert.True(int2.CompareTo(int2) == 0);
            Assert.True(int2.CompareTo(int3) < 0);
            Assert.True(int2.CompareTo(IntegerType.UNSET) > 0);
            Assert.True(int2.CompareTo(IntegerType.DEFAULT) > 0);
            Assert.True(IntegerType.DEFAULT.CompareTo(int2) < 0);
            Assert.True(IntegerType.UNSET.CompareTo(int2) < 0);
            Assert.True(IntegerType.UNSET.CompareTo(IntegerType.UNSET) == 0);
            Assert.True(IntegerType.DEFAULT.CompareTo(IntegerType.DEFAULT) == 0);
            Assert.True(IntegerType.DEFAULT.CompareTo(IntegerType.UNSET) < 0);
            Assert.True(IntegerType.UNSET.CompareTo(IntegerType.DEFAULT) > 0);

            DecimalType decimal1 = new DecimalType(10.1);
            DecimalType decimal2 = new DecimalType(20.2);
            DecimalType decimal3 = new DecimalType(30.3);
            Assert.True(decimal2.CompareTo(decimal1) > 0);
            Assert.True(decimal2.CompareTo(decimal2) == 0);
            Assert.True(decimal2.CompareTo(decimal3) < 0);
            Assert.True(decimal2.CompareTo(DecimalType.UNSET) > 0);
            Assert.True(decimal2.CompareTo(DecimalType.DEFAULT) > 0);
            Assert.True(DecimalType.DEFAULT.CompareTo(decimal2) < 0);
            Assert.True(DecimalType.UNSET.CompareTo(decimal2) < 0);
            Assert.True(DecimalType.UNSET.CompareTo(DecimalType.UNSET) == 0);
            Assert.True(DecimalType.DEFAULT.CompareTo(DecimalType.DEFAULT) == 0);
            Assert.True(DecimalType.DEFAULT.CompareTo(DecimalType.UNSET) < 0);
            Assert.True(DecimalType.UNSET.CompareTo(DecimalType.DEFAULT) > 0);

            StringType string1 = StringType.Parse("bar");
            StringType string2 = StringType.Parse("foo");
            StringType string3 = StringType.Parse("fubar");
            Assert.True(string2.CompareTo(string1) > 0);
            Assert.True(string2.CompareTo(string2) == 0);
            Assert.True(string2.CompareTo(string3) < 0);
            Assert.True(string2.CompareTo(StringType.UNSET) > 0);
            Assert.True(string2.CompareTo(StringType.DEFAULT) > 0);
            Assert.True(StringType.DEFAULT.CompareTo(string2) < 0);
            Assert.True(StringType.UNSET.CompareTo(string2) < 0);
            Assert.True(StringType.UNSET.CompareTo(StringType.UNSET) == 0);
            Assert.True(StringType.DEFAULT.CompareTo(StringType.DEFAULT) == 0);
            Assert.True(StringType.DEFAULT.CompareTo(StringType.UNSET) < 0);
            Assert.True(StringType.UNSET.CompareTo(StringType.DEFAULT) > 0);

            DateType date1 = new DateType(new DateTime(1969, 12, 18));
            DateType date2 = new DateType(new DateTime(2001, 11, 01));
            DateType date3 = new DateType(new DateTime(2003, 5, 9));
            Assert.True(date2.CompareTo(date1) > 0);
            Assert.True(date2.CompareTo(date2) == 0);
            Assert.True(date2.CompareTo(date3) < 0);
            Assert.True(date2.CompareTo(DateType.UNSET) > 0);
            Assert.True(date2.CompareTo(DateType.DEFAULT) > 0);
            Assert.True(DateType.DEFAULT.CompareTo(date2) < 0);
            Assert.True(DateType.UNSET.CompareTo(date2) < 0);
            Assert.True(DateType.UNSET.CompareTo(DateType.UNSET) == 0);
            Assert.True(DateType.DEFAULT.CompareTo(DateType.DEFAULT) == 0);
            Assert.True(DateType.DEFAULT.CompareTo(DateType.UNSET) < 0);
            Assert.True(DateType.UNSET.CompareTo(DateType.DEFAULT) > 0);
        }

        [Fact]
        public void TestLessThanGreaterThan() {
            DecimalType d1 = new DecimalType(-1);
            DecimalType d2 = new DecimalType(1);
            DecimalType d3 = new DecimalType(1);

            Assert.True(d1 < d2);
            Assert.True(d2 > d1);
            Assert.True(d2 > DecimalType.ZERO);
            Assert.True(DecimalType.ZERO < d2);
            Assert.True(d1 < DecimalType.ZERO);
            Assert.True(DecimalType.ZERO > d1);
            Assert.True(!(d2 < d3));
            Assert.True(d2 <= d3);
            Assert.True(d2 >= d3);

            //Assert.True(!(DecimalType.DEFAULT < DecimalType.DEFAULT));
            //Assert.True(DecimalType.DEFAULT <= DecimalType.DEFAULT);
            //Assert.True(!(DecimalType.DEFAULT > DecimalType.DEFAULT));
            //Assert.True(DecimalType.DEFAULT >= DecimalType.DEFAULT);

            //Assert.True(!(DecimalType.UNSET < DecimalType.UNSET));
            //Assert.True(DecimalType.UNSET <= DecimalType.UNSET);
            //Assert.True(!(DecimalType.UNSET > DecimalType.UNSET));
            //Assert.True(DecimalType.UNSET >= DecimalType.UNSET);

            Assert.True(DecimalType.DEFAULT < DecimalType.UNSET);
            Assert.True(DecimalType.DEFAULT < DecimalType.ZERO);
            Assert.True(DecimalType.DEFAULT < d1);
            Assert.True(DecimalType.DEFAULT < d2);

            CurrencyType c1 = new CurrencyType(-1);
            CurrencyType c2 = new CurrencyType(1);
            CurrencyType c3 = new CurrencyType(1);

            Assert.True(c1 < c2);
            Assert.True(c2 > c1);
            Assert.True(c2 > CurrencyType.ZERO);
            Assert.True(CurrencyType.ZERO < c2);
            Assert.True(c1 < CurrencyType.ZERO);
            Assert.True(CurrencyType.ZERO > c1);
            Assert.True(!(c2 < c3));
            Assert.True(c2 <= c3);
            Assert.True(c2 >= c3);

            //Assert.True(!(CurrencyType.DEFAULT < CurrencyType.DEFAULT));
            //Assert.True(CurrencyType.DEFAULT <= CurrencyType.DEFAULT);
            //Assert.True(!(CurrencyType.DEFAULT > CurrencyType.DEFAULT));
            //Assert.True(CurrencyType.DEFAULT >= CurrencyType.DEFAULT);

            //Assert.True(!(CurrencyType.UNSET < CurrencyType.UNSET));
            //Assert.True(CurrencyType.UNSET <= CurrencyType.UNSET);
            //Assert.True(!(CurrencyType.UNSET > CurrencyType.UNSET));
            //Assert.True(CurrencyType.UNSET >= CurrencyType.UNSET);

            Assert.True(CurrencyType.DEFAULT < CurrencyType.UNSET);
            Assert.True(CurrencyType.DEFAULT < CurrencyType.ZERO);
            Assert.True(CurrencyType.DEFAULT < c1);
            Assert.True(CurrencyType.DEFAULT < c2);
        }

        [Fact]
        public void TestEndOfQuarter() {

            DateType date = DateType.Parse("2/28/2002");
            DateType lastQuarterEnd = date.EndOfPreviousQuarter;
            DateType thisQuarterEnd = date.EndOfCurrentQuarter;
            Assert.True(DateTime.Parse("12/31/2001").Date.Equals(lastQuarterEnd.ToDateTime().Date));
            Assert.True(DateTime.Parse("3/31/2002").Date.Equals(thisQuarterEnd.ToDateTime().Date));

            date = DateType.Parse("6/1/2002");
            lastQuarterEnd = date.EndOfPreviousQuarter;
            thisQuarterEnd = date.EndOfCurrentQuarter;
            Assert.True(DateTime.Parse("3/31/2002").Date.Equals(lastQuarterEnd.ToDateTime().Date));
            Assert.True(DateTime.Parse("6/30/2002").Date.Equals(thisQuarterEnd.ToDateTime().Date));

            date = DateType.Parse("7/1/2002");
            lastQuarterEnd = date.EndOfPreviousQuarter;
            thisQuarterEnd = date.EndOfCurrentQuarter;
            Assert.True(DateTime.Parse("6/30/2002").Date.Equals(lastQuarterEnd.ToDateTime().Date));
            Assert.True(DateTime.Parse("9/30/2002").Date.Equals(thisQuarterEnd.ToDateTime().Date));

            date = DateType.Parse("12/31/2002");
            lastQuarterEnd = date.EndOfPreviousQuarter;
            thisQuarterEnd = date.EndOfCurrentQuarter;
            Assert.True(DateTime.Parse("9/30/2002").Date.Equals(lastQuarterEnd.ToDateTime().Date));
            Assert.True(DateTime.Parse("12/31/2002").Date.Equals(thisQuarterEnd.ToDateTime().Date));
        }
    }
}
