
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    public class IdTypeTest {

        [Fact]
        public void ImplicitIntOperator() {
            IdType id = 1;
            Assert.Equal(new IdType(1), id);
        }

        [Fact]
        public void OperatorEquals() {
            IdType id1 = new IdType(5);
            IdType id2 = new IdType(5);
            Assert.Equal(id1, id2);
            Assert.True(id1.Equals(id2));
            Assert.True(id1 == id2);
        }
    }
}
