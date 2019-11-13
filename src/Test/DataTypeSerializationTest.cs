using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    /// <summary>
    /// Tests for BooleanType
    /// </summary>
    public class DataTypeSerializationTest {

        [Serializable]
        public class UserData : DataObject.DataObject {
            private StringType name = StringType.DEFAULT;

            public StringType Name {
                get { return name; }
                set { name = value; }
            }
        }

        [Serializable]
        public class BooleanSerializationClass {
            private BooleanType bUnset = BooleanType.DEFAULT;
            private BooleanType bDefault = BooleanType.DEFAULT;
            private BooleanType bTrue = BooleanType.TRUE;
            private BooleanType bFalse = BooleanType.FALSE;

            public BooleanType BUnset {
                get { return bUnset; }
                set { bUnset = value; }
            }

            public BooleanType BDefault {
                get { return bDefault; }
                set { bDefault = value; }
            }

            public BooleanType BTrue {
                get { return bTrue; }
                set { bTrue = value; }
            }

            public BooleanType BFalse {
                get { return bFalse; }
                set { bFalse = value; }
            }
        }

        [Fact]
        public void TestBooleanTypeSerialization() {
            //Needs 3.0 framework.

            /*
       NetDataContractSerializer serializer = new NetDataContractSerializer();
            
       Stream saveStream = File.Create("save.dat");

       //save code 
		   BooleanSerializationClass before = new BooleanSerializationClass();
		   before.BUnset = BooleanType.UNSET;
		   before.BDefault = BooleanType.DEFAULT;
		   before.BTrue = BooleanType.TRUE;
		   before.BFalse = BooleanType.FALSE;
       serializer.Serialize(saveStream, before);
       saveStream.Close();

       //and my load is this 
       Stream loadStream = File.OpenRead("save.dat");
       //load code 
       BooleanSerializationClass after = (BooleanSerializationClass)(serializer.Deserialize(loadStream));
       loadStream.Close();

		   Assert.Equal(BooleanType.UNSET, after.BUnset);
		   Assert.Equal(BooleanType.DEFAULT, after.BDefault);
		   Assert.Equal(BooleanType.TRUE, after.BTrue);
		   Assert.Equal(BooleanType.FALSE, after.BFalse);
		   */
        }

        [Fact]
        public void TestBooleanTypeSerialization_Binary() {
            BinaryFormatter serializer = new BinaryFormatter();

            Stream saveStream = File.Create("save.dat");

            //save code 
            BooleanSerializationClass before = new BooleanSerializationClass();
            before.BUnset = BooleanType.UNSET;
            before.BDefault = BooleanType.DEFAULT;
            before.BTrue = BooleanType.TRUE;
            before.BFalse = BooleanType.FALSE;
            serializer.Serialize(saveStream, before);
            saveStream.Close();

            //and my load is this 
            Stream loadStream = File.OpenRead("save.dat");
            //load code 
            BooleanSerializationClass after = (BooleanSerializationClass)(serializer.Deserialize(loadStream));
            loadStream.Close();

            Assert.Equal(BooleanType.UNSET, after.BUnset);
            Assert.Equal(BooleanType.DEFAULT, after.BDefault);
            Assert.Equal(BooleanType.TRUE, after.BTrue);
            Assert.Equal(BooleanType.FALSE, after.BFalse);
        }

        [Fact]
        public void ShouldBinarySerializeStringTypeWithValue() {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            StringType s = new StringType("foo");

            FileStream fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            binaryFmt.Serialize(fs, s);
            fs.Close();
            Console.WriteLine("Original value: {0}", s.ToString());

            // Deserialize.
            fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            StringType s2 = (StringType)binaryFmt.Deserialize(fs);
            Console.WriteLine("New value: {0}", s2.ToString());
            fs.Close();

            Assert.False(Object.ReferenceEquals(s, s2));
        }

        [Fact]
        public void ShouldBinarySerializeStringTypeUnset() {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            StringType s = StringType.UNSET;

            FileStream fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            binaryFmt.Serialize(fs, s);
            fs.Close();
            Console.WriteLine("Original value is UNSET: {0}", s.IsUnset);

            // Deserialize.
            fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            StringType s2 = (StringType)binaryFmt.Deserialize(fs);
            Console.WriteLine("new value is UNSET: {0}", s2.IsUnset);
            fs.Close();
            Assert.True(Object.Equals(s, s2));
        }

        [Fact]
        public void TestDataObject() {
            BinaryFormatter binaryFmt = new BinaryFormatter();
            UserData u = new UserData();

            FileStream fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            binaryFmt.Serialize(fs, u);
            fs.Close();
            Console.WriteLine("Original value is UNSET: {0}", u.Name.IsUnset);

            // Deserialize.
            fs = new FileStream("foo.dat", FileMode.OpenOrCreate);
            Object o = binaryFmt.Deserialize(fs);
            UserData u2 = (UserData)o;
            Console.WriteLine("new value is UNSET: {0}", u2.Name.IsUnset);
            fs.Close();
            Assert.True(Object.Equals(u.Name, u2.Name));
            Assert.True(Object.Equals(u, u2));
        }

    }

}
