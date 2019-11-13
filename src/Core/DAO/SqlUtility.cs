using System;

namespace Spring2.Core.DAO {

    /// <summary>
    /// Utilities for Sql Server related operations
    /// </summary>
    public class SqlUtility {

	/// <summary>
	/// sql keywords that need escaping.  all values need to be enclosed in a pair of | characters.  values should be lower case.
	/// </summary>
 	private static readonly String KEYWORDS = 
	    "|add|except|percent|all|exec|plan|alter|execute|precision|and|exists|primary|any|exit|print|as|fetch" +
	    "|proc|asc|file|procedure|authorization|fillfactor|public|backup|for|raiserror|begin|foreign" +
	    "|read|between|freetext|readtext|break|freetexttable|reconfigure|browse|from|references|bulk" +
	    "|full|replication|by|function|restore|cascade|goto|restrict|case|grant|return|check|group" +
	    "|revoke|checkpoint|having|right|close|holdlock|rollback|clustered|identity|rowcount|coalesce" +
	    "|identity_insert|rowguidcol|collate|identitycol|rule|column|if|save|commit|in|schema|compute" +
	    "|index|select|constraint|inner|session_user|contains|insert|set|containstable|intersect" +
	    "|setuser|continue|into|shutdown|convert|is|some|create|join|statistics|cross|key|system_user" +
	    "|current|kill|table|current_date|left|textsize|current_time|like|then|current_timestamp" +
	    "|lineno|to|current_user|load|top|cursor|national||tran|database|nocheck|transaction|dbcc" +
	    "|nonclustered|trigger|deallocate|not|truncate|declare|null|tsequal|default|nullif|union" +
	    "|delete|of|unique|deny|off|update|desc|offsets|updatetext|disk|on|use|distinct|open|user" +
	    "|distributed|opendatasource|values|double|openquery|varying|drop|openrowset|view|dummy" +
	    "|openxml|waitfor|dump|option|when|else|or|where|end|order|while|errlvl|outer|with|escape|over|writetext|min|max|";

    	private static readonly String SPECIAL_CHARACTERS = " /-";
	
	/// <summary>
	/// Escape keywords and object names with special characters
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static String Escape(String s) {
	    Boolean needsEscaping = false;

	    for(Int32 i=0; i<SPECIAL_CHARACTERS.Length; i++) {
	    	if (s.IndexOf(SPECIAL_CHARACTERS.Substring(i, 1))>=0) {
	    		needsEscaping = true;
	    	}
	    }
	    if (KEYWORDS.IndexOf("|"+s.ToLower()+"|")>=0) {
		needsEscaping = true;
	    }
	    
	    if (needsEscaping) {
		return "[" + s + "]";
	    } else {
		return s;
	    }
	}

    	/// <summary>
    	/// Handle quoting of strings that may contain quotes
    	/// </summary>
    	/// <param name="s"></param>
    	/// <returns></returns>
	public static String Quote(String s) {
	    return "'" + s.Replace("'", "''") + "'";
	}
    	
    	/// <summary>
    	/// Returns a new String with all special characters replaced with specified value
    	/// </summary>
    	/// <param name="s"></param>
    	/// <param name="replace"></param>
    	/// <returns></returns>
    	public static String ReplaceSpecialCharacters(String s, String replace) {
    	    String replacedString = s;
	    for(Int32 i=0; i<SPECIAL_CHARACTERS.Length; i++) {
	    	replacedString = replacedString.Replace(SPECIAL_CHARACTERS.Substring(i, 1), replace);
	    }
    	    return replacedString;
    	}
    	
    	/// <summary>
    	/// Returns a new String with all special characters replaced with underscores
    	/// </summary>
    	/// <param name="s"></param>
    	/// <returns></returns>
    	public static String ReplaceSpecialCharacters(String s) {
    	    return ReplaceSpecialCharacters(s, "_");
    	}

    }
}
