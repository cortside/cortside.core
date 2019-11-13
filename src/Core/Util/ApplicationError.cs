using System;

namespace Cortside.Core.Util {

    /// <summary>
    /// Represents an error caused by user input.
    /// </summary>
    public abstract class ApplicationError {

        private readonly String propertyName;
        private String message;

        /// <summary>
        /// Creates an application error from the given property name.
        /// </summary>
        /// <param name="propertyName">the name of the property associated with the error.</param>
        public ApplicationError(String propertyName) {
            this.propertyName = propertyName == null ? String.Empty : propertyName;
        }

        /// <summary>
        /// Creates an application error given a property name and a message.
        /// </summary>
        /// <param name="propertyName">the name of the property associated with the error.</param>
        /// <param name="message">a message describing the error.</param>
        public ApplicationError(String propertyName, String message) {
            this.propertyName = propertyName == null ? String.Empty : propertyName;
            this.message = message == null ? String.Empty : message;
        }

        /// <summary>
        /// Read-only property for accessing the property name of the error.
        /// </summary>
        public String PropertyName {
            get { return propertyName; }
        }

        /// <summary>
        /// Property for getting and setting a unique message associated with the error.
        /// </summary>
        public String Message {
            get { return message; }
            set { message = value == null ? String.Empty : value; }
        }

        public abstract String FormatMessage(String displayName);
    }
}
