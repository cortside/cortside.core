using System;

namespace Cortside.Core.DAO {
    public class OrderByClause : IOrderBy {

        private readonly String sql;

        private OrderByClause(String clause, String field) {
            sql = clause + ", " + field;
        }

        public OrderByClause(String field) {
            sql = field;
        }

        public OrderByClause Add(String field) {
            return new OrderByClause(sql, field);
        }

        public String FormatSql() {
            return " order by " + sql;
        }

    }
}
