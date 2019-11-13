using System;
using System.Runtime.Serialization;

namespace Spring2.Core.Types {
    [Serializable]
    public class TypesException : System.Exception, ISerializable {
        public TypesException() {
        }

        public TypesException(string message)
            : base(message) {
        }

        public TypesException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidValueException : TypesException {
        public InvalidValueException(TypeState state)
            : base(string.Format("State is {0} should be VALID", state.ToString())) {
        }

        public InvalidValueException(TypeState leftState, TypeState rightState)
            : base(string.Format("Invalid state. left and right should be VALID but are ({0}, {1})", leftState.ToString(), rightState.ToString())) {
        }

        public InvalidValueException(TypeState stateOne, TypeState stateTwo, TypeState stateThree)
            : base(string.Format("Invalid state. states should be VALID but are ({0}, {1}, {2})", stateOne.ToString(), stateTwo.ToString(), stateThree.ToString())) {
        }

        public InvalidValueException(string message)
            : base(message) {
        }

        public InvalidValueException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidStateException : TypesException {
        public InvalidStateException(TypeState state)
            : base(string.Format("State is {0} should be VALID", state.ToString())) {
        }

        public InvalidStateException(TypeState leftState, TypeState rightState)
            : base(string.Format("Invalid state. left and right should be VALID but are ({0}, {1})", leftState.ToString(), rightState.ToString())) {
        }

        public InvalidStateException(TypeState stateOne, TypeState stateTwo, TypeState stateThree)
            : base(string.Format("Invalid state. states should be VALID but are ({0}, {1}, {2})", stateOne.ToString(), stateTwo.ToString(), stateThree.ToString())) {
        }

        public InvalidStateException(string message)
            : base(message) {
        }
        public InvalidStateException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidArgumentException : TypesException {
        public InvalidArgumentException(string argumentName)
            : base("Invalid argument '" + argumentName + "'") {
        }
        public InvalidArgumentException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidTypeException : TypesException {
        public InvalidTypeException(string argumentName)
            : base("Invalid type. expected '" + argumentName + "'") {
        }
        public InvalidTypeException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidConversionException : TypesException {
        public InvalidConversionException(string fromType, string toType)
            : base("Invalid type when converting from '" + fromType + "' to '" + toType + "'") {
        }
        public InvalidConversionException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidTypeCastException : TypesException {
        public InvalidTypeCastException(string fromType, string toType)
            : base("Invalid type when casting from '" + fromType + "' to '" + toType + "'") {
        }

        public InvalidTypeCastException(string message)
            : base("message") {
        }
        public InvalidTypeCastException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class NotImplementedException : TypesException {
        public NotImplementedException(string methodName)
            : base("Unimplemented method '" + methodName + "'") {
        }
        public NotImplementedException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class InvalidFormatException : TypesException {
        public InvalidFormatException(string typeName)
            : base("Invalid format for type '" + typeName + "'") {
        }
        public InvalidFormatException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }

    [Serializable]
    public class ValueOverflowException : TypesException {
        public ValueOverflowException(string valueName)
            : base(String.Format("Value overflow for value '{0}'", valueName)) {
        }

        public ValueOverflowException(string from, string to)
            : base(String.Format("Value overflow converting from type '{0}' to type '{1}'", from, to)) {
        }
        public ValueOverflowException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt) { }
    }
}
