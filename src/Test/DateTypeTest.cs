
using Spring2.Core.Types;
using Xunit;

namespace Spring2.Core.Test {

    public class DateTypeTest {

        [Fact]
        public void TestSameDateAs() {
            // TODO: changed from DateType to DateTimeType -- what should be done for DateType
            Assert.True(!DateTimeType.Today.Equals(DateTimeType.Now), "Should not be equal.");
            Assert.True(DateTimeType.Today.SameDayAs(DateTimeType.Now), "Should have same dates.");
            Assert.True(!DateTimeType.Today.SameDayAs(DateTimeType.UNSET), "Should not have same date as UNSET.");
            Assert.True(!DateTimeType.Today.SameDayAs(DateTimeType.DEFAULT), "Should not have same date as DEFAULT.");
        }
    }
}
