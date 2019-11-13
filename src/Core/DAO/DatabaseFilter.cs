using System;
using System.Collections;
using System.Data;

namespace Spring2.Core.DAO {

    /// <summary>
    /// Base class for database filters that offers the ability to create query fragments without having to know the
    /// specific database or concatinate strings.
    /// 
    /// Supports parameterized fragments.
    /// </summary>
    public abstract class DatabaseFilter : IDatabaseExpression {

        protected struct LogicalExpression {
            public LogicalOperatorEnum Operator;
            public IDatabaseExpression Expression;

            public LogicalExpression(IDatabaseExpression expression) {
                Expression = expression;
                Operator = LogicalOperatorEnum.None;
            }
            public LogicalExpression(LogicalOperatorEnum op, IDatabaseExpression expression) {
                Expression = expression;
                Operator = op;
            }
        }

        protected ArrayList expressions = new ArrayList();

        /// <summary>
        /// This is the independent fragment based contained expressions.
        /// </summary>
        public abstract String Expression {
            get;
        }

        /// <summary>
        /// This is the complete WHERE fragment based on the contained expressions.
        /// </summary>
        public abstract String Statement {
            get;
        }

        /// <summary>
        /// Collection of data parameters to be added to the command when executed.
        /// </summary>
        public abstract IDataParameterCollection Parameters {
            get;
        }

        /// <summary>
        /// Adds an expression and logically ands this with the existing contained expressions.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IDatabaseExpression And(IDatabaseExpression expression) {
            if (expressions.Count == 0) {
                expressions.Add(new LogicalExpression(expression));
            } else {
                expressions.Add(new LogicalExpression(LogicalOperatorEnum.And, expression));
            }
            return this;
        }

        /// <summary>
        /// Adds an expression and logically ors this with the existing contained expressions.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IDatabaseExpression Or(IDatabaseExpression expression) {
            if (expressions.Count == 0) {
                expressions.Add(new LogicalExpression(expression));
            } else {
                expressions.Add(new LogicalExpression(LogicalOperatorEnum.Or, expression));
            }
            return this;
        }

        /// <summary>
        /// Adds an expression and logically ands the notted result with the existing contained expressions.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IDatabaseExpression Not(IDatabaseExpression expression) {
            if (expressions.Count == 0) {
                expressions.Add(new LogicalExpression(expression));
            } else {
                expressions.Add(new LogicalExpression(LogicalOperatorEnum.Not, expression));
            }
            return this;
        }

        /// <summary>
        /// Returns true if nothing has been added to the clause; otherwise false.
        /// </summary>
        public Boolean IsEmpty {
            get { return expressions.Count == 0; }
        }

    }
}
