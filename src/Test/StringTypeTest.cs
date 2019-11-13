using System;
using System.Reflection;
using Spring2.Core.Types;
using Xunit;

namespace Spring2.Core.Test {

    /// <summary>
    /// Tests for BooleanType
    /// </summary>

    public class StringTypeTest {

        private StringType propertyValue = StringType.DEFAULT;

        [Fact]
        public void ComparisonAgainstNullValue() {
            string temp = null;
            StringType a = new StringType(temp);
            StringType b = StringType.UNSET;
            bool equals = StringType.Equals(a, b);
        }

        [Fact]
        public void AssignmentFromString() {
            String foo = "foo";
            StringType s2 = StringType.Parse(foo);
            StringType s3 = StringType.Parse(foo);
            Assert.Equal(s2, s3);

            StringType s1 = foo;
            Assert.Equal(foo, s1.ToString());
            Assert.Equal(s2, s1);

            // this fails -- why?
            Assert.Equal(StringType.Parse("foo"), s1);
        }

        [Fact]
        public void AssignementFromObject() {
            StringType s1 = "foo";
            Object o = s1 as Object;

            PropertyInfo property = this.GetType().GetProperty("StringTypeProperty");
            property.SetValue(this, o, null);
            Assert.Equal(s1, propertyValue);
        }

        /// <summary>
        /// Property for AssignementFromDataObject test
        /// </summary>
        public StringType StringTypeProperty {
            get { return propertyValue; }
            set { propertyValue = value; }
        }

        [Fact]
        public void ToStringTest() {
            Assert.Equal("UNSET", StringType.UNSET.ToString());
            Assert.Equal("DEFAULT", StringType.DEFAULT.ToString());

            Assert.Equal("UNSET", BooleanType.UNSET.ToString());
            Assert.Equal("DEFAULT", BooleanType.DEFAULT.ToString());

            Assert.Equal("UNSET", CurrencyType.UNSET.ToString());
            Assert.Equal("DEFAULT", CurrencyType.DEFAULT.ToString());

            Assert.Equal("UNSET", DateType.UNSET.ToString());
            Assert.Equal("DEFAULT", DateType.DEFAULT.ToString());

            Assert.Equal("UNSET", DecimalType.UNSET.ToString());
            Assert.Equal("DEFAULT", DecimalType.DEFAULT.ToString());

            Assert.Equal("UNSET", GenderType.UNSET.ToString());
            Assert.Equal("DEFAULT", GenderType.DEFAULT.ToString());

            Assert.Equal("UNSET", IdType.UNSET.ToString());
            Assert.Equal("DEFAULT", IdType.DEFAULT.ToString());

            Assert.Equal("UNSET", IntegerType.UNSET.ToString());
            Assert.Equal("DEFAULT", IntegerType.DEFAULT.ToString());

            Assert.Equal("UNSET", PhoneNumberType.UNSET.ToString());
            Assert.Equal("DEFAULT", PhoneNumberType.DEFAULT.ToString());

            Assert.Equal("UNSET", QuantityType.UNSET.ToString());
            Assert.Equal("DEFAULT", QuantityType.DEFAULT.ToString());

            Assert.Equal("UNSET", RowVersionType.UNSET.ToString());
            Assert.Equal("DEFAULT", RowVersionType.DEFAULT.ToString());

            Assert.Equal("UNSET", StringType.UNSET.ToString());
            Assert.Equal("DEFAULT", StringType.DEFAULT.ToString());

            Assert.Equal("UNSET", USStateCodeEnum.UNSET.ToString());
            Assert.Equal("DEFAULT", USStateCodeEnum.DEFAULT.ToString());
        }

    }
}
