using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlLiteralPredicate.
    /// </summary>
    public class SqlLiteralPredicate : SqlPredicate {
    	
    	private String value;
	private IDataParameterCollection parameters;

	public SqlLiteralPredicate(String value) {
	    this.value = value;
	    parameters = new SqlParameterList();
	}
	public SqlLiteralPredicate(String value, IDataParameterCollection parameters) {
	    this.value = value;
	    this.parameters = parameters;
	}
    	
	public override String Expression {
	    get {
	    	return " " + value;
	    }
	}

	public override IDataParameterCollection Parameters {
	    get {
		return parameters;
	    }
	}

    }
}
