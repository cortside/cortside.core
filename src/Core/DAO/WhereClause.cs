using System;

namespace Cortside.Core.DAO {

    /// <summary>
    /// Utility class to construct WHERE clause sql fragments
    /// </summary>
    public class WhereClause : IWhere {

        private String sql = String.Empty;

        #region Constructors
        /// <summary>
        /// New empty clause
        /// </summary>
        public WhereClause() {
        }

        /// <summary>
        /// New clause that will check that column equals value
        /// </summary>
        /// <remarks>
        /// field = value
        /// </remarks>
        public WhereClause(String field, Int32 value) {
            sql = field + "=" + value.ToString();
        }

        /// <summary>
        /// New clause that will check that column equals value
        /// </summary>
        /// <remarks>
        /// field = value
        /// </remarks>
        public WhereClause(String field, String value) {
            sql = field + "='" + value.Replace("'", "''") + "'";
        }

        /// <summary>
        /// New clause that will check that column equals value
        /// </summary>
        /// <remarks>
        /// field = value
        /// </remarks>
        public WhereClause(String field, DateTime value) {
            sql = field + "='" + value.ToString() + "'";
        }

        /// <summary>
        /// New clause that will check that column equals value
        /// </summary>
        /// <remarks>
        /// field = value
        /// </remarks>
        public WhereClause(String field, Boolean value) {
            if (value) {
                sql = field + "=1";
            } else {
                sql = field + "=0";
            }
        }

        /// <summary>
        /// New clause using raw sql
        /// </summary>
        public WhereClause(String sql) {
            this.sql = sql;
        }

        /// <summary>
        /// New clause using WhereClause (for wrapping with enclosing parens)
        /// </summary>
        /// <remarks>
        /// ( clause )
        /// </remarks>
        public WhereClause(WhereClause wc) {
            // Note that this is using the internal sql string so that additional formatting is not added
            this.sql = "(" + wc.ToString() + ") ";
        }
        #endregion

        #region And
        public void And(WhereClause wc) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += " (" + wc.ToString() + ") ";
        }

        public void And(String field, Int32 value) {
            AndEquals(field, value);
        }

        public void And(String field, String value) {
            AndEquals(field, value);
        }

        public void And(String field, DateTime value) {
            AndEquals(field, value);
        }

        public void And(String field, Boolean value) {
            AndEquals(field, value);
        }

        public void And(String field, Object value) {
            AndEquals(field, value);
        }
        #endregion

        #region AndEquals
        public void AndEquals(String field, Int32 value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "=" + value.ToString();
        }

        public void AndEquals(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "='" + value.Replace("'", "''") + "'";
        }

        public void AndEquals(String field, DateTime value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "='" + value.ToString() + "'";
        }

        public void AndEquals(String field, Boolean value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            if (value) {
                sql += field + "=1";
            } else {
                sql += field + "=0";
            }
        }

        public void AndEquals(String field, DBNull value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " is null";
        }

        public void AndEquals(String field, Object value) {
            if (value is DBNull) {
                AndEquals(field, value as DBNull);
            } else if (value is Int32) {
                AndEquals(field, (Int32)value);
            } else if (value is DateTime) {
                AndEquals(field, (DateTime)value);
            } else if (value is Boolean) {
                AndEquals(field, (Boolean)value);
            } else {
                AndEquals(field, value.ToString());
            }
        }
        #endregion

        #region AndNotEquals
        public void AndNotEquals(String field, Int32 value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "<>" + value.ToString();
        }

        public void AndNotEquals(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "<>'" + value.Replace("'", "''") + "'";
        }

        public void AndNotEquals(String field, DateTime value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + "<>'" + value.ToString() + "'";
        }

        public void AndNotEquals(String field, DBNull value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " is not null";
        }

        public void AndNotEquals(String field, Boolean value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            if (value) {
                sql += field + "<>" + "1";
            } else {
                sql += field + "<>" + "0";
            }
        }

        public void AndNotEquals(String field, Object value) {
            if (value is DBNull) {
                AndNotEquals(field, value as DBNull);
            } else if (value is Int32) {
                AndNotEquals(field, (Int32)value);
            } else if (value is DateTime) {
                AndNotEquals(field, (DateTime)value);
            } else if (value is Boolean) {
                AndNotEquals(field, (Boolean)value);
            } else {
                AndNotEquals(field, value.ToString().Replace("'", "''"));
            }
        }
        #endregion

        #region Or
        public void Or(WhereClause wc) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += " (" + wc.ToString() + ") ";
        }

        public void Or(String field, Int32 value) {
            OrEquals(field, value);
        }

        public void Or(String field, String value) {
            OrEquals(field, value);
        }

        public void Or(String field, DateTime value) {
            OrEquals(field, value);
        }

        public void Or(String field, Boolean value) {
            OrEquals(field, value);
        }

        public void Or(String field, Object value) {
            OrEquals(field, value);
        }
        #endregion

        #region OrEquals
        public void OrEquals(String field, Int32 value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "=" + value.ToString();
        }

        public void OrEquals(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "='" + value.Replace("'", "''") + "'";
        }

        public void OrEquals(String field, DateTime value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "='" + value.ToString() + "'";
        }

        public void OrEquals(String field, Boolean value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            if (value) {
                sql += field + "=1";
            } else {
                sql += field + "=0";
            }
        }

        public void OrEquals(String field, DBNull value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " is null";
        }

        public void OrEquals(String field, Object value) {
            if (value is DBNull) {
                OrEquals(field, value as DBNull);
            } else if (value is Int32) {
                OrEquals(field, (Int32)value);
            } else if (value is DateTime) {
                OrEquals(field, (DateTime)value);
            } else if (value is Boolean) {
                OrEquals(field, (Boolean)value);
            } else {
                OrEquals(field, value.ToString().Replace("'", "''"));
            }
        }
        #endregion

        #region OrNotEquals
        public void OrNotEquals(String field, Int32 value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "<>" + value.ToString();
        }

        public void OrNotEquals(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "<>'" + value.Replace("'", "''") + "'";
        }

        public void OrNotEquals(String field, DateTime value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + "<>'" + value.ToString() + "'";
        }

        public void OrNotEquals(String field, Boolean value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            if (value) {
                sql += field + "<>1";
            } else {
                sql += field + "<>0";
            }
        }

        public void OrNotEquals(String field, DBNull value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " is not null";
        }

        public void OrNotEquals(String field, Object value) {
            if (value is DBNull) {
                OrNotEquals(field, value as DBNull);
            } else if (value is Int32) {
                OrNotEquals(field, (Int32)value);
            } else if (value is DateTime) {
                OrNotEquals(field, (DateTime)value);
            } else if (value is Boolean) {
                OrNotEquals(field, (Boolean)value);
            } else {
                OrNotEquals(field, value.ToString().Replace("'", "''"));
            }
        }
        #endregion

        #region AndBetween
        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndBetween(String field, Int32 value1, Int32 value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " between " + value1.ToString() + " and " + value2.ToString();
        }

        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndBetween(String field, String value1, String value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " between '" + value1.Replace("'", "''") + "' and '" + value2.Replace("'", "''") + "'";
        }

        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndBetween(String field, DateTime value1, DateTime value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " between '" + value1.ToString() + "' and '" + value2.ToString() + "'";
        }
        #endregion

        #region OrBetween
        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrBetween(String field, Int32 value1, Int32 value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " between " + value1.ToString() + " and " + value2.ToString();
        }

        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrBetween(String field, String value1, String value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " between '" + value1.Replace("'", "''") + "' and '" + value2.Replace("'", "''") + "'";
        }

        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrBetween(String field, DateTime value1, DateTime value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " between '" + value1.ToString() + "' and '" + value2.ToString() + "'";
        }
        #endregion

        #region AndNotBetween
        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndNotBetween(String field, Int32 value1, Int32 value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " NOT between " + value1.ToString() + " and " + value2.ToString();
        }

        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndNotBetween(String field, String value1, String value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " NOT between '" + value1.Replace("'", "''") + "' and '" + value2.Replace("'", "''") + "'";
        }

        /// <summary>
        /// And new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// AND field between value1 AND value2
        /// </remarks>
        public void AndNotBetween(String field, DateTime value1, DateTime value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " NOT between '" + value1.ToString() + "' and '" + value2.ToString() + "'";
        }
        #endregion

        #region OrNotBetween
        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrNotBetween(String field, Int32 value1, Int32 value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " NOT between " + value1.ToString() + " and " + value2.ToString();
        }

        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrNotBetween(String field, String value1, String value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " NOT between '" + value1.Replace("'", "''") + "' and '" + value2.Replace("'", "''") + "'";
        }

        /// <summary>
        /// Or new clause that will check that column is between value1 and value2
        /// </summary>
        /// <remarks>
        /// OR field between value1 AND value2
        /// </remarks>
        public void OrNotBetween(String field, DateTime value1, DateTime value2) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " NOT between '" + value1.ToString() + "' and '" + value2.ToString() + "'";
        }
        #endregion

        #region AndIn
        #endregion

        #region OrIn
        #endregion

        #region AndNotIn
        #endregion

        #region OrNotIn
        #endregion

        #region AndLike
        public void AndLike(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " like '" + value.Replace("'", "''") + "'";
        }
        #endregion

        #region OrLike
        public void OrLike(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " like '" + value.Replace("'", "''") + "'";
        }
        #endregion

        #region AndNotLike
        public void AndNotLike(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " AND ";
            }
            sql += field + " not like '" + value.Replace("'", "''") + "'";
        }
        #endregion

        #region OrNotLike
        public void OrNotLike(String field, String value) {
            if (!sql.Equals(String.Empty)) {
                sql += " OR ";
            }
            sql += field + " not like '" + value.Replace("'", "''") + "'";
        }
        #endregion

        /// <summary>
        /// Format the clause for inclusion in sql statement    
        /// </summary>
        /// <remarks>
        /// WHERE &lt;sql&gt;
        /// </remarks>
        public String FormatSql() {
            if (!sql.Equals(String.Empty)) {
                return " WHERE " + sql;
            } else {
                return String.Empty;
            }
        }

        /// <summary>
        /// Returns true if nothing has been added to the clause; otherwise false.
        /// </summary>
        public Boolean IsEmpty {
            get { return sql.Equals(String.Empty); }
        }

        public override String ToString() {
            return sql;
        }

    }
}
