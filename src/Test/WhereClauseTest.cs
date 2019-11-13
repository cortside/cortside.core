using System;
using Cortside.Core.DAO;
using Xunit;

namespace Cortside.Core.Test {

    /// <summary>
    /// Tests for IWhere functionality
    /// </summary>
    public class WhereClauseTest {

        [Fact]
        public void WhereClause() {
            // make sure an empty object does not emits an empty clause
            WhereClause filter = new WhereClause();
            Assert.True(filter.FormatSql().Equals(String.Empty), filter.FormatSql());

            // make sure that apostrophe is properly escaped
            filter = new WhereClause("column", "foo'bar");
            Assert.Equal(" WHERE column='foo''bar'", filter.FormatSql());

            // Check building where clause from string
            filter = new WhereClause("c1 = 57 and [user].[plan] = 'goodone'");
            Assert.True(filter.FormatSql().Equals(" WHERE c1 = 57 and [user].[plan] = 'goodone'"), filter.FormatSql());

            // Check building where clause from where clause
            WhereClause filter1 = new WhereClause(filter);
            Assert.True(filter1.FormatSql().Equals(" WHERE (c1 = 57 and [user].[plan] = 'goodone') "), filter.FormatSql() + " doesn't equal " + filter1.FormatSql());
        }

        [Fact]
        public void WhereClause_And() {
            // make sure that apostrophe is properly escaped
            WhereClause filter = new WhereClause("foo", "bar");
            filter.And("column", "foo'bar");
            Assert.Equal(" WHERE foo='bar' AND column='foo''bar'", filter.FormatSql());
        }

        [Fact]
        public void WhereClause_Or() {
            // make sure that apostrophe is properly escaped
            WhereClause filter = new WhereClause("foo", "bar");
            filter.Or("column", "foo'bar");
            Assert.Equal(" WHERE foo='bar' OR column='foo''bar'", filter.FormatSql());
        }

        [Fact]
        public void Constructors() {
            WhereClause filter = new WhereClause();
            Assert.True(filter.IsEmpty == true);

            filter = new WhereClause("columnA", 1);
            filter.And("columnB", 2);
            Assert.Equal(" WHERE columnA=1 AND columnB=2", filter.FormatSql());

            filter = new WhereClause("columnA", 1);
            filter.AndEquals("columnB", 2);
            Assert.Equal(" WHERE columnA=1 AND columnB=2", filter.FormatSql());

            filter = new WhereClause("columnA", "foo'bar");
            Assert.Equal(" WHERE columnA='foo''bar'", filter.FormatSql());

            //with Boolean
            filter = new WhereClause("columnA", false);
            Assert.Equal(" WHERE columnA=0", filter.FormatSql());
        }

        [Fact]
        public void And() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", 1);
            filter.And("columnB", 2);
            Assert.Equal(" WHERE columnA=1 AND columnB=2", filter.FormatSql());

            filter = new WhereClause("columnA", "foo'bar");
            filter.And("columnB", "fee'fie");
            Assert.Equal(" WHERE columnA='foo''bar' AND columnB='fee''fie'", filter.FormatSql());

            filter = new WhereClause("columnA", "foo'bar");
            filter.And("columnB", true as object);
            Assert.Equal(" WHERE columnA='foo''bar' AND columnB=1", filter.FormatSql());
        }

        [Fact]
        public void AndEquals() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", 1);
            filter.AndEquals("columnB", 2);
            Assert.Equal(" WHERE columnA=1 AND columnB=2", filter.FormatSql());

            filter = new WhereClause("columnA", "foo'bar");
            filter.AndEquals("columnB", "fee'fie");
            Assert.Equal(" WHERE columnA='foo''bar' AND columnB='fee''fie'", filter.FormatSql());
        }

        [Fact]
        public void AndNotEquals() {
            WhereClause filter = new WhereClause();

            //Boolean as object (best code coverage)
            filter = new WhereClause("columnA", 1);
            filter.AndNotEquals("columnB", true as object);
            Assert.Equal(" WHERE columnA=1 AND columnB<>1", filter.FormatSql());
        }

        [Fact]
        public void OrEquals() {
            WhereClause filter = new WhereClause();

            //Boolean as object (best code coverage)
            filter = new WhereClause("columnA", 1);
            filter.OrEquals("columnB", true as object);
            Assert.Equal(" WHERE columnA=1 OR columnB=1", filter.FormatSql());
        }

        [Fact]
        public void OrNotEquals() {
            WhereClause filter = new WhereClause();

            //Boolean as object (best code coverage)
            filter = new WhereClause("columnA", 1);
            filter.OrNotEquals("columnB", true as object);
            Assert.Equal(" WHERE columnA=1 OR columnB<>1", filter.FormatSql());
        }

        [Fact]
        public void AndLike() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", "a'%");
            filter.AndLike("columnB", "b'%");
            Assert.Equal(" WHERE columnA='a''%' AND columnB like 'b''%'", filter.FormatSql());
        }

        [Fact]
        public void OrLike() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", "a'%");
            filter.OrLike("columnB", "b'%");
            Assert.Equal(" WHERE columnA='a''%' OR columnB like 'b''%'", filter.FormatSql());
        }

        [Fact]
        public void AndNotLike() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", "a'%");
            filter.AndNotLike("columnB", "b'%");
            Assert.Equal(" WHERE columnA='a''%' AND columnB not like 'b''%'", filter.FormatSql());
        }

        [Fact]
        public void OrNotLike() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause("columnA", "a'%");
            filter.OrNotLike("columnB", "b'%");
            Assert.Equal(" WHERE columnA='a''%' OR columnB not like 'b''%'", filter.FormatSql());
        }

        [Fact]
        public void AndBetween() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause();
            filter.AndBetween("columnA", 1, 2);
            Assert.Equal(" WHERE columnA between 1 and 2", filter.FormatSql());

            filter = new WhereClause();
            filter.AndBetween("columnA", "1", "2");
            Assert.Equal(" WHERE columnA between '1' and '2'", filter.FormatSql());

            filter = new WhereClause();
            filter.AndBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE columnA between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.AndBetween("columnA", 1, 2);
            Assert.Equal(" WHERE foo='bar' AND columnA between 1 and 2", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.AndBetween("columnA", "1", "2");
            Assert.Equal(" WHERE foo='bar' AND columnA between '1' and '2'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.AndBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE foo='bar' AND columnA between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());
        }

        [Fact]
        public void AndNotBetween() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause();
            filter.AndNotBetween("columnA", 1, 2);
            Assert.Equal(" WHERE columnA NOT between 1 and 2", filter.FormatSql());

            filter = new WhereClause();
            filter.AndNotBetween("columnA", "1", "2");
            Assert.Equal(" WHERE columnA NOT between '1' and '2'", filter.FormatSql());

            filter = new WhereClause();
            filter.AndNotBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE columnA NOT between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.AndNotBetween("columnA", 1, 2);
            Assert.Equal(" WHERE foo='bar' AND columnA NOT between 1 and 2", filter.FormatSql());

            filter = new WhereClause("foo", "foo'bar");
            filter.AndNotBetween("columnA", "fee'fie", "fo'fum");
            Assert.Equal(" WHERE foo='foo''bar' AND columnA NOT between 'fee''fie' and 'fo''fum'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.AndNotBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE foo='bar' AND columnA NOT between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());
        }

        [Fact]
        public void OrBetween() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause();
            filter.OrBetween("columnA", 1, 2);
            Assert.Equal(" WHERE columnA between 1 and 2", filter.FormatSql());

            filter = new WhereClause();
            filter.OrBetween("columnA", "1", "2");
            Assert.Equal(" WHERE columnA between '1' and '2'", filter.FormatSql());

            filter = new WhereClause();
            filter.OrBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE columnA between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrBetween("columnA", 1, 2);
            Assert.Equal(" WHERE foo='bar' OR columnA between 1 and 2", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrBetween("columnA", "fee'fie", "fo'fum");
            Assert.Equal(" WHERE foo='bar' OR columnA between 'fee''fie' and 'fo''fum'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE foo='bar' OR columnA between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());
        }

        [Fact]
        public void OrNotBetween() {
            WhereClause filter = new WhereClause();

            filter = new WhereClause();
            filter.OrNotBetween("columnA", 1, 2);
            Assert.Equal(" WHERE columnA NOT between 1 and 2", filter.FormatSql());

            filter = new WhereClause();
            filter.OrNotBetween("columnA", "1", "2");
            Assert.Equal(" WHERE columnA NOT between '1' and '2'", filter.FormatSql());

            filter = new WhereClause();
            filter.OrNotBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE columnA NOT between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrNotBetween("columnA", 1, 2);
            Assert.Equal(" WHERE foo='bar' OR columnA NOT between 1 and 2", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrNotBetween("columnA", "fee'fie", "fo'fum");
            Assert.Equal(" WHERE foo='bar' OR columnA NOT between 'fee''fie' and 'fo''fum'", filter.FormatSql());

            filter = new WhereClause("foo", "bar");
            filter.OrNotBetween("columnA", new DateTime(1969, 12, 18), new DateTime(2000, 2, 8));
            Assert.Equal(" WHERE foo='bar' OR columnA NOT between '12/18/1969 12:00:00 AM' and '2/8/2000 12:00:00 AM'", filter.FormatSql());
        }

    }
}
