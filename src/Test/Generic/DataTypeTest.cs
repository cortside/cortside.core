using System;
using Cortside.Core.Types;
using Cortside.Core.Types.Generic;
using Xunit;

namespace Cortside.Core.Test.Generic {

    public class DataTypeTest {

        [Fact]
        public void ShouldCompareEqual() {
            DataType<Int32> t1 = new DataType<Int32>(1);
            DataType<Int32> t2 = new DataType<Int32>(1);

            Assert.Equal(t1, t2);
            Assert.True(t1 == t2);
        }

        [Fact]
        public void ShouldCompareNotEqual() {
            DataType<Int32> t1 = new DataType<Int32>(1);
            DataType<Int32> t2 = new DataType<Int32>(2);

            Assert.NotEqual(t1, t2);
            Assert.True(t1 != t2);
        }

        [Fact]
        public void ShouldCompareLessThan() {
            DataType<Int32> t1 = new DataType<Int32>(1);
            Int32 t2 = 2;

            Assert.True(t1 < t2);
        }

        [Fact]
        public void ShouldCompareGreaterThan() {
            DataType<Int32> t1 = new DataType<Int32>(1);
            Int32 t2 = 2;

            Assert.True(t2 > t1);
        }

        [Fact]
        public void foo() {
            DataType<Int32> t1 = new DataType<Int32>(1);
            DataType<Int32> t2 = new DataType<Int32>(2);
            DataType<Int32> t1_1 = new DataType<Int32>(1);
            DataType<Int32> _unset = new DataType<Int32>(TypeState.UNSET);
            DataType<Int32> _default = new DataType<Int32>(TypeState.DEFAULT);

            Int32 i = t1.Value;
            Assert.Equal(1, i);
            try {
                var foo = _unset.Value;
            } catch (InvalidOperationException) {
                // pass
            }
            try {
                var foo = _default.Value;
            } catch (InvalidOperationException) {
                // pass
            }

            Assert.True(_unset.IsUnset);
            Assert.False(_unset.IsDefault);
            Assert.False(_unset.IsValid);

            Assert.False(_default.IsUnset);
            Assert.True(_default.IsDefault);
            Assert.False(_default.IsValid);

            Assert.False(t1.IsUnset);
            Assert.False(t1.IsDefault);
            Assert.True(t1.IsValid);

            Assert.True(t1 < t2);
            Assert.True(t2 > t1);
            Assert.True(t1 != t2);
            Assert.True(t1 == t1_1);

            Assert.True(t1 == 1);
            Assert.True(t1 != 2);

            Assert.True(IntegerType.DEFAULT > IntegerType.UNSET);
            Assert.True(IntegerType.ZERO > IntegerType.UNSET);
            Assert.True(IntegerType.ZERO > IntegerType.DEFAULT);

            Assert.False(IntegerType.DEFAULT < IntegerType.UNSET);
            Assert.False(IntegerType.ZERO < IntegerType.UNSET);
            Assert.False(IntegerType.ZERO < IntegerType.DEFAULT);

            Assert.True(IntegerType.UNSET < IntegerType.ZERO);
            Assert.True(IntegerType.DEFAULT < IntegerType.ZERO);
            Assert.True(IntegerType.UNSET < IntegerType.DEFAULT);

            Assert.False(IntegerType.UNSET > IntegerType.ZERO);
            Assert.False(IntegerType.DEFAULT > IntegerType.ZERO);
            Assert.False(IntegerType.UNSET > IntegerType.DEFAULT);

            Assert.False(_unset.Equals(null));
            Assert.False(_unset.Equals(_default));
            Assert.False(_default.Equals(_unset));
            Assert.False(_unset.Equals(t1));

            Assert.True(t1.Equals(t1_1));
            Assert.True(_unset.Equals(new DataType<Int32>(TypeState.UNSET)));
            Assert.True(_default.Equals(new DataType<Int32>(TypeState.DEFAULT)));

            Assert.False(t1.Equals(null));
            Assert.False(t1.Equals(_default));
            Assert.False(t1.Equals(_unset));

            Assert.False(t1.Equals(null));
            Assert.False(t1.Equals(new DataType<Int64>(1)));

            Assert.True(_default > _unset);
            Assert.True(t1 > _unset);
            Assert.True(t1 > _default);

            Assert.False(_default < _unset);
            Assert.False(t1 < _unset);
            Assert.False(t1 < _default);

            Assert.True(_unset < t1);
            Assert.True(_default < t1);
            Assert.True(_unset < _default);

            Assert.False(_unset > t1);
            Assert.False(_default > t1);
            Assert.False(_unset > _default);

            Assert.True(1 > _unset);
            Assert.True(1 > _default);

            Assert.False(1 < _unset);
            Assert.False(1 < _default);

            Assert.True(_unset < 1);
            Assert.True(_default < 1);

            Assert.False(_unset > 1);
            Assert.False(_default > 1);

            Assert.Equal(0, _unset.GetHashCode());
            Assert.Equal(0, _default.GetHashCode());
            Assert.Equal(1.GetHashCode(), t1.GetHashCode());

            Assert.Equal("UNSET", _unset.ToString());
            Assert.Equal("DEFAULT", _default.ToString());
            Assert.Equal("1", t1.ToString());

            i = (Int32)t2;
            Assert.Equal(2, i);

            Assert.Equal(1, t1.GetValueOrDefault());
            Assert.Equal(1, t1.GetValueOrDefault(2));
            Assert.Equal(0, _unset.GetValueOrDefault());
            Assert.Equal(2, _unset.GetValueOrDefault(2));

            //Assert.True(_default == _default);
            //Assert.True(_unset == _unset);
            //Assert.True(t1 == t1);

            Object o = t1;
            Assert.True(t1.Equals((DataType<Int32>)o));
        }

    }
}
