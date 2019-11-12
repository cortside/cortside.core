using System;
using System.Collections;

namespace Spring2.Core.DataObject {
    /// <summary>
    /// A colleciton of DataObjectCompareDetail objects.
    /// </summary>
    public class DataObjectCompareList : System.Collections.CollectionBase {
	/// <summary>
	/// Indicates if this collection is modifiable.  The UNSET instance is not
	/// modifiable
	/// </summary>
	private Boolean immutable = false;

	/// <summary>
	/// Constructor used to create an immutable instance.
	/// </summary>
	/// <param name="immutable"></param>
	private DataObjectCompareList (Boolean immutable) {
	    this.immutable = immutable;
	}

	/// <summary>
	/// Constructor to create a modifiable instance.
	/// </summary>
	public DataObjectCompareList() {
	}

	/// <summary>
	/// Allows referencing of a object in the list via an index.
	/// </summary>
	public DataObjectCompareDetail this[int index] {
	    get { return (DataObjectCompareDetail) List[index]; }
	}

	/// <summary>
	/// Adds a DataObjectCompareDetail instance to the list.
	/// </summary>
	/// <param name="a"></param>
	public void Add(DataObjectCompareDetail a) {
	    if (!immutable) {
		List.Add(a);
	    } 
	    else {
		// This happens if we try to add an object to teh UNSET instance.
		throw new System.Data.ReadOnlyException();
	    }
	}

	/// <summary>
	/// Removes an instance from the list.
	/// </summary>
	/// <param name="index">Index of the instance to remove.</param>
	public void Remove(int index) {
	    if (!immutable) {
		if (index > Count - 1 || index < 0) {
		    throw new IndexOutOfRangeException();
		} 
		else {
		    List.RemoveAt(index); 
		}
	    } 
	    else {
		// this happens if we try to remove an instance from the UNSET list.
		throw new System.Data.ReadOnlyException();
	    }
	}

	/// <summary>
	/// Appends list passed as parameter to the current list.
	/// </summary>
	/// <param name="list">List to append</param>
	public void Append(DataObjectCompareList list) {
	    IEnumerator it = list.GetEnumerator();
	    while (it.MoveNext()) {
		this.Add((DataObjectCompareDetail)(it.Current));
	    }
	}

	/// <summary>
	/// Gives string representation of the object contents.
	/// </summary>
	/// <returns>A representation of the object contents.</returns>
	public override String ToString() {
	    if (this.Count == 0) {
		return "Empty List";
	    }

	    IEnumerator il = this.GetEnumerator();
	    String returnValue = "";
	    while (il.MoveNext()) {
		returnValue = returnValue
		    + ((DataObjectCompareDetail)(il.Current)).ToString() 
		    + "\n";
	    }
	    return returnValue;
	}
    }
}
