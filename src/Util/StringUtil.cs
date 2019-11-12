using System;

namespace Spring2.Core.Util {
    /// <summary>
    /// Collection of miscellaneous String functions
    /// </summary>
    public class StringUtil {
	private StringUtil() { }

	/// <summary>
	/// Remove trailing Environment.NewLine from end of string.  Will remove multiples if they exist.
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	public static String RemoveTrailingNewLine(String source) {
	    return RemoveTrailingString(source, Environment.NewLine);
	}

	/// <summary>
	/// Remove trailing string from end of a string.  Will remove multiples if they exist.
	/// </summary>
	/// <param name="source"></param>
	/// <param name="trailer"></param>
	/// <returns></returns>
	public static String RemoveTrailingString(String source, String trailer) {
	    while (source.EndsWith(trailer)) {
		source = source.Substring(0, source.Length - trailer.Length);
	    }
	    return source;
	}

	/// <summary>
	/// Remove trailing Environment.NewLine from end of string.  Spaces are trimmed at end and between Environment.NewLine.
	/// </summary>
	/// <param name="source"></param>
	/// <returns></returns>
	public static String RemoveTrailingBlankLines(String source) {
	    source = source.TrimEnd();
	    while (source.EndsWith(Environment.NewLine)) {
		source = RemoveTrailingString(source, Environment.NewLine).TrimEnd();
	    }
	    return source;
	}

	/// <summary>
	/// Read the contents of a file and place them in a string object.
	/// </summary>
	/// <param name="file">path to file.</param>
	/// <returns>String contents of the file.</returns>
	public static String fileContentsToString(System.String file) {
	    System.String contents = "";
			
	    System.IO.FileInfo f = new System.IO.FileInfo(file);
			
	    bool tmpBool;
	    if (System.IO.File.Exists(f.FullName))
		tmpBool = true;
	    else
		tmpBool = System.IO.Directory.Exists(f.FullName);
	    if (tmpBool) {
	        System.IO.StreamReader fr = new System.IO.StreamReader(f.FullName);
	        char[] template = new char[(int) f.Length];
	        fr.Read((System.Char[]) template, 0, template.Length);
	        contents = new String(template);
	        fr.Close();
	    }
			
	    return contents;
	}

    }
}
