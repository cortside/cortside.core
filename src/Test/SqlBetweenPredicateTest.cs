using System;
using System.Data.SqlClient;
using Cortside.Core.DAO;
using Xunit;

namespace Cortside.Core.Test {

    /// <summary>
    /// Summary description for SqlBetweenPredicateTest.
    /// </summary>

    public class SqlBetweenPredicateTest {

        [Fact]
        public void WithInt64() {
            SqlBetweenPredicate predicate = new SqlBetweenPredicate("foo", 1L, 2L);
            Assert.Equal("(foo BETWEEN @foo1 AND @foo2)", predicate.Expression);
            Assert.Equal(2, predicate.Parameters.Count);
            Assert.Equal(1L, ((SqlParameter)predicate.Parameters["@foo1"]).Value);
            Assert.Equal(2L, ((SqlParameter)predicate.Parameters["@foo2"]).Value);
        }

        [Fact]
        public void WithInt32() {
            SqlBetweenPredicate predicate = new SqlBetweenPredicate("foo", 1, 2);
            Assert.Equal("(foo BETWEEN @foo1 AND @foo2)", predicate.Expression);
            Assert.Equal(2, predicate.Parameters.Count);
            Assert.Equal(1, ((SqlParameter)predicate.Parameters["@foo1"]).Value);
            Assert.Equal(2, ((SqlParameter)predicate.Parameters["@foo2"]).Value);
        }

        [Fact]
        public void WithInt16() {
            SqlBetweenPredicate predicate = new SqlBetweenPredicate("foo", Convert.ToInt16(1), Convert.ToInt16(2));
            Assert.Equal("(foo BETWEEN @foo1 AND @foo2)", predicate.Expression);
            Assert.Equal(2, predicate.Parameters.Count);
            Assert.Equal(Convert.ToInt16(1), ((SqlParameter)predicate.Parameters["@foo1"]).Value);
            Assert.Equal(Convert.ToInt16(2), ((SqlParameter)predicate.Parameters["@foo2"]).Value);
        }

        [Fact]
        public void WithDateTime() {
            SqlBetweenPredicate predicate = new SqlBetweenPredicate("foo", DateTime.Today, DateTime.Today.AddDays(1));
            Assert.Equal("(foo BETWEEN @foo1 AND @foo2)", predicate.Expression);
            Assert.Equal(2, predicate.Parameters.Count);
            Assert.Equal(DateTime.Today, ((SqlParameter)predicate.Parameters["@foo1"]).Value);
            Assert.Equal(DateTime.Today.AddDays(1), ((SqlParameter)predicate.Parameters["@foo2"]).Value);
        }

    }
}
