
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    /// <summary>
    /// Tests for BooleanType
    /// </summary>
    public class BooleanTypeTest {

        [Fact]
        public void TestParse() {
            Assert.True(BooleanType.FALSE.IsValid);
            Assert.True(BooleanType.TRUE.IsValid);

            Assert.False(BooleanType.FALSE.ToBoolean());
            Assert.True(BooleanType.TRUE.ToBoolean());

            Assert.False(BooleanType.UNSET.IsValid);
            Assert.False(BooleanType.DEFAULT.IsValid);
        }

        [Fact]
        public void ShouldConstructFromBoolean() {
            BooleanType bt = new BooleanType(true);
            Assert.True(bt.ToBoolean());

            bt = new BooleanType(false);
            Assert.False(bt.ToBoolean());
        }

        [Fact]
        public void ShouldImplicitlyConvertFromBoolean() {
            BooleanType bt = true;
            Assert.True(bt.ToBoolean());

            bt = false;
            Assert.False(bt.ToBoolean());
        }

    }
}
