using System;

using Spring2.Core.Types;

namespace Spring2.Core.DataObject {
    /// <summary>
    /// Information about a comparison failure for a single property.  Used
    /// to return comparison info from the DataObject Compare method.
    /// </summary>
    public class DataObjectCompareDetail {
	private String propertyName;
	private DataType value1;
	private DataType value2;

	/// <summary>
	/// Creates the compare detail object.
	/// </summary>
	/// <param name="propertyName">Fully qualified name of property with difference - such as EventPageData.Events[2].EventId</param>
	/// <param name="value1">Value of first object.  This is the object the Compare method was called on.</param>
	/// <param name="value2">Value of second object.  This is the object passed as a paramter to the Compare method.</param>
	public DataObjectCompareDetail(String propertyName, DataType value1, DataType value2) {
	    this.propertyName = propertyName;
	    this.value1 = value1;
	    this.value2 = value2;
	}

	/// <summary>
	/// Fully qualified name of the property with the difference - i.e. EventPage.Events[2].EventId
	/// </summary>
	public String PropertyName {
	    get { return this.propertyName; }
	    set { this.propertyName = value; }
	}

	/// <summary>
	/// Value of the property in the first object.  This is the object the Compare method was called on.
	/// </summary>
	public DataType Value1 {
	    get { return this.value1; }
	    set { this.value1 = value; }
	}

	/// <summary>
	/// Value of the property in the second object.  This is the object passed as a parameter to the Compare method.
	/// </summary>
	public DataType Value2 {
	    get { return this.value2; }
	    set { this.value2 = value; }
	}

	/// <summary>
	/// Gives string representation of the object contents.
	/// </summary>
	/// <returns>A representation of the object contents.</returns>
	public override String ToString() {
	    return "Name='" + propertyName + "' value1='" + value1.ToString() + "' value2='" + value2.ToString() + "'";
	}
    }
}
