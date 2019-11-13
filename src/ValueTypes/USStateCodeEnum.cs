using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Cortside.Core.Types {

    [Serializable]
    public class USStateCodeEnum : EnumDataType, IDataType, ISerializable {

        protected static readonly EnumDataTypeList OPTIONS = new EnumDataTypeList();

        public static readonly new USStateCodeEnum DEFAULT = new USStateCodeEnum();
        public static readonly new USStateCodeEnum UNSET = new USStateCodeEnum();

        public static readonly USStateCodeEnum ALABAMA = new USStateCodeEnum("AL", "AL");
        public static readonly USStateCodeEnum ALASKA = new USStateCodeEnum("AK", "AK");
        public static readonly USStateCodeEnum AMERICAN_SAMOA = new USStateCodeEnum("AS", "AS");
        public static readonly USStateCodeEnum ARIZONA = new USStateCodeEnum("AZ", "AZ");
        public static readonly USStateCodeEnum ARKANSAS = new USStateCodeEnum("AR", "AR");
        public static readonly USStateCodeEnum CALIFORNIA = new USStateCodeEnum("CA", "CA");
        public static readonly USStateCodeEnum COLORADO = new USStateCodeEnum("CO", "CO");
        public static readonly USStateCodeEnum CONNECTICUT = new USStateCodeEnum("CT", "CT");
        public static readonly USStateCodeEnum DELAWARE = new USStateCodeEnum("DE", "DE");
        public static readonly USStateCodeEnum DISTRICT_OF_COLUMBIA = new USStateCodeEnum("DC", "DC");
        public static readonly USStateCodeEnum FLORIDA = new USStateCodeEnum("FL", "FL");
        public static readonly USStateCodeEnum GEORGIA = new USStateCodeEnum("GA", "GA");
        public static readonly USStateCodeEnum GUAM = new USStateCodeEnum("GU", "GU");
        public static readonly USStateCodeEnum HAWAII = new USStateCodeEnum("HI", "HI");
        public static readonly USStateCodeEnum IDAHO = new USStateCodeEnum("ID", "ID");
        public static readonly USStateCodeEnum ILLINOIS = new USStateCodeEnum("IL", "IL");
        public static readonly USStateCodeEnum INDIANA = new USStateCodeEnum("IN", "IN");
        public static readonly USStateCodeEnum IOWA = new USStateCodeEnum("IA", "IA");
        public static readonly USStateCodeEnum KANSAS = new USStateCodeEnum("KS", "KS");
        public static readonly USStateCodeEnum KENTUCKY = new USStateCodeEnum("KY", "KY");
        public static readonly USStateCodeEnum LOUISIANA = new USStateCodeEnum("LA", "LA");
        public static readonly USStateCodeEnum MAINE = new USStateCodeEnum("ME", "ME");
        public static readonly USStateCodeEnum MARYLAND = new USStateCodeEnum("MD", "MD");
        public static readonly USStateCodeEnum MASSACHUSETTS = new USStateCodeEnum("MA", "MA");
        public static readonly USStateCodeEnum MICHIGAN = new USStateCodeEnum("MI", "MI");
        public static readonly USStateCodeEnum MINNESOTA = new USStateCodeEnum("MN", "MN");
        public static readonly USStateCodeEnum MISSISSIPPI = new USStateCodeEnum("MS", "MS");
        public static readonly USStateCodeEnum MISSOURI = new USStateCodeEnum("MO", "MO");
        public static readonly USStateCodeEnum MONTANA = new USStateCodeEnum("MT", "MT");
        public static readonly USStateCodeEnum NEBRASKA = new USStateCodeEnum("NE", "NE");
        public static readonly USStateCodeEnum NEVADA = new USStateCodeEnum("NV", "NV");
        public static readonly USStateCodeEnum NEW_HAMPSHIRE = new USStateCodeEnum("NH", "NH");
        public static readonly USStateCodeEnum NEW_JERSEY = new USStateCodeEnum("NJ", "NJ");
        public static readonly USStateCodeEnum NEW_MEXICO = new USStateCodeEnum("NM", "NM");
        public static readonly USStateCodeEnum NEW_YORK = new USStateCodeEnum("NY", "NY");
        public static readonly USStateCodeEnum NORTH_CAROLINA = new USStateCodeEnum("NC", "NC");
        public static readonly USStateCodeEnum NORTH_DAKOTA = new USStateCodeEnum("ND", "ND");
        public static readonly USStateCodeEnum OHIO = new USStateCodeEnum("OH", "OH");
        public static readonly USStateCodeEnum OKLAHOMA = new USStateCodeEnum("OK", "OK");
        public static readonly USStateCodeEnum OREGON = new USStateCodeEnum("OR", "OR");
        public static readonly USStateCodeEnum PENNSYLVANIA = new USStateCodeEnum("PA", "PA");
        public static readonly USStateCodeEnum PUERTO_RICO = new USStateCodeEnum("PR", "PR");
        public static readonly USStateCodeEnum RHODE_ISLAND = new USStateCodeEnum("RI", "RI");
        public static readonly USStateCodeEnum SOUTH_CAROLINA = new USStateCodeEnum("SC", "SC");
        public static readonly USStateCodeEnum SOUTH_DAKOTA = new USStateCodeEnum("SD", "SD");
        public static readonly USStateCodeEnum TENNESSEE = new USStateCodeEnum("TN", "TN");
        public static readonly USStateCodeEnum TEXAS = new USStateCodeEnum("TX", "TX");
        public static readonly USStateCodeEnum UTAH = new USStateCodeEnum("UT", "UT");
        public static readonly USStateCodeEnum VERMONT = new USStateCodeEnum("VT", "VT");
        public static readonly USStateCodeEnum VIRGINIA = new USStateCodeEnum("VA", "VA");
        public static readonly USStateCodeEnum VIRGIN_ISLANDS = new USStateCodeEnum("VI", "VI");
        public static readonly USStateCodeEnum WASHINGTON = new USStateCodeEnum("WA", "WA");
        public static readonly USStateCodeEnum WEST_VIRGINIA = new USStateCodeEnum("WV", "WV");
        public static readonly USStateCodeEnum WISCONSIN = new USStateCodeEnum("WI", "WI");
        public static readonly USStateCodeEnum WYOMING = new USStateCodeEnum("WY", "WY");

        public static USStateCodeEnum GetInstance(Object value) {
            if (value is String) {
                foreach (USStateCodeEnum t in OPTIONS) {
                    if (t.Value.Equals(value)) {
                        return t;
                    }
                }
            }

            return UNSET;
        }

        protected USStateCodeEnum() { }

        protected USStateCodeEnum(String code, String name) {
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

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(USStateCodeEnum_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(USStateCodeEnum_UNSET));
            } else if (this.Equals(ALABAMA)) {
                info.SetType(typeof(USStateCodeEnum_ALABAMA));
            } else if (this.Equals(ALASKA)) {
                info.SetType(typeof(USStateCodeEnum_ALASKA));
            } else if (this.Equals(AMERICAN_SAMOA)) {
                info.SetType(typeof(USStateCodeEnum_AMERICAN_SAMOA));
            } else if (this.Equals(ARIZONA)) {
                info.SetType(typeof(USStateCodeEnum_ARIZONA));
            } else if (this.Equals(ARKANSAS)) {
                info.SetType(typeof(USStateCodeEnum_ARKANSAS));
            } else if (this.Equals(CALIFORNIA)) {
                info.SetType(typeof(USStateCodeEnum_CALIFORNIA));
            } else if (this.Equals(COLORADO)) {
                info.SetType(typeof(USStateCodeEnum_COLORADO));
            } else if (this.Equals(CONNECTICUT)) {
                info.SetType(typeof(USStateCodeEnum_CONNECTICUT));
            } else if (this.Equals(DELAWARE)) {
                info.SetType(typeof(USStateCodeEnum_DELAWARE));
            } else if (this.Equals(DISTRICT_OF_COLUMBIA)) {
                info.SetType(typeof(USStateCodeEnum_DISTRICT_OF_COLUMBIA));
            } else if (this.Equals(FLORIDA)) {
                info.SetType(typeof(USStateCodeEnum_FLORIDA));
            } else if (this.Equals(GEORGIA)) {
                info.SetType(typeof(USStateCodeEnum_GEORGIA));
            } else if (this.Equals(GUAM)) {
                info.SetType(typeof(USStateCodeEnum_GUAM));
            } else if (this.Equals(HAWAII)) {
                info.SetType(typeof(USStateCodeEnum_HAWAII));
            } else if (this.Equals(IDAHO)) {
                info.SetType(typeof(USStateCodeEnum_IDAHO));
            } else if (this.Equals(ILLINOIS)) {
                info.SetType(typeof(USStateCodeEnum_ILLINOIS));
            } else if (this.Equals(INDIANA)) {
                info.SetType(typeof(USStateCodeEnum_INDIANA));
            } else if (this.Equals(IOWA)) {
                info.SetType(typeof(USStateCodeEnum_IOWA));
            } else if (this.Equals(KANSAS)) {
                info.SetType(typeof(USStateCodeEnum_KANSAS));
            } else if (this.Equals(KENTUCKY)) {
                info.SetType(typeof(USStateCodeEnum_KENTUCKY));
            } else if (this.Equals(LOUISIANA)) {
                info.SetType(typeof(USStateCodeEnum_LOUISIANA));
            } else if (this.Equals(MAINE)) {
                info.SetType(typeof(USStateCodeEnum_MAINE));
            } else if (this.Equals(MARYLAND)) {
                info.SetType(typeof(USStateCodeEnum_MARYLAND));
            } else if (this.Equals(MASSACHUSETTS)) {
                info.SetType(typeof(USStateCodeEnum_MASSACHUSETTS));
            } else if (this.Equals(MICHIGAN)) {
                info.SetType(typeof(USStateCodeEnum_MICHIGAN));
            } else if (this.Equals(MINNESOTA)) {
                info.SetType(typeof(USStateCodeEnum_MINNESOTA));
            } else if (this.Equals(MISSISSIPPI)) {
                info.SetType(typeof(USStateCodeEnum_MISSISSIPPI));
            } else if (this.Equals(MISSOURI)) {
                info.SetType(typeof(USStateCodeEnum_MISSOURI));
            } else if (this.Equals(MONTANA)) {
                info.SetType(typeof(USStateCodeEnum_MONTANA));
            } else if (this.Equals(NEBRASKA)) {
                info.SetType(typeof(USStateCodeEnum_NEBRASKA));
            } else if (this.Equals(NEVADA)) {
                info.SetType(typeof(USStateCodeEnum_NEVADA));
            } else if (this.Equals(NEW_HAMPSHIRE)) {
                info.SetType(typeof(USStateCodeEnum_NEW_HAMPSHIRE));
            } else if (this.Equals(NEW_JERSEY)) {
                info.SetType(typeof(USStateCodeEnum_NEW_JERSEY));
            } else if (this.Equals(NEW_MEXICO)) {
                info.SetType(typeof(USStateCodeEnum_NEW_MEXICO));
            } else if (this.Equals(NEW_YORK)) {
                info.SetType(typeof(USStateCodeEnum_NEW_YORK));
            } else if (this.Equals(NORTH_CAROLINA)) {
                info.SetType(typeof(USStateCodeEnum_NORTH_CAROLINA));
            } else if (this.Equals(NORTH_DAKOTA)) {
                info.SetType(typeof(USStateCodeEnum_NORTH_DAKOTA));
            } else if (this.Equals(OHIO)) {
                info.SetType(typeof(USStateCodeEnum_OHIO));
            } else if (this.Equals(OKLAHOMA)) {
                info.SetType(typeof(USStateCodeEnum_OKLAHOMA));
            } else if (this.Equals(OREGON)) {
                info.SetType(typeof(USStateCodeEnum_OREGON));
            } else if (this.Equals(PENNSYLVANIA)) {
                info.SetType(typeof(USStateCodeEnum_PENNSYLVANIA));
            } else if (this.Equals(PUERTO_RICO)) {
                info.SetType(typeof(USStateCodeEnum_PUERTO_RICO));
            } else if (this.Equals(RHODE_ISLAND)) {
                info.SetType(typeof(USStateCodeEnum_RHODE_ISLAND));
            } else if (this.Equals(SOUTH_CAROLINA)) {
                info.SetType(typeof(USStateCodeEnum_SOUTH_CAROLINA));
            } else if (this.Equals(SOUTH_DAKOTA)) {
                info.SetType(typeof(USStateCodeEnum_SOUTH_DAKOTA));
            } else if (this.Equals(TENNESSEE)) {
                info.SetType(typeof(USStateCodeEnum_TENNESSEE));
            } else if (this.Equals(TEXAS)) {
                info.SetType(typeof(USStateCodeEnum_TEXAS));
            } else if (this.Equals(UTAH)) {
                info.SetType(typeof(USStateCodeEnum_UTAH));
            } else if (this.Equals(VERMONT)) {
                info.SetType(typeof(USStateCodeEnum_VERMONT));
            } else if (this.Equals(VIRGINIA)) {
                info.SetType(typeof(USStateCodeEnum_VIRGINIA));
            } else if (this.Equals(VIRGIN_ISLANDS)) {
                info.SetType(typeof(USStateCodeEnum_VIRGIN_ISLANDS));
            } else if (this.Equals(WASHINGTON)) {
                info.SetType(typeof(USStateCodeEnum_WASHINGTON));
            } else if (this.Equals(WEST_VIRGINIA)) {
                info.SetType(typeof(USStateCodeEnum_WEST_VIRGINIA));
            } else if (this.Equals(WISCONSIN)) {
                info.SetType(typeof(USStateCodeEnum_WISCONSIN));
            } else if (this.Equals(WYOMING)) {
                info.SetType(typeof(USStateCodeEnum_WYOMING));
            }
        }

        [Serializable]
        public class USStateCodeEnum_DEFAULT : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.DEFAULT;
            }
        }

        [Serializable]
        public class USStateCodeEnum_UNSET : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.UNSET;
            }
        }

        [Serializable]
        public class USStateCodeEnum_ALABAMA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.ALABAMA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_ALASKA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.ALASKA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_AMERICAN_SAMOA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.AMERICAN_SAMOA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_ARIZONA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.ARIZONA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_ARKANSAS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.ARKANSAS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_CALIFORNIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.CALIFORNIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_COLORADO : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.COLORADO;
            }
        }

        [Serializable]
        public class USStateCodeEnum_CONNECTICUT : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.CONNECTICUT;
            }
        }

        [Serializable]
        public class USStateCodeEnum_DELAWARE : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.DELAWARE;
            }
        }

        [Serializable]
        public class USStateCodeEnum_DISTRICT_OF_COLUMBIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.DISTRICT_OF_COLUMBIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_FLORIDA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.FLORIDA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_GEORGIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.GEORGIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_GUAM : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.GUAM;
            }
        }

        [Serializable]
        public class USStateCodeEnum_HAWAII : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.HAWAII;
            }
        }

        [Serializable]
        public class USStateCodeEnum_IDAHO : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.IDAHO;
            }
        }

        [Serializable]
        public class USStateCodeEnum_ILLINOIS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.ILLINOIS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_INDIANA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.INDIANA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_IOWA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.IOWA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_KANSAS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.KANSAS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_KENTUCKY : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.KENTUCKY;
            }
        }

        [Serializable]
        public class USStateCodeEnum_LOUISIANA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.LOUISIANA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MAINE : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MAINE;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MARYLAND : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MARYLAND;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MASSACHUSETTS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MASSACHUSETTS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MICHIGAN : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MICHIGAN;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MINNESOTA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MINNESOTA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MISSISSIPPI : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MISSISSIPPI;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MISSOURI : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MISSOURI;
            }
        }

        [Serializable]
        public class USStateCodeEnum_MONTANA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.MONTANA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEBRASKA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEBRASKA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEVADA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEVADA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEW_HAMPSHIRE : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEW_HAMPSHIRE;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEW_JERSEY : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEW_JERSEY;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEW_MEXICO : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEW_MEXICO;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NEW_YORK : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NEW_YORK;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NORTH_CAROLINA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NORTH_CAROLINA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_NORTH_DAKOTA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.NORTH_DAKOTA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_OHIO : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.OHIO;
            }
        }

        [Serializable]
        public class USStateCodeEnum_OKLAHOMA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.OKLAHOMA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_OREGON : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.OREGON;
            }
        }

        [Serializable]
        public class USStateCodeEnum_PENNSYLVANIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.PENNSYLVANIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_PUERTO_RICO : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.PUERTO_RICO;
            }
        }

        [Serializable]
        public class USStateCodeEnum_RHODE_ISLAND : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.RHODE_ISLAND;
            }
        }

        [Serializable]
        public class USStateCodeEnum_SOUTH_CAROLINA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.SOUTH_CAROLINA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_SOUTH_DAKOTA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.SOUTH_DAKOTA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_TENNESSEE : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.TENNESSEE;
            }
        }

        [Serializable]
        public class USStateCodeEnum_TEXAS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.TEXAS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_UTAH : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.UTAH;
            }
        }

        [Serializable]
        public class USStateCodeEnum_VERMONT : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.VERMONT;
            }
        }

        [Serializable]
        public class USStateCodeEnum_VIRGINIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.VIRGINIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_VIRGIN_ISLANDS : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.VIRGIN_ISLANDS;
            }
        }

        [Serializable]
        public class USStateCodeEnum_WASHINGTON : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.WASHINGTON;
            }
        }

        [Serializable]
        public class USStateCodeEnum_WEST_VIRGINIA : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.WEST_VIRGINIA;
            }
        }

        [Serializable]
        public class USStateCodeEnum_WISCONSIN : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.WISCONSIN;
            }
        }

        [Serializable]
        public class USStateCodeEnum_WYOMING : IObjectReference {
            public object GetRealObject(StreamingContext context) {
                return USStateCodeEnum.WYOMING;
            }
        }
    }
}
