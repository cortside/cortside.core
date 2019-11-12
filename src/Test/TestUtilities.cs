using System;
using System.IO;

using Spring2.Core.DAO;
using Spring2.Core.Types;

using Xunit;

namespace Spring2.Core.Test {
    /// <summary>
    /// Utilities to help in the testing process.
    /// </summary>
    public class TestUtilities {

	private static readonly int COMPAREBUFFERSIZE = 512;
	
	/// <summary>
	/// All methods are static.
	/// </summary>
	private TestUtilities() {
	}

	/// <summary>
	/// Asserts two files are identical
	/// </summary>
	/// <param name="filename1">File to compare.</param>
	/// <param name="filename2">File to compare.</param>
	public static void CompareFiles(string filename1, string filename2) {
	    FileStream file1 = new FileStream(filename1, FileMode.Open, FileAccess.Read);
	    FileStream file2 = new FileStream(filename2, FileMode.Open, FileAccess.Read);

	    try {
		byte[] buffer1 = new byte[COMPAREBUFFERSIZE];
		byte[] buffer2 = new byte[COMPAREBUFFERSIZE];
		int bytes1 = file1.Read(buffer1, 0, COMPAREBUFFERSIZE);
		int bytes2 = file2.Read(buffer2, 0, COMPAREBUFFERSIZE);
		while(bytes1 > 0) {
		    Assert.True(bytes1 == bytes2, filename1 + " has different length than " + filename2 + ".");
		    for(int i=0;i<bytes1;i++) {
			Assert.True(buffer1[i] == buffer2[i], filename1 + " and " + filename2 + " differ.");
		    }
		    bytes1 = file1.Read(buffer1, 0, COMPAREBUFFERSIZE);
		    bytes2 = file2.Read(buffer2, 0, COMPAREBUFFERSIZE);
		}

		Assert.True(bytes1 == bytes2, filename1 + " has different length than " + filename2 + ".");
	    }
	    finally {
		file1.Close();
		file2.Close();
	    }
	}

    }
}
