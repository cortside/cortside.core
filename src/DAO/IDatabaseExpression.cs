using System;
using System.Data;

namespace Spring2.Core.DAO {
	
    /// <summary>
    /// Summary description for IDatabaseExpression.
    /// </summary>
    public interface IDatabaseExpression {

    	String Expression {
    	    get;
    	}
    	
	IDataParameterCollection Parameters {
	    get;
	}
    
    }
}
