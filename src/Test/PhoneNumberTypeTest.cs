
using Spring2.Core.Types;
using Xunit;

namespace Spring2.Core.Test {

    public class PhoneNumberTypeTest {

        [Fact]
        public void Parse() {
            Assert.False(PhoneNumberType.Parse("-").IsDefault);
            Assert.True(PhoneNumberType.Parse("-").IsUnset);
            Assert.False(PhoneNumberType.Parse("-").IsValid);
            Assert.Equal("UNSET", PhoneNumberType.Parse("-").ToString());

            Assert.False(PhoneNumberType.Parse("").IsDefault);
            Assert.True(PhoneNumberType.Parse("").IsUnset);
            Assert.False(PhoneNumberType.Parse("").IsValid);
            Assert.Equal("UNSET", PhoneNumberType.Parse("").ToString());

            PhoneNumberType phoneNumber = PhoneNumberType.Parse("1234567");
            Assert.True(phoneNumber.IsValid);
            Assert.Equal("123-4567", phoneNumber.ToString());

            // what should this really do?
            phoneNumber = PhoneNumberType.Parse("123456");
            Assert.True(phoneNumber.IsValid);
            Assert.Equal("123-456", phoneNumber.ToString());

            // I am sure the number is not supposed to be truncated, but what is right?
            phoneNumber = PhoneNumberType.Parse("12345678901234567890");
            Assert.True(phoneNumber.IsValid);
            // TODO: fails
            //Assert.Equal("12345678901234567890", phoneNumber.ToString());

            Assert.Equal("(801) 123-1234", PhoneNumberType.Parse("801.123.1234").ToString());
        }
    }
}
