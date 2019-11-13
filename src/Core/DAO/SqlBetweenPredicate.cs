using System;
using System.Data;

namespace Cortside.Core.DAO {
    /// <summary>
    /// Summary description for SqlBetweenPredicate.
    /// </summary>
    public class SqlBetweenPredicate : SqlPredicate {

        private readonly String columnName;
        private readonly Object value1;
        private readonly Object value2;
        private readonly Boolean not = false;
        private readonly SqlDbType dbType;

        public SqlBetweenPredicate(String columnName, Int64 value1, Int64 value2) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            dbType = SqlDbType.BigInt;
        }

        public SqlBetweenPredicate(String columnName, Int64 value1, Int64 value2, Boolean not) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            this.not = not;
            dbType = SqlDbType.BigInt;
        }

        public SqlBetweenPredicate(String columnName, Int32 value1, Int32 value2) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            dbType = SqlDbType.Int;
        }

        public SqlBetweenPredicate(String columnName, Int32 value1, Int32 value2, Boolean not) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            this.not = not;
            dbType = SqlDbType.Int;
        }

        public SqlBetweenPredicate(String columnName, Int16 value1, Int16 value2) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            dbType = SqlDbType.SmallInt;
        }

        public SqlBetweenPredicate(String columnName, Int16 value1, Int16 value2, Boolean not) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            this.not = not;
            dbType = SqlDbType.SmallInt;
        }

        public SqlBetweenPredicate(String columnName, DateTime value1, DateTime value2) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            dbType = SqlDbType.DateTime;
        }

        public SqlBetweenPredicate(String columnName, DateTime value1, DateTime value2, Boolean not) {
            this.columnName = columnName;
            this.value1 = value1;
            this.value2 = value2;
            this.not = not;
            dbType = SqlDbType.DateTime;
        }

        public override String Expression {
            get {
                return String.Format("({0} {1}BETWEEN @{0}1 AND @{0}2)", columnName, not ? "NOT " : String.Empty);
            }
        }

        public override IDataParameterCollection Parameters {
            get {
                SqlParameterList parameters = new SqlParameterList();
                parameters.Add("@" + columnName + "1", dbType, value1);
                parameters.Add("@" + columnName + "2", dbType, value2);
                return parameters;
            }
        }

    }
}
