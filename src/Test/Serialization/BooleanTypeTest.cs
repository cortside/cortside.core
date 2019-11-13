using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test.Serialization {

    public class BooleanTypeTest {

        [Serializable]
        public class ValueObject : DataObject.DataObject {
            private BooleanType _valid = new BooleanType(true);
            private BooleanType _unset = BooleanType.UNSET;
            private BooleanType _default = BooleanType.DEFAULT;

            public BooleanType Valid {
                get { return _valid; }
                set { _valid = value; }
            }

            public BooleanType Unset {
                get { return _unset; }
                set { _unset = value; }
            }

            public BooleanType Default {
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
            BooleanType s = new BooleanType(true);
            BooleanType s2 = (BooleanType)SerializeDeserialze(s);

            Assert.True(s2.IsValid);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeUnset() {
            BooleanType s = BooleanType.UNSET;
            BooleanType s2 = (BooleanType)SerializeDeserialze(s);

            Assert.True(s2.IsUnset);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeDefault() {
            BooleanType s = BooleanType.DEFAULT;
            BooleanType s2 = (BooleanType)SerializeDeserialze(s);

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
