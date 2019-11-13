using System;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    public class DateTimeTypeTest {

        [Fact]
        public void TestCompareNoSeconds() {
            DateTimeType d1 = DateTimeType.Now;
            DateTimeType d2 = d1;
            Assert.Equal(0, d1.CompareNoSeconds(d2));
            d2 = DateTimeType.Now.AddSeconds(50);
            Assert.Equal(0, d1.CompareNoSeconds(d2));
            d2 = DateTimeType.Now.AddSeconds(120);
            Assert.Equal(-1, d1.CompareNoSeconds(d2));
            d2 = DateTimeType.Now.AddSeconds(-240);
            Assert.Equal(1, d1.CompareNoSeconds(d2));
        }

        [Fact]
        public void ShouldBeAbleToCreateWithTicks() {
            DateTimeType date = new DateTimeType(630823790450060000);
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(6, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDay() {
            DateTimeType date = new DateTimeType(2000, 1, 2);
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(0, date.Hour);
            Assert.Equal(0, date.Minute);
            Assert.Equal(0, date.Second);
            Assert.Equal(0, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDayCalendar() {
            DateTimeType date = new DateTimeType(2000, 1, 2, new System.Globalization.GregorianCalendar());
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(0, date.Hour);
            Assert.Equal(0, date.Minute);
            Assert.Equal(0, date.Second);
            Assert.Equal(0, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDayHourMinutesSeconds() {
            DateTimeType date = new DateTimeType(2000, 1, 2, 3, 4, 5);
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(0, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDayHourMinutesSecondsCalendar() {
            DateTimeType date = new DateTimeType(2000, 1, 2, 3, 4, 5, new System.Globalization.GregorianCalendar());
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(0, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDayHourMinutesSecondsMilliseconds() {
            DateTimeType date = new DateTimeType(2000, 1, 2, 3, 4, 5, 6);
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(6, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateWithYearMonthDayHourMinutesSecondsMillisecondsCalendar() {
            DateTimeType date = new DateTimeType(2000, 1, 2, 3, 4, 5, 6, new System.Globalization.GregorianCalendar());
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(6, date.Millisecond);
        }

        [Fact]
        public void ShouldBeAbleToCreateFromDateTime() {
            DateTimeType date = new DateTimeType(new DateTime(2000, 1, 2, 3, 4, 5, 6));
            Assert.Equal(2000, date.Year);
            Assert.Equal(1, date.Month);
            Assert.Equal(2, date.Day);
            Assert.Equal(3, date.Hour);
            Assert.Equal(4, date.Minute);
            Assert.Equal(5, date.Second);
            Assert.Equal(6, date.Millisecond);
        }

        [Fact]
        public void ShouldCalculateBeginningOfDay() {
            DateTimeType date = DateTimeType.Now;
            Assert.Equal(DateTimeType.Today, date.BeginningOfDay);
        }

        [Fact]
        public void ShouldCalculateEndOfDay() {
            DateTimeType date = DateTimeType.Now;
            DateTimeType endOfDay = DateTimeType.Today.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(997);
            Assert.Equal(endOfDay, date.EndOfDay);
        }
        [Fact]
        public void ShoulCalculateEndOfMonth() {
            DateTimeType date = new DateTimeType(2007, 1, 1);
            DateTimeType endOfMonth = new DateTimeType(date.Year, date.Month, DateTimeType.DaysInMonth(date.Year, date.Month));
            Assert.Equal(endOfMonth, date.EndOfMonth);
        }
    }
}
