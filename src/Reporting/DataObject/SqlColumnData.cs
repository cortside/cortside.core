using System;

using Spring2.Core.Types;

namespace Spring2.Core.Reporting {
    public class SqlColumnData : Spring2.Core.DataObject.DataObject {

	private StringType name = StringType.DEFAULT;
	private StringType type = StringType.DEFAULT;
	private StringType sqlObject = StringType.DEFAULT;
	private IntegerType ordinalPosition = IntegerType.DEFAULT;
	private IntegerType length = IntegerType.DEFAULT;
	private IntegerType precision = IntegerType.DEFAULT;
	private IntegerType scale = IntegerType.DEFAULT;

	public static readonly String NAME = "Name";
	public static readonly String TYPE = "Type";
	public static readonly String SQLOBJECT = "SqlObject";
	public static readonly String ORDINALPOSITION = "OrdinalPosition";
	public static readonly String LENGTH = "Length";
	public static readonly String PRECISION = "Precision";
	public static readonly String SCALE = "Scale";

	public StringType Name {
	    get { return this.name; }
	    set { this.name = value; }
	}

	public StringType Type {
	    get { return this.type; }
	    set { this.type = value; }
	}

	public StringType SqlObject {
	    get { return this.sqlObject; }
	    set { this.sqlObject = value; }
	}

	public IntegerType OrdinalPosition {
	    get { return this.ordinalPosition; }
	    set { this.ordinalPosition = value; }
	}

	public IntegerType Length {
	    get { return this.length; }
	    set { this.length = value; }
	}

	public IntegerType Precision {
	    get { return this.precision; }
	    set { this.precision = value; }
	}

	public IntegerType Scale {
	    get { return this.scale; }
	    set { this.scale = value; }
	}
    }
}
