using System;
using System.Data.SqlClient;
using Xunit;
using Spring2.Core.DAO;
using System.Data;

namespace Spring2.Core.Test {
	
    /// <summary>
    /// Summary description for SqlBetweenPredicateTest.
    /// </summary>

    public class SqlInPredicateTest {

	[Fact]
	public void WithInt64() {
	    SqlInPredicate predicate = new SqlInPredicate("foo", new Int64[] {1, 2, 3});
	    Assert.Equal(" foo IN (@foo1, @foo2, @foo3)", predicate.Expression);
	    Assert.Equal(3, predicate.Parameters.Count);
	    Assert.Equal(Convert.ToInt64(1), ((SqlParameter)predicate.Parameters["@foo1"]).Value);
	    Assert.Equal(Convert.ToInt64(2), ((SqlParameter)predicate.Parameters["@foo2"]).Value);
	    Assert.Equal(Convert.ToInt64(3), ((SqlParameter)predicate.Parameters["@foo3"]).Value);
	    foreach (SqlParameter parameter in predicate.Parameters) {
		Assert.Equal(SqlDbType.BigInt, parameter.SqlDbType);
	    }
	}

	[Fact]
	public void WithInt32() {
	    SqlInPredicate predicate = new SqlInPredicate("foo", new Int32[] { 1, 2, 3 });
	    Assert.Equal(" foo IN (@foo1, @foo2, @foo3)", predicate.Expression);
	    Assert.Equal(3, predicate.Parameters.Count);
	    Assert.Equal(1, ((SqlParameter)predicate.Parameters["@foo1"]).Value);
	    Assert.Equal(2, ((SqlParameter)predicate.Parameters["@foo2"]).Value);
	    Assert.Equal(3, ((SqlParameter)predicate.Parameters["@foo3"]).Value);
	    foreach (SqlParameter parameter in predicate.Parameters) {
		Assert.Equal(SqlDbType.Int, parameter.SqlDbType);
	    }
	}
    }
}
