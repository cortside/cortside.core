using System;
using System.Collections;
using Spring2.Core.Types;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {
	[Serializable]
    public class LocaleEnum : Spring2.Core.Types.EnumDataType, ILocale, ISerializable {

	private static readonly EnumDataTypeList OPTIONS = new EnumDataTypeList();

	public static readonly new LocaleEnum DEFAULT = new LocaleEnum();
	public static readonly new LocaleEnum UNSET = new LocaleEnum();

	public static readonly LocaleEnum ALBANIA = new LocaleEnum("AL", "Albania");
	public static readonly LocaleEnum ALGERIA = new LocaleEnum("DZ", "Algeria");
	public static readonly LocaleEnum ARGENTINA = new LocaleEnum("AR", "Argentina");
	public static readonly LocaleEnum ARMENIA = new LocaleEnum("AM", "Armenia");
	public static readonly LocaleEnum AUSTRALIA = new LocaleEnum("AU", "Australia");
	public static readonly LocaleEnum AUSTRIA = new LocaleEnum("AT", "Austria");
	public static readonly LocaleEnum AZERBAIJAN = new LocaleEnum("AZ", "Azerbaijan");
	public static readonly LocaleEnum BAHRAIN = new LocaleEnum("BH", "Bahrain");
	public static readonly LocaleEnum BELARUS = new LocaleEnum("BY", "Belarus");
	public static readonly LocaleEnum BELGIUM = new LocaleEnum("BE", "Belgium");
	public static readonly LocaleEnum BELIZE = new LocaleEnum("BZ", "Belize");
	public static readonly LocaleEnum BOLIVIA = new LocaleEnum("BO", "Bolivia");
	public static readonly LocaleEnum BRAZIL = new LocaleEnum("BR", "Brazil");
	public static readonly LocaleEnum BRUNEI = new LocaleEnum("BN", "Brunei");
	public static readonly LocaleEnum BULGARIA = new LocaleEnum("BG", "Bulgaria");
	public static readonly LocaleEnum CANADA = new LocaleEnum("CA", "Canada");
	public static readonly LocaleEnum CARIBBEAN = new LocaleEnum("CB", "Caribbean");
	public static readonly LocaleEnum CHILE = new LocaleEnum("CL", "Chile");
	public static readonly LocaleEnum CHINA = new LocaleEnum("CN", "China");
	public static readonly LocaleEnum COLOMBIA = new LocaleEnum("CO", "Colombia");
	public static readonly LocaleEnum COSTA_RICA = new LocaleEnum("CR", "Costa Rica");
	public static readonly LocaleEnum CROATIA = new LocaleEnum("HR", "Croatia");
	public static readonly LocaleEnum CZECH_REPUBLIC = new LocaleEnum("CZ", "Czech Republic");
	public static readonly LocaleEnum DENMARK = new LocaleEnum("DK", "Denmark");
	public static readonly LocaleEnum DOMINICAN_REPUBLIC = new LocaleEnum("DO", "Dominican Republic");
	public static readonly LocaleEnum ECUADOR = new LocaleEnum("EC", "Ecuador");
	public static readonly LocaleEnum EGYPT = new LocaleEnum("EG", "Egypt");
	public static readonly LocaleEnum EL_SALVADOR = new LocaleEnum("SV", "El Salvador");
	public static readonly LocaleEnum ESTONIA = new LocaleEnum("EE", "Estonia");
	public static readonly LocaleEnum FAROE_ISLANDS = new LocaleEnum("FO", "Faroe Islands");
	public static readonly LocaleEnum FINLAND = new LocaleEnum("FI", "Finland");
	public static readonly LocaleEnum FRANCE = new LocaleEnum("FR", "France");
	public static readonly LocaleEnum FYROM = new LocaleEnum("MK", "FYROM");
	public static readonly LocaleEnum GEORGIA = new LocaleEnum("GE", "Georgia");
	public static readonly LocaleEnum GERMANY = new LocaleEnum("DE", "Germany");
	public static readonly LocaleEnum UNITED_KINGDOM = new LocaleEnum("GB", "United Kingdom");
	public static readonly LocaleEnum GREECE = new LocaleEnum("GR", "Greece");
	public static readonly LocaleEnum GUATEMALA = new LocaleEnum("GT", "Guatemala");
	public static readonly LocaleEnum HONDURAS = new LocaleEnum("HN", "Honduras");
	public static readonly LocaleEnum HONG_KONG = new LocaleEnum("HK", "Hong Kong");
	public static readonly LocaleEnum HUNGARY = new LocaleEnum("HU", "Hungary");
	public static readonly LocaleEnum ICELAND = new LocaleEnum("IS", "Iceland");
	public static readonly LocaleEnum INDIA = new LocaleEnum("IN", "India");
	public static readonly LocaleEnum INDONESIA = new LocaleEnum("ID", "Indonesia");
	public static readonly LocaleEnum IRAN = new LocaleEnum("IR", "Iran");
	public static readonly LocaleEnum IRAQ = new LocaleEnum("IQ", "Iraq");
	public static readonly LocaleEnum IRELAND = new LocaleEnum("IE", "Ireland");
	public static readonly LocaleEnum ISRAEL = new LocaleEnum("IL", "Israel");
	public static readonly LocaleEnum ITALY = new LocaleEnum("IT", "Italy");
	public static readonly LocaleEnum JAMAICA = new LocaleEnum("JM", "Jamaica");
	public static readonly LocaleEnum JAPAN = new LocaleEnum("JP", "Japan");
	public static readonly LocaleEnum JORDAN = new LocaleEnum("JO", "Jordan");
	public static readonly LocaleEnum KAZAKHSTAN = new LocaleEnum("KZ", "Kazakhstan");
	public static readonly LocaleEnum KENYA = new LocaleEnum("KE", "Kenya");
	public static readonly LocaleEnum KOREA = new LocaleEnum("KR", "Korea");
	public static readonly LocaleEnum KUWAIT = new LocaleEnum("KW", "Kuwait");
	public static readonly LocaleEnum LATVIA = new LocaleEnum("LV", "Latvia");
	public static readonly LocaleEnum LEBANON = new LocaleEnum("LB", "Lebanon");
	public static readonly LocaleEnum LIBYA = new LocaleEnum("LY", "Libya");
	public static readonly LocaleEnum LIECHTENSTEIN = new LocaleEnum("LI", "Liechtenstein");
	public static readonly LocaleEnum LITHUANIA = new LocaleEnum("LT", "Lithuania");
	public static readonly LocaleEnum LUXEMBOURG = new LocaleEnum("LU", "Luxembourg");
	public static readonly LocaleEnum MACAU = new LocaleEnum("MO", "Macau");
	public static readonly LocaleEnum MALAYSIA = new LocaleEnum("MY", "Malaysia");
	public static readonly LocaleEnum MALDIVES = new LocaleEnum("MV", "Maldives");
	public static readonly LocaleEnum MEXICO = new LocaleEnum("MX", "Mexico");
	public static readonly LocaleEnum MONACO = new LocaleEnum("MC", "Monaco");
	public static readonly LocaleEnum MONGOLIA = new LocaleEnum("MN", "Mongolia");
	public static readonly LocaleEnum MOROCCO = new LocaleEnum("MA", "Morocco");
	public static readonly LocaleEnum NEW_ZEALAND = new LocaleEnum("NZ", "New Zealand");
	public static readonly LocaleEnum NICARAGUA = new LocaleEnum("NI", "Nicaragua");
	public static readonly LocaleEnum NORWAY = new LocaleEnum("NO", "Norway");
	public static readonly LocaleEnum OMAN = new LocaleEnum("OM", "Oman");
	public static readonly LocaleEnum PAKISTAN = new LocaleEnum("PK", "Pakistan");
	public static readonly LocaleEnum PANAMA = new LocaleEnum("PA", "Panama");
	public static readonly LocaleEnum PARAGUAY = new LocaleEnum("PY", "Paraguay");
	public static readonly LocaleEnum PERU = new LocaleEnum("PE", "Peru");
	public static readonly LocaleEnum PHILIPPINES = new LocaleEnum("PH", "Philippines");
	public static readonly LocaleEnum POLAND = new LocaleEnum("PL", "Poland");
	public static readonly LocaleEnum PORTUGAL = new LocaleEnum("PT", "Portugal");
	public static readonly LocaleEnum PUERTO_RICO = new LocaleEnum("PR", "Puerto Rico");
	public static readonly LocaleEnum QATAR = new LocaleEnum("QA", "Qatar");
	public static readonly LocaleEnum ROMANIA = new LocaleEnum("RO", "Romania");
	public static readonly LocaleEnum RUSSIA = new LocaleEnum("RU", "Russia");
	public static readonly LocaleEnum SAUDI_ARABIA = new LocaleEnum("SA", "Saudi Arabia");
	public static readonly LocaleEnum SERBIA = new LocaleEnum("SP", "Serbia");
	public static readonly LocaleEnum SINGAPORE = new LocaleEnum("SG", "Singapore");
	public static readonly LocaleEnum SLOVAKIA = new LocaleEnum("SK", "Slovakia");
	public static readonly LocaleEnum SLOVENIA = new LocaleEnum("SI", "Slovenia");
	public static readonly LocaleEnum SOUTH_AFRICA = new LocaleEnum("ZA ", "South Africa");
	public static readonly LocaleEnum SPAIN = new LocaleEnum("ES", "Spain");
	public static readonly LocaleEnum SWEDEN = new LocaleEnum("SE", "Sweden");
	public static readonly LocaleEnum SYRIA = new LocaleEnum("SY", "Syria");
	public static readonly LocaleEnum TAIWAN = new LocaleEnum("TW", "Taiwan");
	public static readonly LocaleEnum THAILAND = new LocaleEnum("TH", "Thailand");
	public static readonly LocaleEnum THE_NETHERLANDS = new LocaleEnum("NL", "The Netherlands");
	public static readonly LocaleEnum TRINIDAD_AND_TOBAGO = new LocaleEnum("TT", "Trinidad and Tobago");
	public static readonly LocaleEnum TUNISIA = new LocaleEnum("TN", "Tunisia");
	public static readonly LocaleEnum TURKEY = new LocaleEnum("TR", "Turkey");
	public static readonly LocaleEnum UKRAINE = new LocaleEnum("UA", "Ukraine");
	public static readonly LocaleEnum UNITED_ARAB_EMIRATES = new LocaleEnum("AE", "United Arab Emirates");
	public static readonly LocaleEnum UNITED_STATES = new LocaleEnum("US", "United States");
	public static readonly LocaleEnum URUGUAY = new LocaleEnum("UY", "Uruguay");
	public static readonly LocaleEnum UZBEKISTAN = new LocaleEnum("UZ", "Uzbekistan");
	public static readonly LocaleEnum VENEZUELA = new LocaleEnum("VE", "Venezuela");
	public static readonly LocaleEnum VIETNAM = new LocaleEnum("VN", "Vietnam");
	public static readonly LocaleEnum YEMEN = new LocaleEnum("YE", "Yemen");
	public static readonly LocaleEnum ZIMBABWE = new LocaleEnum("ZW", "Zimbabwe");

	public static LocaleEnum GetInstance(Object value) {
	    if (value is String) {
		foreach (LocaleEnum t in OPTIONS) {
		    if (t.Value.Equals(value)) {
			return t;
		    }
		}
	    }

	    return UNSET;
	}

	public ILocale GetInstanceNonStatic(Object value) {
	    if (value is String) {
		foreach (LocaleEnum t in OPTIONS) {
		    if (t.Value.Equals(value)) {
			return t;
		    }
		}
	    }

	    return UNSET;
	}

	private LocaleEnum() {}

	private LocaleEnum(String code, String name) {
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

	public void SetValue(Object newValue){
	    LocaleEnum instance = LocaleEnum.GetInstance(newValue);
	    code = instance.Code;
	    name = instance.Name;
	
	}

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(LocaleEnum_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(LocaleEnum_UNSET));
			} else if (this.Equals(ALBANIA)) {
				info.SetType(typeof(LocaleEnum_ALBANIA));
			} else if (this.Equals(ALGERIA)) {
				info.SetType(typeof(LocaleEnum_ALGERIA));
			} else if (this.Equals(ARGENTINA)) {
				info.SetType(typeof(LocaleEnum_ARGENTINA));
			} else if (this.Equals(ARMENIA)) {
				info.SetType(typeof(LocaleEnum_ARMENIA));
			} else if (this.Equals(AUSTRALIA)) {
				info.SetType(typeof(LocaleEnum_AUSTRALIA));
			} else if (this.Equals(AUSTRIA)) {
				info.SetType(typeof(LocaleEnum_AUSTRIA));
			} else if (this.Equals(AZERBAIJAN)) {
				info.SetType(typeof(LocaleEnum_AZERBAIJAN));
			} else if (this.Equals(BAHRAIN)) {
				info.SetType(typeof(LocaleEnum_BAHRAIN));
			} else if (this.Equals(BELARUS)) {
				info.SetType(typeof(LocaleEnum_BELARUS));
			} else if (this.Equals(BELGIUM)) {
				info.SetType(typeof(LocaleEnum_BELGIUM));
			} else if (this.Equals(BELIZE)) {
				info.SetType(typeof(LocaleEnum_BELIZE));
			} else if (this.Equals(BOLIVIA)) {
				info.SetType(typeof(LocaleEnum_BOLIVIA));
			} else if (this.Equals(BRAZIL)) {
				info.SetType(typeof(LocaleEnum_BRAZIL));
			} else if (this.Equals(BRUNEI)) {
				info.SetType(typeof(LocaleEnum_BRUNEI));
			} else if (this.Equals(BULGARIA)) {
				info.SetType(typeof(LocaleEnum_BULGARIA));
			} else if (this.Equals(CANADA)) {
				info.SetType(typeof(LocaleEnum_CANADA));
			} else if (this.Equals(CARIBBEAN)) {
				info.SetType(typeof(LocaleEnum_CARIBBEAN));
			} else if (this.Equals(CHILE)) {
				info.SetType(typeof(LocaleEnum_CHILE));
			} else if (this.Equals(CHINA)) {
				info.SetType(typeof(LocaleEnum_CHINA));
			} else if (this.Equals(COLOMBIA)) {
				info.SetType(typeof(LocaleEnum_COLOMBIA));
			} else if (this.Equals(COSTA_RICA)) {
				info.SetType(typeof(LocaleEnum_COSTA_RICA));
			} else if (this.Equals(CROATIA)) {
				info.SetType(typeof(LocaleEnum_CROATIA));
			} else if (this.Equals(CZECH_REPUBLIC)) {
				info.SetType(typeof(LocaleEnum_CZECH_REPUBLIC));
			} else if (this.Equals(DENMARK)) {
				info.SetType(typeof(LocaleEnum_DENMARK));
			} else if (this.Equals(DOMINICAN_REPUBLIC)) {
				info.SetType(typeof(LocaleEnum_DOMINICAN_REPUBLIC));
			} else if (this.Equals(ECUADOR)) {
				info.SetType(typeof(LocaleEnum_ECUADOR));
			} else if (this.Equals(EGYPT)) {
				info.SetType(typeof(LocaleEnum_EGYPT));
			} else if (this.Equals(EL_SALVADOR)) {
				info.SetType(typeof(LocaleEnum_EL_SALVADOR));
			} else if (this.Equals(ESTONIA)) {
				info.SetType(typeof(LocaleEnum_ESTONIA));
			} else if (this.Equals(FAROE_ISLANDS)) {
				info.SetType(typeof(LocaleEnum_FAROE_ISLANDS));
			} else if (this.Equals(FINLAND)) {
				info.SetType(typeof(LocaleEnum_FINLAND));
			} else if (this.Equals(FRANCE)) {
				info.SetType(typeof(LocaleEnum_FRANCE));
			} else if (this.Equals(FYROM)) {
				info.SetType(typeof(LocaleEnum_FYROM));
			} else if (this.Equals(GEORGIA)) {
				info.SetType(typeof(LocaleEnum_GEORGIA));
			} else if (this.Equals(GERMANY)) {
				info.SetType(typeof(LocaleEnum_GERMANY));
			} else if (this.Equals(UNITED_KINGDOM)) {
				info.SetType(typeof(LocaleEnum_UNITED_KINGDOM));
			} else if (this.Equals(GREECE)) {
				info.SetType(typeof(LocaleEnum_GREECE));
			} else if (this.Equals(GUATEMALA)) {
				info.SetType(typeof(LocaleEnum_GUATEMALA));
			} else if (this.Equals(HONDURAS)) {
				info.SetType(typeof(LocaleEnum_HONDURAS));
			} else if (this.Equals(HONG_KONG)) {
				info.SetType(typeof(LocaleEnum_HONG_KONG));
			} else if (this.Equals(HUNGARY)) {
				info.SetType(typeof(LocaleEnum_HUNGARY));
			} else if (this.Equals(ICELAND)) {
				info.SetType(typeof(LocaleEnum_ICELAND));
			} else if (this.Equals(INDIA)) {
				info.SetType(typeof(LocaleEnum_INDIA));
			} else if (this.Equals(INDONESIA)) {
				info.SetType(typeof(LocaleEnum_INDONESIA));
			} else if (this.Equals(IRAN)) {
				info.SetType(typeof(LocaleEnum_IRAN));
			} else if (this.Equals(IRAQ)) {
				info.SetType(typeof(LocaleEnum_IRAQ));
			} else if (this.Equals(IRELAND)) {
				info.SetType(typeof(LocaleEnum_IRELAND));
			} else if (this.Equals(ISRAEL)) {
				info.SetType(typeof(LocaleEnum_ISRAEL));
			} else if (this.Equals(ITALY)) {
				info.SetType(typeof(LocaleEnum_ITALY));
			} else if (this.Equals(JAMAICA)) {
				info.SetType(typeof(LocaleEnum_JAMAICA));
			} else if (this.Equals(JAPAN)) {
				info.SetType(typeof(LocaleEnum_JAPAN));
			} else if (this.Equals(JORDAN)) {
				info.SetType(typeof(LocaleEnum_JORDAN));
			} else if (this.Equals(KAZAKHSTAN)) {
				info.SetType(typeof(LocaleEnum_KAZAKHSTAN));
			} else if (this.Equals(KENYA)) {
				info.SetType(typeof(LocaleEnum_KENYA));
			} else if (this.Equals(KOREA)) {
				info.SetType(typeof(LocaleEnum_KOREA));
			} else if (this.Equals(KUWAIT)) {
				info.SetType(typeof(LocaleEnum_KUWAIT));
			} else if (this.Equals(LATVIA)) {
				info.SetType(typeof(LocaleEnum_LATVIA));
			} else if (this.Equals(LEBANON)) {
				info.SetType(typeof(LocaleEnum_LEBANON));
			} else if (this.Equals(LIBYA)) {
				info.SetType(typeof(LocaleEnum_LIBYA));
			} else if (this.Equals(LIECHTENSTEIN)) {
				info.SetType(typeof(LocaleEnum_LIECHTENSTEIN));
			} else if (this.Equals(LITHUANIA)) {
				info.SetType(typeof(LocaleEnum_LITHUANIA));
			} else if (this.Equals(LUXEMBOURG)) {
				info.SetType(typeof(LocaleEnum_LUXEMBOURG));
			} else if (this.Equals(MACAU)) {
				info.SetType(typeof(LocaleEnum_MACAU));
			} else if (this.Equals(MALAYSIA)) {
				info.SetType(typeof(LocaleEnum_MALAYSIA));
			} else if (this.Equals(MALDIVES)) {
				info.SetType(typeof(LocaleEnum_MALDIVES));
			} else if (this.Equals(MEXICO)) {
				info.SetType(typeof(LocaleEnum_MEXICO));
			} else if (this.Equals(MONACO)) {
				info.SetType(typeof(LocaleEnum_MONACO));
			} else if (this.Equals(MONGOLIA)) {
				info.SetType(typeof(LocaleEnum_MONGOLIA));
			} else if (this.Equals(MOROCCO)) {
				info.SetType(typeof(LocaleEnum_MOROCCO));
			} else if (this.Equals(NEW_ZEALAND)) {
				info.SetType(typeof(LocaleEnum_NEW_ZEALAND));
			} else if (this.Equals(NICARAGUA)) {
				info.SetType(typeof(LocaleEnum_NICARAGUA));
			} else if (this.Equals(NORWAY)) {
				info.SetType(typeof(LocaleEnum_NORWAY));
			} else if (this.Equals(OMAN)) {
				info.SetType(typeof(LocaleEnum_OMAN));
			} else if (this.Equals(PAKISTAN)) {
				info.SetType(typeof(LocaleEnum_PAKISTAN));
			} else if (this.Equals(PANAMA)) {
				info.SetType(typeof(LocaleEnum_PANAMA));
			} else if (this.Equals(PARAGUAY)) {
				info.SetType(typeof(LocaleEnum_PARAGUAY));
			} else if (this.Equals(PERU)) {
				info.SetType(typeof(LocaleEnum_PERU));
			} else if (this.Equals(PHILIPPINES)) {
				info.SetType(typeof(LocaleEnum_PHILIPPINES));
			} else if (this.Equals(POLAND)) {
				info.SetType(typeof(LocaleEnum_POLAND));
			} else if (this.Equals(PORTUGAL)) {
				info.SetType(typeof(LocaleEnum_PORTUGAL));
			} else if (this.Equals(PUERTO_RICO)) {
				info.SetType(typeof(LocaleEnum_PUERTO_RICO));
			} else if (this.Equals(QATAR)) {
				info.SetType(typeof(LocaleEnum_QATAR));
			} else if (this.Equals(ROMANIA)) {
				info.SetType(typeof(LocaleEnum_ROMANIA));
			} else if (this.Equals(RUSSIA)) {
				info.SetType(typeof(LocaleEnum_RUSSIA));
			} else if (this.Equals(SAUDI_ARABIA)) {
				info.SetType(typeof(LocaleEnum_SAUDI_ARABIA));
			} else if (this.Equals(SERBIA)) {
				info.SetType(typeof(LocaleEnum_SERBIA));
			} else if (this.Equals(SINGAPORE)) {
				info.SetType(typeof(LocaleEnum_SINGAPORE));
			} else if (this.Equals(SLOVAKIA)) {
				info.SetType(typeof(LocaleEnum_SLOVAKIA));
			} else if (this.Equals(SLOVENIA)) {
				info.SetType(typeof(LocaleEnum_SLOVENIA));
			} else if (this.Equals(SOUTH_AFRICA)) {
				info.SetType(typeof(LocaleEnum_SOUTH_AFRICA));
			} else if (this.Equals(SPAIN)) {
				info.SetType(typeof(LocaleEnum_SPAIN));
			} else if (this.Equals(SWEDEN)) {
				info.SetType(typeof(LocaleEnum_SWEDEN));
			} else if (this.Equals(SYRIA)) {
				info.SetType(typeof(LocaleEnum_SYRIA));
			} else if (this.Equals(TAIWAN)) {
				info.SetType(typeof(LocaleEnum_TAIWAN));
			} else if (this.Equals(THAILAND)) {
				info.SetType(typeof(LocaleEnum_THAILAND));
			} else if (this.Equals(THE_NETHERLANDS)) {
				info.SetType(typeof(LocaleEnum_THE_NETHERLANDS));
			} else if (this.Equals(TRINIDAD_AND_TOBAGO)) {
				info.SetType(typeof(LocaleEnum_TRINIDAD_AND_TOBAGO));
			} else if (this.Equals(TUNISIA)) {
				info.SetType(typeof(LocaleEnum_TUNISIA));
			} else if (this.Equals(TURKEY)) {
				info.SetType(typeof(LocaleEnum_TURKEY));
			} else if (this.Equals(UKRAINE)) {
				info.SetType(typeof(LocaleEnum_UKRAINE));
			} else if (this.Equals(UNITED_ARAB_EMIRATES)) {
				info.SetType(typeof(LocaleEnum_UNITED_ARAB_EMIRATES));
			} else if (this.Equals(UNITED_STATES)) {
				info.SetType(typeof(LocaleEnum_UNITED_STATES));
			} else if (this.Equals(URUGUAY)) {
				info.SetType(typeof(LocaleEnum_URUGUAY));
			} else if (this.Equals(UZBEKISTAN)) {
				info.SetType(typeof(LocaleEnum_UZBEKISTAN));
			} else if (this.Equals(VENEZUELA)) {
				info.SetType(typeof(LocaleEnum_VENEZUELA));
			} else if (this.Equals(VIETNAM)) {
				info.SetType(typeof(LocaleEnum_VIETNAM));
			} else if (this.Equals(YEMEN)) {
				info.SetType(typeof(LocaleEnum_YEMEN));
			} else if (this.Equals(ZIMBABWE)) {
				info.SetType(typeof(LocaleEnum_ZIMBABWE));
			}
        }
    }

    
    [Serializable]
    public class LocaleEnum_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LocaleEnum.DEFAULT;
        }
    }

    [Serializable]
    public class LocaleEnum_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return LocaleEnum.UNSET;
        }
    }
	
	[Serializable]
	public class LocaleEnum_ALBANIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ALBANIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ALGERIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ALGERIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ARGENTINA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ARGENTINA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ARMENIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ARMENIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_AUSTRALIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.AUSTRALIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_AUSTRIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.AUSTRIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_AZERBAIJAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.AZERBAIJAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BAHRAIN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BAHRAIN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BELARUS : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BELARUS;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BELGIUM : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BELGIUM;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BELIZE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BELIZE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BOLIVIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BOLIVIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BRAZIL : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BRAZIL;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BRUNEI : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BRUNEI;
		}
	}
	
	[Serializable]
	public class LocaleEnum_BULGARIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.BULGARIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CANADA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CANADA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CARIBBEAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CARIBBEAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CHILE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CHILE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CHINA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CHINA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_COLOMBIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.COLOMBIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_COSTA_RICA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.COSTA_RICA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CROATIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CROATIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_CZECH_REPUBLIC : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.CZECH_REPUBLIC;
		}
	}
	
	[Serializable]
	public class LocaleEnum_DENMARK : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.DENMARK;
		}
	}
	
	[Serializable]
	public class LocaleEnum_DOMINICAN_REPUBLIC : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.DOMINICAN_REPUBLIC;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ECUADOR : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ECUADOR;
		}
	}
	
	[Serializable]
	public class LocaleEnum_EGYPT : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.EGYPT;
		}
	}
	
	[Serializable]
	public class LocaleEnum_EL_SALVADOR : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.EL_SALVADOR;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ESTONIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ESTONIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_FAROE_ISLANDS : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.FAROE_ISLANDS;
		}
	}
	
	[Serializable]
	public class LocaleEnum_FINLAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.FINLAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_FRANCE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.FRANCE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_FYROM : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.FYROM;
		}
	}
	
	[Serializable]
	public class LocaleEnum_GEORGIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.GEORGIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_GERMANY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.GERMANY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_UNITED_KINGDOM : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.UNITED_KINGDOM;
		}
	}
	
	[Serializable]
	public class LocaleEnum_GREECE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.GREECE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_GUATEMALA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.GUATEMALA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_HONDURAS : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.HONDURAS;
		}
	}
	
	[Serializable]
	public class LocaleEnum_HONG_KONG : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.HONG_KONG;
		}
	}
	
	[Serializable]
	public class LocaleEnum_HUNGARY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.HUNGARY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ICELAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ICELAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_INDIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.INDIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_INDONESIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.INDONESIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_IRAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.IRAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_IRAQ : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.IRAQ;
		}
	}
	
	[Serializable]
	public class LocaleEnum_IRELAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.IRELAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ISRAEL : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ISRAEL;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ITALY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ITALY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_JAMAICA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.JAMAICA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_JAPAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.JAPAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_JORDAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.JORDAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_KAZAKHSTAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.KAZAKHSTAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_KENYA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.KENYA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_KOREA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.KOREA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_KUWAIT : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.KUWAIT;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LATVIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LATVIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LEBANON : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LEBANON;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LIBYA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LIBYA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LIECHTENSTEIN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LIECHTENSTEIN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LITHUANIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LITHUANIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_LUXEMBOURG : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.LUXEMBOURG;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MACAU : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MACAU;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MALAYSIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MALAYSIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MALDIVES : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MALDIVES;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MEXICO : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MEXICO;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MONACO : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MONACO;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MONGOLIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MONGOLIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_MOROCCO : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.MOROCCO;
		}
	}
	
	[Serializable]
	public class LocaleEnum_NEW_ZEALAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.NEW_ZEALAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_NICARAGUA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.NICARAGUA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_NORWAY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.NORWAY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_OMAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.OMAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PAKISTAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PAKISTAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PANAMA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PANAMA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PARAGUAY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PARAGUAY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PERU : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PERU;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PHILIPPINES : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PHILIPPINES;
		}
	}
	
	[Serializable]
	public class LocaleEnum_POLAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.POLAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PORTUGAL : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PORTUGAL;
		}
	}
	
	[Serializable]
	public class LocaleEnum_PUERTO_RICO : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.PUERTO_RICO;
		}
	}
	
	[Serializable]
	public class LocaleEnum_QATAR : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.QATAR;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ROMANIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ROMANIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_RUSSIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.RUSSIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SAUDI_ARABIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SAUDI_ARABIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SERBIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SERBIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SINGAPORE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SINGAPORE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SLOVAKIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SLOVAKIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SLOVENIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SLOVENIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SOUTH_AFRICA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SOUTH_AFRICA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SPAIN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SPAIN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SWEDEN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SWEDEN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_SYRIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.SYRIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_TAIWAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.TAIWAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_THAILAND : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.THAILAND;
		}
	}
	
	[Serializable]
	public class LocaleEnum_THE_NETHERLANDS : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.THE_NETHERLANDS;
		}
	}
	
	[Serializable]
	public class LocaleEnum_TRINIDAD_AND_TOBAGO : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.TRINIDAD_AND_TOBAGO;
		}
	}
	
	[Serializable]
	public class LocaleEnum_TUNISIA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.TUNISIA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_TURKEY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.TURKEY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_UKRAINE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.UKRAINE;
		}
	}
	
	[Serializable]
	public class LocaleEnum_UNITED_ARAB_EMIRATES : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.UNITED_ARAB_EMIRATES;
		}
	}
	
	[Serializable]
	public class LocaleEnum_UNITED_STATES : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.UNITED_STATES;
		}
	}
	
	[Serializable]
	public class LocaleEnum_URUGUAY : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.URUGUAY;
		}
	}
	
	[Serializable]
	public class LocaleEnum_UZBEKISTAN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.UZBEKISTAN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_VENEZUELA : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.VENEZUELA;
		}
	}
	
	[Serializable]
	public class LocaleEnum_VIETNAM : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.VIETNAM;
		}
	}
	
	[Serializable]
	public class LocaleEnum_YEMEN : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.YEMEN;
		}
	}
	
	[Serializable]
	public class LocaleEnum_ZIMBABWE : IObjectReference {
		public object GetRealObject(StreamingContext context) {
			return LocaleEnum.ZIMBABWE;
		}
	}
}
