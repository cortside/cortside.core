using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlInPredicate.
    /// </summary>
    public class SqlInPredicate : SqlPredicate {

	private String columnName;
	private Object[] values;
	private Boolean not = false;
	private SqlDbType dbType;
    	
    	public SqlInPredicate(String columnName, Int64[] values) {
    	    this.columnName = columnName;
    	    this.values = new Object[values.Length];
    	    values.CopyTo(this.values, 0);
    	    dbType = SqlDbType.BigInt;
	}
    	
	public SqlInPredicate(String columnName, Int64[] values, Boolean not) {
	    this.columnName = columnName;
	    this.values = new Object[values.Length];
	    values.CopyTo(this.values, 0);
	    this.not = not;
	    dbType = SqlDbType.BigInt;
	}

	public SqlInPredicate(String columnName, Int32[] values) {
	    this.columnName = columnName;
	    this.values = new Object[values.Length];
	    values.CopyTo(this.values, 0);
	    dbType = SqlDbType.Int;
	}

	public SqlInPredicate(String columnName, Int32[] values, Boolean not) {
	    this.columnName = columnName;
	    this.values = new Object[values.Length];
	    values.CopyTo(this.values, 0);
	    this.not = not;
	    dbType = SqlDbType.Int;
	}

	public override String Expression {
	    get {
	    	StringBuilder sb = new StringBuilder();
	    	for(Int32 i=0; i<values.Length; i++) {
		    if (i>0) {
		    	sb.Append(", ");
		    }
	    	    sb.Append("@").Append(columnName.Replace(".","_")).Append((i+1).ToString());
	    	}
		return String.Format(" {0} {1}IN ({2})", columnName, not ? "NOT " : String.Empty, sb.ToString());
	    }
	}

	public override IDataParameterCollection Parameters {
	    get {
		SqlParameterList parameters = new SqlParameterList();
		for(Int32 i=0; i<values.Length; i++) {
		    parameters.Add("@" + columnName.Replace(".","_") + (i+1).ToString(), dbType, values[i]);
		}
		return parameters;
	    }
	}

    }
}
