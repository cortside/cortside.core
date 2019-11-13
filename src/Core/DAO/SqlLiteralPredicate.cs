using System;
using System.Data;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlLiteralPredicate.
    /// </summary>
    public class SqlLiteralPredicate : SqlPredicate {

        private readonly String value;
        private readonly IDataParameterCollection parameters;

        public SqlLiteralPredicate(String value) {
            this.value = value;
            parameters = new SqlParameterList();
        }
        public SqlLiteralPredicate(String value, IDataParameterCollection parameters) {
            this.value = value;
            this.parameters = parameters;
        }

        public override String Expression {
            get {
                return " " + value;
            }
        }

        public override IDataParameterCollection Parameters {
            get {
                return parameters;
            }
        }

    }
}
