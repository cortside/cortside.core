using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Spring2.Core.DataObject {

    /// <summary>
    /// Abstract base class for data objects.
    /// </summary>
    [Serializable()]
    public abstract class DataObject {

        private static readonly String SINGLE_INDENT = "    ";

        protected virtual Int32 MaximumIndentLevel {
            get { return 5; }
        }

        /// <summary>
        /// Creates a string representation of the DataObject.
        /// </summary>
        /// <returns>String representing the data object.</returns>
        public override String ToString() {
            return ToString(0);
        }

        public String ToString(Int32 indentLevel) {
            return ToString(indentLevel, true);
        }

        /// <summary>
        /// Creates a string representation of the DataObject indented to indentLevel (for nested objects)
        /// </summary>
        /// <returns>String representing the data object.</returns>
        public String ToString(Int32 indentLevel, Boolean recurse) {
            String indent = String.Empty;
            for (int i = 0; i < indentLevel; i++) {
                indent += SINGLE_INDENT;
            }

            if (indentLevel > MaximumIndentLevel) {
                return indent + "NESTING LEVEL EXCEEDED" + Environment.NewLine;
            }

            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo p in GetType().GetProperties()) {
                if (!p.GetGetMethod().IsStatic) {
                    Object value;

                    // get the value, but handle any unfriendly exceptions by outputing that as the value
                    try {
                        value = p.GetValue(this, null);
                    } catch (Exception ex) {
                        value = ex.ToString();
                    }

                    sb.Append(indent);
                    sb.Append(p.Name + ": ");
                    if (value is DataObject) {
                        DataObject o = value as DataObject;
                        if (o.IsEmpty()) {
                            sb.Append("EMPTY").Append(Environment.NewLine);
                        } else {
                            sb.Append(Environment.NewLine);
                            if (recurse) {
                                if (value.GetType().Equals(this.GetType())) {
                                    sb.Append(((DataObject)value).ToString(indentLevel + 1, false));
                                } else {
                                    sb.Append(((DataObject)value).ToString(indentLevel + 1));
                                }
                            }
                        }
                    } else if (value is ICollection) {
                        ICollection collection = (ICollection)value;
                        sb.Append(value.GetType().Name).Append(" (count=").Append(collection.Count).Append(")").Append(Environment.NewLine);
                        if (recurse) {
                            foreach (Object item in collection) {
                                sb.Append(indent).Append(SINGLE_INDENT).Append("Item: ");
                                if (item is DataObject) {
                                    if (item.GetType().Equals(this.GetType())) {
                                        sb.Append(Environment.NewLine).Append(((DataObject)item).ToString(indentLevel + 2, false));
                                    } else {
                                        sb.Append(Environment.NewLine).Append(((DataObject)item).ToString(indentLevel + 2));
                                    }
                                } else {
                                    sb.Append(item.ToString());
                                    sb.Append(Environment.NewLine);
                                }
                            }
                        }
                    } else {
                        sb.Append(value == null ? "<NULL>" : value.ToString());
                        sb.Append(Environment.NewLine);
                    }
                }
            }

            return sb.ToString();
        }

        public virtual Boolean IsEmpty() {
            return false;
        }

        /// <summary>
        /// Does a deep compare of the current object with the passed object.
        /// </summary>
        /// <param name="obj">Object to compare current object with.</param>
        /// <returns>True if objects are equal, false otherwise.</returns>
        public override Boolean Equals(Object obj) {
            if (obj == null) {
                return false;
            }

            if (obj == this) {
                return true;
            }

            if (!GetType().Equals(obj.GetType())) {
                return false;
            }

            if (Object.ReferenceEquals(this, obj)) {
                return true;
            }

            foreach (PropertyInfo p in GetType().GetProperties()) {
                Object value1 = p.GetValue(this, null);
                Object value2 = p.GetValue(obj, null);
                if (value1 is ICollection) {
                    ICollection collection1 = (ICollection)value1;
                    ICollection collection2 = (ICollection)value2;
                    if (collection1.Count != collection2.Count) {
                        return false;
                    }

                    IEnumerator enumerator1 = collection1.GetEnumerator();
                    IEnumerator enumerator2 = collection2.GetEnumerator();
                    while (enumerator1.MoveNext() && enumerator2.MoveNext()) {
                        if (!enumerator1.Current.Equals(enumerator2.Current)) {
                            return false;
                        }
                    }
                } else {
                    if (!value1.Equals(value2)) {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code.
        /// </summary>
        /// <returns>Hash code value</returns>
        public override int GetHashCode() {
            int hashCode = 0;
            foreach (PropertyInfo p in GetType().GetProperties()) {
                object value = p.GetValue(this, null);
                if (value != null) {
                    hashCode = (hashCode + value.GetHashCode()) % 2000000000;
                }
            }

            return hashCode;
        }

    }
}
