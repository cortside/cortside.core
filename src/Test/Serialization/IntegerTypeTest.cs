using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test.Serialization {

    public class IntegerTypeTest {

        [Serializable]
        public class ValueObject : DataObject.DataObject {
            private IntegerType _valid = new IntegerType(1);
            private IntegerType _unset = IntegerType.UNSET;
            private IntegerType _default = IntegerType.DEFAULT;

            public IntegerType Valid {
                get { return _valid; }
                set { _valid = value; }
            }

            public IntegerType Unset {
                get { return _unset; }
                set { _unset = value; }
            }

            public IntegerType Default {
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
            IntegerType s = new IntegerType(1);
            IntegerType s2 = (IntegerType)SerializeDeserialze(s);

            Assert.True(s2.IsValid);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeUnset() {
            IntegerType s = IntegerType.UNSET;
            IntegerType s2 = (IntegerType)SerializeDeserialze(s);

            Assert.True(s2.IsUnset);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeDefault() {
            IntegerType s = IntegerType.DEFAULT;
            IntegerType s2 = (IntegerType)SerializeDeserialze(s);

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
