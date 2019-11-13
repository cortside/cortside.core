using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    [Serializable]
    public class USStateAndMilitaryCodeEnum : USStateCodeEnum, ISerializable {

        protected static readonly EnumDataTypeList EXTRAOPTIONS = new EnumDataTypeList();
        protected static EnumDataTypeList CombinedList = null;

        public static readonly USStateAndMilitaryCodeEnum AMERICA_AMERICAS_THEATER = new USStateAndMilitaryCodeEnum("AA", "AA");
        public static readonly USStateAndMilitaryCodeEnum AMERICA_EUROPE_THEATER = new USStateAndMilitaryCodeEnum("AE", "AE");
        public static readonly USStateAndMilitaryCodeEnum AMERICA_PACIFIC_THEATER = new USStateAndMilitaryCodeEnum("AP", "AP");

        public static new USStateCodeEnum GetInstance(Object code) {
            if (code is String) {
                // first, check the military states
                foreach (USStateCodeEnum state in EXTRAOPTIONS) {
                    if (state.Code == (String)code) {
                        return state;
                    }
                }
                // if not a military state, check the regular state options
                foreach (USStateCodeEnum state in OPTIONS) {
                    if (state.Code == (String)code) {
                        return state;
                    }
                }
            }
            return UNSET;
        }

        private USStateAndMilitaryCodeEnum() { }

        private USStateAndMilitaryCodeEnum(String code, String name) {
            this.code = code;
            this.name = name;
            EXTRAOPTIONS.Add(this);
        }

        public override Boolean IsDefault {
            get { return Object.ReferenceEquals(this, DEFAULT); }
        }

        public override Boolean IsUnset {
            get { return Object.ReferenceEquals(this, UNSET); }
        }

        public static bool IsMilitary(USStateAndMilitaryCodeEnum codeInQuestion) {
            bool isMilitary = (codeInQuestion == USStateAndMilitaryCodeEnum.AMERICA_AMERICAS_THEATER) ||
                              (codeInQuestion == USStateAndMilitaryCodeEnum.AMERICA_EUROPE_THEATER) ||
                              (codeInQuestion == USStateAndMilitaryCodeEnum.AMERICA_PACIFIC_THEATER);
            return isMilitary;
        }

        public static new EnumDataTypeList Options {
            get {
                if (CombinedList == null) {
                    CombinedList = new EnumDataTypeList();
                    CombinedList.AddRange(OPTIONS);
                    CombinedList.AddRange(EXTRAOPTIONS);
                }
                return CombinedList;
            }
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
            } else if (this.Equals(AMERICA_AMERICAS_THEATER)) {
                info.SetType(typeof(USStateCodeEnum_AMERICA_AMERICAS_THEATER));
            } else if (this.Equals(AMERICA_EUROPE_THEATER)) {
                info.SetType(typeof(USStateCodeEnum_AMERICA_EUROPE_THEATER));
            } else if (this.Equals(AMERICA_PACIFIC_THEATER)) {
                info.SetType(typeof(USStateCodeEnum_AMERICA_PACIFIC_THEATER));
            }
        }
    }

    [Serializable]
    public class USStateAndMilitaryCodeEnum_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return USStateCodeEnum.DEFAULT;
        }
    }

    [Serializable]
    public class USStateAndMilitaryCodeEnum_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return USStateCodeEnum.UNSET;
        }
    }

    [Serializable]
    public class USStateCodeEnum_AMERICA_AMERICAS_THEATER : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return USStateAndMilitaryCodeEnum.AMERICA_AMERICAS_THEATER;
        }
    }

    [Serializable]
    public class USStateCodeEnum_AMERICA_EUROPE_THEATER : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return USStateAndMilitaryCodeEnum.AMERICA_EUROPE_THEATER;
        }
    }

    [Serializable]
    public class USStateCodeEnum_AMERICA_PACIFIC_THEATER : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return USStateAndMilitaryCodeEnum.AMERICA_PACIFIC_THEATER;
        }
    }
}
