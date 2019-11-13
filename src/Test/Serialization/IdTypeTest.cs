using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Spring2.Core.Types;
using Xunit;

namespace Spring2.Core.Test.Serialization {

    public class IdTypeTest {

        [Serializable]
        public class ValueObject : DataObject.DataObject {
            private IdType _valid = new IdType(1);
            private IdType _unset = IdType.UNSET;
            private IdType _default = IdType.DEFAULT;

            public IdType Valid {
                get { return _valid; }
                set { _valid = value; }
            }

            public IdType Unset {
                get { return _unset; }
                set { _unset = value; }
            }

            public IdType Default {
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
            IdType s = new IdType(1);
            IdType s2 = (IdType)SerializeDeserialze(s);

            Assert.True(s2.IsValid);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeUnset() {
            IdType s = IdType.UNSET;
            IdType s2 = (IdType)SerializeDeserialze(s);

            Assert.True(s2.IsUnset);
            Assert.True(s.Equals(s2));
        }

        [Fact]
        public void ShouldBinarySerializeDefault() {
            IdType s = IdType.DEFAULT;
            IdType s2 = (IdType)SerializeDeserialze(s);

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
