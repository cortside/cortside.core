using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Spring2.Core.Types {

    [Serializable]
    public struct IdType : IDataType, ISerializable {

        private IntegerType myValue;

        public static readonly IdType DEFAULT = new IdType(TypeState.DEFAULT);
        public static readonly IdType UNSET = new IdType(TypeState.UNSET);

        #region State management
        public bool IsValid {
            get { return myValue.IsValid; }
        }

        public bool IsDefault {
            get { return myValue.IsDefault; }
        }

        public bool IsUnset {
            get { return myValue.IsUnset; }
        }

        #endregion

        #region Constructors
        private IdType(TypeState state) {
            if (state == TypeState.DEFAULT) {
                myValue = IntegerType.DEFAULT;
            } else if (state == TypeState.UNSET) {
                myValue = IntegerType.UNSET;
            } else {
                myValue = new IntegerType(0);
            }
        }

        public IdType(IntegerType value) {
            myValue = value;
        }

        public IdType(Int32 value) {
            myValue = value;
        }
        #endregion

        public static IdType Parse(String value) {
            return new IdType(IntegerType.Parse(value));
        }

        public override System.String ToString() {
            return myValue.ToString();
        }

        public System.String Display() {
            return myValue.Display();
        }

        public int ToInt32() {
            if (!IsValid) {
                throw new InvalidStateException(myValue.ToString());
            }

            return myValue.ToInt32();
        }

        public static implicit operator IdType(int castFrom) {
            IdType returnType = new IdType(castFrom);

            return returnType;
        }

        #region Equality operators and methods
        public override bool Equals(Object value) {
            if (value is IdType) {
                return Compare(this, (IdType)value) == 0;
            }

            return false;
        }

        public override int GetHashCode() {
            return myValue.GetHashCode();
        }

        public static int Compare(IdType leftHand, IdType rightHand) {
            if (leftHand.myValue.IsValid && rightHand.myValue.IsValid) {
                if (leftHand.myValue < rightHand.myValue) {
                    return -1;
                }

                if (leftHand.myValue == rightHand.myValue) {
                    return 0;
                }

                if (leftHand.myValue > rightHand.myValue) {
                    return 1;
                }
            }

            if (leftHand.myValue.IsUnset) {
                if (rightHand.myValue.IsDefault || rightHand.myValue.IsValid) {
                    return -1;
                }

                if (rightHand.myValue.IsUnset) {
                    return 0;
                }
            }

            if (leftHand.myValue.IsDefault) {
                if (rightHand.myValue.IsDefault) {
                    return 0;
                }

                if (rightHand.myValue.IsUnset) {
                    return 1;
                }

                return -1;
            }

            if (leftHand.myValue.IsValid) {
                return 1;
            }

            //should this throw an exception?
            return 0;
        }

        #region Equality operators
        public static bool operator ==(IdType leftHand, IdType rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(IdType leftHand, IdType rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator ==(IdType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue == rightHand;
        }

        public static bool operator !=(IdType leftHand, int rightHand) {
            if (!leftHand.IsValid) {
                return false;
            }

            return leftHand.myValue != rightHand;
        }
        #endregion
        #endregion

        public Int32 CompareTo(Object o) {
            if (!(o is IdType)) {
                throw new ArgumentException("Argument must be an instance of IdType");
            }

            IdType that = (IdType)o;

            if (this.IsDefault) {
                if (that.IsDefault) {
                    return 0;
                } else {
                    return -1;
                }
            }

            if (this.IsUnset) {
                if (that.IsUnset) {
                    return 0;
                } else if (that.IsDefault) {
                    return 1;
                } else {
                    return -1;
                }
            }

            if (!that.IsValid) {
                return 1;
            }

            if (this.IsValid && that.IsValid) {
                return myValue.CompareTo(that.myValue);
            }

            //return Compare(that);
            return Compare(this, that);
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        IdType(SerializationInfo info, StreamingContext context) {
            myValue = new IntegerType((Int32)(info.GetValue("myValue", typeof(Int32))));
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
            if (this.Equals(DEFAULT)) {
                info.SetType(typeof(IdType_DEFAULT));
            } else if (this.Equals(UNSET)) {
                info.SetType(typeof(IdType_UNSET));
            } else {
                info.SetType(typeof(IdType));
                info.AddValue("myValue", myValue.ToInt32());
            }
        }

    }

    [Serializable]
    public struct IdType_DEFAULT : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IdType.DEFAULT;
        }
    }

    [Serializable]
    public struct IdType_UNSET : IObjectReference {
        public object GetRealObject(StreamingContext context) {
            return IdType.UNSET;
        }
    }
}
