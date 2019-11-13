using System.Data;
using System.Data.SqlClient;
using Spring2.Core.DAO;
using Xunit;

namespace Spring2.Core.Test {

    /// <summary>
    /// Summary description for SqlLiteralPredicateTest.
    /// </summary>

    public class SqlLiteralPredicateTest {

        [Fact]
        public void WithString() {
            SqlLiteralPredicate predicate = new SqlLiteralPredicate("foo='bar'");
            Assert.Equal(" foo='bar'", predicate.Expression);
            Assert.Equal(0, predicate.Parameters.Count);
        }

        [Fact]
        public void WithStringAndParameters() {
            SqlParameterList parameters = new SqlParameterList();
            parameters.Add("@bar", SqlDbType.VarChar, "bar");

            SqlLiteralPredicate predicate = new SqlLiteralPredicate("foo=@bar", parameters);
            Assert.Equal(" foo=@bar", predicate.Expression);
            Assert.Equal(1, predicate.Parameters.Count);
            Assert.Equal("bar", ((SqlParameter)predicate.Parameters["@bar"]).Value);
        }

    }
}
