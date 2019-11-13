using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {
    [Serializable]
    public class CurrencyCodeEnum : Cortside.Core.Types.EnumDataType, ISerializable {

        private static readonly ArrayList OPTIONS = new ArrayList();

        public static readonly new CurrencyCodeEnum DEFAULT = new CurrencyCodeEnum();
        public static readonly new CurrencyCodeEnum UNSET = new CurrencyCodeEnum();

        public static readonly CurrencyCodeEnum UNITED_ARAB_EMIRATES_DIRHAMS = new CurrencyCodeEnum("AED", "United Arab Emirates, Dirhams");
        public static readonly CurrencyCodeEnum AFGHANISTAN_AFGHANIS = new CurrencyCodeEnum("AFN", "Afghanistan, Afghanis");
        public static readonly CurrencyCodeEnum ALBANIA_LEKE = new CurrencyCodeEnum("ALL", "Albania, Leke");
        public static readonly CurrencyCodeEnum ARMENIA_DRAMS = new CurrencyCodeEnum("AMD", "Armenia, Drams");
        public static readonly CurrencyCodeEnum NETHERLANDS_ANTILLES_GUILDERS_ALSO_CALLED_FLORINS = new CurrencyCodeEnum("ANG", "Netherlands Antilles, Guilders (also called Florins)");
        public static readonly CurrencyCodeEnum ANGOLA_KWANZA = new CurrencyCodeEnum("AOA", "Angola, Kwanza");
        public static readonly CurrencyCodeEnum ARGENTINA_PESOS = new CurrencyCodeEnum("ARS", "Argentina, Pesos");
        public static readonly CurrencyCodeEnum AUSTRALIA_DOLLARS = new CurrencyCodeEnum("AUD", "Australia, Dollars");
        public static readonly CurrencyCodeEnum ARUBA_GUILDERS_ALSO_CALLED_FLORINS = new CurrencyCodeEnum("AWG", "Aruba, Guilders (also called Florins)");
        public static readonly CurrencyCodeEnum AZERBAIJAN_NEW_MANATS = new CurrencyCodeEnum("AZN", "Azerbaijan, New Manats");
        public static readonly CurrencyCodeEnum BOSNIA_AND_HERZEGOVINA_CONVERTIBLE_MARKA = new CurrencyCodeEnum("BAM", "Bosnia and Herzegovina, Convertible Marka");
        public static readonly CurrencyCodeEnum BARBADOS_DOLLARS = new CurrencyCodeEnum("BBD", "Barbados, Dollars");
        public static readonly CurrencyCodeEnum BANGLADESH_TAKA = new CurrencyCodeEnum("BDT", "Bangladesh, Taka");
        public static readonly CurrencyCodeEnum BULGARIA_LEVA = new CurrencyCodeEnum("BGN", "Bulgaria, Leva");
        public static readonly CurrencyCodeEnum BAHRAIN_DINARS = new CurrencyCodeEnum("BHD", "Bahrain, Dinars");
        public static readonly CurrencyCodeEnum BURUNDI_FRANCS = new CurrencyCodeEnum("BIF", "Burundi, Francs");
        public static readonly CurrencyCodeEnum BERMUDA_DOLLARS = new CurrencyCodeEnum("BMD", "Bermuda, Dollars");
        public static readonly CurrencyCodeEnum BRUNEI_DARUSSALAM_DOLLARS = new CurrencyCodeEnum("BND", "Brunei Darussalam, Dollars");
        public static readonly CurrencyCodeEnum BOLIVIA_BOLIVIANOS = new CurrencyCodeEnum("BOB", "Bolivia, Bolivianos");
        public static readonly CurrencyCodeEnum BRAZIL_BRAZIL_REAL = new CurrencyCodeEnum("BRL", "Brazil, Brazil Real");
        public static readonly CurrencyCodeEnum BAHAMAS_DOLLARS = new CurrencyCodeEnum("BSD", "Bahamas, Dollars");
        public static readonly CurrencyCodeEnum BHUTAN_NGULTRUM = new CurrencyCodeEnum("BTN", "Bhutan, Ngultrum");
        public static readonly CurrencyCodeEnum BOTSWANA_PULAS = new CurrencyCodeEnum("BWP", "Botswana, Pulas");
        public static readonly CurrencyCodeEnum BELARUS_RUBLES = new CurrencyCodeEnum("BYR", "Belarus, Rubles");
        public static readonly CurrencyCodeEnum BELIZE_DOLLARS = new CurrencyCodeEnum("BZD", "Belize, Dollars");
        public static readonly CurrencyCodeEnum CANADA_DOLLARS = new CurrencyCodeEnum("CAD", "Canada, Dollars");
        public static readonly CurrencyCodeEnum CONGOKINSHASA_CONGOLESE_FRANCS = new CurrencyCodeEnum("CDF", "Congo/Kinshasa, Congolese Francs");
        public static readonly CurrencyCodeEnum SWITZERLAND_FRANCS = new CurrencyCodeEnum("CHF", "Switzerland, Francs");
        public static readonly CurrencyCodeEnum CHILE_PESOS = new CurrencyCodeEnum("CLP", "Chile, Pesos");
        public static readonly CurrencyCodeEnum CHINA_YUAN_RENMINBI = new CurrencyCodeEnum("CNY", "China, Yuan Renminbi");
        public static readonly CurrencyCodeEnum COLOMBIA_PESOS = new CurrencyCodeEnum("COP", "Colombia, Pesos");
        public static readonly CurrencyCodeEnum COSTA_RICA_COLONES = new CurrencyCodeEnum("CRC", "Costa Rica, Colones");
        public static readonly CurrencyCodeEnum CUBA_PESOS = new CurrencyCodeEnum("CUP", "Cuba, Pesos");
        public static readonly CurrencyCodeEnum CAPE_VERDE_ESCUDOS = new CurrencyCodeEnum("CVE", "Cape Verde, Escudos");
        public static readonly CurrencyCodeEnum CYPRUS_POUNDS_EXPIRES_2008JAN31 = new CurrencyCodeEnum("CYP", "Cyprus, Pounds (expires 2008-Jan-31)");
        public static readonly CurrencyCodeEnum CZECH_REPUBLIC_KORUNY = new CurrencyCodeEnum("CZK", "Czech Republic, Koruny");
        public static readonly CurrencyCodeEnum DJIBOUTI_FRANCS = new CurrencyCodeEnum("DJF", "Djibouti, Francs");
        public static readonly CurrencyCodeEnum DENMARK_KRONER = new CurrencyCodeEnum("DKK", "Denmark, Kroner");
        public static readonly CurrencyCodeEnum DOMINICAN_REPUBLIC_PESOS = new CurrencyCodeEnum("DOP", "Dominican Republic, Pesos");
        public static readonly CurrencyCodeEnum ALGERIA_ALGERIA_DINARS = new CurrencyCodeEnum("DZD", "Algeria, Algeria Dinars");
        public static readonly CurrencyCodeEnum ESTONIA_KROONI = new CurrencyCodeEnum("EEK", "Estonia, Krooni");
        public static readonly CurrencyCodeEnum EGYPT_POUNDS = new CurrencyCodeEnum("EGP", "Egypt, Pounds");
        public static readonly CurrencyCodeEnum ERITREA_NAKFA = new CurrencyCodeEnum("ERN", "Eritrea, Nakfa");
        public static readonly CurrencyCodeEnum ETHIOPIA_BIRR = new CurrencyCodeEnum("ETB", "Ethiopia, Birr");
        public static readonly CurrencyCodeEnum EURO_MEMBER_COUNTRIES_EURO = new CurrencyCodeEnum("EUR", "Euro Member Countries, Euro");
        public static readonly CurrencyCodeEnum FIJI_DOLLARS = new CurrencyCodeEnum("FJD", "Fiji, Dollars");
        public static readonly CurrencyCodeEnum FALKLAND_ISLANDS_MALVINAS_POUNDS = new CurrencyCodeEnum("FKP", "Falkland Islands (Malvinas), Pounds");
        public static readonly CurrencyCodeEnum UNITED_KINGDOM_POUNDS = new CurrencyCodeEnum("GBP", "United Kingdom, Pounds");
        public static readonly CurrencyCodeEnum GEORGIA_LARI = new CurrencyCodeEnum("GEL", "Georgia, Lari");
        public static readonly CurrencyCodeEnum GUERNSEY_POUNDS = new CurrencyCodeEnum("GGP", "Guernsey, Pounds");
        public static readonly CurrencyCodeEnum GHANA_CEDIS = new CurrencyCodeEnum("GHS", "Ghana, Cedis");
        public static readonly CurrencyCodeEnum GIBRALTAR_POUNDS = new CurrencyCodeEnum("GIP", "Gibraltar, Pounds");
        public static readonly CurrencyCodeEnum GAMBIA_DALASI = new CurrencyCodeEnum("GMD", "Gambia, Dalasi");
        public static readonly CurrencyCodeEnum GUINEA_FRANCS = new CurrencyCodeEnum("GNF", "Guinea, Francs");
        public static readonly CurrencyCodeEnum GUATEMALA_QUETZALES = new CurrencyCodeEnum("GTQ", "Guatemala, Quetzales");
        public static readonly CurrencyCodeEnum GUYANA_DOLLARS = new CurrencyCodeEnum("GYD", "Guyana, Dollars");
        public static readonly CurrencyCodeEnum HONG_KONG_DOLLARS = new CurrencyCodeEnum("HKD", "Hong Kong, Dollars");
        public static readonly CurrencyCodeEnum HONDURAS_LEMPIRAS = new CurrencyCodeEnum("HNL", "Honduras, Lempiras");
        public static readonly CurrencyCodeEnum CROATIA_KUNA = new CurrencyCodeEnum("HRK", "Croatia, Kuna");
        public static readonly CurrencyCodeEnum HAITI_GOURDES = new CurrencyCodeEnum("HTG", "Haiti, Gourdes");
        public static readonly CurrencyCodeEnum HUNGARY_FORINT = new CurrencyCodeEnum("HUF", "Hungary, Forint");
        public static readonly CurrencyCodeEnum INDONESIA_RUPIAHS = new CurrencyCodeEnum("IDR", "Indonesia, Rupiahs");
        public static readonly CurrencyCodeEnum ISRAEL_NEW_SHEKELS = new CurrencyCodeEnum("ILS", "Israel, New Shekels");
        public static readonly CurrencyCodeEnum ISLE_OF_MAN_POUNDS = new CurrencyCodeEnum("IMP", "Isle of Man, Pounds");
        public static readonly CurrencyCodeEnum INDIA_RUPEES = new CurrencyCodeEnum("INR", "India, Rupees");
        public static readonly CurrencyCodeEnum IRAQ_DINARS = new CurrencyCodeEnum("IQD", "Iraq, Dinars");
        public static readonly CurrencyCodeEnum IRAN_RIALS = new CurrencyCodeEnum("IRR", "Iran, Rials");
        public static readonly CurrencyCodeEnum ICELAND_KRONUR = new CurrencyCodeEnum("ISK", "Iceland, Kronur");
        public static readonly CurrencyCodeEnum JERSEY_POUNDS = new CurrencyCodeEnum("JEP", "Jersey, Pounds");
        public static readonly CurrencyCodeEnum JAMAICA_DOLLARS = new CurrencyCodeEnum("JMD", "Jamaica, Dollars");
        public static readonly CurrencyCodeEnum JORDAN_DINARS = new CurrencyCodeEnum("JOD", "Jordan, Dinars");
        public static readonly CurrencyCodeEnum JAPAN_YEN = new CurrencyCodeEnum("JPY", "Japan, Yen");
        public static readonly CurrencyCodeEnum KENYA_SHILLINGS = new CurrencyCodeEnum("KES", "Kenya, Shillings");
        public static readonly CurrencyCodeEnum KYRGYZSTAN_SOMS = new CurrencyCodeEnum("KGS", "Kyrgyzstan, Soms");
        public static readonly CurrencyCodeEnum CAMBODIA_RIELS = new CurrencyCodeEnum("KHR", "Cambodia, Riels");
        public static readonly CurrencyCodeEnum COMOROS_FRANCS = new CurrencyCodeEnum("KMF", "Comoros, Francs");
        public static readonly CurrencyCodeEnum KOREA_NORTH_WON = new CurrencyCodeEnum("KPW", "Korea (North), Won");
        public static readonly CurrencyCodeEnum KOREA_SOUTH_WON = new CurrencyCodeEnum("KRW", "Korea (South), Won");
        public static readonly CurrencyCodeEnum KUWAIT_DINARS = new CurrencyCodeEnum("KWD", "Kuwait, Dinars");
        public static readonly CurrencyCodeEnum CAYMAN_ISLANDS_DOLLARS = new CurrencyCodeEnum("KYD", "Cayman Islands, Dollars");
        public static readonly CurrencyCodeEnum KAZAKHSTAN_TENGE = new CurrencyCodeEnum("KZT", "Kazakhstan, Tenge");
        public static readonly CurrencyCodeEnum LAOS_KIPS = new CurrencyCodeEnum("LAK", "Laos, Kips");
        public static readonly CurrencyCodeEnum LEBANON_POUNDS = new CurrencyCodeEnum("LBP", "Lebanon, Pounds");
        public static readonly CurrencyCodeEnum SRI_LANKA_RUPEES = new CurrencyCodeEnum("LKR", "Sri Lanka, Rupees");
        public static readonly CurrencyCodeEnum LIBERIA_DOLLARS = new CurrencyCodeEnum("LRD", "Liberia, Dollars");
        public static readonly CurrencyCodeEnum LESOTHO_MALOTI = new CurrencyCodeEnum("LSL", "Lesotho, Maloti");
        public static readonly CurrencyCodeEnum LITHUANIA_LITAI = new CurrencyCodeEnum("LTL", "Lithuania, Litai");
        public static readonly CurrencyCodeEnum LATVIA_LATI = new CurrencyCodeEnum("LVL", "Latvia, Lati");
        public static readonly CurrencyCodeEnum LIBYA_DINARS = new CurrencyCodeEnum("LYD", "Libya, Dinars");
        public static readonly CurrencyCodeEnum MOROCCO_DIRHAMS = new CurrencyCodeEnum("MAD", "Morocco, Dirhams");
        public static readonly CurrencyCodeEnum MOLDOVA_LEI = new CurrencyCodeEnum("MDL", "Moldova, Lei");
        public static readonly CurrencyCodeEnum MADAGASCAR_ARIARY = new CurrencyCodeEnum("MGA", "Madagascar, Ariary");
        public static readonly CurrencyCodeEnum MACEDONIA_DENARS = new CurrencyCodeEnum("MKD", "Macedonia, Denars");
        public static readonly CurrencyCodeEnum MYANMAR_BURMA_KYATS = new CurrencyCodeEnum("MMK", "Myanmar (Burma), Kyats");
        public static readonly CurrencyCodeEnum MONGOLIA_TUGRIKS = new CurrencyCodeEnum("MNT", "Mongolia, Tugriks");
        public static readonly CurrencyCodeEnum MACAU_PATACAS = new CurrencyCodeEnum("MOP", "Macau, Patacas");
        public static readonly CurrencyCodeEnum MAURITANIA_OUGUIYAS = new CurrencyCodeEnum("MRO", "Mauritania, Ouguiyas");
        public static readonly CurrencyCodeEnum MALTA_LIRI_EXPIRES_2008JAN31 = new CurrencyCodeEnum("MTL", "Malta, Liri (expires 2008-Jan-31)");
        public static readonly CurrencyCodeEnum MAURITIUS_RUPEES = new CurrencyCodeEnum("MUR", "Mauritius, Rupees");
        public static readonly CurrencyCodeEnum MALDIVES_MALDIVE_ISLANDS_RUFIYAA = new CurrencyCodeEnum("MVR", "Maldives (Maldive Islands), Rufiyaa");
        public static readonly CurrencyCodeEnum MALAWI_KWACHAS = new CurrencyCodeEnum("MWK", "Malawi, Kwachas");
        public static readonly CurrencyCodeEnum MEXICO_PESOS = new CurrencyCodeEnum("MXN", "Mexico, Pesos");
        public static readonly CurrencyCodeEnum MALAYSIA_RINGGITS = new CurrencyCodeEnum("MYR", "Malaysia, Ringgits");
        public static readonly CurrencyCodeEnum MOZAMBIQUE_METICAIS = new CurrencyCodeEnum("MZN", "Mozambique, Meticais");
        public static readonly CurrencyCodeEnum NAMIBIA_DOLLARS = new CurrencyCodeEnum("NAD", "Namibia, Dollars");
        public static readonly CurrencyCodeEnum NIGERIA_NAIRAS = new CurrencyCodeEnum("NGN", "Nigeria, Nairas");
        public static readonly CurrencyCodeEnum NICARAGUA_CORDOBAS = new CurrencyCodeEnum("NIO", "Nicaragua, Cordobas");
        public static readonly CurrencyCodeEnum NORWAY_KRONE = new CurrencyCodeEnum("NOK", "Norway, Krone");
        public static readonly CurrencyCodeEnum NEPAL_NEPAL_RUPEES = new CurrencyCodeEnum("NPR", "Nepal, Nepal Rupees");
        public static readonly CurrencyCodeEnum NEW_ZEALAND_DOLLARS = new CurrencyCodeEnum("NZD", "New Zealand, Dollars");
        public static readonly CurrencyCodeEnum OMAN_RIALS = new CurrencyCodeEnum("OMR", "Oman, Rials");
        public static readonly CurrencyCodeEnum PANAMA_BALBOA = new CurrencyCodeEnum("PAB", "Panama, Balboa");
        public static readonly CurrencyCodeEnum PERU_NUEVOS_SOLES = new CurrencyCodeEnum("PEN", "Peru, Nuevos Soles");
        public static readonly CurrencyCodeEnum PAPUA_NEW_GUINEA_KINA = new CurrencyCodeEnum("PGK", "Papua New Guinea, Kina");
        public static readonly CurrencyCodeEnum PHILIPPINES_PESOS = new CurrencyCodeEnum("PHP", "Philippines, Pesos");
        public static readonly CurrencyCodeEnum PAKISTAN_RUPEES = new CurrencyCodeEnum("PKR", "Pakistan, Rupees");
        public static readonly CurrencyCodeEnum POLAND_ZLOTYCH = new CurrencyCodeEnum("PLN", "Poland, Zlotych");
        public static readonly CurrencyCodeEnum PARAGUAY_GUARANI = new CurrencyCodeEnum("PYG", "Paraguay, Guarani");
        public static readonly CurrencyCodeEnum QATAR_RIALS = new CurrencyCodeEnum("QAR", "Qatar, Rials");
        public static readonly CurrencyCodeEnum ROMANIA_NEW_LEI = new CurrencyCodeEnum("RON", "Romania, New Lei");
        public static readonly CurrencyCodeEnum SERBIA_DINARS = new CurrencyCodeEnum("RSD", "Serbia, Dinars");
        public static readonly CurrencyCodeEnum RUSSIA_RUBLES = new CurrencyCodeEnum("RUB", "Russia, Rubles");
        public static readonly CurrencyCodeEnum RWANDA_RWANDA_FRANCS = new CurrencyCodeEnum("RWF", "Rwanda, Rwanda Francs");
        public static readonly CurrencyCodeEnum SAUDI_ARABIA_RIYALS = new CurrencyCodeEnum("SAR", "Saudi Arabia, Riyals");
        public static readonly CurrencyCodeEnum SOLOMON_ISLANDS_DOLLARS = new CurrencyCodeEnum("SBD", "Solomon Islands, Dollars");
        public static readonly CurrencyCodeEnum SEYCHELLES_RUPEES = new CurrencyCodeEnum("SCR", "Seychelles, Rupees");
        public static readonly CurrencyCodeEnum SUDAN_POUNDS = new CurrencyCodeEnum("SDG", "Sudan, Pounds");
        public static readonly CurrencyCodeEnum SWEDEN_KRONOR = new CurrencyCodeEnum("SEK", "Sweden, Kronor");
        public static readonly CurrencyCodeEnum SINGAPORE_DOLLARS = new CurrencyCodeEnum("SGD", "Singapore, Dollars");
        public static readonly CurrencyCodeEnum SAINT_HELENA_POUNDS = new CurrencyCodeEnum("SHP", "Saint Helena, Pounds");
        public static readonly CurrencyCodeEnum SIERRA_LEONE_LEONES = new CurrencyCodeEnum("SLL", "Sierra Leone, Leones");
        public static readonly CurrencyCodeEnum SOMALIA_SHILLINGS = new CurrencyCodeEnum("SOS", "Somalia, Shillings");
        public static readonly CurrencyCodeEnum SEBORGA_LUIGINI = new CurrencyCodeEnum("SPL", "Seborga, Luigini");
        public static readonly CurrencyCodeEnum SURINAME_DOLLARS = new CurrencyCodeEnum("SRD", "Suriname, Dollars");
        public static readonly CurrencyCodeEnum SAO_TOME_AND_PRINCIPE_DOBRAS = new CurrencyCodeEnum("STD", "Sao Tome and Principe, Dobras");
        public static readonly CurrencyCodeEnum EL_SALVADOR_COLONES = new CurrencyCodeEnum("SVC", "El Salvador, Colones");
        public static readonly CurrencyCodeEnum SYRIA_POUNDS = new CurrencyCodeEnum("SYP", "Syria, Pounds");
        public static readonly CurrencyCodeEnum SWAZILAND_EMALANGENI = new CurrencyCodeEnum("SZL", "Swaziland, Emalangeni");
        public static readonly CurrencyCodeEnum THAILAND_BAHT = new CurrencyCodeEnum("THB", "Thailand, Baht");
        public static readonly CurrencyCodeEnum TAJIKISTAN_SOMONI = new CurrencyCodeEnum("TJS", "Tajikistan, Somoni");
        public static readonly CurrencyCodeEnum TURKMENISTAN_MANATS = new CurrencyCodeEnum("TMM", "Turkmenistan, Manats");
        public static readonly CurrencyCodeEnum TUNISIA_DINARS = new CurrencyCodeEnum("TND", "Tunisia, Dinars");
        public static readonly CurrencyCodeEnum TONGA_PAANGA = new CurrencyCodeEnum("TOP", "Tonga, Pa'anga");
        public static readonly CurrencyCodeEnum TURKEY_NEW_LIRA = new CurrencyCodeEnum("TRY", "Turkey, New Lira");
        public static readonly CurrencyCodeEnum TRINIDAD_AND_TOBAGO_DOLLARS = new CurrencyCodeEnum("TTD", "Trinidad and Tobago, Dollars");
        public static readonly CurrencyCodeEnum TUVALU_TUVALU_DOLLARS = new CurrencyCodeEnum("TVD", "Tuvalu, Tuvalu Dollars");
        public static readonly CurrencyCodeEnum TAIWAN_NEW_DOLLARS = new CurrencyCodeEnum("TWD", "Taiwan, New Dollars");
        public static readonly CurrencyCodeEnum TANZANIA_SHILLINGS = new CurrencyCodeEnum("TZS", "Tanzania, Shillings");
        public static readonly CurrencyCodeEnum UKRAINE_HRYVNIA = new CurrencyCodeEnum("UAH", "Ukraine, Hryvnia");
        public static readonly CurrencyCodeEnum UGANDA_SHILLINGS = new CurrencyCodeEnum("UGX", "Uganda, Shillings");
        public static readonly CurrencyCodeEnum UNITED_STATES_OF_AMERICA_DOLLARS = new CurrencyCodeEnum("USD", "United States of America, Dollars");
        public static readonly CurrencyCodeEnum URUGUAY_PESOS = new CurrencyCodeEnum("UYU", "Uruguay, Pesos");
        public static readonly CurrencyCodeEnum UZBEKISTAN_SUMS = new CurrencyCodeEnum("UZS", "Uzbekistan, Sums");
        public static readonly CurrencyCodeEnum VENEZUELA_BOLIVARES_EXPIRES_2008JUN30 = new CurrencyCodeEnum("VEB", "Venezuela, Bolivares (expires 2008-Jun-30)");
        public static readonly CurrencyCodeEnum VENEZUELA_BOLIVARES_FUERTES = new CurrencyCodeEnum("VEF", "Venezuela, Bolivares Fuertes");
        public static readonly CurrencyCodeEnum VIET_NAM_DONG = new CurrencyCodeEnum("VND", "Viet Nam, Dong");
        public static readonly CurrencyCodeEnum VANUATU_VATU = new CurrencyCodeEnum("VUV", "Vanuatu, Vatu");
        public static readonly CurrencyCodeEnum SAMOA_TALA = new CurrencyCodeEnum("WST", "Samoa, Tala");
        public static readonly CurrencyCodeEnum COMMUNAUTE_FINANCIERE_AFRICAINE_BEAC_FRANCS = new CurrencyCodeEnum("XAF", "Communaute Financiere Africaine BEAC, Francs");
        public static readonly CurrencyCodeEnum SILVER_OUNCES = new CurrencyCodeEnum("XAG", "Silver, Ounces");
        public static readonly CurrencyCodeEnum GOLD_OUNCES = new CurrencyCodeEnum("XAU", "Gold, Ounces");
        public static readonly CurrencyCodeEnum EAST_CARIBBEAN_DOLLARS = new CurrencyCodeEnum("XCD", "East Caribbean Dollars");
        public static readonly CurrencyCodeEnum INTERNATIONAL_MONETARY_FUND_IMF_SPECIAL_DRAWING_RIGHTS = new CurrencyCodeEnum("XDR", "International Monetary Fund (IMF) Special Drawing Rights");
        public static readonly CurrencyCodeEnum COMMUNAUTE_FINANCIERE_AFRICAINE_BCEAO_FRANCS = new CurrencyCodeEnum("XOF", "Communaute Financiere Africaine BCEAO, Francs");
        public static readonly CurrencyCodeEnum PALLADIUM_OUNCES = new CurrencyCodeEnum("XPD", "Palladium Ounces");
        public static readonly CurrencyCodeEnum COMPTOIRS_FRANCAIS_DU_PACIFIQUE_FRANCS = new CurrencyCodeEnum("XPF", "Comptoirs Francais du Pacifique Francs");
        public static readonly CurrencyCodeEnum PLATINUM_OUNCES = new CurrencyCodeEnum("XPT", "Platinum, Ounces");
        public static readonly CurrencyCodeEnum YEMEN_RIALS = new CurrencyCodeEnum("YER", "Yemen, Rials");
        public static readonly CurrencyCodeEnum SOUTH_AFRICA_RAND = new CurrencyCodeEnum("ZAR", "South Africa, Rand");
        public static readonly CurrencyCodeEnum ZAMBIA_KWACHA = new CurrencyCodeEnum("ZMK", "Zambia, Kwacha");
        public static readonly CurrencyCodeEnum ZIMBABWE_ZIMBABWE_DOLLARS = new CurrencyCodeEnum("ZWD", "Zimbabwe, Zimbabwe Dollars");

        public static CurrencyCodeEnum GetInstance(Object value) {
            if (value is String) {
                foreach (CurrencyCodeEnum t in OPTIONS) {
                    if (t.Value.Equals(value)) {
                        return t;
                    }
                }
            }

            return UNSET;
        }

        private CurrencyCodeEnum() { }

        private CurrencyCodeEnum(String code, String name) {
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
                info.SetType(typeof(CurrencyCodeEnum_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(CurrencyCodeEnum_UNSET));
            } else if (this.Equals(UNITED_ARAB_EMIRATES_DIRHAMS)) {
                info.SetType(typeof(CurrencyCodeEnum_UNITED_ARAB_EMIRATES_DIRHAMS));
            } else if (this.Equals(AFGHANISTAN_AFGHANIS)) {
                info.SetType(typeof(CurrencyCodeEnum_AFGHANISTAN_AFGHANIS));
            } else if (this.Equals(ALBANIA_LEKE)) {
                info.SetType(typeof(CurrencyCodeEnum_ALBANIA_LEKE));
            } else if (this.Equals(ARMENIA_DRAMS)) {
                info.SetType(typeof(CurrencyCodeEnum_ARMENIA_DRAMS));
            } else if (this.Equals(NETHERLANDS_ANTILLES_GUILDERS_ALSO_CALLED_FLORINS)) {
                info.SetType(typeof(CurrencyCodeEnum_NETHERLANDS_ANTILLES_GUILDERS_ALSO_CALLED_FLORINS));
            } else if (this.Equals(ANGOLA_KWANZA)) {
                info.SetType(typeof(CurrencyCodeEnum_ANGOLA_KWANZA));
            } else if (this.Equals(ARGENTINA_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_ARGENTINA_PESOS));
            } else if (this.Equals(AUSTRALIA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_AUSTRALIA_DOLLARS));
            } else if (this.Equals(ARUBA_GUILDERS_ALSO_CALLED_FLORINS)) {
                info.SetType(typeof(CurrencyCodeEnum_ARUBA_GUILDERS_ALSO_CALLED_FLORINS));
            } else if (this.Equals(AZERBAIJAN_NEW_MANATS)) {
                info.SetType(typeof(CurrencyCodeEnum_AZERBAIJAN_NEW_MANATS));
            } else if (this.Equals(BOSNIA_AND_HERZEGOVINA_CONVERTIBLE_MARKA)) {
                info.SetType(typeof(CurrencyCodeEnum_BOSNIA_AND_HERZEGOVINA_CONVERTIBLE_MARKA));
            } else if (this.Equals(BARBADOS_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BARBADOS_DOLLARS));
            } else if (this.Equals(BANGLADESH_TAKA)) {
                info.SetType(typeof(CurrencyCodeEnum_BANGLADESH_TAKA));
            } else if (this.Equals(BULGARIA_LEVA)) {
                info.SetType(typeof(CurrencyCodeEnum_BULGARIA_LEVA));
            } else if (this.Equals(BAHRAIN_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BAHRAIN_DINARS));
            } else if (this.Equals(BURUNDI_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_BURUNDI_FRANCS));
            } else if (this.Equals(BERMUDA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BERMUDA_DOLLARS));
            } else if (this.Equals(BRUNEI_DARUSSALAM_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BRUNEI_DARUSSALAM_DOLLARS));
            } else if (this.Equals(BOLIVIA_BOLIVIANOS)) {
                info.SetType(typeof(CurrencyCodeEnum_BOLIVIA_BOLIVIANOS));
            } else if (this.Equals(BRAZIL_BRAZIL_REAL)) {
                info.SetType(typeof(CurrencyCodeEnum_BRAZIL_BRAZIL_REAL));
            } else if (this.Equals(BAHAMAS_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BAHAMAS_DOLLARS));
            } else if (this.Equals(BHUTAN_NGULTRUM)) {
                info.SetType(typeof(CurrencyCodeEnum_BHUTAN_NGULTRUM));
            } else if (this.Equals(BOTSWANA_PULAS)) {
                info.SetType(typeof(CurrencyCodeEnum_BOTSWANA_PULAS));
            } else if (this.Equals(BELARUS_RUBLES)) {
                info.SetType(typeof(CurrencyCodeEnum_BELARUS_RUBLES));
            } else if (this.Equals(BELIZE_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_BELIZE_DOLLARS));
            } else if (this.Equals(CANADA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_CANADA_DOLLARS));
            } else if (this.Equals(CONGOKINSHASA_CONGOLESE_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_CONGOKINSHASA_CONGOLESE_FRANCS));
            } else if (this.Equals(SWITZERLAND_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_SWITZERLAND_FRANCS));
            } else if (this.Equals(CHILE_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_CHILE_PESOS));
            } else if (this.Equals(CHINA_YUAN_RENMINBI)) {
                info.SetType(typeof(CurrencyCodeEnum_CHINA_YUAN_RENMINBI));
            } else if (this.Equals(COLOMBIA_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_COLOMBIA_PESOS));
            } else if (this.Equals(COSTA_RICA_COLONES)) {
                info.SetType(typeof(CurrencyCodeEnum_COSTA_RICA_COLONES));
            } else if (this.Equals(CUBA_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_CUBA_PESOS));
            } else if (this.Equals(CAPE_VERDE_ESCUDOS)) {
                info.SetType(typeof(CurrencyCodeEnum_CAPE_VERDE_ESCUDOS));
            } else if (this.Equals(CYPRUS_POUNDS_EXPIRES_2008JAN31)) {
                info.SetType(typeof(CurrencyCodeEnum_CYPRUS_POUNDS_EXPIRES_2008JAN31));
            } else if (this.Equals(CZECH_REPUBLIC_KORUNY)) {
                info.SetType(typeof(CurrencyCodeEnum_CZECH_REPUBLIC_KORUNY));
            } else if (this.Equals(DJIBOUTI_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_DJIBOUTI_FRANCS));
            } else if (this.Equals(DENMARK_KRONER)) {
                info.SetType(typeof(CurrencyCodeEnum_DENMARK_KRONER));
            } else if (this.Equals(DOMINICAN_REPUBLIC_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_DOMINICAN_REPUBLIC_PESOS));
            } else if (this.Equals(ALGERIA_ALGERIA_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_ALGERIA_ALGERIA_DINARS));
            } else if (this.Equals(ESTONIA_KROONI)) {
                info.SetType(typeof(CurrencyCodeEnum_ESTONIA_KROONI));
            } else if (this.Equals(EGYPT_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_EGYPT_POUNDS));
            } else if (this.Equals(ERITREA_NAKFA)) {
                info.SetType(typeof(CurrencyCodeEnum_ERITREA_NAKFA));
            } else if (this.Equals(ETHIOPIA_BIRR)) {
                info.SetType(typeof(CurrencyCodeEnum_ETHIOPIA_BIRR));
            } else if (this.Equals(EURO_MEMBER_COUNTRIES_EURO)) {
                info.SetType(typeof(CurrencyCodeEnum_EURO_MEMBER_COUNTRIES_EURO));
            } else if (this.Equals(FIJI_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_FIJI_DOLLARS));
            } else if (this.Equals(FALKLAND_ISLANDS_MALVINAS_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_FALKLAND_ISLANDS_MALVINAS_POUNDS));
            } else if (this.Equals(UNITED_KINGDOM_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_UNITED_KINGDOM_POUNDS));
            } else if (this.Equals(GEORGIA_LARI)) {
                info.SetType(typeof(CurrencyCodeEnum_GEORGIA_LARI));
            } else if (this.Equals(GUERNSEY_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_GUERNSEY_POUNDS));
            } else if (this.Equals(GHANA_CEDIS)) {
                info.SetType(typeof(CurrencyCodeEnum_GHANA_CEDIS));
            } else if (this.Equals(GIBRALTAR_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_GIBRALTAR_POUNDS));
            } else if (this.Equals(GAMBIA_DALASI)) {
                info.SetType(typeof(CurrencyCodeEnum_GAMBIA_DALASI));
            } else if (this.Equals(GUINEA_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_GUINEA_FRANCS));
            } else if (this.Equals(GUATEMALA_QUETZALES)) {
                info.SetType(typeof(CurrencyCodeEnum_GUATEMALA_QUETZALES));
            } else if (this.Equals(GUYANA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_GUYANA_DOLLARS));
            } else if (this.Equals(HONG_KONG_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_HONG_KONG_DOLLARS));
            } else if (this.Equals(HONDURAS_LEMPIRAS)) {
                info.SetType(typeof(CurrencyCodeEnum_HONDURAS_LEMPIRAS));
            } else if (this.Equals(CROATIA_KUNA)) {
                info.SetType(typeof(CurrencyCodeEnum_CROATIA_KUNA));
            } else if (this.Equals(HAITI_GOURDES)) {
                info.SetType(typeof(CurrencyCodeEnum_HAITI_GOURDES));
            } else if (this.Equals(HUNGARY_FORINT)) {
                info.SetType(typeof(CurrencyCodeEnum_HUNGARY_FORINT));
            } else if (this.Equals(INDONESIA_RUPIAHS)) {
                info.SetType(typeof(CurrencyCodeEnum_INDONESIA_RUPIAHS));
            } else if (this.Equals(ISRAEL_NEW_SHEKELS)) {
                info.SetType(typeof(CurrencyCodeEnum_ISRAEL_NEW_SHEKELS));
            } else if (this.Equals(ISLE_OF_MAN_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_ISLE_OF_MAN_POUNDS));
            } else if (this.Equals(INDIA_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_INDIA_RUPEES));
            } else if (this.Equals(IRAQ_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_IRAQ_DINARS));
            } else if (this.Equals(IRAN_RIALS)) {
                info.SetType(typeof(CurrencyCodeEnum_IRAN_RIALS));
            } else if (this.Equals(ICELAND_KRONUR)) {
                info.SetType(typeof(CurrencyCodeEnum_ICELAND_KRONUR));
            } else if (this.Equals(JERSEY_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_JERSEY_POUNDS));
            } else if (this.Equals(JAMAICA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_JAMAICA_DOLLARS));
            } else if (this.Equals(JORDAN_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_JORDAN_DINARS));
            } else if (this.Equals(JAPAN_YEN)) {
                info.SetType(typeof(CurrencyCodeEnum_JAPAN_YEN));
            } else if (this.Equals(KENYA_SHILLINGS)) {
                info.SetType(typeof(CurrencyCodeEnum_KENYA_SHILLINGS));
            } else if (this.Equals(KYRGYZSTAN_SOMS)) {
                info.SetType(typeof(CurrencyCodeEnum_KYRGYZSTAN_SOMS));
            } else if (this.Equals(CAMBODIA_RIELS)) {
                info.SetType(typeof(CurrencyCodeEnum_CAMBODIA_RIELS));
            } else if (this.Equals(COMOROS_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_COMOROS_FRANCS));
            } else if (this.Equals(KOREA_NORTH_WON)) {
                info.SetType(typeof(CurrencyCodeEnum_KOREA_NORTH_WON));
            } else if (this.Equals(KOREA_SOUTH_WON)) {
                info.SetType(typeof(CurrencyCodeEnum_KOREA_SOUTH_WON));
            } else if (this.Equals(KUWAIT_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_KUWAIT_DINARS));
            } else if (this.Equals(CAYMAN_ISLANDS_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_CAYMAN_ISLANDS_DOLLARS));
            } else if (this.Equals(KAZAKHSTAN_TENGE)) {
                info.SetType(typeof(CurrencyCodeEnum_KAZAKHSTAN_TENGE));
            } else if (this.Equals(LAOS_KIPS)) {
                info.SetType(typeof(CurrencyCodeEnum_LAOS_KIPS));
            } else if (this.Equals(LEBANON_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_LEBANON_POUNDS));
            } else if (this.Equals(SRI_LANKA_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_SRI_LANKA_RUPEES));
            } else if (this.Equals(LIBERIA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_LIBERIA_DOLLARS));
            } else if (this.Equals(LESOTHO_MALOTI)) {
                info.SetType(typeof(CurrencyCodeEnum_LESOTHO_MALOTI));
            } else if (this.Equals(LITHUANIA_LITAI)) {
                info.SetType(typeof(CurrencyCodeEnum_LITHUANIA_LITAI));
            } else if (this.Equals(LATVIA_LATI)) {
                info.SetType(typeof(CurrencyCodeEnum_LATVIA_LATI));
            } else if (this.Equals(LIBYA_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_LIBYA_DINARS));
            } else if (this.Equals(MOROCCO_DIRHAMS)) {
                info.SetType(typeof(CurrencyCodeEnum_MOROCCO_DIRHAMS));
            } else if (this.Equals(MOLDOVA_LEI)) {
                info.SetType(typeof(CurrencyCodeEnum_MOLDOVA_LEI));
            } else if (this.Equals(MADAGASCAR_ARIARY)) {
                info.SetType(typeof(CurrencyCodeEnum_MADAGASCAR_ARIARY));
            } else if (this.Equals(MACEDONIA_DENARS)) {
                info.SetType(typeof(CurrencyCodeEnum_MACEDONIA_DENARS));
            } else if (this.Equals(MYANMAR_BURMA_KYATS)) {
                info.SetType(typeof(CurrencyCodeEnum_MYANMAR_BURMA_KYATS));
            } else if (this.Equals(MONGOLIA_TUGRIKS)) {
                info.SetType(typeof(CurrencyCodeEnum_MONGOLIA_TUGRIKS));
            } else if (this.Equals(MACAU_PATACAS)) {
                info.SetType(typeof(CurrencyCodeEnum_MACAU_PATACAS));
            } else if (this.Equals(MAURITANIA_OUGUIYAS)) {
                info.SetType(typeof(CurrencyCodeEnum_MAURITANIA_OUGUIYAS));
            } else if (this.Equals(MALTA_LIRI_EXPIRES_2008JAN31)) {
                info.SetType(typeof(CurrencyCodeEnum_MALTA_LIRI_EXPIRES_2008JAN31));
            } else if (this.Equals(MAURITIUS_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_MAURITIUS_RUPEES));
            } else if (this.Equals(MALDIVES_MALDIVE_ISLANDS_RUFIYAA)) {
                info.SetType(typeof(CurrencyCodeEnum_MALDIVES_MALDIVE_ISLANDS_RUFIYAA));
            } else if (this.Equals(MALAWI_KWACHAS)) {
                info.SetType(typeof(CurrencyCodeEnum_MALAWI_KWACHAS));
            } else if (this.Equals(MEXICO_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_MEXICO_PESOS));
            } else if (this.Equals(MALAYSIA_RINGGITS)) {
                info.SetType(typeof(CurrencyCodeEnum_MALAYSIA_RINGGITS));
            } else if (this.Equals(MOZAMBIQUE_METICAIS)) {
                info.SetType(typeof(CurrencyCodeEnum_MOZAMBIQUE_METICAIS));
            } else if (this.Equals(NAMIBIA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_NAMIBIA_DOLLARS));
            } else if (this.Equals(NIGERIA_NAIRAS)) {
                info.SetType(typeof(CurrencyCodeEnum_NIGERIA_NAIRAS));
            } else if (this.Equals(NICARAGUA_CORDOBAS)) {
                info.SetType(typeof(CurrencyCodeEnum_NICARAGUA_CORDOBAS));
            } else if (this.Equals(NORWAY_KRONE)) {
                info.SetType(typeof(CurrencyCodeEnum_NORWAY_KRONE));
            } else if (this.Equals(NEPAL_NEPAL_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_NEPAL_NEPAL_RUPEES));
            } else if (this.Equals(NEW_ZEALAND_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_NEW_ZEALAND_DOLLARS));
            } else if (this.Equals(OMAN_RIALS)) {
                info.SetType(typeof(CurrencyCodeEnum_OMAN_RIALS));
            } else if (this.Equals(PANAMA_BALBOA)) {
                info.SetType(typeof(CurrencyCodeEnum_PANAMA_BALBOA));
            } else if (this.Equals(PERU_NUEVOS_SOLES)) {
                info.SetType(typeof(CurrencyCodeEnum_PERU_NUEVOS_SOLES));
            } else if (this.Equals(PAPUA_NEW_GUINEA_KINA)) {
                info.SetType(typeof(CurrencyCodeEnum_PAPUA_NEW_GUINEA_KINA));
            } else if (this.Equals(PHILIPPINES_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_PHILIPPINES_PESOS));
            } else if (this.Equals(PAKISTAN_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_PAKISTAN_RUPEES));
            } else if (this.Equals(POLAND_ZLOTYCH)) {
                info.SetType(typeof(CurrencyCodeEnum_POLAND_ZLOTYCH));
            } else if (this.Equals(PARAGUAY_GUARANI)) {
                info.SetType(typeof(CurrencyCodeEnum_PARAGUAY_GUARANI));
            } else if (this.Equals(QATAR_RIALS)) {
                info.SetType(typeof(CurrencyCodeEnum_QATAR_RIALS));
            } else if (this.Equals(ROMANIA_NEW_LEI)) {
                info.SetType(typeof(CurrencyCodeEnum_ROMANIA_NEW_LEI));
            } else if (this.Equals(SERBIA_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_SERBIA_DINARS));
            } else if (this.Equals(RUSSIA_RUBLES)) {
                info.SetType(typeof(CurrencyCodeEnum_RUSSIA_RUBLES));
            } else if (this.Equals(RWANDA_RWANDA_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_RWANDA_RWANDA_FRANCS));
            } else if (this.Equals(SAUDI_ARABIA_RIYALS)) {
                info.SetType(typeof(CurrencyCodeEnum_SAUDI_ARABIA_RIYALS));
            } else if (this.Equals(SOLOMON_ISLANDS_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_SOLOMON_ISLANDS_DOLLARS));
            } else if (this.Equals(SEYCHELLES_RUPEES)) {
                info.SetType(typeof(CurrencyCodeEnum_SEYCHELLES_RUPEES));
            } else if (this.Equals(SUDAN_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_SUDAN_POUNDS));
            } else if (this.Equals(SWEDEN_KRONOR)) {
                info.SetType(typeof(CurrencyCodeEnum_SWEDEN_KRONOR));
            } else if (this.Equals(SINGAPORE_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_SINGAPORE_DOLLARS));
            } else if (this.Equals(SAINT_HELENA_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_SAINT_HELENA_POUNDS));
            } else if (this.Equals(SIERRA_LEONE_LEONES)) {
                info.SetType(typeof(CurrencyCodeEnum_SIERRA_LEONE_LEONES));
            } else if (this.Equals(SOMALIA_SHILLINGS)) {
                info.SetType(typeof(CurrencyCodeEnum_SOMALIA_SHILLINGS));
            } else if (this.Equals(SEBORGA_LUIGINI)) {
                info.SetType(typeof(CurrencyCodeEnum_SEBORGA_LUIGINI));
            } else if (this.Equals(SURINAME_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_SURINAME_DOLLARS));
            } else if (this.Equals(SAO_TOME_AND_PRINCIPE_DOBRAS)) {
                info.SetType(typeof(CurrencyCodeEnum_SAO_TOME_AND_PRINCIPE_DOBRAS));
            } else if (this.Equals(EL_SALVADOR_COLONES)) {
                info.SetType(typeof(CurrencyCodeEnum_EL_SALVADOR_COLONES));
            } else if (this.Equals(SYRIA_POUNDS)) {
                info.SetType(typeof(CurrencyCodeEnum_SYRIA_POUNDS));
            } else if (this.Equals(SWAZILAND_EMALANGENI)) {
                info.SetType(typeof(CurrencyCodeEnum_SWAZILAND_EMALANGENI));
            } else if (this.Equals(THAILAND_BAHT)) {
                info.SetType(typeof(CurrencyCodeEnum_THAILAND_BAHT));
            } else if (this.Equals(TAJIKISTAN_SOMONI)) {
                info.SetType(typeof(CurrencyCodeEnum_TAJIKISTAN_SOMONI));
            } else if (this.Equals(TURKMENISTAN_MANATS)) {
                info.SetType(typeof(CurrencyCodeEnum_TURKMENISTAN_MANATS));
            } else if (this.Equals(TUNISIA_DINARS)) {
                info.SetType(typeof(CurrencyCodeEnum_TUNISIA_DINARS));
            } else if (this.Equals(TONGA_PAANGA)) {
                info.SetType(typeof(CurrencyCodeEnum_TONGA_PAANGA));
            } else if (this.Equals(TURKEY_NEW_LIRA)) {
                info.SetType(typeof(CurrencyCodeEnum_TURKEY_NEW_LIRA));
            } else if (this.Equals(TRINIDAD_AND_TOBAGO_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_TRINIDAD_AND_TOBAGO_DOLLARS));
            } else if (this.Equals(TUVALU_TUVALU_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_TUVALU_TUVALU_DOLLARS));
            } else if (this.Equals(TAIWAN_NEW_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_TAIWAN_NEW_DOLLARS));
            } else if (this.Equals(TANZANIA_SHILLINGS)) {
                info.SetType(typeof(CurrencyCodeEnum_TANZANIA_SHILLINGS));
            } else if (this.Equals(UKRAINE_HRYVNIA)) {
                info.SetType(typeof(CurrencyCodeEnum_UKRAINE_HRYVNIA));
            } else if (this.Equals(UGANDA_SHILLINGS)) {
                info.SetType(typeof(CurrencyCodeEnum_UGANDA_SHILLINGS));
            } else if (this.Equals(UNITED_STATES_OF_AMERICA_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_UNITED_STATES_OF_AMERICA_DOLLARS));
            } else if (this.Equals(URUGUAY_PESOS)) {
                info.SetType(typeof(CurrencyCodeEnum_URUGUAY_PESOS));
            } else if (this.Equals(UZBEKISTAN_SUMS)) {
                info.SetType(typeof(CurrencyCodeEnum_UZBEKISTAN_SUMS));
            } else if (this.Equals(VENEZUELA_BOLIVARES_EXPIRES_2008JUN30)) {
                info.SetType(typeof(CurrencyCodeEnum_VENEZUELA_BOLIVARES_EXPIRES_2008JUN30));
            } else if (this.Equals(VENEZUELA_BOLIVARES_FUERTES)) {
                info.SetType(typeof(CurrencyCodeEnum_VENEZUELA_BOLIVARES_FUERTES));
            } else if (this.Equals(VIET_NAM_DONG)) {
                info.SetType(typeof(CurrencyCodeEnum_VIET_NAM_DONG));
            } else if (this.Equals(VANUATU_VATU)) {
                info.SetType(typeof(CurrencyCodeEnum_VANUATU_VATU));
            } else if (this.Equals(SAMOA_TALA)) {
                info.SetType(typeof(CurrencyCodeEnum_SAMOA_TALA));
            } else if (this.Equals(COMMUNAUTE_FINANCIERE_AFRICAINE_BEAC_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_COMMUNAUTE_FINANCIERE_AFRICAINE_BEAC_FRANCS));
            } else if (this.Equals(SILVER_OUNCES)) {
                info.SetType(typeof(CurrencyCodeEnum_SILVER_OUNCES));
            } else if (this.Equals(GOLD_OUNCES)) {
                info.SetType(typeof(CurrencyCodeEnum_GOLD_OUNCES));
            } else if (this.Equals(EAST_CARIBBEAN_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_EAST_CARIBBEAN_DOLLARS));
            } else if (this.Equals(INTERNATIONAL_MONETARY_FUND_IMF_SPECIAL_DRAWING_RIGHTS)) {
                info.SetType(typeof(CurrencyCodeEnum_INTERNATIONAL_MONETARY_FUND_IMF_SPECIAL_DRAWING_RIGHTS));
            } else if (this.Equals(COMMUNAUTE_FINANCIERE_AFRICAINE_BCEAO_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_COMMUNAUTE_FINANCIERE_AFRICAINE_BCEAO_FRANCS));
            } else if (this.Equals(PALLADIUM_OUNCES)) {
                info.SetType(typeof(CurrencyCodeEnum_PALLADIUM_OUNCES));
            } else if (this.Equals(COMPTOIRS_FRANCAIS_DU_PACIFIQUE_FRANCS)) {
                info.SetType(typeof(CurrencyCodeEnum_COMPTOIRS_FRANCAIS_DU_PACIFIQUE_FRANCS));
            } else if (this.Equals(PLATINUM_OUNCES)) {
                info.SetType(typeof(CurrencyCodeEnum_PLATINUM_OUNCES));
            } else if (this.Equals(YEMEN_RIALS)) {
                info.SetType(typeof(CurrencyCodeEnum_YEMEN_RIALS));
            } else if (this.Equals(SOUTH_AFRICA_RAND)) {
                info.SetType(typeof(CurrencyCodeEnum_SOUTH_AFRICA_RAND));
            } else if (this.Equals(ZAMBIA_KWACHA)) {
                info.SetType(typeof(CurrencyCodeEnum_ZAMBIA_KWACHA));
            } else if (this.Equals(ZIMBABWE_ZIMBABWE_DOLLARS)) {
                info.SetType(typeof(CurrencyCodeEnum_ZIMBABWE_ZIMBABWE_DOLLARS));
            }
        }

    }

    [Serializable]
    public class CurrencyCodeEnum_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.DEFAULT;
        }
    }

    [Serializable]
    public class CurrencyCodeEnum_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UNSET;
        }
    }

    [Serializable]
    public class CurrencyCodeEnum_UNITED_ARAB_EMIRATES_DIRHAMS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UNITED_ARAB_EMIRATES_DIRHAMS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_AFGHANISTAN_AFGHANIS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.AFGHANISTAN_AFGHANIS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ALBANIA_LEKE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ALBANIA_LEKE;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ARMENIA_DRAMS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ARMENIA_DRAMS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NETHERLANDS_ANTILLES_GUILDERS_ALSO_CALLED_FLORINS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NETHERLANDS_ANTILLES_GUILDERS_ALSO_CALLED_FLORINS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ANGOLA_KWANZA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ANGOLA_KWANZA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ARGENTINA_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ARGENTINA_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_AUSTRALIA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.AUSTRALIA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ARUBA_GUILDERS_ALSO_CALLED_FLORINS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ARUBA_GUILDERS_ALSO_CALLED_FLORINS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_AZERBAIJAN_NEW_MANATS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.AZERBAIJAN_NEW_MANATS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BOSNIA_AND_HERZEGOVINA_CONVERTIBLE_MARKA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BOSNIA_AND_HERZEGOVINA_CONVERTIBLE_MARKA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BARBADOS_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BARBADOS_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BANGLADESH_TAKA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BANGLADESH_TAKA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BULGARIA_LEVA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BULGARIA_LEVA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BAHRAIN_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BAHRAIN_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BURUNDI_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BURUNDI_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BERMUDA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BERMUDA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BRUNEI_DARUSSALAM_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BRUNEI_DARUSSALAM_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BOLIVIA_BOLIVIANOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BOLIVIA_BOLIVIANOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BRAZIL_BRAZIL_REAL : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BRAZIL_BRAZIL_REAL;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BAHAMAS_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BAHAMAS_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BHUTAN_NGULTRUM : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BHUTAN_NGULTRUM;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BOTSWANA_PULAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BOTSWANA_PULAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BELARUS_RUBLES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BELARUS_RUBLES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_BELIZE_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.BELIZE_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CANADA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CANADA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CONGOKINSHASA_CONGOLESE_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CONGOKINSHASA_CONGOLESE_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SWITZERLAND_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SWITZERLAND_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CHILE_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CHILE_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CHINA_YUAN_RENMINBI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CHINA_YUAN_RENMINBI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COLOMBIA_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COLOMBIA_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COSTA_RICA_COLONES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COSTA_RICA_COLONES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CUBA_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CUBA_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CAPE_VERDE_ESCUDOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CAPE_VERDE_ESCUDOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CYPRUS_POUNDS_EXPIRES_2008JAN31 : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CYPRUS_POUNDS_EXPIRES_2008JAN31;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CZECH_REPUBLIC_KORUNY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CZECH_REPUBLIC_KORUNY;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_DJIBOUTI_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.DJIBOUTI_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_DENMARK_KRONER : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.DENMARK_KRONER;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_DOMINICAN_REPUBLIC_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.DOMINICAN_REPUBLIC_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ALGERIA_ALGERIA_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ALGERIA_ALGERIA_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ESTONIA_KROONI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ESTONIA_KROONI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_EGYPT_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.EGYPT_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ERITREA_NAKFA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ERITREA_NAKFA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ETHIOPIA_BIRR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ETHIOPIA_BIRR;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_EURO_MEMBER_COUNTRIES_EURO : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.EURO_MEMBER_COUNTRIES_EURO;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_FIJI_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.FIJI_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_FALKLAND_ISLANDS_MALVINAS_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.FALKLAND_ISLANDS_MALVINAS_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_UNITED_KINGDOM_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UNITED_KINGDOM_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GEORGIA_LARI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GEORGIA_LARI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GUERNSEY_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GUERNSEY_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GHANA_CEDIS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GHANA_CEDIS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GIBRALTAR_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GIBRALTAR_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GAMBIA_DALASI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GAMBIA_DALASI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GUINEA_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GUINEA_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GUATEMALA_QUETZALES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GUATEMALA_QUETZALES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GUYANA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GUYANA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_HONG_KONG_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.HONG_KONG_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_HONDURAS_LEMPIRAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.HONDURAS_LEMPIRAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CROATIA_KUNA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CROATIA_KUNA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_HAITI_GOURDES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.HAITI_GOURDES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_HUNGARY_FORINT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.HUNGARY_FORINT;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_INDONESIA_RUPIAHS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.INDONESIA_RUPIAHS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ISRAEL_NEW_SHEKELS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ISRAEL_NEW_SHEKELS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ISLE_OF_MAN_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ISLE_OF_MAN_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_INDIA_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.INDIA_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_IRAQ_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.IRAQ_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_IRAN_RIALS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.IRAN_RIALS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ICELAND_KRONUR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ICELAND_KRONUR;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_JERSEY_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.JERSEY_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_JAMAICA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.JAMAICA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_JORDAN_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.JORDAN_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_JAPAN_YEN : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.JAPAN_YEN;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KENYA_SHILLINGS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KENYA_SHILLINGS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KYRGYZSTAN_SOMS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KYRGYZSTAN_SOMS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CAMBODIA_RIELS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CAMBODIA_RIELS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COMOROS_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COMOROS_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KOREA_NORTH_WON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KOREA_NORTH_WON;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KOREA_SOUTH_WON : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KOREA_SOUTH_WON;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KUWAIT_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KUWAIT_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_CAYMAN_ISLANDS_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.CAYMAN_ISLANDS_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_KAZAKHSTAN_TENGE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.KAZAKHSTAN_TENGE;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LAOS_KIPS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LAOS_KIPS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LEBANON_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LEBANON_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SRI_LANKA_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SRI_LANKA_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LIBERIA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LIBERIA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LESOTHO_MALOTI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LESOTHO_MALOTI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LITHUANIA_LITAI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LITHUANIA_LITAI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LATVIA_LATI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LATVIA_LATI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_LIBYA_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.LIBYA_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MOROCCO_DIRHAMS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MOROCCO_DIRHAMS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MOLDOVA_LEI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MOLDOVA_LEI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MADAGASCAR_ARIARY : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MADAGASCAR_ARIARY;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MACEDONIA_DENARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MACEDONIA_DENARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MYANMAR_BURMA_KYATS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MYANMAR_BURMA_KYATS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MONGOLIA_TUGRIKS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MONGOLIA_TUGRIKS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MACAU_PATACAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MACAU_PATACAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MAURITANIA_OUGUIYAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MAURITANIA_OUGUIYAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MALTA_LIRI_EXPIRES_2008JAN31 : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MALTA_LIRI_EXPIRES_2008JAN31;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MAURITIUS_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MAURITIUS_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MALDIVES_MALDIVE_ISLANDS_RUFIYAA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MALDIVES_MALDIVE_ISLANDS_RUFIYAA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MALAWI_KWACHAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MALAWI_KWACHAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MEXICO_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MEXICO_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MALAYSIA_RINGGITS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MALAYSIA_RINGGITS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_MOZAMBIQUE_METICAIS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.MOZAMBIQUE_METICAIS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NAMIBIA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NAMIBIA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NIGERIA_NAIRAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NIGERIA_NAIRAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NICARAGUA_CORDOBAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NICARAGUA_CORDOBAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NORWAY_KRONE : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NORWAY_KRONE;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NEPAL_NEPAL_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NEPAL_NEPAL_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_NEW_ZEALAND_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.NEW_ZEALAND_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_OMAN_RIALS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.OMAN_RIALS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PANAMA_BALBOA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PANAMA_BALBOA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PERU_NUEVOS_SOLES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PERU_NUEVOS_SOLES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PAPUA_NEW_GUINEA_KINA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PAPUA_NEW_GUINEA_KINA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PHILIPPINES_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PHILIPPINES_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PAKISTAN_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PAKISTAN_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_POLAND_ZLOTYCH : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.POLAND_ZLOTYCH;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PARAGUAY_GUARANI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PARAGUAY_GUARANI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_QATAR_RIALS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.QATAR_RIALS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ROMANIA_NEW_LEI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ROMANIA_NEW_LEI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SERBIA_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SERBIA_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_RUSSIA_RUBLES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.RUSSIA_RUBLES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_RWANDA_RWANDA_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.RWANDA_RWANDA_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SAUDI_ARABIA_RIYALS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SAUDI_ARABIA_RIYALS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SOLOMON_ISLANDS_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SOLOMON_ISLANDS_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SEYCHELLES_RUPEES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SEYCHELLES_RUPEES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SUDAN_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SUDAN_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SWEDEN_KRONOR : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SWEDEN_KRONOR;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SINGAPORE_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SINGAPORE_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SAINT_HELENA_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SAINT_HELENA_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SIERRA_LEONE_LEONES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SIERRA_LEONE_LEONES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SOMALIA_SHILLINGS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SOMALIA_SHILLINGS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SEBORGA_LUIGINI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SEBORGA_LUIGINI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SURINAME_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SURINAME_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SAO_TOME_AND_PRINCIPE_DOBRAS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SAO_TOME_AND_PRINCIPE_DOBRAS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_EL_SALVADOR_COLONES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.EL_SALVADOR_COLONES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SYRIA_POUNDS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SYRIA_POUNDS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SWAZILAND_EMALANGENI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SWAZILAND_EMALANGENI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_THAILAND_BAHT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.THAILAND_BAHT;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TAJIKISTAN_SOMONI : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TAJIKISTAN_SOMONI;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TURKMENISTAN_MANATS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TURKMENISTAN_MANATS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TUNISIA_DINARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TUNISIA_DINARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TONGA_PAANGA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TONGA_PAANGA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TURKEY_NEW_LIRA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TURKEY_NEW_LIRA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TRINIDAD_AND_TOBAGO_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TRINIDAD_AND_TOBAGO_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TUVALU_TUVALU_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TUVALU_TUVALU_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TAIWAN_NEW_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TAIWAN_NEW_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_TANZANIA_SHILLINGS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.TANZANIA_SHILLINGS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_UKRAINE_HRYVNIA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UKRAINE_HRYVNIA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_UGANDA_SHILLINGS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UGANDA_SHILLINGS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_UNITED_STATES_OF_AMERICA_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UNITED_STATES_OF_AMERICA_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_URUGUAY_PESOS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.URUGUAY_PESOS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_UZBEKISTAN_SUMS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.UZBEKISTAN_SUMS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_VENEZUELA_BOLIVARES_EXPIRES_2008JUN30 : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.VENEZUELA_BOLIVARES_EXPIRES_2008JUN30;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_VENEZUELA_BOLIVARES_FUERTES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.VENEZUELA_BOLIVARES_FUERTES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_VIET_NAM_DONG : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.VIET_NAM_DONG;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_VANUATU_VATU : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.VANUATU_VATU;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SAMOA_TALA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SAMOA_TALA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COMMUNAUTE_FINANCIERE_AFRICAINE_BEAC_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COMMUNAUTE_FINANCIERE_AFRICAINE_BEAC_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SILVER_OUNCES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SILVER_OUNCES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_GOLD_OUNCES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.GOLD_OUNCES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_EAST_CARIBBEAN_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.EAST_CARIBBEAN_DOLLARS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_INTERNATIONAL_MONETARY_FUND_IMF_SPECIAL_DRAWING_RIGHTS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.INTERNATIONAL_MONETARY_FUND_IMF_SPECIAL_DRAWING_RIGHTS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COMMUNAUTE_FINANCIERE_AFRICAINE_BCEAO_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COMMUNAUTE_FINANCIERE_AFRICAINE_BCEAO_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PALLADIUM_OUNCES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PALLADIUM_OUNCES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_COMPTOIRS_FRANCAIS_DU_PACIFIQUE_FRANCS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.COMPTOIRS_FRANCAIS_DU_PACIFIQUE_FRANCS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_PLATINUM_OUNCES : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.PLATINUM_OUNCES;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_YEMEN_RIALS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.YEMEN_RIALS;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_SOUTH_AFRICA_RAND : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.SOUTH_AFRICA_RAND;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ZAMBIA_KWACHA : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ZAMBIA_KWACHA;
        }
    }
    [Serializable]
    public class CurrencyCodeEnum_ZIMBABWE_ZIMBABWE_DOLLARS : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return CurrencyCodeEnum.ZIMBABWE_ZIMBABWE_DOLLARS;
        }
    }
}
