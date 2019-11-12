using System;
using System.Data.SqlClient;
using Xunit;
using Spring2.Core.DAO;

namespace Spring2.Core.Test {
	
    /// <summary>
    /// Summary description for SqlBetweenPredicateTest.
    /// </summary>

    public class SqlEqualityPredicateTest {

	[Fact]
	public void EqualInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.Equal, Int64.MaxValue);
	    Assert.Equal("(foo = @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}
    
	[Fact]
	public void NotEqualInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.NotEqual, Int64.MaxValue);
	    Assert.Equal("(foo <> @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}

	[Fact]
	public void LessThanInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.LessThan, Int64.MaxValue);
	    Assert.Equal("(foo < @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}
    
	[Fact]
	public void LessThanOrEqualInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.LessThanOrEqual, Int64.MaxValue);
	    Assert.Equal("(foo <= @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}
    
	[Fact]
	public void GreaterThanInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.GreaterThan, Int64.MaxValue);
	    Assert.Equal("(foo > @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}
    	
	[Fact]
	public void GreaterThanOrEqualInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.GreaterThanOrEqual, Int64.MaxValue);
	    Assert.Equal("(foo >= @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}
    	
	[Fact]
	public void LikeInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.Like, Int64.MaxValue);
	    Assert.Equal("(foo LIKE @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}

	[Fact]
	public void NotLikeInt64() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.NotLike, Int64.MaxValue);
	    Assert.Equal("(foo NOT LIKE @foo)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@foo"]).Value);
	}

	[Fact]
	public void EqualDBNull() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.Equal, DBNull.Value);
	    Assert.Equal("(foo IS NULL)", predicate.Expression);
	    Assert.Equal(0, predicate.Parameters.Count);
	}
    
	[Fact]
	public void NotEqualDBNull() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.NotEqual, DBNull.Value);
	    Assert.Equal("(foo IS NOT NULL)", predicate.Expression);
	    Assert.Equal(0, predicate.Parameters.Count);
	}

	[Fact]
	public void EqualNull() {
	    String s = null;
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.Equal, s);
	    Assert.Equal("(foo IS NULL)", predicate.Expression);
	    Assert.Equal(0, predicate.Parameters.Count);
	}
    
	[Fact]
	public void NotEqualNull() {
	    String s = null;
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("foo", EqualityOperatorEnum.NotEqual, s);
	    Assert.Equal("(foo IS NOT NULL)", predicate.Expression);
	    Assert.Equal(0, predicate.Parameters.Count);
	}

    	[Fact]
	public void ShouldEscapeKeywords() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("order", EqualityOperatorEnum.Equal, Int64.MaxValue);
	    Assert.Equal("([order] = @order)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@order"]).Value);    	    
    	}

	[Fact]
	public void ShouldEscapeNamesWithSpecialCharacters() {
	    SqlEqualityPredicate predicate = new SqlEqualityPredicate("Unit Price", EqualityOperatorEnum.Equal, Int64.MaxValue);
	    Assert.Equal("([Unit Price] = @Unit_Price)", predicate.Expression);
	    Assert.Equal(1, predicate.Parameters.Count);
	    Assert.Equal(Int64.MaxValue, ((SqlParameter)predicate.Parameters["@Unit_Price"]).Value);    	    
	}
    }
}
