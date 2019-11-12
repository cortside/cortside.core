using System;
using System.Collections;
using System.Threading;
using NUnit.Framework;
using Spring2.Core.Test.DAO;
using Spring2.Core.Types;

namespace Spring2.Core.Test {

    /// <summary>
    /// Tests for BooleanType
    /// </summary>
    [TestFixture]
    public class SqlEntityDAOTest {

	[Test]
	public void TestConnectionStringParse() {
	    ArrayList list = new ArrayList();
	    for(Int32 i=0; i< 1000; i++) {
		ThreadStart ts = new ThreadStart(TestDAO.GetConnectionString);
		Thread t = new Thread(ts);
		list.Add(t);
	    }

	    for(Int32 i=0; i<list.Count; i++) {
		Thread t = list[i] as Thread;
		t.Start();
	    }
	}

    }
}
