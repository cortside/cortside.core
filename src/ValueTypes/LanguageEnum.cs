using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    [Serializable]
    public class LanguageEnum : Cortside.Core.Types.EnumDataType, ILanguage, ISerializable {

        private static readonly EnumDataTypeList OPTIONS = new EnumDataTypeList();

        public static readonly new LanguageEnum DEFAULT = new LanguageEnum();
        public static readonly new LanguageEnum UNSET = new LanguageEnum();

        public static readonly LanguageEnum AFRIKAANS = new LanguageEnum("af", "Afrikaans");
        public static readonly LanguageEnum ALBANIAN = new LanguageEnum("sq", "Albanian");
        public static readonly LanguageEnum ARABIC = new LanguageEnum("ar", "Arabic");
        public static readonly LanguageEnum ARMENIAN = new LanguageEnum("hy", "Armenian");
        public static readonly LanguageEnum AZERI = new LanguageEnum("az", "Azeri");
        public static readonly LanguageEnum BASQUE = new LanguageEnum("eu", "Basque");
        public static readonly LanguageEnum BELARUSIAN = new LanguageEnum("be", "Belarusian");
        public static readonly LanguageEnum BULGARIAN = new LanguageEnum("bg", "Bulgarian");
        public static readonly LanguageEnum CATALAN = new LanguageEnum("ca", "Catalan");
        public static readonly LanguageEnum CHINESE = new LanguageEnum("zh", "Chinese");
        public static readonly LanguageEnum CROATIAN = new LanguageEnum("hr", "Croatian");
        public static readonly LanguageEnum CZECH = new LanguageEnum("cs", "Czech");
        public static readonly LanguageEnum DANISH = new LanguageEnum("da", "Danish");
        public static readonly LanguageEnum DHIVEHI = new LanguageEnum("div", "Dhivehi");
        public static readonly LanguageEnum DUTCH = new LanguageEnum("nl", "Dutch");
        public static readonly LanguageEnum ENGLISH = new LanguageEnum("en", "English");
        public static readonly LanguageEnum ESTONIAN = new LanguageEnum("et", "Estonian");
        public static readonly LanguageEnum FAROESE = new LanguageEnum("fo", "Faroese");
        public static readonly LanguageEnum FARSI = new LanguageEnum("fa", "Farsi");
        public static readonly LanguageEnum FINNISH = new LanguageEnum("fi", "Finnish");
        public static readonly LanguageEnum FRENCH = new LanguageEnum("fr", "French");
        public static readonly LanguageEnum GALICIAN = new LanguageEnum("gl", "Galician");
        public static readonly LanguageEnum GEORGIAN = new LanguageEnum("ka", "Georgian");
        public static readonly LanguageEnum GERMAN = new LanguageEnum("de", "German");
        public static readonly LanguageEnum GREEK = new LanguageEnum("el", "Greek");
        public static readonly LanguageEnum GUJARATI = new LanguageEnum("gu", "Gujarati");
        public static readonly LanguageEnum HEBREW = new LanguageEnum("he", "Hebrew");
        public static readonly LanguageEnum HINDI = new LanguageEnum("hi", "Hindi");
        public static readonly LanguageEnum HUNGARIAN = new LanguageEnum("hu", "Hungarian");
        public static readonly LanguageEnum ICELANDIC = new LanguageEnum("is", "Icelandic");
        public static readonly LanguageEnum INDONESIAN = new LanguageEnum("id", "Indonesian");
        public static readonly LanguageEnum ITALIAN = new LanguageEnum("it", "Italian");
        public static readonly LanguageEnum JAPANESE = new LanguageEnum("ja", "Japanese");
        public static readonly LanguageEnum KANNADA = new LanguageEnum("kn", "Kannada");
        public static readonly LanguageEnum KAZAKH = new LanguageEnum("kk", "Kazakh");
        public static readonly LanguageEnum KONKANI = new LanguageEnum("kok", "Konkani");
        public static readonly LanguageEnum KOREAN = new LanguageEnum("ko", "Korean");
        public static readonly LanguageEnum KYRGYZ = new LanguageEnum("ky", "Kyrgyz");
        public static readonly LanguageEnum LATVIAN = new LanguageEnum("lv", "Latvian");
        public static readonly LanguageEnum LITHUANIAN = new LanguageEnum("lt", "Lithuanian");
        public static readonly LanguageEnum MACEDONIAN = new LanguageEnum("mk", "Macedonian");
        public static readonly LanguageEnum MALAY = new LanguageEnum("ms", "Malay");
        public static readonly LanguageEnum MARATHI = new LanguageEnum("mr", "Marathi");
        public static readonly LanguageEnum MONGOLIAN = new LanguageEnum("mn", "Mongolian");
        public static readonly LanguageEnum NORWEGIAN = new LanguageEnum("no", "Norwegian");
        public static readonly LanguageEnum POLISH = new LanguageEnum("pl", "Polish");
        public static readonly LanguageEnum PORTUGUESE = new LanguageEnum("pt", "Portuguese");
        public static readonly LanguageEnum PUNJABI = new LanguageEnum("pa", "Punjabi");
        public static readonly LanguageEnum ROMANIAN = new LanguageEnum("ro", "Romanian");
        public static readonly LanguageEnum RUSSIAN = new LanguageEnum("ru", "Russian");
        public static readonly LanguageEnum SANSKRIT = new LanguageEnum("sa", "Sanskrit");
        public static readonly LanguageEnum SERBIAN = new LanguageEnum("sr", "Serbian");
        public static readonly LanguageEnum SLOVAK = new LanguageEnum("sk", "Slovak");
        public static readonly LanguageEnum SLOVENIAN = new LanguageEnum("sl", "Slovenian");
        public static readonly LanguageEnum SPANISH = new LanguageEnum("es", "Spanish");
        public static readonly LanguageEnum SWAHILI = new LanguageEnum("sw", "Swahili");
        public static readonly LanguageEnum SWEDISH = new LanguageEnum("sv", "Swedish");
        public static readonly LanguageEnum SYRIAC = new LanguageEnum("syr", "Syriac");
        public static readonly LanguageEnum TAMIL = new LanguageEnum("ta", "Tamil");
        public static readonly LanguageEnum TATAR = new LanguageEnum("tt", "Tatar");
        public static readonly LanguageEnum TELUGU = new LanguageEnum("te", "Telugu");
        public static readonly LanguageEnum THAI = new LanguageEnum("th", "Thai");
        public static readonly LanguageEnum TURKISH = new LanguageEnum("tr", "Turkish");
        public static readonly LanguageEnum UKRAINIAN = new LanguageEnum("uk", "Ukrainian");
        public static readonly LanguageEnum URDU = new LanguageEnum("ur", "Urdu");
        public static readonly LanguageEnum UZBEK = new LanguageEnum("uz", "Uzbek");
        public static readonly LanguageEnum VIETNAMESE = new LanguageEnum("vi", "Vietnamese");

        public static LanguageEnum GetInstance(Object value) {
            if (value is String) {
                foreach (LanguageEnum t in OPTIONS) {
                    if (t.Value.Equals(value)) {
                        return t;
                    }
                }
            }

            return UNSET;
        }

        public ILanguage GetInstanceNonStatic(Object value) {
            if (value is String) {
                foreach (LanguageEnum t in OPTIONS) {
                    if (t.Value.Equals(value)) {
                        return t;
                    }
                }
            }

            return UNSET;
        }

        private LanguageEnum() { }

        private LanguageEnum(String code, String name) {
            this.code = code;
            this.name = name;
            OPTIONS.Add(this);
        }

        public override Boolean IsDefault {
            get { return Object.ReferenceEquals(this, DEFAULT); }
        }

        public override Boolean IsUnset {
            get { return Object.ReferenceEquals(this, UNSET); }
        }

        public static EnumDataTypeList Options {
            get { return OPTIONS; }
        }

        public void SetValue(Object newValue) {
            LanguageEnum instance = LanguageEnum.GetInstance(newValue);
            code = instance.Code;
            name = instance.Name;

        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(LanguageEnum_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(LanguageEnum_UNSET));
            } else if (this.Equals(AFRIKAANS)) {
                info.SetType(typeof(LanguageEnum_AFRIKAANS));
            } else if (this.Equals(ALBANIAN)) {
                info.SetType(typeof(LanguageEnum_ALBANIAN));
            } else if (this.Equals(ARABIC)) {
                info.SetType(typeof(LanguageEnum_ARABIC));
            } else if (this.Equals(ARMENIAN)) {
                info.SetType(typeof(LanguageEnum_ARMENIAN));
            } else if (this.Equals(AZERI)) {
                info.SetType(typeof(LanguageEnum_AZERI));
            } else if (this.Equals(BASQUE)) {
                info.SetType(typeof(LanguageEnum_BASQUE));
            } else if (this.Equals(BELARUSIAN)) {
                info.SetType(typeof(LanguageEnum_BELARUSIAN));
            } else if (this.Equals(BULGARIAN)) {
                info.SetType(typeof(LanguageEnum_BULGARIAN));
            } else if (this.Equals(CATALAN)) {
                info.SetType(typeof(LanguageEnum_CATALAN));
            } else if (this.Equals(CHINESE)) {
                info.SetType(typeof(LanguageEnum_CHINESE));
            } else if (this.Equals(CROATIAN)) {
                info.SetType(typeof(LanguageEnum_CROATIAN));
            } else if (this.Equals(CZECH)) {
                info.SetType(typeof(LanguageEnum_CZECH));
            } else if (this.Equals(DANISH)) {
                info.SetType(typeof(LanguageEnum_DANISH));
            } else if (this.Equals(DHIVEHI)) {
                info.SetType(typeof(LanguageEnum_DHIVEHI));
            } else if (this.Equals(DUTCH)) {
                info.SetType(typeof(LanguageEnum_DUTCH));
            } else if (this.Equals(ENGLISH)) {
                info.SetType(typeof(LanguageEnum_ENGLISH));
            } else if (this.Equals(ESTONIAN)) {
                info.SetType(typeof(LanguageEnum_ESTONIAN));
            } else if (this.Equals(FAROESE)) {
                info.SetType(typeof(LanguageEnum_FAROESE));
            } else if (this.Equals(FARSI)) {
                info.SetType(typeof(LanguageEnum_FARSI));
            } else if (this.Equals(FINNISH)) {
                info.SetType(typeof(LanguageEnum_FINNISH));
            } else if (this.Equals(FRENCH)) {
                info.SetType(typeof(LanguageEnum_FRENCH));
            } else if (this.Equals(GALICIAN)) {
                info.SetType(typeof(LanguageEnum_GALICIAN));
            } else if (this.Equals(GEORGIAN)) {
                info.SetType(typeof(LanguageEnum_GEORGIAN));
            } else if (this.Equals(GERMAN)) {
                info.SetType(typeof(LanguageEnum_GERMAN));
            } else if (this.Equals(GREEK)) {
                info.SetType(typeof(LanguageEnum_GREEK));
            } else if (this.Equals(GUJARATI)) {
                info.SetType(typeof(LanguageEnum_GUJARATI));
            } else if (this.Equals(HEBREW)) {
                info.SetType(typeof(LanguageEnum_HEBREW));
            } else if (this.Equals(HINDI)) {
                info.SetType(typeof(LanguageEnum_HINDI));
            } else if (this.Equals(HUNGARIAN)) {
                info.SetType(typeof(LanguageEnum_HUNGARIAN));
            } else if (this.Equals(ICELANDIC)) {
                info.SetType(typeof(LanguageEnum_ICELANDIC));
            } else if (this.Equals(INDONESIAN)) {
                info.SetType(typeof(LanguageEnum_INDONESIAN));
            } else if (this.Equals(ITALIAN)) {
                info.SetType(typeof(LanguageEnum_ITALIAN));
            } else if (this.Equals(JAPANESE)) {
                info.SetType(typeof(LanguageEnum_JAPANESE));
            } else if (this.Equals(KANNADA)) {
                info.SetType(typeof(LanguageEnum_KANNADA));
            } else if (this.Equals(KAZAKH)) {
                info.SetType(typeof(LanguageEnum_KAZAKH));
            } else if (this.Equals(KONKANI)) {
                info.SetType(typeof(LanguageEnum_KONKANI));
            } else if (this.Equals(KOREAN)) {
                info.SetType(typeof(LanguageEnum_KOREAN));
            } else if (this.Equals(KYRGYZ)) {
                info.SetType(typeof(LanguageEnum_KYRGYZ));
            } else if (this.Equals(LATVIAN)) {
                info.SetType(typeof(LanguageEnum_LATVIAN));
            } else if (this.Equals(LITHUANIAN)) {
                info.SetType(typeof(LanguageEnum_LITHUANIAN));
            } else if (this.Equals(MACEDONIAN)) {
                info.SetType(typeof(LanguageEnum_MACEDONIAN));
            } else if (this.Equals(MALAY)) {
                info.SetType(typeof(LanguageEnum_MALAY));
            } else if (this.Equals(MARATHI)) {
                info.SetType(typeof(LanguageEnum_MARATHI));
            } else if (this.Equals(MONGOLIAN)) {
                info.SetType(typeof(LanguageEnum_MONGOLIAN));
            } else if (this.Equals(NORWEGIAN)) {
                info.SetType(typeof(LanguageEnum_NORWEGIAN));
            } else if (this.Equals(POLISH)) {
                info.SetType(typeof(LanguageEnum_POLISH));
            } else if (this.Equals(PORTUGUESE)) {
                info.SetType(typeof(LanguageEnum_PORTUGUESE));
            } else if (this.Equals(PUNJABI)) {
                info.SetType(typeof(LanguageEnum_PUNJABI));
            } else if (this.Equals(ROMANIAN)) {
                info.SetType(typeof(LanguageEnum_ROMANIAN));
            } else if (this.Equals(RUSSIAN)) {
                info.SetType(typeof(LanguageEnum_RUSSIAN));
            } else if (this.Equals(SANSKRIT)) {
                info.SetType(typeof(LanguageEnum_SANSKRIT));
            } else if (this.Equals(SERBIAN)) {
                info.SetType(typeof(LanguageEnum_SERBIAN));
            } else if (this.Equals(SLOVAK)) {
                info.SetType(typeof(LanguageEnum_SLOVAK));
            } else if (this.Equals(SLOVENIAN)) {
                info.SetType(typeof(LanguageEnum_SLOVENIAN));
            } else if (this.Equals(SPANISH)) {
                info.SetType(typeof(LanguageEnum_SPANISH));
            } else if (this.Equals(SWAHILI)) {
                info.SetType(typeof(LanguageEnum_SWAHILI));
            } else if (this.Equals(SWEDISH)) {
                info.SetType(typeof(LanguageEnum_SWEDISH));
            } else if (this.Equals(SYRIAC)) {
                info.SetType(typeof(LanguageEnum_SYRIAC));
            } else if (this.Equals(TAMIL)) {
                info.SetType(typeof(LanguageEnum_TAMIL));
            } else if (this.Equals(TATAR)) {
                info.SetType(typeof(LanguageEnum_TATAR));
            } else if (this.Equals(TELUGU)) {
                info.SetType(typeof(LanguageEnum_TELUGU));
            } else if (this.Equals(THAI)) {
                info.SetType(typeof(LanguageEnum_THAI));
            } else if (this.Equals(TURKISH)) {
                info.SetType(typeof(LanguageEnum_TURKISH));
            } else if (this.Equals(UKRAINIAN)) {
                info.SetType(typeof(LanguageEnum_UKRAINIAN));
            } else if (this.Equals(URDU)) {
                info.SetType(typeof(LanguageEnum_URDU));
            } else if (this.Equals(UZBEK)) {
                info.SetType(typeof(LanguageEnum_UZBEK));
            } else if (this.Equals(VIETNAMESE)) {
                info.SetType(typeof(LanguageEnum_VIETNAMESE));
            }
        }
    }

    [Serializable]
    public class LanguageEnum_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.DEFAULT;
        }
    }

    [Serializable]
    public class LanguageEnum_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.UNSET;
        }
    }

    [Serializable]
    public class LanguageEnum_AFRIKAANS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.AFRIKAANS;
        }
    }
    [Serializable]
    public class LanguageEnum_ALBANIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ALBANIAN;
        }
    }

    [Serializable]
    public class LanguageEnum_ARABIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ARABIC;
        }
    }

    [Serializable]
    public class LanguageEnum_ARMENIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ARMENIAN;
        }
    }

    [Serializable]
    public class LanguageEnum_AZERI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.AZERI;
        }
    }
    [Serializable]
    public class LanguageEnum_BASQUE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.BASQUE;
        }
    }
    [Serializable]
    public class LanguageEnum_BELARUSIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.BELARUSIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_BULGARIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.BULGARIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_CATALAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.CATALAN;
        }
    }
    [Serializable]
    public class LanguageEnum_CHINESE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.CHINESE;
        }
    }
    [Serializable]
    public class LanguageEnum_CROATIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.CROATIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_CZECH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.CZECH;
        }
    }
    [Serializable]
    public class LanguageEnum_DANISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.DANISH;
        }
    }
    [Serializable]
    public class LanguageEnum_DHIVEHI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.DHIVEHI;
        }
    }
    [Serializable]
    public class LanguageEnum_DUTCH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.DUTCH;
        }
    }
    [Serializable]
    public class LanguageEnum_ENGLISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ENGLISH;
        }
    }
    [Serializable]
    public class LanguageEnum_ESTONIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ESTONIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_FAROESE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.FAROESE;
        }
    }
    [Serializable]
    public class LanguageEnum_FARSI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.FARSI;
        }
    }
    [Serializable]
    public class LanguageEnum_FINNISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.FINNISH;
        }
    }
    [Serializable]
    public class LanguageEnum_FRENCH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.FRENCH;
        }
    }
    [Serializable]
    public class LanguageEnum_GALICIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.GALICIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_GEORGIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.GEORGIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_GERMAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.GERMAN;
        }
    }
    [Serializable]
    public class LanguageEnum_GREEK : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.GREEK;
        }
    }
    [Serializable]
    public class LanguageEnum_GUJARATI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.GUJARATI;
        }
    }
    [Serializable]
    public class LanguageEnum_HEBREW : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.HEBREW;
        }
    }
    [Serializable]
    public class LanguageEnum_HINDI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.HINDI;
        }
    }
    [Serializable]
    public class LanguageEnum_HUNGARIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.HUNGARIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_ICELANDIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ICELANDIC;
        }
    }
    [Serializable]
    public class LanguageEnum_INDONESIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.INDONESIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_ITALIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ITALIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_JAPANESE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.JAPANESE;
        }
    }
    [Serializable]
    public class LanguageEnum_KANNADA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.KANNADA;
        }
    }
    [Serializable]
    public class LanguageEnum_KAZAKH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.KAZAKH;
        }
    }
    [Serializable]
    public class LanguageEnum_KONKANI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.KONKANI;
        }
    }
    [Serializable]
    public class LanguageEnum_KOREAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.KOREAN;
        }
    }
    [Serializable]
    public class LanguageEnum_KYRGYZ : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.KYRGYZ;
        }
    }
    [Serializable]
    public class LanguageEnum_LATVIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.LATVIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_LITHUANIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.LITHUANIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_MACEDONIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.MACEDONIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_MALAY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.MALAY;
        }
    }
    [Serializable]
    public class LanguageEnum_MARATHI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.MARATHI;
        }
    }
    [Serializable]
    public class LanguageEnum_MONGOLIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.MONGOLIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_NORWEGIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.NORWEGIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_POLISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.POLISH;
        }
    }
    [Serializable]
    public class LanguageEnum_PORTUGUESE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.PORTUGUESE;
        }
    }
    [Serializable]
    public class LanguageEnum_PUNJABI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.PUNJABI;
        }
    }
    [Serializable]
    public class LanguageEnum_ROMANIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.ROMANIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_RUSSIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.RUSSIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_SANSKRIT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SANSKRIT;
        }
    }
    [Serializable]
    public class LanguageEnum_SERBIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SERBIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_SLOVAK : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SLOVAK;
        }
    }
    [Serializable]
    public class LanguageEnum_SLOVENIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SLOVENIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_SPANISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SPANISH;
        }
    }
    [Serializable]
    public class LanguageEnum_SWAHILI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SWAHILI;
        }
    }
    [Serializable]
    public class LanguageEnum_SWEDISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SWEDISH;
        }
    }
    [Serializable]
    public class LanguageEnum_SYRIAC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.SYRIAC;
        }
    }
    [Serializable]
    public class LanguageEnum_TAMIL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.TAMIL;
        }
    }
    [Serializable]
    public class LanguageEnum_TATAR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.TATAR;
        }
    }
    [Serializable]
    public class LanguageEnum_TELUGU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.TELUGU;
        }
    }
    [Serializable]
    public class LanguageEnum_THAI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.THAI;
        }
    }
    [Serializable]
    public class LanguageEnum_TURKISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.TURKISH;
        }
    }
    [Serializable]
    public class LanguageEnum_UKRAINIAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.UKRAINIAN;
        }
    }
    [Serializable]
    public class LanguageEnum_URDU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.URDU;
        }
    }
    [Serializable]
    public class LanguageEnum_UZBEK : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.UZBEK;
        }
    }
    [Serializable]
    public class LanguageEnum_VIETNAMESE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LanguageEnum.VIETNAMESE;
        }
    }
}
