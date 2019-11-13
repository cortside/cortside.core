using System;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    public class IntegerTypeTest {

        [Fact]
        public void ImplicitIntOperator() {
            IntegerType id = 1;
            Assert.Equal(new IntegerType(1), id);
        }

        [Fact]
        public void ExplicitCastToInt32() {
            Int32 i32 = 1111111;
            IntegerType i = i32;
            Assert.Equal(i32, i.ToInt32());
            Assert.Equal(i32, (int)i);
        }

    }
}
