using System;
using Spring2.Core.Util;
using Xunit;

namespace Spring2.Core.Test {
    /// <summary>
    /// Summary description for PagedListTest.
    /// </summary>
    public class RangeTest {
        [Fact]
        public void ShouldBeAbleToCreateRange() {
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);

            Range<DateTime> obj = new Range<DateTime>(yesterday, today);
            Assert.Equal(yesterday, obj.Start);
            Assert.Equal(today, obj.End);
        }
        [Fact]
        public void ShouldNotBeAbleToCreateRangeWhereStartIsAfterEnd() {
            DateTime today = DateTime.Now;
            DateTime yesterday = today.AddDays(-1);

            try {
                Range<DateTime> obj = new Range<DateTime>(today, yesterday);
                Assert.True(false, "Should not allow a Range where end is before start");
            } catch {
                //Expected
            }
        }
        [Fact]
        public void ShouldCorrectlyDetermineIfRangesOverlap() {
            int one = 1;
            int five = 5;
            int ten = 10;
            int fifteen = 15;

            Assert.True(Range.Overlap<int>(new Range<int>(one, ten), new Range<int>(five, fifteen)));
            Assert.True(Range.Overlap<int>(new Range<int>(one, five), new Range<int>(five, ten)));
            Assert.True(Range.Overlap<int>(new Range<int>(one, ten), new Range<int>(one, ten)));
            Assert.False(Range.Overlap<int>(new Range<int>(one, five), new Range<int>(ten, fifteen)));
            Assert.False(Range.Overlap<int>(new Range<int>(one, one), new Range<int>(fifteen, fifteen)));
        }
    }
}