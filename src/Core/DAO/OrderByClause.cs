using System;

namespace Spring2.Core.DAO {
    public class OrderByClause : IOrderBy {

	private String sql;

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
