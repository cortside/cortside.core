using System;
using System.Collections;

using Spring2.Core.Types;

namespace Spring2.Core.DataObject {
    /// <summary>
    /// List of compare options available for the DataObject.Compare method
    /// </summary>
    public class DataObjectCompareOptionEnum : EnumDataType {

	private static readonly IList OPTIONS = new ArrayList();

	public static readonly new DataObjectCompareOptionEnum DEFAULT = new DataObjectCompareOptionEnum();
	public static readonly new DataObjectCompareOptionEnum UNSET = new DataObjectCompareOptionEnum();

	public static readonly DataObjectCompareOptionEnum COMPARE_ALL = new DataObjectCompareOptionEnum("A", "Compare all items");
	public static readonly DataObjectCompareOptionEnum IGNORE_DEFAULT = new DataObjectCompareOptionEnum("D", "Default matches anything");
	public static readonly DataObjectCompareOptionEnum DEFAULT_EQUALS_UNSET = new DataObjectCompareOptionEnum("D", "DEFAULT matches UNSET");

	public static DataObjectCompareOptionEnum GetInstance(Object value) {
	    if (value is String) {
		foreach (DataObjectCompareOptionEnum t in OPTIONS) {
		    if (t.Value.Equals(value)) {
			return t;
		    }
		}
	    }

	    return UNSET;
	}

	private DataObjectCompareOptionEnum() {}

	private DataObjectCompareOptionEnum(String code, String name) {
	    this.code = code;
	    this.name = name;
	    OPTIONS.Add(this);
	}

	public override Boolean IsDefault {
	    get { return Object.ReferenceEquals(this, DEFAULT); }
	}

	public override Boolean IsUnset {
	    get { return Object.ReferenceEquals(this, UNSET); }
	}

	public static IList Options {
	    get { return OPTIONS; }
	}
    }
}
