using System;
using System.Data;
using System.Text;

namespace Spring2.Core.DAO {
    /// <summary>
    /// Summary description for SqlFilter.
    /// </summary>
    public class SqlFilter : DatabaseFilter, IDatabaseExpression {

        public SqlFilter() {
        }

        public SqlFilter(IDatabaseExpression expression) {
            expressions.Add(new LogicalExpression(expression));
        }

        /// <summary>
        /// Returns the entire WHERE clause, including "WHERE", or blank if there are not any contained expressions
        /// </summary>
        public override String Statement {
            get {
                String expression = Expression;
                if (expression.Length == 0) {
                    return String.Empty;
                }

                return " WHERE " + expression;
            }
        }

        /// <summary>
        /// This is the independent fragment based contained expressions.
        /// </summary>
        public override String Expression {
            get {
                if (expressions.Count == 0) {
                    return String.Empty;
                }

                StringBuilder sb = new StringBuilder();
                if (expressions.Count > 1) {
                    sb.Append("(");
                }
                foreach (LogicalExpression expression in expressions) {
                    switch (expression.Operator) {
                        case LogicalOperatorEnum.And:
                            sb.Append(" AND ");
                            break;
                        case LogicalOperatorEnum.Or:
                            sb.Append(" OR ");
                            break;
                        case LogicalOperatorEnum.Not:
                            sb.Append(" NOT ");
                            break;
                        case LogicalOperatorEnum.None:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    sb.Append(expression.Expression.Expression);
                }
                if (expressions.Count > 1) {
                    sb.Append(")");
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Collection of data parameters to be added to the command when executed.
        /// </summary>
        public override IDataParameterCollection Parameters {
            get {
                SqlParameterList parameters = new SqlParameterList();
                foreach (LogicalExpression expression in expressions) {
                    parameters.AddRange(expression.Expression.Parameters);
                }
                return parameters;
            }
        }

    }
}
