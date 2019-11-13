using System;
using System.Collections;
using System.Reflection;
using System.Text;

using Spring2.Core.Types;

namespace Spring2.Core.DataObject {
    
    /// <summary>
    /// Abstract base class for data objects.
    /// </summary>
    [Serializable()]
    public abstract class DataObject {

	private static readonly String SINGLE_INDENT = "    ";

	/// <summary>
	/// Creates a string representation of the DataObject.
	/// </summary>
	/// <returns>String representing the data object.</returns>
	public override String ToString() {
	    return ToString(0);
	}

	/// <summary>
	/// Creates a string representation of the DataObject indented to indentLevel (for nested objects)
	/// </summary>
	/// <returns>String representing the data object.</returns>
	public String ToString(Int32 indentLevel) {

	    String indent = String.Empty;
	    for (int i = 0; i < indentLevel; i++) {
		indent += SINGLE_INDENT;
	    }

	    StringBuilder sb = new StringBuilder();
	    foreach (PropertyInfo p in GetType().GetProperties()) {
		Object value = p.GetValue(this, null);

		sb.Append(indent);
		sb.Append(p.Name + ": ");
		if (value is DataObject) {
		    DataObject o = value as DataObject;
		    if (o.IsEmpty()) {
			sb.Append("EMPTY").Append(Environment.NewLine);
		    } else {
			sb.Append(Environment.NewLine);
			sb.Append(((DataObject)value).ToString(indentLevel+1));
		    }
		} else if (value is ICollection) {
		    ICollection collection = (ICollection)value;
		    sb.Append(value.GetType().Name).Append(" (count=").Append(collection.Count).Append(")").Append(Environment.NewLine);
		    foreach (Object item in collection) {
			sb.Append(indent).Append(SINGLE_INDENT).Append("Item: ");
			if (item is DataObject) {
			    sb.Append(Environment.NewLine).Append(((DataObject)item).ToString(indentLevel+2));
			} else {
			    sb.Append(item.ToString());
			    sb.Append(Environment.NewLine);
			}
		    }
		} else {
		    sb.Append(value.ToString());
		    sb.Append(Environment.NewLine);
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
		}
		else {
		    if (!value1.Equals(value2)) {
			return false;
		    }
		}
	    }

	    return true;
	}

	/// <summary>
	/// Does a deep compare of the current object with the passed object.
	/// </summary>
	/// <param name="obj">Object to compare current object with.</param>
	/// <returns>List of differences between the objects.</returns>
	public DataObjectCompareList Compare(DataObject obj) {
	    return Compare(obj, this.GetType().Name, DataObjectCompareOptionEnum.COMPARE_ALL);
	}

	/// <summary>
	/// Does a deep compare of the current object with the passed object.
	/// </summary>
	/// <param name="obj">Object to compare current object with.</param>
	/// <param name="option">Allows customization of how DEFAULT values are compared.</param>
	/// <returns>List of differences between the objects.</returns>
	public DataObjectCompareList Compare(DataObject obj, DataObjectCompareOptionEnum option) {
	    return Compare(obj, this.GetType().Name, option);
	}

	/// <summary>
	/// Does a deep compare of the current object with the passed object.
	/// </summary>
	/// <param name="obj">Object to compare current object with.</param>
	/// <param name="prefix">Prefix to use when identifying properties.</param>
	/// <param name="option">Allows customization of how DEFAULT values are compared.</param>
	/// <returns>List of differences between the objects.</returns>
	public DataObjectCompareList Compare(DataObject obj, String prefix,
	    DataObjectCompareOptionEnum option) {
	    DataObjectCompareList returnValue = new DataObjectCompareList();
	    if (obj == null) {
		returnValue.Add(new DataObjectCompareDetail(prefix, 
		    StringType.Parse("Data Object"), StringType.Parse("Null Data Object")));
		return returnValue;
	    }

	    if (obj == this) {
		return returnValue;
	    }

	    if (!GetType().Equals(obj.GetType())) {
		returnValue.Add(new DataObjectCompareDetail(prefix, 
		    StringType.Parse("different types"), 
		    StringType.Parse("different types")));
		return returnValue;
	    }

	    foreach (PropertyInfo p in GetType().GetProperties()) {
		Object value1 = p.GetValue(this, null);
		Object value2 = p.GetValue(obj, null);
		String valuePrefix = prefix + "." + p.Name;
		if (value1 is ICollection && value2 is ICollection) {
		    ICollection collection1 = (ICollection)value1;
		    ICollection collection2 = (ICollection)value2;
		    if (collection1.Count != collection2.Count) {
			returnValue.Add(new DataObjectCompareDetail(
			    valuePrefix
			    + ".Count", 
			    new IntegerType(collection1.Count), 
			    new IntegerType(collection2.Count)));
		    }
		    else {
			IEnumerator enumerator1 = collection1.GetEnumerator();
			IEnumerator enumerator2 = collection2.GetEnumerator();
			int whichOccurrence = 0;
			while (enumerator1.MoveNext() && enumerator2.MoveNext()) {
			    String collectionPrefix = valuePrefix
				+ "[" + whichOccurrence.ToString() + "]";
			    if (enumerator1.Current is DataObject && enumerator2.Current is DataObject) {
				returnValue.Append(((DataObject)(enumerator1.Current)).Compare(
				    (DataObject)(enumerator2.Current), 
				    collectionPrefix, option));
			    } 
			    else  if (enumerator1.Current is DataType 
				&& enumerator2.Current is DataType) {
				if (!CompareDataTypes((DataType)(enumerator1.Current),
				    (DataType)(enumerator2.Current),
				    option)) {
				    returnValue.Add(new DataObjectCompareDetail(collectionPrefix,
					(DataType)(enumerator1.Current),
					(DataType)(enumerator2.Current)));
				}
			    }
			    else {
				if (!enumerator1.Current.Equals(enumerator2.Current)) {
				    returnValue.Add(new DataObjectCompareDetail(
					collectionPrefix,
					StringType.Parse("Not DataType"),
					StringType.Parse("Not DataType")));
				}
			    }
			    whichOccurrence++;
			}
		    }
		}
		else if (value1 is DataObject && value2 is DataObject) {
		    returnValue.Append(((DataObject)value1).Compare(
			(DataObject)value2,
			valuePrefix, option));
		}
		else {
		    if (!value1.Equals(value2)) { 
			if (value1 is DataType && value2 is DataType) {
			    if (!CompareDataTypes((DataType)value1, (DataType)value2, option)) {
				returnValue.Add(new DataObjectCompareDetail(valuePrefix,
				    (DataType)value1,
				    (DataType)value2));
			    }
			}
			else {
			    DataType v1;
			    DataType v2;
			    if (value1 is DataType) {
				v1 = (DataType)value1;
			    }
			    else {
				v1 = StringType.Parse("Not DataType");
			    }
			    if (value2 is DataType) {
				v2 = (DataType)value2;
			    }
			    else {
				v2 = StringType.Parse("Not DataType");
			    }
			    returnValue.Add(new DataObjectCompareDetail(valuePrefix, v1, v2));
			}
		    }
		}
	    }

	    return returnValue;
	}

	/// <summary>
	/// Returns a hash code.
	/// </summary>
	/// <returns>Hash code value</returns>
	public override int GetHashCode() {
	    int hashCode = 0;
	    foreach (PropertyInfo p in GetType().GetProperties()) {
		hashCode = (hashCode + p.GetValue(this, null).GetHashCode()) % 2000000000;
	    }

	    return hashCode;
	}

	/// <summary>
	/// Updates the current DataObject instance with values from the
	/// passed DataObject instance.  Contained DataObjects are also updated.
	/// Instance values set to Default are not copied.  Collections in the 
	/// DataObject are ignored.
	/// </summary>
	/// <param name="that">Object to copy from.</param>
	public void Update(DataObject that) {

	    if (GetType().IsInstanceOfType(that)) {
		foreach (PropertyInfo p in GetType().GetProperties()) {
		    Object value = p.GetValue(that, null);
		    if (value is DataType) {
			if (!((DataType)value).IsDefault) {
			    p.SetValue(this, value, null);
			}
		    } 
		    else if (value is DataObject) {
			((DataObject)(p.GetValue(this, null))).Update((DataObject)value);
		    }
		}
	    }
	}

	/// <summary>
	/// Compares two data types based on the enum passed.
	/// </summary>
	/// <param name="v1">First Value</param>
	/// <param name="v2">Second Value</param>
	/// <param name="option">option value to use</param>
	private bool CompareDataTypes(DataType v1, DataType v2,
	    DataObjectCompareOptionEnum option) {
	    bool found = false;
	    if (v1.Equals(v2)) {
		found = true;
	    }
	    if (!found) {
		if (option.Equals(DataObjectCompareOptionEnum.IGNORE_DEFAULT)
		    && (v1.IsDefault || v2.IsDefault)) {
		    found = true;
		}
		else if (option.Equals(DataObjectCompareOptionEnum.DEFAULT_EQUALS_UNSET)
		    && ((v1.IsUnset && v2.IsDefault)
		    || (v1.IsDefault && v2.IsUnset))) {
		    found = true;
		}
	    }

	    return found;
	}
    }
}
