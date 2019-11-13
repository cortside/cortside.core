using System;

namespace Spring2.Core.Types.Generic {

    [Serializable]
    public struct DataType<T> : IDataType where T : struct, IComparable { //, IComparable, IFormattable, ISerializable {

        private T myValue;
        private TypeState myState;

        public DataType(TypeState state) {
            myValue = default(T);
            myState = state;
        }

        public DataType(T value) {
            myValue = value;
            myState = TypeState.VALID;
        }

        public bool IsValid {
            get { return myState == TypeState.VALID; }
        }

        public bool IsDefault {
            get { return myState == TypeState.DEFAULT; }
        }

        public bool IsUnset {
            get { return myState == TypeState.UNSET; }
        }

        public T Value {
            get {
                if (myState != TypeState.VALID) {
                    throw new InvalidOperationException("DataType object must have a value.");
                }

                return myValue;
            }
        }

        // not right -- changed from Nullable
        public override bool Equals(object other) {
            if (other == null)
                return false;

            if (!(other is DataType<T>))
                return false;

            return Equals((DataType<T>)other);
        }

        // not right -- changed from Nullable
        bool Equals(DataType<T> other) {
            if (other == null) {
                return false;
            }
            if (other.myState != myState)
                return false;

            if (IsValid == false)
                return true;

            return other.myValue.Equals(myValue);
        }

        // not right -- changed from Nullable
        public override int GetHashCode() {
            if (!IsValid)
                return 0;

            return myValue.GetHashCode();
        }

        public T GetValueOrDefault() {
            return GetValueOrDefault(default(T));
        }

        public T GetValueOrDefault(T def_value) {
            if (!IsValid)
                return def_value;
            else
                return myValue;
        }

        public override string ToString() {
            if (IsValid) {
                return myValue.ToString();
            } else if (IsDefault) {
                return "DEFAULT";
            } else {
                return "UNSET";
            }
        }

        public static implicit operator DataType<T>(T value) {
            return new DataType<T>(value);
        }

        public static explicit operator T(DataType<T> value) {
            return value.Value;
        }

        public static int Compare(DataType<T> leftHand, DataType<T> rightHand) {
            if (leftHand.IsValid && rightHand.IsValid) {
                return leftHand.Value.CompareTo(rightHand.Value);
            }

            if (leftHand.myState == TypeState.UNSET) {
                if (rightHand.myState == TypeState.DEFAULT || rightHand.myState == TypeState.VALID) {
                    return -1;
                }

                if (rightHand.myState == TypeState.UNSET) {
                    return 0;
                }
            }

            if (leftHand.myState == TypeState.DEFAULT) {
                if (rightHand.myState == TypeState.DEFAULT) {
                    return 0;
                }

                if (rightHand.myState == TypeState.UNSET) {
                    return 1;
                }

                return -1;
            }

            if (leftHand.myState == TypeState.VALID) {
                return 1;
            }

            //should this throw an exception?
            return 0;
        }

        public static int Compare(DataType<T> leftHand, T rightHand) {
            if (leftHand.IsValid) {
                return leftHand.Value.CompareTo(rightHand);
            }

            if (leftHand.myState == TypeState.UNSET) {
                return -1;
            }

            if (leftHand.myState == TypeState.DEFAULT) {
                return -1;
            }

            //should this throw an exception?
            return 0;
        }

        #region Equality operators
        public static bool operator ==(DataType<T> leftHand, DataType<T> rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(DataType<T> leftHand, DataType<T> rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }

        public static bool operator ==(DataType<T> leftHand, T rightHand) {
            return Compare(leftHand, rightHand) == 0;
        }

        public static bool operator !=(DataType<T> leftHand, T rightHand) {
            return Compare(leftHand, rightHand) != 0;
        }
        #endregion

        #region < and > operators
        public static bool operator <(DataType<T> leftHand, DataType<T> rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator >(DataType<T> leftHand, DataType<T> rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }

        public static bool operator <(DataType<T> leftHand, T rightHand) {
            return Compare(leftHand, rightHand) < 0;
        }

        public static bool operator >(DataType<T> leftHand, T rightHand) {
            return Compare(leftHand, rightHand) > 0;
        }
        #endregion

        // These are called by the JIT
        // Ironicly, the C#  code is the same for these two,
        // however, on the inside they do somewhat different things
        static object Box(T? o) {
            if (o == null)
                return null;
            return (T)o;
        }

        static T? Unbox(object o) {
            if (o == null)
                return null;
            return (T)o;
        }

    }

}
