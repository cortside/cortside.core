using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {
    [Serializable]
    public class CountryCodeEnum : Spring2.Core.Types.EnumDataType, ISerializable {

        private static readonly ArrayList OPTIONS = new ArrayList();

        public static readonly new CountryCodeEnum DEFAULT = new CountryCodeEnum();
        public static readonly new CountryCodeEnum UNSET = new CountryCodeEnum();

        public static readonly CountryCodeEnum ARUBA = new CountryCodeEnum("ABW", "Aruba");
        public static readonly CountryCodeEnum AFGHANISTAN = new CountryCodeEnum("AFG", "Afghanistan");
        public static readonly CountryCodeEnum ANGOLA = new CountryCodeEnum("AGO", "Angola");
        public static readonly CountryCodeEnum ANGUILLA = new CountryCodeEnum("AIA", "Anguilla");
        public static readonly CountryCodeEnum ALAND_ISLANDS = new CountryCodeEnum("ALA", "Aland Islands");
        public static readonly CountryCodeEnum ALBANIA = new CountryCodeEnum("ALB", "Albania");
        public static readonly CountryCodeEnum ANDORRA = new CountryCodeEnum("AND", "Andorra");
        public static readonly CountryCodeEnum NETHERLANDS_ANTILLES = new CountryCodeEnum("ANT", "Netherlands Antilles");
        public static readonly CountryCodeEnum UNITED_ARAB_EMIRATES = new CountryCodeEnum("ARE", "United Arab Emirates");
        public static readonly CountryCodeEnum ARGENTINA = new CountryCodeEnum("ARG", "Argentina");
        public static readonly CountryCodeEnum ARMENIA = new CountryCodeEnum("ARM", "Armenia");
        public static readonly CountryCodeEnum AMERICAN_SAMOA = new CountryCodeEnum("ASM", "American Samoa");
        public static readonly CountryCodeEnum ANTARCTICA = new CountryCodeEnum("ATA", "Antarctica");
        public static readonly CountryCodeEnum FRENCH_SOUTHERN_TERRITORIES = new CountryCodeEnum("ATF", "French Southern Territories");
        public static readonly CountryCodeEnum ANTIGUA_AND_BARBUDA = new CountryCodeEnum("ATG", "Antigua and Barbuda");
        public static readonly CountryCodeEnum AUSTRALIA = new CountryCodeEnum("AUS", "Australia");
        public static readonly CountryCodeEnum AUSTRIA = new CountryCodeEnum("AUT", "Austria");
        public static readonly CountryCodeEnum AZERBAIJAN = new CountryCodeEnum("AZE", "Azerbaijan");
        public static readonly CountryCodeEnum BURUNDI = new CountryCodeEnum("BDI", "Burundi");
        public static readonly CountryCodeEnum BELGIUM = new CountryCodeEnum("BEL", "Belgium");
        public static readonly CountryCodeEnum BENIN = new CountryCodeEnum("BEN", "Benin");
        public static readonly CountryCodeEnum BURKINA_FASO = new CountryCodeEnum("BFA", "Burkina Faso");
        public static readonly CountryCodeEnum BANGLADESH = new CountryCodeEnum("BGD", "Bangladesh");
        public static readonly CountryCodeEnum BULGARIA = new CountryCodeEnum("BGR", "Bulgaria");
        public static readonly CountryCodeEnum BAHRAIN = new CountryCodeEnum("BHR", "Bahrain");
        public static readonly CountryCodeEnum BAHAMAS = new CountryCodeEnum("BHS", "Bahamas");
        public static readonly CountryCodeEnum BOSNIA_AND_HERZEGOVINA = new CountryCodeEnum("BIH", "Bosnia and Herzegovina");
        public static readonly CountryCodeEnum SAINT_BARTHELEMY = new CountryCodeEnum("BLM", "Saint Barthelemy");
        public static readonly CountryCodeEnum BELARUS = new CountryCodeEnum("BLR", "Belarus");
        public static readonly CountryCodeEnum BELIZE = new CountryCodeEnum("BLZ", "Belize");
        public static readonly CountryCodeEnum BERMUDA = new CountryCodeEnum("BMU", "Bermuda");
        public static readonly CountryCodeEnum BOLIVIA_PLURINATIONAL_STATE_OF = new CountryCodeEnum("BOL", "Bolivia, Plurinational State of");
        public static readonly CountryCodeEnum BRAZIL = new CountryCodeEnum("BRA", "Brazil");
        public static readonly CountryCodeEnum BARBADOS = new CountryCodeEnum("BRB", "Barbados");
        public static readonly CountryCodeEnum BRUNEI_DARUSSALAM = new CountryCodeEnum("BRN", "Brunei Darussalam");
        public static readonly CountryCodeEnum BHUTAN = new CountryCodeEnum("BTN", "Bhutan");
        public static readonly CountryCodeEnum BOUVET_ISLAND = new CountryCodeEnum("BVT", "Bouvet Island");
        public static readonly CountryCodeEnum BOTSWANA = new CountryCodeEnum("BWA", "Botswana");
        public static readonly CountryCodeEnum CENTRAL_AFRICAN_REPUBLIC = new CountryCodeEnum("CAF", "Central African Republic");
        public static readonly CountryCodeEnum CANADA = new CountryCodeEnum("CAN", "Canada");
        public static readonly CountryCodeEnum COCOS_KEELING_ISLANDS = new CountryCodeEnum("CCK", "Cocos (Keeling) Islands");
        public static readonly CountryCodeEnum SWITZERLAND = new CountryCodeEnum("CHE", "Switzerland");
        public static readonly CountryCodeEnum CHILE = new CountryCodeEnum("CHL", "Chile");
        public static readonly CountryCodeEnum CHINA = new CountryCodeEnum("CHN", "China");
        public static readonly CountryCodeEnum COTE_DIVOIRE = new CountryCodeEnum("CIV", "Cote d'Ivoire");
        public static readonly CountryCodeEnum CAMEROON = new CountryCodeEnum("CMR", "Cameroon");
        public static readonly CountryCodeEnum CONGO_THE_DEMOCRATIC_REPUBLIC_OF_THE = new CountryCodeEnum("COD", "Congo, the Democratic Republic of the");
        public static readonly CountryCodeEnum CONGO = new CountryCodeEnum("COG", "Congo");
        public static readonly CountryCodeEnum COOK_ISLANDS = new CountryCodeEnum("COK", "Cook Islands");
        public static readonly CountryCodeEnum COLOMBIA = new CountryCodeEnum("COL", "Colombia");
        public static readonly CountryCodeEnum COMOROS = new CountryCodeEnum("COM", "Comoros");
        public static readonly CountryCodeEnum CAPE_VERDE = new CountryCodeEnum("CPV", "Cape Verde");
        public static readonly CountryCodeEnum COSTA_RICA = new CountryCodeEnum("CRI", "Costa Rica");
        public static readonly CountryCodeEnum CUBA = new CountryCodeEnum("CUB", "Cuba");
        public static readonly CountryCodeEnum CHRISTMAS_ISLAND = new CountryCodeEnum("CXR", "Christmas Island");
        public static readonly CountryCodeEnum CAYMAN_ISLANDS = new CountryCodeEnum("CYM", "Cayman Islands");
        public static readonly CountryCodeEnum CYPRUS = new CountryCodeEnum("CYP", "Cyprus");
        public static readonly CountryCodeEnum CZECH_REPUBLIC = new CountryCodeEnum("CZE", "Czech Republic");
        public static readonly CountryCodeEnum GERMANY = new CountryCodeEnum("DEU", "Germany");
        public static readonly CountryCodeEnum DJIBOUTI = new CountryCodeEnum("DJI", "Djibouti");
        public static readonly CountryCodeEnum DOMINICA = new CountryCodeEnum("DMA", "Dominica");
        public static readonly CountryCodeEnum DENMARK = new CountryCodeEnum("DNK", "Denmark");
        public static readonly CountryCodeEnum DOMINICAN_REPUBLIC = new CountryCodeEnum("DOM", "Dominican Republic");
        public static readonly CountryCodeEnum ALGERIA = new CountryCodeEnum("DZA", "Algeria");
        public static readonly CountryCodeEnum ECUADOR = new CountryCodeEnum("ECU", "Ecuador");
        public static readonly CountryCodeEnum EGYPT = new CountryCodeEnum("EGY", "Egypt");
        public static readonly CountryCodeEnum ERITREA = new CountryCodeEnum("ERI", "Eritrea");
        public static readonly CountryCodeEnum WESTERN_SAHARA = new CountryCodeEnum("ESH", "Western Sahara");
        public static readonly CountryCodeEnum SPAIN = new CountryCodeEnum("ESP", "Spain");
        public static readonly CountryCodeEnum ESTONIA = new CountryCodeEnum("EST", "Estonia");
        public static readonly CountryCodeEnum ETHIOPIA = new CountryCodeEnum("ETH", "Ethiopia");
        public static readonly CountryCodeEnum FINLAND = new CountryCodeEnum("FIN", "Finland");
        public static readonly CountryCodeEnum FIJI = new CountryCodeEnum("FJI", "Fiji");
        public static readonly CountryCodeEnum FALKLAND_ISLANDS_MALVINAS = new CountryCodeEnum("FLK", "Falkland Islands (Malvinas)");
        public static readonly CountryCodeEnum FRANCE = new CountryCodeEnum("FRA", "France");
        public static readonly CountryCodeEnum FAROE_ISLANDS = new CountryCodeEnum("FRO", "Faroe Islands");
        public static readonly CountryCodeEnum MICRONESIA_FEDERATED_STATES_OF = new CountryCodeEnum("FSM", "Micronesia, Federated States of");
        public static readonly CountryCodeEnum GABON = new CountryCodeEnum("GAB", "Gabon");
        public static readonly CountryCodeEnum UNITED_KINGDOM = new CountryCodeEnum("GBR", "United Kingdom");
        public static readonly CountryCodeEnum GEORGIA = new CountryCodeEnum("GEO", "Georgia");
        public static readonly CountryCodeEnum GUERNSEY = new CountryCodeEnum("GGY", "Guernsey");
        public static readonly CountryCodeEnum GHANA = new CountryCodeEnum("GHA", "Ghana");
        public static readonly CountryCodeEnum GIBRALTAR = new CountryCodeEnum("GIB", "Gibraltar");
        public static readonly CountryCodeEnum GUINEA = new CountryCodeEnum("GIN", "Guinea");
        public static readonly CountryCodeEnum GUADELOUPE = new CountryCodeEnum("GLP", "Guadeloupe");
        public static readonly CountryCodeEnum GAMBIA = new CountryCodeEnum("GMB", "Gambia");
        public static readonly CountryCodeEnum GUINEABISSAU = new CountryCodeEnum("GNB", "Guinea-Bissau");
        public static readonly CountryCodeEnum EQUATORIAL_GUINEA = new CountryCodeEnum("GNQ", "Equatorial Guinea");
        public static readonly CountryCodeEnum GREECE = new CountryCodeEnum("GRC", "Greece");
        public static readonly CountryCodeEnum GRENADA = new CountryCodeEnum("GRD", "Grenada");
        public static readonly CountryCodeEnum GREENLAND = new CountryCodeEnum("GRL", "Greenland");
        public static readonly CountryCodeEnum GUATEMALA = new CountryCodeEnum("GTM", "Guatemala");
        public static readonly CountryCodeEnum FRENCH_GUIANA = new CountryCodeEnum("GUF", "French Guiana");
        public static readonly CountryCodeEnum GUAM = new CountryCodeEnum("GUM", "Guam");
        public static readonly CountryCodeEnum GUYANA = new CountryCodeEnum("GUY", "Guyana");
        public static readonly CountryCodeEnum HONG_KONG = new CountryCodeEnum("HKG", "Hong Kong");
        public static readonly CountryCodeEnum HEARD_ISLAND_AND_MCDONALD_ISLANDS = new CountryCodeEnum("HMD", "Heard Island and McDonald Islands");
        public static readonly CountryCodeEnum HONDURAS = new CountryCodeEnum("HND", "Honduras");
        public static readonly CountryCodeEnum CROATIA = new CountryCodeEnum("HRV", "Croatia");
        public static readonly CountryCodeEnum HAITI = new CountryCodeEnum("HTI", "Haiti");
        public static readonly CountryCodeEnum HUNGARY = new CountryCodeEnum("HUN", "Hungary");
        public static readonly CountryCodeEnum INDONESIA = new CountryCodeEnum("IDN", "Indonesia");
        public static readonly CountryCodeEnum ISLE_OF_MAN = new CountryCodeEnum("IMN", "Isle of Man");
        public static readonly CountryCodeEnum INDIA = new CountryCodeEnum("IND", "India");
        public static readonly CountryCodeEnum BRITISH_INDIAN_OCEAN_TERRITORY = new CountryCodeEnum("IOT", "British Indian Ocean Territory");
        public static readonly CountryCodeEnum IRELAND = new CountryCodeEnum("IRL", "Ireland");
        public static readonly CountryCodeEnum IRAN_ISLAMIC_REPUBLIC_OF = new CountryCodeEnum("IRN", "Iran, Islamic Republic of");
        public static readonly CountryCodeEnum IRAQ = new CountryCodeEnum("IRQ", "Iraq");
        public static readonly CountryCodeEnum ICELAND = new CountryCodeEnum("ISL", "Iceland");
        public static readonly CountryCodeEnum ISRAEL = new CountryCodeEnum("ISR", "Israel");
        public static readonly CountryCodeEnum ITALY = new CountryCodeEnum("ITA", "Italy");
        public static readonly CountryCodeEnum JAMAICA = new CountryCodeEnum("JAM", "Jamaica");
        public static readonly CountryCodeEnum JERSEY = new CountryCodeEnum("JEY", "Jersey");
        public static readonly CountryCodeEnum JORDAN = new CountryCodeEnum("JOR", "Jordan");
        public static readonly CountryCodeEnum JAPAN = new CountryCodeEnum("JPN", "Japan");
        public static readonly CountryCodeEnum KAZAKHSTAN = new CountryCodeEnum("KAZ", "Kazakhstan");
        public static readonly CountryCodeEnum KENYA = new CountryCodeEnum("KEN", "Kenya");
        public static readonly CountryCodeEnum KYRGYZSTAN = new CountryCodeEnum("KGZ", "Kyrgyzstan");
        public static readonly CountryCodeEnum CAMBODIA = new CountryCodeEnum("KHM", "Cambodia");
        public static readonly CountryCodeEnum KIRIBATI = new CountryCodeEnum("KIR", "Kiribati");
        public static readonly CountryCodeEnum SAINT_KITTS_AND_NEVIS = new CountryCodeEnum("KNA", "Saint Kitts and Nevis");
        public static readonly CountryCodeEnum KOREA_REPUBLIC_OF = new CountryCodeEnum("KOR", "Korea, Republic of");
        public static readonly CountryCodeEnum KUWAIT = new CountryCodeEnum("KWT", "Kuwait");
        public static readonly CountryCodeEnum LAO_PEOPLES_DEMOCRATIC_REPUBLIC = new CountryCodeEnum("LAO", "Lao People's Democratic Republic");
        public static readonly CountryCodeEnum LEBANON = new CountryCodeEnum("LBN", "Lebanon");
        public static readonly CountryCodeEnum LIBERIA = new CountryCodeEnum("LBR", "Liberia");
        public static readonly CountryCodeEnum LIBYAN_ARAB_JAMAHIRIYA = new CountryCodeEnum("LBY", "Libyan Arab Jamahiriya");
        public static readonly CountryCodeEnum SAINT_LUCIA = new CountryCodeEnum("LCA", "Saint Lucia");
        public static readonly CountryCodeEnum LIECHTENSTEIN = new CountryCodeEnum("LIE", "Liechtenstein");
        public static readonly CountryCodeEnum SRI_LANKA = new CountryCodeEnum("LKA", "Sri Lanka");
        public static readonly CountryCodeEnum LESOTHO = new CountryCodeEnum("LSO", "Lesotho");
        public static readonly CountryCodeEnum LITHUANIA = new CountryCodeEnum("LTU", "Lithuania");
        public static readonly CountryCodeEnum LUXEMBOURG = new CountryCodeEnum("LUX", "Luxembourg");
        public static readonly CountryCodeEnum LATVIA = new CountryCodeEnum("LVA", "Latvia");
        public static readonly CountryCodeEnum MACAO = new CountryCodeEnum("MAC", "Macao");
        public static readonly CountryCodeEnum SAINT_MARTIN_FRENCH_PART = new CountryCodeEnum("MAF", "Saint Martin (French part)");
        public static readonly CountryCodeEnum MOROCCO = new CountryCodeEnum("MAR", "Morocco");
        public static readonly CountryCodeEnum MONACO = new CountryCodeEnum("MCO", "Monaco");
        public static readonly CountryCodeEnum MOLDOVA_REPUBLIC_OF = new CountryCodeEnum("MDA", "Moldova, Republic of");
        public static readonly CountryCodeEnum MADAGASCAR = new CountryCodeEnum("MDG", "Madagascar");
        public static readonly CountryCodeEnum MALDIVES = new CountryCodeEnum("MDV", "Maldives");
        public static readonly CountryCodeEnum MEXICO = new CountryCodeEnum("MEX", "Mexico");
        public static readonly CountryCodeEnum MARSHALL_ISLANDS = new CountryCodeEnum("MHL", "Marshall Islands");
        public static readonly CountryCodeEnum MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF = new CountryCodeEnum("MKD", "Macedonia, the former Yugoslav Republic of");
        public static readonly CountryCodeEnum MALI = new CountryCodeEnum("MLI", "Mali");
        public static readonly CountryCodeEnum MALTA = new CountryCodeEnum("MLT", "Malta");
        public static readonly CountryCodeEnum MYANMAR = new CountryCodeEnum("MMR", "Myanmar");
        public static readonly CountryCodeEnum MONTENEGRO = new CountryCodeEnum("MNE", "Montenegro");
        public static readonly CountryCodeEnum MONGOLIA = new CountryCodeEnum("MNG", "Mongolia");
        public static readonly CountryCodeEnum NORTHERN_MARIANA_ISLANDS = new CountryCodeEnum("MNP", "Northern Mariana Islands");
        public static readonly CountryCodeEnum MOZAMBIQUE = new CountryCodeEnum("MOZ", "Mozambique");
        public static readonly CountryCodeEnum MAURITANIA = new CountryCodeEnum("MRT", "Mauritania");
        public static readonly CountryCodeEnum MONTSERRAT = new CountryCodeEnum("MSR", "Montserrat");
        public static readonly CountryCodeEnum MARTINIQUE = new CountryCodeEnum("MTQ", "Martinique");
        public static readonly CountryCodeEnum MAURITIUS = new CountryCodeEnum("MUS", "Mauritius");
        public static readonly CountryCodeEnum MALAWI = new CountryCodeEnum("MWI", "Malawi");
        public static readonly CountryCodeEnum MALAYSIA = new CountryCodeEnum("MYS", "Malaysia");
        public static readonly CountryCodeEnum MAYOTTE = new CountryCodeEnum("MYT", "Mayotte");
        public static readonly CountryCodeEnum NAMIBIA = new CountryCodeEnum("NAM", "Namibia");
        public static readonly CountryCodeEnum NEW_CALEDONIA = new CountryCodeEnum("NCL", "New Caledonia");
        public static readonly CountryCodeEnum NIGER = new CountryCodeEnum("NER", "Niger");
        public static readonly CountryCodeEnum NORFOLK_ISLAND = new CountryCodeEnum("NFK", "Norfolk Island");
        public static readonly CountryCodeEnum NIGERIA = new CountryCodeEnum("NGA", "Nigeria");
        public static readonly CountryCodeEnum NICARAGUA = new CountryCodeEnum("NIC", "Nicaragua");
        public static readonly CountryCodeEnum _NIUE = new CountryCodeEnum(" NI", " Niue");
        public static readonly CountryCodeEnum NETHERLANDS = new CountryCodeEnum("NLD", "Netherlands");
        public static readonly CountryCodeEnum NORWAY = new CountryCodeEnum("NOR", "Norway");
        public static readonly CountryCodeEnum NEPAL = new CountryCodeEnum("NPL", "Nepal");
        public static readonly CountryCodeEnum NAURU = new CountryCodeEnum("NRU", "Nauru");
        public static readonly CountryCodeEnum NEW_ZEALAND = new CountryCodeEnum("NZL", "New Zealand");
        public static readonly CountryCodeEnum OMAN = new CountryCodeEnum("OMN", "Oman");
        public static readonly CountryCodeEnum PAKISTAN = new CountryCodeEnum("PAK", "Pakistan");
        public static readonly CountryCodeEnum PANAMA = new CountryCodeEnum("PAN", "Panama");
        public static readonly CountryCodeEnum PITCAIRN = new CountryCodeEnum("PCN", "Pitcairn");
        public static readonly CountryCodeEnum PERU = new CountryCodeEnum("PER", "Peru");
        public static readonly CountryCodeEnum PHILIPPINES = new CountryCodeEnum("PHL", "Philippines");
        public static readonly CountryCodeEnum PALAU = new CountryCodeEnum("PLW", "Palau");
        public static readonly CountryCodeEnum PAPUA_NEW_GUINEA = new CountryCodeEnum("PNG", "Papua New Guinea");
        public static readonly CountryCodeEnum POLAND = new CountryCodeEnum("POL", "Poland");
        public static readonly CountryCodeEnum PUERTO_RICO = new CountryCodeEnum("PRI", "Puerto Rico");
        public static readonly CountryCodeEnum KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF = new CountryCodeEnum("PRK", "Korea, Democratic People's Republic of");
        public static readonly CountryCodeEnum PORTUGAL = new CountryCodeEnum("PRT", "Portugal");
        public static readonly CountryCodeEnum PARAGUAY = new CountryCodeEnum("PRY", "Paraguay");
        public static readonly CountryCodeEnum PALESTINIAN_TERRITORY_OCCUPIED = new CountryCodeEnum("PSE", "Palestinian Territory, Occupied");
        public static readonly CountryCodeEnum FRENCH_POLYNESIA = new CountryCodeEnum("PYF", "French Polynesia");
        public static readonly CountryCodeEnum QATAR = new CountryCodeEnum("QAT", "Qatar");
        public static readonly CountryCodeEnum REUNION = new CountryCodeEnum("REU", "Reunion");
        public static readonly CountryCodeEnum ROMANIA = new CountryCodeEnum("ROU", "Romania");
        public static readonly CountryCodeEnum RUSSIAN_FEDERATION = new CountryCodeEnum("RUS", "Russian Federation");
        public static readonly CountryCodeEnum RWANDA = new CountryCodeEnum("RWA", "Rwanda");
        public static readonly CountryCodeEnum SAUDI_ARABIA = new CountryCodeEnum("SAU", "Saudi Arabia");
        public static readonly CountryCodeEnum SUDAN = new CountryCodeEnum("SDN", "Sudan");
        public static readonly CountryCodeEnum SENEGAL = new CountryCodeEnum("SEN", "Senegal");
        public static readonly CountryCodeEnum SINGAPORE = new CountryCodeEnum("SGP", "Singapore");
        public static readonly CountryCodeEnum SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS = new CountryCodeEnum("SGS", "South Georgia and the South Sandwich Islands");
        public static readonly CountryCodeEnum SAINT_HELENA = new CountryCodeEnum("SHN", "Saint Helena");
        public static readonly CountryCodeEnum SVALBARD_AND_JAN_MAYEN = new CountryCodeEnum("SJM", "Svalbard and Jan Mayen");
        public static readonly CountryCodeEnum SOLOMON_ISLANDS = new CountryCodeEnum("SLB", "Solomon Islands");
        public static readonly CountryCodeEnum SIERRA_LEONE = new CountryCodeEnum("SLE", "Sierra Leone");
        public static readonly CountryCodeEnum EL_SALVADOR = new CountryCodeEnum("SLV", "El Salvador");
        public static readonly CountryCodeEnum SAN_MARINO = new CountryCodeEnum("SMR", "San Marino");
        public static readonly CountryCodeEnum SOMALIA = new CountryCodeEnum("SOM", "Somalia");
        public static readonly CountryCodeEnum SAINT_PIERRE_AND_MIQUELON = new CountryCodeEnum("SPM", "Saint Pierre and Miquelon");
        public static readonly CountryCodeEnum SERBIA = new CountryCodeEnum("SRB", "Serbia");
        public static readonly CountryCodeEnum SAO_TOME_AND_PRINCIPE = new CountryCodeEnum("STP", "Sao Tome and Principe");
        public static readonly CountryCodeEnum SURINAME = new CountryCodeEnum("SUR", "Suriname");
        public static readonly CountryCodeEnum SLOVAKIA = new CountryCodeEnum("SVK", "Slovakia");
        public static readonly CountryCodeEnum SLOVENIA = new CountryCodeEnum("SVN", "Slovenia");
        public static readonly CountryCodeEnum SWEDEN = new CountryCodeEnum("SWE", "Sweden");
        public static readonly CountryCodeEnum SWAZILAND = new CountryCodeEnum("SWZ", "Swaziland");
        public static readonly CountryCodeEnum SEYCHELLES = new CountryCodeEnum("SYC", "Seychelles");
        public static readonly CountryCodeEnum SYRIAN_ARAB_REPUBLIC = new CountryCodeEnum("SYR", "Syrian Arab Republic");
        public static readonly CountryCodeEnum TURKS_AND_CAICOS_ISLANDS = new CountryCodeEnum("TCA", "Turks and Caicos Islands");
        public static readonly CountryCodeEnum CHAD = new CountryCodeEnum("TCD", "Chad");
        public static readonly CountryCodeEnum TOGO = new CountryCodeEnum("TGO", "Togo");
        public static readonly CountryCodeEnum THAILAND = new CountryCodeEnum("THA", "Thailand");
        public static readonly CountryCodeEnum TAJIKISTAN = new CountryCodeEnum("TJK", "Tajikistan");
        public static readonly CountryCodeEnum TOKELAU = new CountryCodeEnum("TKL", "Tokelau");
        public static readonly CountryCodeEnum TURKMENISTAN = new CountryCodeEnum("TKM", "Turkmenistan");
        public static readonly CountryCodeEnum TIMORLESTE = new CountryCodeEnum("TLS", "Timor-Leste");
        public static readonly CountryCodeEnum TONGA = new CountryCodeEnum("TON", "Tonga");
        public static readonly CountryCodeEnum TRINIDAD_AND_TOBAGO = new CountryCodeEnum("TTO", "Trinidad and Tobago");
        public static readonly CountryCodeEnum TUNISIA = new CountryCodeEnum("TUN", "Tunisia");
        public static readonly CountryCodeEnum TURKEY = new CountryCodeEnum("TUR", "Turkey");
        public static readonly CountryCodeEnum TUVALU = new CountryCodeEnum("TUV", "Tuvalu");
        public static readonly CountryCodeEnum TAIWAN_PROVINCE_OF_CHINA = new CountryCodeEnum("TWN", "Taiwan, Province of China");
        public static readonly CountryCodeEnum TANZANIA_UNITED_REPUBLIC_OF = new CountryCodeEnum("TZA", "Tanzania, United Republic of");
        public static readonly CountryCodeEnum UGANDA = new CountryCodeEnum("UGA", "Uganda");
        public static readonly CountryCodeEnum UKRAINE = new CountryCodeEnum("UKR", "Ukraine");
        public static readonly CountryCodeEnum UNITED_STATES_MINOR_OUTLYING_ISLANDS = new CountryCodeEnum("UMI", "United States Minor Outlying Islands");
        public static readonly CountryCodeEnum URUGUAY = new CountryCodeEnum("URY", "Uruguay");
        public static readonly CountryCodeEnum UNITED_STATES = new CountryCodeEnum("USA", "United States");
        public static readonly CountryCodeEnum UZBEKISTAN = new CountryCodeEnum("UZB", "Uzbekistan");
        public static readonly CountryCodeEnum HOLY_SEE_VATICAN_CITY_STATE = new CountryCodeEnum("VAT", "Holy See (Vatican City State)");
        public static readonly CountryCodeEnum SAINT_VINCENT_AND_THE_GRENADINES = new CountryCodeEnum("VCT", "Saint Vincent and the Grenadines");
        public static readonly CountryCodeEnum VENEZUELA_BOLIVARIAN_REPUBLIC_OF = new CountryCodeEnum("VEN", "Venezuela, Bolivarian Republic of");
        public static readonly CountryCodeEnum VIRGIN_ISLANDS_BRITISH = new CountryCodeEnum("VGB", "Virgin Islands, British");
        public static readonly CountryCodeEnum VIRGIN_ISLANDS_US = new CountryCodeEnum("VIR", "Virgin Islands, U.S.");
        public static readonly CountryCodeEnum VIET_NAM = new CountryCodeEnum("VNM", "Viet Nam");
        public static readonly CountryCodeEnum VANUATU = new CountryCodeEnum("VUT", "Vanuatu");
        public static readonly CountryCodeEnum WALLIS_AND_FUTUNA = new CountryCodeEnum("WLF", "Wallis and Futuna");
        public static readonly CountryCodeEnum SAMOA = new CountryCodeEnum("WSM", "Samoa");
        public static readonly CountryCodeEnum YEMEN = new CountryCodeEnum("YEM", "Yemen");
        public static readonly CountryCodeEnum SOUTH_AFRICA = new CountryCodeEnum("ZAF", "South Africa");
        public static readonly CountryCodeEnum ZAMBIA = new CountryCodeEnum("ZMB", "Zambia");
        public static readonly CountryCodeEnum ZIMBABWE = new CountryCodeEnum("ZWE", "Zimbabwe");

        public static CountryCodeEnum GetInstance(Object value) {
            if (value is String) {
                foreach (CountryCodeEnum t in OPTIONS) {
                    if (t.Value.Equals(value)) {
                        return t;
                    }
                }
            }

            return UNSET;
        }

        private CountryCodeEnum() { }

        private CountryCodeEnum(String code, String name) {
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

        public static IList Options {
            get { return OPTIONS; }
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(CountryCodeEnum_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(CountryCodeEnum_UNSET));
            } else if (this.Equals(ARUBA)) {
                info.SetType(typeof(CountryCodeEnum_ARUBA));
            } else if (this.Equals(AFGHANISTAN)) {
                info.SetType(typeof(CountryCodeEnum_AFGHANISTAN));
            } else if (this.Equals(ANGOLA)) {
                info.SetType(typeof(CountryCodeEnum_ANGOLA));
            } else if (this.Equals(ANGUILLA)) {
                info.SetType(typeof(CountryCodeEnum_ANGUILLA));
            } else if (this.Equals(ALAND_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_ALAND_ISLANDS));
            } else if (this.Equals(ALBANIA)) {
                info.SetType(typeof(CountryCodeEnum_ALBANIA));
            } else if (this.Equals(ANDORRA)) {
                info.SetType(typeof(CountryCodeEnum_ANDORRA));
            } else if (this.Equals(NETHERLANDS_ANTILLES)) {
                info.SetType(typeof(CountryCodeEnum_NETHERLANDS_ANTILLES));
            } else if (this.Equals(UNITED_ARAB_EMIRATES)) {
                info.SetType(typeof(CountryCodeEnum_UNITED_ARAB_EMIRATES));
            } else if (this.Equals(ARGENTINA)) {
                info.SetType(typeof(CountryCodeEnum_ARGENTINA));
            } else if (this.Equals(ARMENIA)) {
                info.SetType(typeof(CountryCodeEnum_ARMENIA));
            } else if (this.Equals(AMERICAN_SAMOA)) {
                info.SetType(typeof(CountryCodeEnum_AMERICAN_SAMOA));
            } else if (this.Equals(ANTARCTICA)) {
                info.SetType(typeof(CountryCodeEnum_ANTARCTICA));
            } else if (this.Equals(FRENCH_SOUTHERN_TERRITORIES)) {
                info.SetType(typeof(CountryCodeEnum_FRENCH_SOUTHERN_TERRITORIES));
            } else if (this.Equals(ANTIGUA_AND_BARBUDA)) {
                info.SetType(typeof(CountryCodeEnum_ANTIGUA_AND_BARBUDA));
            } else if (this.Equals(AUSTRALIA)) {
                info.SetType(typeof(CountryCodeEnum_AUSTRALIA));
            } else if (this.Equals(AUSTRIA)) {
                info.SetType(typeof(CountryCodeEnum_AUSTRIA));
            } else if (this.Equals(AZERBAIJAN)) {
                info.SetType(typeof(CountryCodeEnum_AZERBAIJAN));
            } else if (this.Equals(BURUNDI)) {
                info.SetType(typeof(CountryCodeEnum_BURUNDI));
            } else if (this.Equals(BELGIUM)) {
                info.SetType(typeof(CountryCodeEnum_BELGIUM));
            } else if (this.Equals(BENIN)) {
                info.SetType(typeof(CountryCodeEnum_BENIN));
            } else if (this.Equals(BURKINA_FASO)) {
                info.SetType(typeof(CountryCodeEnum_BURKINA_FASO));
            } else if (this.Equals(BANGLADESH)) {
                info.SetType(typeof(CountryCodeEnum_BANGLADESH));
            } else if (this.Equals(BULGARIA)) {
                info.SetType(typeof(CountryCodeEnum_BULGARIA));
            } else if (this.Equals(BAHRAIN)) {
                info.SetType(typeof(CountryCodeEnum_BAHRAIN));
            } else if (this.Equals(BAHAMAS)) {
                info.SetType(typeof(CountryCodeEnum_BAHAMAS));
            } else if (this.Equals(BOSNIA_AND_HERZEGOVINA)) {
                info.SetType(typeof(CountryCodeEnum_BOSNIA_AND_HERZEGOVINA));
            } else if (this.Equals(SAINT_BARTHELEMY)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_BARTHELEMY));
            } else if (this.Equals(BELARUS)) {
                info.SetType(typeof(CountryCodeEnum_BELARUS));
            } else if (this.Equals(BELIZE)) {
                info.SetType(typeof(CountryCodeEnum_BELIZE));
            } else if (this.Equals(BERMUDA)) {
                info.SetType(typeof(CountryCodeEnum_BERMUDA));
            } else if (this.Equals(BOLIVIA_PLURINATIONAL_STATE_OF)) {
                info.SetType(typeof(CountryCodeEnum_BOLIVIA_PLURINATIONAL_STATE_OF));
            } else if (this.Equals(BRAZIL)) {
                info.SetType(typeof(CountryCodeEnum_BRAZIL));
            } else if (this.Equals(BARBADOS)) {
                info.SetType(typeof(CountryCodeEnum_BARBADOS));
            } else if (this.Equals(BRUNEI_DARUSSALAM)) {
                info.SetType(typeof(CountryCodeEnum_BRUNEI_DARUSSALAM));
            } else if (this.Equals(BHUTAN)) {
                info.SetType(typeof(CountryCodeEnum_BHUTAN));
            } else if (this.Equals(BOUVET_ISLAND)) {
                info.SetType(typeof(CountryCodeEnum_BOUVET_ISLAND));
            } else if (this.Equals(BOTSWANA)) {
                info.SetType(typeof(CountryCodeEnum_BOTSWANA));
            } else if (this.Equals(CENTRAL_AFRICAN_REPUBLIC)) {
                info.SetType(typeof(CountryCodeEnum_CENTRAL_AFRICAN_REPUBLIC));
            } else if (this.Equals(CANADA)) {
                info.SetType(typeof(CountryCodeEnum_CANADA));
            } else if (this.Equals(COCOS_KEELING_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_COCOS_KEELING_ISLANDS));
            } else if (this.Equals(SWITZERLAND)) {
                info.SetType(typeof(CountryCodeEnum_SWITZERLAND));
            } else if (this.Equals(CHILE)) {
                info.SetType(typeof(CountryCodeEnum_CHILE));
            } else if (this.Equals(CHINA)) {
                info.SetType(typeof(CountryCodeEnum_CHINA));
            } else if (this.Equals(COTE_DIVOIRE)) {
                info.SetType(typeof(CountryCodeEnum_COTE_DIVOIRE));
            } else if (this.Equals(CAMEROON)) {
                info.SetType(typeof(CountryCodeEnum_CAMEROON));
            } else if (this.Equals(CONGO_THE_DEMOCRATIC_REPUBLIC_OF_THE)) {
                info.SetType(typeof(CountryCodeEnum_CONGO_THE_DEMOCRATIC_REPUBLIC_OF_THE));
            } else if (this.Equals(CONGO)) {
                info.SetType(typeof(CountryCodeEnum_CONGO));
            } else if (this.Equals(COOK_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_COOK_ISLANDS));
            } else if (this.Equals(COLOMBIA)) {
                info.SetType(typeof(CountryCodeEnum_COLOMBIA));
            } else if (this.Equals(COMOROS)) {
                info.SetType(typeof(CountryCodeEnum_COMOROS));
            } else if (this.Equals(CAPE_VERDE)) {
                info.SetType(typeof(CountryCodeEnum_CAPE_VERDE));
            } else if (this.Equals(COSTA_RICA)) {
                info.SetType(typeof(CountryCodeEnum_COSTA_RICA));
            } else if (this.Equals(CUBA)) {
                info.SetType(typeof(CountryCodeEnum_CUBA));
            } else if (this.Equals(CHRISTMAS_ISLAND)) {
                info.SetType(typeof(CountryCodeEnum_CHRISTMAS_ISLAND));
            } else if (this.Equals(CAYMAN_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_CAYMAN_ISLANDS));
            } else if (this.Equals(CYPRUS)) {
                info.SetType(typeof(CountryCodeEnum_CYPRUS));
            } else if (this.Equals(CZECH_REPUBLIC)) {
                info.SetType(typeof(CountryCodeEnum_CZECH_REPUBLIC));
            } else if (this.Equals(GERMANY)) {
                info.SetType(typeof(CountryCodeEnum_GERMANY));
            } else if (this.Equals(DJIBOUTI)) {
                info.SetType(typeof(CountryCodeEnum_DJIBOUTI));
            } else if (this.Equals(DOMINICA)) {
                info.SetType(typeof(CountryCodeEnum_DOMINICA));
            } else if (this.Equals(DENMARK)) {
                info.SetType(typeof(CountryCodeEnum_DENMARK));
            } else if (this.Equals(DOMINICAN_REPUBLIC)) {
                info.SetType(typeof(CountryCodeEnum_DOMINICAN_REPUBLIC));
            } else if (this.Equals(ALGERIA)) {
                info.SetType(typeof(CountryCodeEnum_ALGERIA));
            } else if (this.Equals(ECUADOR)) {
                info.SetType(typeof(CountryCodeEnum_ECUADOR));
            } else if (this.Equals(EGYPT)) {
                info.SetType(typeof(CountryCodeEnum_EGYPT));
            } else if (this.Equals(ERITREA)) {
                info.SetType(typeof(CountryCodeEnum_ERITREA));
            } else if (this.Equals(WESTERN_SAHARA)) {
                info.SetType(typeof(CountryCodeEnum_WESTERN_SAHARA));
            } else if (this.Equals(SPAIN)) {
                info.SetType(typeof(CountryCodeEnum_SPAIN));
            } else if (this.Equals(ESTONIA)) {
                info.SetType(typeof(CountryCodeEnum_ESTONIA));
            } else if (this.Equals(ETHIOPIA)) {
                info.SetType(typeof(CountryCodeEnum_ETHIOPIA));
            } else if (this.Equals(FINLAND)) {
                info.SetType(typeof(CountryCodeEnum_FINLAND));
            } else if (this.Equals(FIJI)) {
                info.SetType(typeof(CountryCodeEnum_FIJI));
            } else if (this.Equals(FALKLAND_ISLANDS_MALVINAS)) {
                info.SetType(typeof(CountryCodeEnum_FALKLAND_ISLANDS_MALVINAS));
            } else if (this.Equals(FRANCE)) {
                info.SetType(typeof(CountryCodeEnum_FRANCE));
            } else if (this.Equals(FAROE_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_FAROE_ISLANDS));
            } else if (this.Equals(MICRONESIA_FEDERATED_STATES_OF)) {
                info.SetType(typeof(CountryCodeEnum_MICRONESIA_FEDERATED_STATES_OF));
            } else if (this.Equals(GABON)) {
                info.SetType(typeof(CountryCodeEnum_GABON));
            } else if (this.Equals(UNITED_KINGDOM)) {
                info.SetType(typeof(CountryCodeEnum_UNITED_KINGDOM));
            } else if (this.Equals(GEORGIA)) {
                info.SetType(typeof(CountryCodeEnum_GEORGIA));
            } else if (this.Equals(GUERNSEY)) {
                info.SetType(typeof(CountryCodeEnum_GUERNSEY));
            } else if (this.Equals(GHANA)) {
                info.SetType(typeof(CountryCodeEnum_GHANA));
            } else if (this.Equals(GIBRALTAR)) {
                info.SetType(typeof(CountryCodeEnum_GIBRALTAR));
            } else if (this.Equals(GUINEA)) {
                info.SetType(typeof(CountryCodeEnum_GUINEA));
            } else if (this.Equals(GUADELOUPE)) {
                info.SetType(typeof(CountryCodeEnum_GUADELOUPE));
            } else if (this.Equals(GAMBIA)) {
                info.SetType(typeof(CountryCodeEnum_GAMBIA));
            } else if (this.Equals(GUINEABISSAU)) {
                info.SetType(typeof(CountryCodeEnum_GUINEABISSAU));
            } else if (this.Equals(EQUATORIAL_GUINEA)) {
                info.SetType(typeof(CountryCodeEnum_EQUATORIAL_GUINEA));
            } else if (this.Equals(GREECE)) {
                info.SetType(typeof(CountryCodeEnum_GREECE));
            } else if (this.Equals(GRENADA)) {
                info.SetType(typeof(CountryCodeEnum_GRENADA));
            } else if (this.Equals(GREENLAND)) {
                info.SetType(typeof(CountryCodeEnum_GREENLAND));
            } else if (this.Equals(GUATEMALA)) {
                info.SetType(typeof(CountryCodeEnum_GUATEMALA));
            } else if (this.Equals(FRENCH_GUIANA)) {
                info.SetType(typeof(CountryCodeEnum_FRENCH_GUIANA));
            } else if (this.Equals(GUAM)) {
                info.SetType(typeof(CountryCodeEnum_GUAM));
            } else if (this.Equals(GUYANA)) {
                info.SetType(typeof(CountryCodeEnum_GUYANA));
            } else if (this.Equals(HONG_KONG)) {
                info.SetType(typeof(CountryCodeEnum_HONG_KONG));
            } else if (this.Equals(HEARD_ISLAND_AND_MCDONALD_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_HEARD_ISLAND_AND_MCDONALD_ISLANDS));
            } else if (this.Equals(HONDURAS)) {
                info.SetType(typeof(CountryCodeEnum_HONDURAS));
            } else if (this.Equals(CROATIA)) {
                info.SetType(typeof(CountryCodeEnum_CROATIA));
            } else if (this.Equals(HAITI)) {
                info.SetType(typeof(CountryCodeEnum_HAITI));
            } else if (this.Equals(HUNGARY)) {
                info.SetType(typeof(CountryCodeEnum_HUNGARY));
            } else if (this.Equals(INDONESIA)) {
                info.SetType(typeof(CountryCodeEnum_INDONESIA));
            } else if (this.Equals(ISLE_OF_MAN)) {
                info.SetType(typeof(CountryCodeEnum_ISLE_OF_MAN));
            } else if (this.Equals(INDIA)) {
                info.SetType(typeof(CountryCodeEnum_INDIA));
            } else if (this.Equals(BRITISH_INDIAN_OCEAN_TERRITORY)) {
                info.SetType(typeof(CountryCodeEnum_BRITISH_INDIAN_OCEAN_TERRITORY));
            } else if (this.Equals(IRELAND)) {
                info.SetType(typeof(CountryCodeEnum_IRELAND));
            } else if (this.Equals(IRAN_ISLAMIC_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_IRAN_ISLAMIC_REPUBLIC_OF));
            } else if (this.Equals(IRAQ)) {
                info.SetType(typeof(CountryCodeEnum_IRAQ));
            } else if (this.Equals(ICELAND)) {
                info.SetType(typeof(CountryCodeEnum_ICELAND));
            } else if (this.Equals(ISRAEL)) {
                info.SetType(typeof(CountryCodeEnum_ISRAEL));
            } else if (this.Equals(ITALY)) {
                info.SetType(typeof(CountryCodeEnum_ITALY));
            } else if (this.Equals(JAMAICA)) {
                info.SetType(typeof(CountryCodeEnum_JAMAICA));
            } else if (this.Equals(JERSEY)) {
                info.SetType(typeof(CountryCodeEnum_JERSEY));
            } else if (this.Equals(JORDAN)) {
                info.SetType(typeof(CountryCodeEnum_JORDAN));
            } else if (this.Equals(JAPAN)) {
                info.SetType(typeof(CountryCodeEnum_JAPAN));
            } else if (this.Equals(KAZAKHSTAN)) {
                info.SetType(typeof(CountryCodeEnum_KAZAKHSTAN));
            } else if (this.Equals(KENYA)) {
                info.SetType(typeof(CountryCodeEnum_KENYA));
            } else if (this.Equals(KYRGYZSTAN)) {
                info.SetType(typeof(CountryCodeEnum_KYRGYZSTAN));
            } else if (this.Equals(CAMBODIA)) {
                info.SetType(typeof(CountryCodeEnum_CAMBODIA));
            } else if (this.Equals(KIRIBATI)) {
                info.SetType(typeof(CountryCodeEnum_KIRIBATI));
            } else if (this.Equals(SAINT_KITTS_AND_NEVIS)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_KITTS_AND_NEVIS));
            } else if (this.Equals(KOREA_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_KOREA_REPUBLIC_OF));
            } else if (this.Equals(KUWAIT)) {
                info.SetType(typeof(CountryCodeEnum_KUWAIT));
            } else if (this.Equals(LAO_PEOPLES_DEMOCRATIC_REPUBLIC)) {
                info.SetType(typeof(CountryCodeEnum_LAO_PEOPLES_DEMOCRATIC_REPUBLIC));
            } else if (this.Equals(LEBANON)) {
                info.SetType(typeof(CountryCodeEnum_LEBANON));
            } else if (this.Equals(LIBERIA)) {
                info.SetType(typeof(CountryCodeEnum_LIBERIA));
            } else if (this.Equals(LIBYAN_ARAB_JAMAHIRIYA)) {
                info.SetType(typeof(CountryCodeEnum_LIBYAN_ARAB_JAMAHIRIYA));
            } else if (this.Equals(SAINT_LUCIA)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_LUCIA));
            } else if (this.Equals(LIECHTENSTEIN)) {
                info.SetType(typeof(CountryCodeEnum_LIECHTENSTEIN));
            } else if (this.Equals(SRI_LANKA)) {
                info.SetType(typeof(CountryCodeEnum_SRI_LANKA));
            } else if (this.Equals(LESOTHO)) {
                info.SetType(typeof(CountryCodeEnum_LESOTHO));
            } else if (this.Equals(LITHUANIA)) {
                info.SetType(typeof(CountryCodeEnum_LITHUANIA));
            } else if (this.Equals(LUXEMBOURG)) {
                info.SetType(typeof(CountryCodeEnum_LUXEMBOURG));
            } else if (this.Equals(LATVIA)) {
                info.SetType(typeof(CountryCodeEnum_LATVIA));
            } else if (this.Equals(MACAO)) {
                info.SetType(typeof(CountryCodeEnum_MACAO));
            } else if (this.Equals(SAINT_MARTIN_FRENCH_PART)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_MARTIN_FRENCH_PART));
            } else if (this.Equals(MOROCCO)) {
                info.SetType(typeof(CountryCodeEnum_MOROCCO));
            } else if (this.Equals(MONACO)) {
                info.SetType(typeof(CountryCodeEnum_MONACO));
            } else if (this.Equals(MOLDOVA_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_MOLDOVA_REPUBLIC_OF));
            } else if (this.Equals(MADAGASCAR)) {
                info.SetType(typeof(CountryCodeEnum_MADAGASCAR));
            } else if (this.Equals(MALDIVES)) {
                info.SetType(typeof(CountryCodeEnum_MALDIVES));
            } else if (this.Equals(MEXICO)) {
                info.SetType(typeof(CountryCodeEnum_MEXICO));
            } else if (this.Equals(MARSHALL_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_MARSHALL_ISLANDS));
            } else if (this.Equals(MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF));
            } else if (this.Equals(MALI)) {
                info.SetType(typeof(CountryCodeEnum_MALI));
            } else if (this.Equals(MALTA)) {
                info.SetType(typeof(CountryCodeEnum_MALTA));
            } else if (this.Equals(MYANMAR)) {
                info.SetType(typeof(CountryCodeEnum_MYANMAR));
            } else if (this.Equals(MONTENEGRO)) {
                info.SetType(typeof(CountryCodeEnum_MONTENEGRO));
            } else if (this.Equals(MONGOLIA)) {
                info.SetType(typeof(CountryCodeEnum_MONGOLIA));
            } else if (this.Equals(NORTHERN_MARIANA_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_NORTHERN_MARIANA_ISLANDS));
            } else if (this.Equals(MOZAMBIQUE)) {
                info.SetType(typeof(CountryCodeEnum_MOZAMBIQUE));
            } else if (this.Equals(MAURITANIA)) {
                info.SetType(typeof(CountryCodeEnum_MAURITANIA));
            } else if (this.Equals(MONTSERRAT)) {
                info.SetType(typeof(CountryCodeEnum_MONTSERRAT));
            } else if (this.Equals(MARTINIQUE)) {
                info.SetType(typeof(CountryCodeEnum_MARTINIQUE));
            } else if (this.Equals(MAURITIUS)) {
                info.SetType(typeof(CountryCodeEnum_MAURITIUS));
            } else if (this.Equals(MALAWI)) {
                info.SetType(typeof(CountryCodeEnum_MALAWI));
            } else if (this.Equals(MALAYSIA)) {
                info.SetType(typeof(CountryCodeEnum_MALAYSIA));
            } else if (this.Equals(MAYOTTE)) {
                info.SetType(typeof(CountryCodeEnum_MAYOTTE));
            } else if (this.Equals(NAMIBIA)) {
                info.SetType(typeof(CountryCodeEnum_NAMIBIA));
            } else if (this.Equals(NEW_CALEDONIA)) {
                info.SetType(typeof(CountryCodeEnum_NEW_CALEDONIA));
            } else if (this.Equals(NIGER)) {
                info.SetType(typeof(CountryCodeEnum_NIGER));
            } else if (this.Equals(NORFOLK_ISLAND)) {
                info.SetType(typeof(CountryCodeEnum_NORFOLK_ISLAND));
            } else if (this.Equals(NIGERIA)) {
                info.SetType(typeof(CountryCodeEnum_NIGERIA));
            } else if (this.Equals(NICARAGUA)) {
                info.SetType(typeof(CountryCodeEnum_NICARAGUA));
            } else if (this.Equals(_NIUE)) {
                info.SetType(typeof(CountryCodeEnum__NIUE));
            } else if (this.Equals(NETHERLANDS)) {
                info.SetType(typeof(CountryCodeEnum_NETHERLANDS));
            } else if (this.Equals(NORWAY)) {
                info.SetType(typeof(CountryCodeEnum_NORWAY));
            } else if (this.Equals(NEPAL)) {
                info.SetType(typeof(CountryCodeEnum_NEPAL));
            } else if (this.Equals(NAURU)) {
                info.SetType(typeof(CountryCodeEnum_NAURU));
            } else if (this.Equals(NEW_ZEALAND)) {
                info.SetType(typeof(CountryCodeEnum_NEW_ZEALAND));
            } else if (this.Equals(OMAN)) {
                info.SetType(typeof(CountryCodeEnum_OMAN));
            } else if (this.Equals(PAKISTAN)) {
                info.SetType(typeof(CountryCodeEnum_PAKISTAN));
            } else if (this.Equals(PANAMA)) {
                info.SetType(typeof(CountryCodeEnum_PANAMA));
            } else if (this.Equals(PITCAIRN)) {
                info.SetType(typeof(CountryCodeEnum_PITCAIRN));
            } else if (this.Equals(PERU)) {
                info.SetType(typeof(CountryCodeEnum_PERU));
            } else if (this.Equals(PHILIPPINES)) {
                info.SetType(typeof(CountryCodeEnum_PHILIPPINES));
            } else if (this.Equals(PALAU)) {
                info.SetType(typeof(CountryCodeEnum_PALAU));
            } else if (this.Equals(PAPUA_NEW_GUINEA)) {
                info.SetType(typeof(CountryCodeEnum_PAPUA_NEW_GUINEA));
            } else if (this.Equals(POLAND)) {
                info.SetType(typeof(CountryCodeEnum_POLAND));
            } else if (this.Equals(PUERTO_RICO)) {
                info.SetType(typeof(CountryCodeEnum_PUERTO_RICO));
            } else if (this.Equals(KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF));
            } else if (this.Equals(PORTUGAL)) {
                info.SetType(typeof(CountryCodeEnum_PORTUGAL));
            } else if (this.Equals(PARAGUAY)) {
                info.SetType(typeof(CountryCodeEnum_PARAGUAY));
            } else if (this.Equals(PALESTINIAN_TERRITORY_OCCUPIED)) {
                info.SetType(typeof(CountryCodeEnum_PALESTINIAN_TERRITORY_OCCUPIED));
            } else if (this.Equals(FRENCH_POLYNESIA)) {
                info.SetType(typeof(CountryCodeEnum_FRENCH_POLYNESIA));
            } else if (this.Equals(QATAR)) {
                info.SetType(typeof(CountryCodeEnum_QATAR));
            } else if (this.Equals(REUNION)) {
                info.SetType(typeof(CountryCodeEnum_REUNION));
            } else if (this.Equals(ROMANIA)) {
                info.SetType(typeof(CountryCodeEnum_ROMANIA));
            } else if (this.Equals(RUSSIAN_FEDERATION)) {
                info.SetType(typeof(CountryCodeEnum_RUSSIAN_FEDERATION));
            } else if (this.Equals(RWANDA)) {
                info.SetType(typeof(CountryCodeEnum_RWANDA));
            } else if (this.Equals(SAUDI_ARABIA)) {
                info.SetType(typeof(CountryCodeEnum_SAUDI_ARABIA));
            } else if (this.Equals(SUDAN)) {
                info.SetType(typeof(CountryCodeEnum_SUDAN));
            } else if (this.Equals(SENEGAL)) {
                info.SetType(typeof(CountryCodeEnum_SENEGAL));
            } else if (this.Equals(SINGAPORE)) {
                info.SetType(typeof(CountryCodeEnum_SINGAPORE));
            } else if (this.Equals(SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS));
            } else if (this.Equals(SAINT_HELENA)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_HELENA));
            } else if (this.Equals(SVALBARD_AND_JAN_MAYEN)) {
                info.SetType(typeof(CountryCodeEnum_SVALBARD_AND_JAN_MAYEN));
            } else if (this.Equals(SOLOMON_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_SOLOMON_ISLANDS));
            } else if (this.Equals(SIERRA_LEONE)) {
                info.SetType(typeof(CountryCodeEnum_SIERRA_LEONE));
            } else if (this.Equals(EL_SALVADOR)) {
                info.SetType(typeof(CountryCodeEnum_EL_SALVADOR));
            } else if (this.Equals(SAN_MARINO)) {
                info.SetType(typeof(CountryCodeEnum_SAN_MARINO));
            } else if (this.Equals(SOMALIA)) {
                info.SetType(typeof(CountryCodeEnum_SOMALIA));
            } else if (this.Equals(SAINT_PIERRE_AND_MIQUELON)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_PIERRE_AND_MIQUELON));
            } else if (this.Equals(SERBIA)) {
                info.SetType(typeof(CountryCodeEnum_SERBIA));
            } else if (this.Equals(SAO_TOME_AND_PRINCIPE)) {
                info.SetType(typeof(CountryCodeEnum_SAO_TOME_AND_PRINCIPE));
            } else if (this.Equals(SURINAME)) {
                info.SetType(typeof(CountryCodeEnum_SURINAME));
            } else if (this.Equals(SLOVAKIA)) {
                info.SetType(typeof(CountryCodeEnum_SLOVAKIA));
            } else if (this.Equals(SLOVENIA)) {
                info.SetType(typeof(CountryCodeEnum_SLOVENIA));
            } else if (this.Equals(SWEDEN)) {
                info.SetType(typeof(CountryCodeEnum_SWEDEN));
            } else if (this.Equals(SWAZILAND)) {
                info.SetType(typeof(CountryCodeEnum_SWAZILAND));
            } else if (this.Equals(SEYCHELLES)) {
                info.SetType(typeof(CountryCodeEnum_SEYCHELLES));
            } else if (this.Equals(SYRIAN_ARAB_REPUBLIC)) {
                info.SetType(typeof(CountryCodeEnum_SYRIAN_ARAB_REPUBLIC));
            } else if (this.Equals(TURKS_AND_CAICOS_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_TURKS_AND_CAICOS_ISLANDS));
            } else if (this.Equals(CHAD)) {
                info.SetType(typeof(CountryCodeEnum_CHAD));
            } else if (this.Equals(TOGO)) {
                info.SetType(typeof(CountryCodeEnum_TOGO));
            } else if (this.Equals(THAILAND)) {
                info.SetType(typeof(CountryCodeEnum_THAILAND));
            } else if (this.Equals(TAJIKISTAN)) {
                info.SetType(typeof(CountryCodeEnum_TAJIKISTAN));
            } else if (this.Equals(TOKELAU)) {
                info.SetType(typeof(CountryCodeEnum_TOKELAU));
            } else if (this.Equals(TURKMENISTAN)) {
                info.SetType(typeof(CountryCodeEnum_TURKMENISTAN));
            } else if (this.Equals(TIMORLESTE)) {
                info.SetType(typeof(CountryCodeEnum_TIMORLESTE));
            } else if (this.Equals(TONGA)) {
                info.SetType(typeof(CountryCodeEnum_TONGA));
            } else if (this.Equals(TRINIDAD_AND_TOBAGO)) {
                info.SetType(typeof(CountryCodeEnum_TRINIDAD_AND_TOBAGO));
            } else if (this.Equals(TUNISIA)) {
                info.SetType(typeof(CountryCodeEnum_TUNISIA));
            } else if (this.Equals(TURKEY)) {
                info.SetType(typeof(CountryCodeEnum_TURKEY));
            } else if (this.Equals(TUVALU)) {
                info.SetType(typeof(CountryCodeEnum_TUVALU));
            } else if (this.Equals(TAIWAN_PROVINCE_OF_CHINA)) {
                info.SetType(typeof(CountryCodeEnum_TAIWAN_PROVINCE_OF_CHINA));
            } else if (this.Equals(TANZANIA_UNITED_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_TANZANIA_UNITED_REPUBLIC_OF));
            } else if (this.Equals(UGANDA)) {
                info.SetType(typeof(CountryCodeEnum_UGANDA));
            } else if (this.Equals(UKRAINE)) {
                info.SetType(typeof(CountryCodeEnum_UKRAINE));
            } else if (this.Equals(UNITED_STATES_MINOR_OUTLYING_ISLANDS)) {
                info.SetType(typeof(CountryCodeEnum_UNITED_STATES_MINOR_OUTLYING_ISLANDS));
            } else if (this.Equals(URUGUAY)) {
                info.SetType(typeof(CountryCodeEnum_URUGUAY));
            } else if (this.Equals(UNITED_STATES)) {
                info.SetType(typeof(CountryCodeEnum_UNITED_STATES));
            } else if (this.Equals(UZBEKISTAN)) {
                info.SetType(typeof(CountryCodeEnum_UZBEKISTAN));
            } else if (this.Equals(HOLY_SEE_VATICAN_CITY_STATE)) {
                info.SetType(typeof(CountryCodeEnum_HOLY_SEE_VATICAN_CITY_STATE));
            } else if (this.Equals(SAINT_VINCENT_AND_THE_GRENADINES)) {
                info.SetType(typeof(CountryCodeEnum_SAINT_VINCENT_AND_THE_GRENADINES));
            } else if (this.Equals(VENEZUELA_BOLIVARIAN_REPUBLIC_OF)) {
                info.SetType(typeof(CountryCodeEnum_VENEZUELA_BOLIVARIAN_REPUBLIC_OF));
            } else if (this.Equals(VIRGIN_ISLANDS_BRITISH)) {
                info.SetType(typeof(CountryCodeEnum_VIRGIN_ISLANDS_BRITISH));
            } else if (this.Equals(VIRGIN_ISLANDS_US)) {
                info.SetType(typeof(CountryCodeEnum_VIRGIN_ISLANDS_US));
            } else if (this.Equals(VIET_NAM)) {
                info.SetType(typeof(CountryCodeEnum_VIET_NAM));
            } else if (this.Equals(VANUATU)) {
                info.SetType(typeof(CountryCodeEnum_VANUATU));
            } else if (this.Equals(WALLIS_AND_FUTUNA)) {
                info.SetType(typeof(CountryCodeEnum_WALLIS_AND_FUTUNA));
            } else if (this.Equals(SAMOA)) {
                info.SetType(typeof(CountryCodeEnum_SAMOA));
            } else if (this.Equals(YEMEN)) {
                info.SetType(typeof(CountryCodeEnum_YEMEN));
            } else if (this.Equals(SOUTH_AFRICA)) {
                info.SetType(typeof(CountryCodeEnum_SOUTH_AFRICA));
            } else if (this.Equals(ZAMBIA)) {
                info.SetType(typeof(CountryCodeEnum_ZAMBIA));
            } else if (this.Equals(ZIMBABWE)) {
                info.SetType(typeof(CountryCodeEnum_ZIMBABWE));
            }
        }

    }

    [Serializable]
    public class CountryCodeEnum_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.DEFAULT;
        }
    }

    [Serializable]
    public class CountryCodeEnum_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UNSET;
        }
    }

    [Serializable]
    public class CountryCodeEnum_ARUBA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ARUBA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_AFGHANISTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.AFGHANISTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ANGOLA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ANGOLA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ANGUILLA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ANGUILLA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ALAND_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ALAND_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ALBANIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ALBANIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ANDORRA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ANDORRA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NETHERLANDS_ANTILLES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NETHERLANDS_ANTILLES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UNITED_ARAB_EMIRATES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UNITED_ARAB_EMIRATES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ARGENTINA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ARGENTINA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ARMENIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ARMENIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_AMERICAN_SAMOA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.AMERICAN_SAMOA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ANTARCTICA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ANTARCTICA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FRENCH_SOUTHERN_TERRITORIES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FRENCH_SOUTHERN_TERRITORIES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ANTIGUA_AND_BARBUDA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ANTIGUA_AND_BARBUDA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_AUSTRALIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.AUSTRALIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_AUSTRIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.AUSTRIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_AZERBAIJAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.AZERBAIJAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BURUNDI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BURUNDI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BELGIUM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BELGIUM;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BENIN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BENIN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BURKINA_FASO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BURKINA_FASO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BANGLADESH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BANGLADESH;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BULGARIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BULGARIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BAHRAIN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BAHRAIN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BAHAMAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BAHAMAS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BOSNIA_AND_HERZEGOVINA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BOSNIA_AND_HERZEGOVINA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_BARTHELEMY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_BARTHELEMY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BELARUS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BELARUS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BELIZE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BELIZE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BERMUDA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BERMUDA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BOLIVIA_PLURINATIONAL_STATE_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BOLIVIA_PLURINATIONAL_STATE_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BRAZIL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BRAZIL;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BARBADOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BARBADOS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BRUNEI_DARUSSALAM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BRUNEI_DARUSSALAM;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BHUTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BHUTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BOUVET_ISLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BOUVET_ISLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BOTSWANA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BOTSWANA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CENTRAL_AFRICAN_REPUBLIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CENTRAL_AFRICAN_REPUBLIC;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CANADA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CANADA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COCOS_KEELING_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COCOS_KEELING_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SWITZERLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SWITZERLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CHILE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CHILE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CHINA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CHINA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COTE_DIVOIRE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COTE_DIVOIRE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CAMEROON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CAMEROON;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CONGO_THE_DEMOCRATIC_REPUBLIC_OF_THE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CONGO_THE_DEMOCRATIC_REPUBLIC_OF_THE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CONGO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CONGO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COOK_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COOK_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COLOMBIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COLOMBIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COMOROS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COMOROS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CAPE_VERDE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CAPE_VERDE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_COSTA_RICA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.COSTA_RICA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CUBA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CUBA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CHRISTMAS_ISLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CHRISTMAS_ISLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CAYMAN_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CAYMAN_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CYPRUS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CYPRUS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CZECH_REPUBLIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CZECH_REPUBLIC;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GERMANY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GERMANY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_DJIBOUTI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.DJIBOUTI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_DOMINICA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.DOMINICA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_DENMARK : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.DENMARK;
        }
    }
    [Serializable]
    public class CountryCodeEnum_DOMINICAN_REPUBLIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.DOMINICAN_REPUBLIC;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ALGERIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ALGERIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ECUADOR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ECUADOR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_EGYPT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.EGYPT;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ERITREA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ERITREA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_WESTERN_SAHARA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.WESTERN_SAHARA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SPAIN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SPAIN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ESTONIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ESTONIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ETHIOPIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ETHIOPIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FINLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FINLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FIJI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FIJI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FALKLAND_ISLANDS_MALVINAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FALKLAND_ISLANDS_MALVINAS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FRANCE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FRANCE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FAROE_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FAROE_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MICRONESIA_FEDERATED_STATES_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MICRONESIA_FEDERATED_STATES_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GABON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GABON;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UNITED_KINGDOM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UNITED_KINGDOM;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GEORGIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GEORGIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUERNSEY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUERNSEY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GHANA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GHANA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GIBRALTAR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GIBRALTAR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUINEA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUINEA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUADELOUPE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUADELOUPE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GAMBIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GAMBIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUINEABISSAU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUINEABISSAU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_EQUATORIAL_GUINEA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.EQUATORIAL_GUINEA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GREECE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GREECE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GRENADA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GRENADA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GREENLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GREENLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUATEMALA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUATEMALA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FRENCH_GUIANA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FRENCH_GUIANA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUAM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUAM;
        }
    }
    [Serializable]
    public class CountryCodeEnum_GUYANA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.GUYANA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HONG_KONG : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HONG_KONG;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HEARD_ISLAND_AND_MCDONALD_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HEARD_ISLAND_AND_MCDONALD_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HONDURAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HONDURAS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CROATIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CROATIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HAITI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HAITI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HUNGARY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HUNGARY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_INDONESIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.INDONESIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ISLE_OF_MAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ISLE_OF_MAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_INDIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.INDIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_BRITISH_INDIAN_OCEAN_TERRITORY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.BRITISH_INDIAN_OCEAN_TERRITORY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_IRELAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.IRELAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_IRAN_ISLAMIC_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.IRAN_ISLAMIC_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_IRAQ : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.IRAQ;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ICELAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ICELAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ISRAEL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ISRAEL;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ITALY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ITALY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_JAMAICA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.JAMAICA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_JERSEY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.JERSEY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_JORDAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.JORDAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_JAPAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.JAPAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KAZAKHSTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KAZAKHSTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KENYA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KENYA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KYRGYZSTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KYRGYZSTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CAMBODIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CAMBODIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KIRIBATI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KIRIBATI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_KITTS_AND_NEVIS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_KITTS_AND_NEVIS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KOREA_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KOREA_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KUWAIT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KUWAIT;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LAO_PEOPLES_DEMOCRATIC_REPUBLIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LAO_PEOPLES_DEMOCRATIC_REPUBLIC;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LEBANON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LEBANON;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LIBERIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LIBERIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LIBYAN_ARAB_JAMAHIRIYA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LIBYAN_ARAB_JAMAHIRIYA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_LUCIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_LUCIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LIECHTENSTEIN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LIECHTENSTEIN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SRI_LANKA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SRI_LANKA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LESOTHO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LESOTHO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LITHUANIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LITHUANIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LUXEMBOURG : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LUXEMBOURG;
        }
    }
    [Serializable]
    public class CountryCodeEnum_LATVIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.LATVIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MACAO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MACAO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_MARTIN_FRENCH_PART : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_MARTIN_FRENCH_PART;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MOROCCO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MOROCCO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MONACO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MONACO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MOLDOVA_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MOLDOVA_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MADAGASCAR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MADAGASCAR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MALDIVES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MALDIVES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MEXICO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MEXICO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MARSHALL_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MARSHALL_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MACEDONIA_THE_FORMER_YUGOSLAV_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MALI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MALI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MALTA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MALTA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MYANMAR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MYANMAR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MONTENEGRO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MONTENEGRO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MONGOLIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MONGOLIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NORTHERN_MARIANA_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NORTHERN_MARIANA_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MOZAMBIQUE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MOZAMBIQUE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MAURITANIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MAURITANIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MONTSERRAT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MONTSERRAT;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MARTINIQUE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MARTINIQUE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MAURITIUS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MAURITIUS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MALAWI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MALAWI;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MALAYSIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MALAYSIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_MAYOTTE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.MAYOTTE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NAMIBIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NAMIBIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NEW_CALEDONIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NEW_CALEDONIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NIGER : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NIGER;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NORFOLK_ISLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NORFOLK_ISLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NIGERIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NIGERIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NICARAGUA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NICARAGUA;
        }
    }
    [Serializable]
    public class CountryCodeEnum__NIUE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum._NIUE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NETHERLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NETHERLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NORWAY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NORWAY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NEPAL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NEPAL;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NAURU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NAURU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_NEW_ZEALAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.NEW_ZEALAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_OMAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.OMAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PAKISTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PAKISTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PANAMA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PANAMA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PITCAIRN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PITCAIRN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PERU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PERU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PHILIPPINES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PHILIPPINES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PALAU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PALAU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PAPUA_NEW_GUINEA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PAPUA_NEW_GUINEA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_POLAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.POLAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PUERTO_RICO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PUERTO_RICO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.KOREA_DEMOCRATIC_PEOPLES_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PORTUGAL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PORTUGAL;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PARAGUAY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PARAGUAY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_PALESTINIAN_TERRITORY_OCCUPIED : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.PALESTINIAN_TERRITORY_OCCUPIED;
        }
    }
    [Serializable]
    public class CountryCodeEnum_FRENCH_POLYNESIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.FRENCH_POLYNESIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_QATAR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.QATAR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_REUNION : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.REUNION;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ROMANIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ROMANIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_RUSSIAN_FEDERATION : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.RUSSIAN_FEDERATION;
        }
    }
    [Serializable]
    public class CountryCodeEnum_RWANDA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.RWANDA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAUDI_ARABIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAUDI_ARABIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SUDAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SUDAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SENEGAL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SENEGAL;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SINGAPORE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SINGAPORE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SOUTH_GEORGIA_AND_THE_SOUTH_SANDWICH_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_HELENA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_HELENA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SVALBARD_AND_JAN_MAYEN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SVALBARD_AND_JAN_MAYEN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SOLOMON_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SOLOMON_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SIERRA_LEONE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SIERRA_LEONE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_EL_SALVADOR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.EL_SALVADOR;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAN_MARINO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAN_MARINO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SOMALIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SOMALIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_PIERRE_AND_MIQUELON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_PIERRE_AND_MIQUELON;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SERBIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SERBIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAO_TOME_AND_PRINCIPE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAO_TOME_AND_PRINCIPE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SURINAME : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SURINAME;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SLOVAKIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SLOVAKIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SLOVENIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SLOVENIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SWEDEN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SWEDEN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SWAZILAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SWAZILAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SEYCHELLES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SEYCHELLES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SYRIAN_ARAB_REPUBLIC : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SYRIAN_ARAB_REPUBLIC;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TURKS_AND_CAICOS_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TURKS_AND_CAICOS_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_CHAD : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.CHAD;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TOGO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TOGO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_THAILAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.THAILAND;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TAJIKISTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TAJIKISTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TOKELAU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TOKELAU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TURKMENISTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TURKMENISTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TIMORLESTE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TIMORLESTE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TONGA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TONGA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TRINIDAD_AND_TOBAGO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TRINIDAD_AND_TOBAGO;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TUNISIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TUNISIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TURKEY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TURKEY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TUVALU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TUVALU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TAIWAN_PROVINCE_OF_CHINA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TAIWAN_PROVINCE_OF_CHINA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_TANZANIA_UNITED_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.TANZANIA_UNITED_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UGANDA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UGANDA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UKRAINE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UKRAINE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UNITED_STATES_MINOR_OUTLYING_ISLANDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UNITED_STATES_MINOR_OUTLYING_ISLANDS;
        }
    }
    [Serializable]
    public class CountryCodeEnum_URUGUAY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.URUGUAY;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UNITED_STATES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UNITED_STATES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_UZBEKISTAN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.UZBEKISTAN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_HOLY_SEE_VATICAN_CITY_STATE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.HOLY_SEE_VATICAN_CITY_STATE;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAINT_VINCENT_AND_THE_GRENADINES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAINT_VINCENT_AND_THE_GRENADINES;
        }
    }
    [Serializable]
    public class CountryCodeEnum_VENEZUELA_BOLIVARIAN_REPUBLIC_OF : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.VENEZUELA_BOLIVARIAN_REPUBLIC_OF;
        }
    }
    [Serializable]
    public class CountryCodeEnum_VIRGIN_ISLANDS_BRITISH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.VIRGIN_ISLANDS_BRITISH;
        }
    }
    [Serializable]
    public class CountryCodeEnum_VIRGIN_ISLANDS_US : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.VIRGIN_ISLANDS_US;
        }
    }
    [Serializable]
    public class CountryCodeEnum_VIET_NAM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.VIET_NAM;
        }
    }
    [Serializable]
    public class CountryCodeEnum_VANUATU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.VANUATU;
        }
    }
    [Serializable]
    public class CountryCodeEnum_WALLIS_AND_FUTUNA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.WALLIS_AND_FUTUNA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SAMOA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SAMOA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_YEMEN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.YEMEN;
        }
    }
    [Serializable]
    public class CountryCodeEnum_SOUTH_AFRICA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.SOUTH_AFRICA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ZAMBIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ZAMBIA;
        }
    }
    [Serializable]
    public class CountryCodeEnum_ZIMBABWE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CountryCodeEnum.ZIMBABWE;
        }
    }
}
