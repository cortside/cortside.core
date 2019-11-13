using System;
using System.Collections;
using System.Data;
using Cortside.Core.IoC;

namespace Cortside.Core.DAO {

    public abstract class BaseEntityDAO {

        /// <summary>
        /// Hash table mapping entity property names to sql code.
        /// </summary>
        private static Hashtable propertyToSqlMap = new Hashtable();
        private IConnectionStringStrategy connectionStringStrategy = new DefaultConnectionStringStrategy();

        protected static void AddPropertyMapping(String property, String mapping) {
            if (!propertyToSqlMap.Contains(property)) {
                propertyToSqlMap.Add(property, mapping);
            }
        }

        public BaseEntityDAO() {
            if (ClassRegistry.CanResolve<IConnectionStringStrategy>()) {
                this.connectionStringStrategy = ClassRegistry.Resolve<IConnectionStringStrategy>();
            }
        }

        public BaseEntityDAO(IConnectionStringStrategy strategy) {
            if (strategy != null) {
                this.connectionStringStrategy = strategy;
            }
        }

        /// <summary>
        /// Creates a where clause object by mapping the given where clause text.  The text may reference
        /// entity properties which will be mapped to sql code by enclosing the property names in braces.
        /// </summary>
        /// <param name="whereText">Text to be mapped</param>
        /// <returns>SqlFilter object.</returns>
        /// <exception cref="ApplicationException">When property name found in braces is not found in the entity.</exception>
        public static SqlFilter Filter(String whereText) {
            return new SqlFilter(new SqlLiteralPredicate(ProcessExpression(propertyToSqlMap, whereText)));
        }

        /// <summary>
        /// Creates a where clause object that can be used to create sql to find objects whose entity property value
        /// matches the value passed.  Note that the propertyName passed is an entity property name and will be mapped
        /// to the appropriate sql.
        /// </summary>
        /// <param name="propertyName">Entity property to be matched.</param>
        /// <param name="value">Value to match the property with</param>
        /// <returns>A SqlFilter object.</returns>
        /// <exception cref="ApplicationException">When the property name passed is not found in the entity.</exception>
        public static SqlFilter Filter(String propertyName, String value) {
            return new SqlFilter(new SqlEqualityPredicate(GetPropertyMapping(propertyToSqlMap, propertyName), EqualityOperatorEnum.Equal, value));
        }

        /// <summary>
        /// Creates a where clause object that can be used to create sql to find objects whose entity property value
        /// matches the value passed.  Note that the propertyName passed is an entity property name and will be mapped
        /// to the appropriate sql.
        /// </summary>
        /// <param name="propertyName">Entity property to be matched.</param>
        /// <param name="value">Value to match the property with</param>
        /// <returns>A SqlFilter object.</returns>
        /// <exception cref="ApplicationException">When the property name passed is not found in the entity.</exception>
        public static SqlFilter Filter(String propertyName, Int32 value) {
            return new SqlFilter(new SqlEqualityPredicate(GetPropertyMapping(propertyToSqlMap, propertyName), EqualityOperatorEnum.Equal, value));
        }

        /// <summary>
        /// Creates a where clause object that can be used to create sql to find objects whose entity property value
        /// matches the value passed.  Note that the propertyName passed is an entity property name and will be mapped
        /// to the appropriate sql.
        /// </summary>
        /// <param name="propertyName">Entity property to be matched.</param>
        /// <param name="value">Value to match the property with</param>
        /// <returns>A SqlFilter object.</returns>
        /// <exception cref="ApplicationException">When the property name passed is not found in the entity.</exception>
        public static SqlFilter filter(String propertyName, DateTime value) {
            return new SqlFilter(new SqlEqualityPredicate(GetPropertyMapping(propertyToSqlMap, propertyName), EqualityOperatorEnum.Equal, value));
        }

        #region WhereClause
        protected IDataReader GetListReader(String key, String viewName) {
            return GetListReader(key, viewName, new SqlFilter(), null);
        }

        protected IDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause) {
            return GetListReader(key, viewName, whereClause, orderByClause, -1);
        }

        protected IDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause, Int32 maxRows) {
            return GetListReader(key, viewName, whereClause, orderByClause, maxRows, -1);
        }

        protected IDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause, Int32 maxRows, Int32 commandTimeout) {
            String sql = "";
            if (maxRows < 1) {
                sql = "select * from " + viewName;
            } else {
                sql = "select top " + maxRows.ToString() + " * from " + viewName;
            }
            if (whereClause != null) {
                sql = sql + whereClause.FormatSql();
            }
            if (orderByClause != null) {
                sql = sql + orderByClause.FormatSql();
            }

            return ExecuteReader(key, sql, commandTimeout);
        }
        #endregion

        #region SqlFilter
        protected IDataReader GetListReader(String key, String viewName, DatabaseFilter filter, IOrderBy orderByClause) {
            return GetListReader(key, viewName, filter, orderByClause, -1);
        }

        protected IDataReader GetListReader(String key, String viewName, DatabaseFilter filter, IOrderBy orderByClause, Int32 maxRows) {
            return GetListReader(key, viewName, filter, orderByClause, maxRows, -1);
        }

        protected IDataReader GetListReader(String key, String viewName, DatabaseFilter filter, IOrderBy orderByClause, Int32 maxRows, Int32 commandTimeout) {
            String sql = "";
            if (maxRows < 1) {
                sql = "select * from " + viewName;
            } else {
                sql = "select top " + maxRows.ToString() + " * from " + viewName;
            }
            if (filter != null && !filter.IsEmpty) {
                sql = sql + filter.Statement;
            }
            if (orderByClause != null) {
                sql = sql + orderByClause.FormatSql();
            }

            if (filter != null) {
                return ExecuteReader(key, sql, filter.Parameters, commandTimeout);
            } else {
                return ExecuteReader(key, sql, commandTimeout);
            }
        }

        #endregion

        protected IDataReader ExecuteReader(String key, String sql) {
            return ExecuteReader(key, sql, -1);
        }

        protected IDataReader ExecuteReader(String key, String sql, Int32 commandTimeout) {
            IDbCommand cmd = GetDbCommand(key);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            if (commandTimeout > 0) {
                cmd.CommandTimeout = commandTimeout;
            }

            try {
                // if there is a current connection scope, don't close the connection when the reader is closed
                IDataReader reader;
                if (DbConnectionScope.Current != null) {
                    reader = cmd.ExecuteReader();
                } else {
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                return reader;
            } catch (Exception ex) {
                throw new DaoException(ex.Message + " [running statement: " + sql + "]", ex);
            }
        }

        protected IDataReader ExecuteReader(String key, String sql, IDataParameterCollection parameters, Int32 commandTimeout) {
            IDbCommand cmd = GetDbCommand(key);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            if (commandTimeout > 0) {
                cmd.CommandTimeout = commandTimeout;
            }

            foreach (IDataParameter parameter in parameters) {
                cmd.Parameters.Add(parameter);
            }

            try {
                // if there is a current connection scope, don't close the connection when the reader is closed
                IDataReader reader;
                if (DbConnectionScope.Current != null) {
                    reader = cmd.ExecuteReader();
                } else {
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                return reader;
            } catch (Exception ex) {
                throw new DaoException(ex.Message + " [running statement: " + sql + "]", ex);
            }
        }

        protected abstract IDbCommand CreateCommand();

        protected IDbCommand GetDbCommand(String key) {
            IDbConnection conn = GetDbConnection(key);
            IDbCommand cmd = CreateCommand();
            cmd.Connection = conn;
            return cmd;
        }

        protected abstract IDbCommand GetDbCommand(String key, IDbTransaction transaction);

        protected IDbCommand GetDbCommand(String key, String commandText, CommandType commandType) {
            IDbCommand cmd = GetDbCommand(key);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            return cmd;
        }

        protected IDbCommand GetDbCommand(String key, String commandText, CommandType commandType, Int32 commandTimeout) {
            IDbCommand cmd = GetDbCommand(key);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = commandTimeout;
            return cmd;
        }

        protected IDbCommand GetDbCommand(String key, String commandText, CommandType commandType, Int32 commandTimeout, IDbTransaction transaction) {
            IDbCommand cmd = GetDbCommand(key, transaction);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = commandTimeout;
            return cmd;
        }

        protected abstract IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value);
        protected abstract IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value, int length);
        protected abstract IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value, byte precision, byte scale);

        protected abstract IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction);

        //	protected abstract IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, Int32 size, ParameterDirection direction, Boolean isNullable, Byte precision, Byte scale, String sourceColumn, DataRowVersion sourceVersion, Object value);

        protected IDbConnection GetDbConnection(String key) {
            String connectionString = GetConnectionString(key);
            IDbConnection conn = CreateConnection(connectionString);
            return conn;
        }

        protected abstract IDbConnection CreateConnection(String connectionString);

        protected IDbConnection GetDbConnection() {
            return GetDbConnection(ConnectionStringKey);
        }

        protected DaoTransaction GetDbTransaction(String key) {
            IDbConnection conn = GetDbConnection(key);
            return new DaoTransaction(conn.BeginTransaction());
        }

        public DaoTransaction GetDbTransaction() {
            return GetDbTransaction(ConnectionStringKey);
        }

        protected abstract String ConnectionStringKey {
            get;
        }

        protected virtual String GetConnectionString(String key) {
            return connectionStringStrategy.GetConnectionString(key);
        }

        protected static String ProcessExpression(Hashtable propertyToSqlMap, String expression) {
            String checkExpression = expression;
            String retVal = String.Empty;
            Int32 leftBrace = 0;
            Int32 startPos = 0;
            for (leftBrace = checkExpression.IndexOf("{", startPos); startPos >= 0; leftBrace = checkExpression.IndexOf("{", startPos)) {
                if (leftBrace == -1) {
                    // No more strings to replace.
                    retVal += checkExpression.Substring(startPos, checkExpression.Length - startPos);
                    break;
                } else {
                    // Concatenate portion of string without embedded references.
                    retVal += checkExpression.Substring(startPos, leftBrace - startPos);
                }
                Int32 rightBrace = checkExpression.IndexOf("}", leftBrace);
                if (rightBrace == -1) {
                    throw new ApplicationException("Where clause contains a left brace ({) with no corresponding right brace(}).");
                }

                // Isolate the property reference and concatenate it's expansion.
                String expressionReference = checkExpression.Substring(leftBrace + 1, rightBrace - leftBrace - 1);
                retVal += GetPropertyMapping(propertyToSqlMap, expressionReference);

                // On to the next reference.
                startPos = rightBrace + 1;
            }

            return retVal;
        }

        protected static String GetPropertyMapping(Hashtable propertyToSqlMap, String propertyName) {
            if (!propertyToSqlMap.ContainsKey(propertyName)) {
                throw new ApplicationException("Property " + propertyName + " not found for where clause.");
            }
            return propertyToSqlMap[propertyName] as String;
        }
    }
}
