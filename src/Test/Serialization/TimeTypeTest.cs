using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test.Serialization {

    public class TimeTypeTest {

        [Serializable]
        public class ValueObject : DataObject.DataObject {
            private TimeType _valid = new TimeType(1);
            private TimeType _unset = TimeType.UNSET;
            private TimeType _default = TimeType.DEFAULT;

            public TimeType Valid {
                get { return _valid; }
                set { _valid = value; }
            }

            public TimeType Unset {
                get { return _unset; }
                set { _unset = value; }
            }

            public TimeType Default {
                get { return _default; }
                set { _default = value; }
            }
        }

        /// <summary>
        /// Utility method to serialize to memory and then deserialize an object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Object SerializeDeserialze(Object value) {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            binaryFmt.Serialize(ms, value);

            // Deserialize.
            ms.Position = 0;
            Object value2 = binaryFmt.Deserialize(ms);
            ms.Close();

            return value2;
        }

        [Fact]
        public void ShouldBinarySerializeWithValue() {
            TimeType s = new TimeType(1);
            TimeType s2 = (TimeType)SerializeDeserialze(s);

            Assert.True(s2.IsValid);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeUnset() {
            TimeType s = TimeType.UNSET;
            TimeType s2 = (TimeType)SerializeDeserialze(s);

            Assert.True(s2.IsUnset);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeDefault() {
            TimeType s = TimeType.DEFAULT;
            TimeType s2 = (TimeType)SerializeDeserialze(s);

            Assert.True(s2.IsDefault);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeInValueObject() {
            ValueObject vo = new ValueObject();
            ValueObject vo2 = (ValueObject)SerializeDeserialze(vo);

            Assert.True(vo.Equals(vo2));
            Assert.True(vo.Valid.IsValid);
            Assert.True(vo.Unset.IsUnset);
            Assert.True(vo.Default.IsDefault);
        }

    }

}
