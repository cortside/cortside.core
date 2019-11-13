using System;
using System.Data;

namespace Spring2.Core.DAO {
	
    /// <summary>
    /// Summary description for SqlPredicate.
    /// </summary>
    public abstract class SqlPredicate : IDatabaseExpression {
    	
    	public abstract string Expression {
    	    get;
    	}

    	public abstract IDataParameterCollection Parameters {
    	    get;
    	}
    	
    	/// <summary>
    	/// Escape keywords and object names with special characters
    	/// </summary>
    	/// <param name="s"></param>
    	/// <returns></returns>
    	public String Escape(String s) {
    	    return SqlUtility.Escape(s);
    	}
    	
	/// <summary>
	/// Handle quoting of strings that may contain quotes
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public String Quote(String s) {
	    return SqlUtility.Quote(s);
	}
    	
	/// <summary>
	/// Returns a new String with all special characters replaced with specified value
	/// </summary>
	/// <param name="s"></param>
	/// <param name="replace"></param>
	/// <returns></returns>
	public String ReplaceSpecialCharacters(String s, String replace) {
	    return SqlUtility.ReplaceSpecialCharacters(s, replace);
	}
    	
	/// <summary>
	/// Returns a new String with all special characters replaced with underscores
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public String ReplaceSpecialCharacters(String s) {
	    return SqlUtility.ReplaceSpecialCharacters(s, "_");
	}

    	
    }
}
