using System;
using System.Collections.Specialized;
using Cortside.Core.Message;
using Cortside.Core.PropertyPopulator;
using Cortside.Core.Types;
using Xunit;

namespace Cortside.Core.Test {

    public class PropertyPopulatorTest {

        [Fact]
        public void ShouldBeAbleToPopulateSomeProperties() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "value1");
            collection.Add("systemBool", "true");
            collection.Add("systemDecimal", "1.1");
            collection.Add("systemSByte", "1");
            collection.Add("systemByte", "1");
            collection.Add("systemShort", "1");
            collection.Add("systemUShort", "1");
            collection.Add("systemInt", "1");
            collection.Add("systemUInt", "1");
            collection.Add("systemLong", "1");
            collection.Add("systemULong", "1");
            collection.Add("systemChar", "a");
            collection.Add("systemFloat", "1");
            collection.Add("systemDouble", "1");
            collection.Add("valueBooleanType", "Y");
            collection.Add("valueCurrencyType", "1.01");
            collection.Add("valueCurrencyTypeList", "1.01,2.02");
            collection.Add("valueDateTimeType", "1/1/2005 1:01");
            collection.Add("valueDateType", "1/1/2005");
            collection.Add("valueDateTypeList", "1/1/2005,2/2/2005");
            collection.Add("valueDecimalType", "1.1");
            collection.Add("valueDecimalTypeList", "1.1,2.2");
            collection.Add("valueGenderType", "M");
            collection.Add("valueIdType", "1");
            collection.Add("valueIdTypeList", "1,2");
            collection.Add("valueIntegerType", "1");
            collection.Add("valueIntegerTypeList", "1,2");
            collection.Add("valueLongType", "1");
            collection.Add("valuePhoneNumberType", "(801)555-6666");
            collection.Add("valueQuantityType", "1");
            collection.Add("valueShortType", "1");
            collection.Add("valueStringType", "value2");
            collection.Add("valueStringTypeList", "value2,value3");
            collection.Add("valueTimeType", "11:11");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleDataForm data = new SampleDataForm();
            Populator.Instance.Populate(data, collection);

            //assert object was populated
            Assert.Equal("value1", data.SystemString);
            Assert.True(data.SystemBool);
            Assert.Equal(1.1M, data.SystemDecimal);
            Assert.Equal(1, data.SystemSByte);
            Assert.Equal(1, data.SystemByte);
            Assert.Equal(1, data.SystemShort);
            Assert.Equal(1, data.SystemUShort);
            Assert.Equal(1, data.SystemInt);
            Assert.Equal(Convert.ToUInt16(1), data.SystemUInt);
            Assert.Equal(1, data.SystemLong);
            Assert.Equal(Convert.ToUInt32(1), data.SystemULong);
            Assert.Equal('a', data.SystemChar);
            Assert.Equal(1, data.SystemFloat);
            Assert.Equal(1, data.SystemDouble);
            Assert.Equal(BooleanType.TRUE, data.ValueBooleanType);
            Assert.Equal(new CurrencyType(1.01), data.ValueCurrencyType);
            Assert.Equal(2, data.ValueCurrencyTypeList.Count);
            Assert.True(data.ValueCurrencyTypeList.Contains(new CurrencyType(1.01)));
            Assert.True(data.ValueCurrencyTypeList.Contains(new CurrencyType(2.02)));
            Assert.Equal(new DateTimeType(2005, 1, 1, 1, 1, 0), data.ValueDateTimeType);
            Assert.Equal(new DateType(2005, 1, 1), data.ValueDateType);
            Assert.Equal(2, data.ValueDateTypeList.Count);
            Assert.True(data.ValueDateTypeList.Contains(new DateType(2005, 1, 1)));
            Assert.True(data.ValueDateTypeList.Contains(new DateType(2005, 2, 2)));
            Assert.Equal(new DecimalType(1.1), data.ValueDecimalType);
            Assert.Equal(2, data.ValueDecimalTypeList.Count);
            Assert.True(data.ValueDecimalTypeList.Contains(new DecimalType(1.1)));
            Assert.True(data.ValueDecimalTypeList.Contains(new DecimalType(1.1)));
            Assert.Equal(GenderType.MALE, data.ValueGenderType);
            Assert.Equal(new IdType(1), data.ValueIdType);
            Assert.Equal(2, data.ValueIdTypeList.Count);
            Assert.True(data.ValueIdTypeList.Contains(new IdType(1)));
            Assert.True(data.ValueIdTypeList.Contains(new IdType(2)));
            Assert.Equal(new IntegerType(1), data.ValueIntegerType);
            Assert.Equal(2, data.ValueIntegerTypeList.Count);
            Assert.True(data.ValueIntegerTypeList.Contains(new IntegerType(1)));
            Assert.True(data.ValueIntegerTypeList.Contains(new IntegerType(2)));
            Assert.Equal(new LongType(1), data.ValueLongType);
            Assert.Equal(new PhoneNumberType("801", "555", "6666", String.Empty), data.ValuePhoneNumberType);
            Assert.Equal(new QuantityType(1), data.ValueQuantityType);
            Assert.Equal(new ShortType(1), data.ValueShortType);
            Assert.Equal(new StringType("value2"), data.ValueStringType);
            Assert.Equal(2, data.ValueStringTypeList.Count);
            Assert.True(data.ValueStringTypeList.Contains(new StringType("value2")));
            Assert.True(data.ValueStringTypeList.Contains(new StringType("value3")));
            Assert.Equal(new TimeType(11, 11, 0), data.ValueTimeType);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        [Fact]
        public void ShouldNotDieIfPropertyNotInCollection() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "value1");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleDataForm data = new SampleDataForm();
            Populator.Instance.Populate(data, collection);

            //assert object was populated
            Assert.Equal("value1", data.SystemString);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        [Fact]
        public void ShouldNotBlowUpIfNameValueCollectionIsNull() {
            NameValueCollection collection = null;

            SampleDataForm data = new SampleDataForm();
            Populator.Instance.Populate(data, collection);
        }

        [Fact]
        public void ShouldBeAbleToPopulateObjectUsingPrefix() {
            //set up NameValueCollection with prefix
            String prefix = "prefix";
            NameValueCollection collection = new NameValueCollection();
            collection.Add(prefix + "systemString", "value1");
            collection.Add(prefix + "valueStringType", "value2");
            collection.Add("valueIdType", "1");

            //run populator
            SampleDataForm data = new SampleDataForm();
            Populator.Instance.Populate(data, collection, prefix);

            //assert object was populated correctly
            Assert.Equal("value1", data.SystemString);
            Assert.Equal(new StringType("value2"), data.ValueStringType);
            Assert.True(data.ValueIdType.IsDefault);
        }

        [Fact]
        public void ShouldGetMessageListWhenParseException() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("valueIdType", "value1");

            //run populator
            SampleDataForm data = new SampleDataForm();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(1));
            Assert.Equal("InvalidTypeFormatError", errors[0].GetType().Name);
        }

        [Fact]
        public void ShouldGetMessageListWhenMissingRequiredField() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();

            //run populator
            SampleClassWithRequiredField data = new SampleClassWithRequiredField();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(5));
            Assert.Equal("MissingRequiredFieldError", errors[0].GetType().Name);
            Assert.Equal("MissingRequiredFieldError", errors[1].GetType().Name);
            Assert.Equal("MissingRequiredFieldError", errors[2].GetType().Name);
            Assert.Equal("MissingRequiredFieldError", errors[3].GetType().Name);
            Assert.Equal("MissingRequiredFieldError", errors[4].GetType().Name);
        }

        [Fact]
        public void ShouldBeAbleToPopulateRequiredProperties() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "value1");
            collection.Add("systemInt", "1");
            collection.Add("valueIntegerType", "1");
            collection.Add("valueStringType", "value2");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleClassWithRequiredField data = new SampleClassWithRequiredField();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(0));
            Assert.Equal("value1", data.SystemString);
            Assert.Equal(1, data.SystemInt);
            Assert.Equal(new IntegerType(1), data.ValueIntegerType);
            Assert.Equal(new StringType("value2"), data.ValueStringType);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        //if the value is an empty string and is not required then no problem
        [Fact]
        public void ShouldNotGetMessageListWhenPropertyIsNotRequiredAndTypeIsStringType() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "value1");
            collection.Add("systemInt", "1");
            collection.Add("valueIntegerType", "1");
            collection.Add("valueStringType", "");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleClassWithRequiredField data = new SampleClassWithRequiredField();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(0));
            Assert.Equal("value1", data.SystemString);
            Assert.Equal(1, data.SystemInt);
            Assert.Equal(new IntegerType(1), data.ValueIntegerType);
            Assert.Equal(new StringType(""), data.ValueStringType);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        [Fact]
        public void ShouldNotGetMessageListWhenPropertyIsNotRequiredAndTypeIsString() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "");
            collection.Add("systemInt", "1");
            collection.Add("valueIntegerType", "1");
            collection.Add("valueStringType", "value2");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleClassWithRequiredField data = new SampleClassWithRequiredField();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(0));
            Assert.Equal("", data.SystemString);
            Assert.Equal(1, data.SystemInt);
            Assert.Equal(new IntegerType(1), data.ValueIntegerType);
            Assert.Equal(new StringType("value2"), data.ValueStringType);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        [Fact]
        public void IfParseErrorOnRequiredFieldShouldGetMissingRequiredFieldError() {
            //set up NameValueCollection
            NameValueCollection collection = new NameValueCollection();
            collection.Add("systemString", "value1");
            collection.Add("systemInt", "1");
            collection.Add("valueIntegerType", "ONE");
            collection.Add("valueStringType", "value2");
            collection.Add("valueLanguageEnum", LanguageEnum.VIETNAMESE.Code);

            //run populator
            SampleClassWithRequiredField data = new SampleClassWithRequiredField();
            MessageList errors = Populator.Instance.Populate(data, collection);

            Assert.True(errors.Count.Equals(1));
            Assert.Equal("MissingRequiredFieldError", errors[0].GetType().Name);
            Assert.Equal("value1", data.SystemString);
            Assert.Equal(1, data.SystemInt);
            Assert.True(data.ValueIntegerType.IsDefault);
            Assert.Equal(new StringType("value2"), data.ValueStringType);
            Assert.Equal(LanguageEnum.VIETNAMESE, data.ValueLanguageEnum);
        }

        [Fact]
        public void ShouldNotAttemptToPopulateReadOnlyProperty() {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("ReadOnlySystemString", "value1");

            SampleDataForm data = new SampleDataForm();
            Populator.Instance.Populate(data, collection);
        }

        public class SampleDataForm {
            private string systemString;
            private bool systemBool;
            private decimal systemDecimal;
            private sbyte systemSByte;
            private byte systemByte;
            private short systemShort;
            private ushort systemUShort;
            private int systemInt;
            private uint systemUInt;
            private long systemLong;
            private ulong systemULong;
            private char systemChar;
            private float systemFloat;
            private double systemDouble;
            private BooleanType valueBooleanType;
            private CurrencyType valueCurrencyType;
            private CurrencyTypeList valueCurrencyTypeList;
            private DateTimeType valueDateTimeType;
            private DateType valueDateType;
            private DateTypeList valueDateTypeList;
            private DecimalType valueDecimalType;
            private DecimalTypeList valueDecimalTypeList;
            private GenderType valueGenderType;
            private IdType valueIdType;
            private IdTypeList valueIdTypeList;
            private IntegerType valueIntegerType;
            private IntegerTypeList valueIntegerTypeList;
            private LongType valueLongType;
            private PhoneNumberType valuePhoneNumberType;
            private QuantityType valueQuantityType;
            private ShortType valueShortType;
            private StringType valueStringType;
            private StringTypeList valueStringTypeList;
            private TimeType valueTimeType;
            private LanguageEnum valueLanguageEnum;

            public string SystemString {
                get { return systemString; }
                set { systemString = value; }
            }
            public bool SystemBool {
                get { return systemBool; }
                set { systemBool = value; }
            }
            public decimal SystemDecimal {
                get { return systemDecimal; }
                set { systemDecimal = value; }
            }
            public sbyte SystemSByte {
                get { return systemSByte; }
                set { systemSByte = value; }
            }
            public byte SystemByte {
                get { return systemByte; }
                set { systemByte = value; }
            }
            public short SystemShort {
                get { return systemShort; }
                set { systemShort = value; }
            }
            public ushort SystemUShort {
                get { return systemUShort; }
                set { systemUShort = value; }
            }
            public int SystemInt {
                get { return systemInt; }
                set { systemInt = value; }
            }
            public uint SystemUInt {
                get { return systemUInt; }
                set { systemUInt = value; }
            }
            public long SystemLong {
                get { return systemLong; }
                set { systemLong = value; }
            }
            public ulong SystemULong {
                get { return systemULong; }
                set { systemULong = value; }
            }
            public char SystemChar {
                get { return systemChar; }
                set { systemChar = value; }
            }
            public float SystemFloat {
                get { return systemFloat; }
                set { systemFloat = value; }
            }
            public double SystemDouble {
                get { return systemDouble; }
                set { systemDouble = value; }
            }
            public BooleanType ValueBooleanType {
                get { return valueBooleanType; }
                set { valueBooleanType = value; }
            }
            public CurrencyType ValueCurrencyType {
                get { return valueCurrencyType; }
                set { valueCurrencyType = value; }
            }
            public CurrencyTypeList ValueCurrencyTypeList {
                get { return valueCurrencyTypeList; }
                set { valueCurrencyTypeList = value; }
            }
            public DateTimeType ValueDateTimeType {
                get { return valueDateTimeType; }
                set { valueDateTimeType = value; }
            }
            public DateType ValueDateType {
                get { return valueDateType; }
                set { valueDateType = value; }
            }
            public DateTypeList ValueDateTypeList {
                get { return valueDateTypeList; }
                set { valueDateTypeList = value; }
            }
            public DecimalType ValueDecimalType {
                get { return valueDecimalType; }
                set { valueDecimalType = value; }
            }
            public DecimalTypeList ValueDecimalTypeList {
                get { return valueDecimalTypeList; }
                set { valueDecimalTypeList = value; }
            }
            public GenderType ValueGenderType {
                get { return valueGenderType; }
                set { valueGenderType = value; }
            }
            public IdType ValueIdType {
                get { return valueIdType; }
                set { valueIdType = value; }
            }
            public IdTypeList ValueIdTypeList {
                get { return valueIdTypeList; }
                set { valueIdTypeList = value; }
            }
            public IntegerType ValueIntegerType {
                get { return valueIntegerType; }
                set { valueIntegerType = value; }
            }
            public IntegerTypeList ValueIntegerTypeList {
                get { return valueIntegerTypeList; }
                set { valueIntegerTypeList = value; }
            }
            public LongType ValueLongType {
                get { return valueLongType; }
                set { valueLongType = value; }
            }
            public PhoneNumberType ValuePhoneNumberType {
                get { return valuePhoneNumberType; }
                set { valuePhoneNumberType = value; }
            }
            public QuantityType ValueQuantityType {
                get { return valueQuantityType; }
                set { valueQuantityType = value; }
            }
            public ShortType ValueShortType {
                get { return valueShortType; }
                set { valueShortType = value; }
            }
            public StringType ValueStringType {
                get { return valueStringType; }
                set { valueStringType = value; }
            }
            public StringTypeList ValueStringTypeList {
                get { return valueStringTypeList; }
                set { valueStringTypeList = value; }
            }
            public TimeType ValueTimeType {
                get { return valueTimeType; }
                set { valueTimeType = value; }
            }
            public LanguageEnum ValueLanguageEnum {
                get { return valueLanguageEnum; }
                set { valueLanguageEnum = value; }
            }

            public String ReadOnlySystemString {
                get { return String.Empty; }
            }

        }

        public class SampleClassWithRequiredField {
            private string systemString;
            private int systemInt;
            private IntegerType valueIntegerType;
            private StringType valueStringType;
            private LanguageEnum valueLanguageEnum;

            [Required]
            public string SystemString {
                get { return systemString; }
                set { systemString = value; }
            }
            [Required]
            public int SystemInt {
                get { return systemInt; }
                set { systemInt = value; }
            }
            [Required]
            public IntegerType ValueIntegerType {
                get { return valueIntegerType; }
                set { valueIntegerType = value; }
            }
            [Required]
            public StringType ValueStringType {
                get { return valueStringType; }
                set { valueStringType = value; }
            }
            [Required]
            public LanguageEnum ValueLanguageEnum {
                get { return valueLanguageEnum; }
                set { valueLanguageEnum = value; }
            }
        }
    }
}
