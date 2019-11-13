using System;

namespace Spring2.Core.Types {

    /// <summary>
    /// Indicates that a property value is required to be mapped from the request
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute {

        public RequiredAttribute() {
        }

    }
}
