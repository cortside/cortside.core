using System;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

using Cortside.Core.Message;
using Cortside.Core.Types;

namespace Cortside.Core.PropertyPopulator {
    /// <summary>
    /// Summary description for PropertyPopulator.
    /// </summary>
    public class Populator {
        public static readonly Populator Instance = new Populator();

        private readonly ArrayList properties = new ArrayList();

        private Populator() { }

        public MessageList Populate(Object target, NameValueCollection data) {
            MessageList errors = new MessageList();

            if (data == null) {
                return errors;
            }

            Type t = target.GetType();
            PropertyInfo[] ps = t.GetProperties(BindingFlags.SetProperty);
            foreach (PropertyInfo property in t.GetProperties()) {
                if (property.CanWrite) {
                    Boolean required = property.GetCustomAttributes(typeof(RequiredAttribute), true).Length == 1;

                    //set value Note:NameValueCollection is not case sensitive
                    String val = data[property.Name];

                    if (val == null) {
                        if (required) {
                            errors.Add(new MissingRequiredFieldError(property.Name));
                        }
                    } else {
                        try {
                            Object o = ParseValue(val, property.PropertyType);
                            property.SetValue(target, o, null);
                        } catch (Exception) {
                            if (required) {
                                errors.Add(new MissingRequiredFieldError(property.Name));
                            } else {
                                // only add an error if there was a value
                                if (val.Length > 0) {
                                    errors.Add(new InvalidTypeFormatError(property.Name, val));
                                }
                            }
                        }
                    }
                }
            }
            return errors;
        }

        public MessageList Populate(Object target, NameValueCollection data, String prefix) {
            NameValueCollection filteredData = new NameValueCollection();
            foreach (String key in data) {
                if (key.StartsWith(prefix)) {
                    filteredData.Add(key.Substring(prefix.Length, key.Length - prefix.Length), data[key]);
                }
            }
            return Populate(target, filteredData);
        }

        /// <summary>
        /// Attempts to parse the given string as one of the standard
        /// value types: bool, decimal, sbyte, byte, short, ushort,
        /// int, uint, long, ulong, char, float, or double.
        /// Simply returns val on failure.
        /// </summary>
        /// <param name="val">The string containing the value to be parsed.</param>
        /// <param name="type">The target type of val after parsing.</param>
        /// <returns>
        ///	A new object representing the string val parsed as the
        ///	appropriate type or val if type is not one of the standard
        ///	value types.
        /// </returns>
        private object ParseValue(string val, Type type) {
            // allow for other types not specified here to be handled
            Object o = ParseCustomValue(val, type);
            if (o != null) {
                return o;
            }

            // check for .Net types
            if (typeof(bool).Equals(type)) {
                return bool.Parse(val);

            } else if (typeof(decimal).Equals(type)) {
                return decimal.Parse(val);

            } else if (typeof(sbyte).Equals(type)) {
                return sbyte.Parse(val);

            } else if (typeof(byte).Equals(type)) {
                return byte.Parse(val);

            } else if (typeof(short).Equals(type)) {
                return short.Parse(val);

            } else if (typeof(ushort).Equals(type)) {
                return ushort.Parse(val);

            } else if (typeof(int).Equals(type)) {
                return int.Parse(val);

            } else if (typeof(uint).Equals(type)) {
                return uint.Parse(val);

            } else if (typeof(long).Equals(type)) {
                return long.Parse(val);

            } else if (typeof(ulong).Equals(type)) {
                return ulong.Parse(val);

            } else if (typeof(char).Equals(type)) {
                return char.Parse(val);

            } else if (typeof(float).Equals(type)) {
                return float.Parse(val);

            } else if (typeof(double).Equals(type)) {
                return double.Parse(val);
            }

            return val;
        }

        /// <summary>
        /// Extendeds types that ParseValue can parse
        /// </summary>
        /// <param name="val" type="string"></param>
        /// <param name="type" type="System.Type"></param>
        /// <returns>The parsed value, or null indicating that this type was not parsable by this method</returns>
        private object ParseCustomValue(String val, Type type) {
            // check for Cortside.Core.Types
            if (typeof(StringType).Equals(type)) {
                return StringType.Parse(val);

            } else if (typeof(DateType).Equals(type)) {
                return DateType.Parse(val);

            } else if (typeof(DateTimeType).Equals(type)) {
                return DateTimeType.Parse(val);

            } else if (typeof(IdType).Equals(type)) {
                return IdType.Parse(val);

            } else if (typeof(IntegerType).Equals(type)) {
                return IntegerType.Parse(val);

            } else if (typeof(LongType).Equals(type)) {
                return LongType.Parse(val);
            } else if (typeof(CurrencyType).Equals(type)) {
                return CurrencyType.Parse(val);

            } else if (typeof(QuantityType).Equals(type)) {
                return QuantityType.Parse(val);

            } else if (typeof(DecimalType).Equals(type)) {
                return DecimalType.Parse(val);

            } else if (typeof(BooleanType).Equals(type)) {
                return BooleanType.GetInstance(val);

            } else if (typeof(PhoneNumberType).Equals(type)) {
                return PhoneNumberType.Parse(val);

            } else if (typeof(GenderType).Equals(type)) {
                return GenderType.Parse(val);

            } else if (typeof(ShortType).Equals(type)) {
                return ShortType.Parse(val);

            } else if (typeof(TimeType).Equals(type)) {
                return TimeType.Parse(val);

            } else if (typeof(IdTypeList).Equals(type)) {
                IdTypeList ids = new IdTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        ids.Add(IdType.Parse(key));
                    }
                }
                return ids;
            } else if (typeof(CurrencyTypeList).Equals(type)) {
                CurrencyTypeList currencies = new CurrencyTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        currencies.Add(CurrencyType.Parse(key));
                    }
                }
                return currencies;
            } else if (typeof(DateTypeList).Equals(type)) {
                DateTypeList dates = new DateTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        dates.Add(DateType.Parse(key));
                    }
                }
                return dates;
            } else if (typeof(DecimalTypeList).Equals(type)) {
                DecimalTypeList decimals = new DecimalTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        decimals.Add(DecimalType.Parse(key));
                    }
                }
                return decimals;
            } else if (typeof(IntegerTypeList).Equals(type)) {
                IntegerTypeList integers = new IntegerTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        integers.Add(IntegerType.Parse(key));
                    }
                }
                return integers;
            } else if (typeof(StringTypeList).Equals(type)) {
                StringTypeList strings = new StringTypeList();
                foreach (String key in val.Split(',')) {
                    if (!key.Trim().Equals(String.Empty)) {
                        strings.Add(StringType.Parse(key));
                    }
                }
                return strings;
            } else if (type.IsSubclassOf(typeof(EnumDataType))) {
                // The GetInstance method is expected from anything that inherits from EnumDataType.  If it is missing, values cannot be parsed.
                return type.InvokeMember("GetInstance", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { val });
            }

            // not one of the known types, return null
            return null;
        }
    }
}
