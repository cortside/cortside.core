using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using Spring2.Core.Util;

namespace Spring2.Core.DAO {

    public abstract class EntityDAO {

        private static StringDictionary connectionStrings = new StringDictionary();
        protected static SqlDataReader GetListReader(String key, String viewName) {
            return GetListReader(key, viewName, null, null);
        }

        /// <summary>
        /// Gets a data reader.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="viewName">View name to use.</param>
        /// <param name="whereClause">Where clause to use or null.</param>
        /// <param name="orderByClause">Order by clause to use or null</param>
        /// <returns>DataReader containing selected data</returns>
        protected static SqlDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause) {
            return GetListReader(key, viewName, whereClause, orderByClause, -1);
        }

        /// <summary>
        /// Gets a data reader.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="viewName">View name to use.</param>
        /// <param name="whereClause">Where clause to use or null.</param>
        /// <param name="orderByClause">Order by clause to use or null</param>
        /// <param name="maxRows">Maximum number of rows to return or </param>
        /// <returns>DataReader containing selected data</returns>
        protected static SqlDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause, Int32 maxRows) {
            return GetListReader(key, viewName, whereClause, orderByClause, maxRows, -1);
        }

        /// <summary>
        /// Gets a data reader.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="viewName">View name to use.</param>
        /// <param name="whereClause">Where clause to use or null.</param>
        /// <param name="orderByClause">Order by clause to use or null</param>
        /// <param name="maxRows">Maximum number of rows to return or lt 1 for unlimitted.</param>
        /// <param name="commandTimeout">Number of seconds before command times out or lt 1 for default.</param>
        /// <returns>DataReader containing selected data</returns>
        protected static SqlDataReader GetListReader(String key, String viewName, IWhere whereClause, IOrderBy orderByClause, Int32 maxRows, Int32 commandTimeout) {
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

        protected static SqlDataReader ExecuteReader(String key, String sql) {
            return ExecuteReader(key, sql, -1);
        }

        protected static SqlDataReader ExecuteReader(String key, String sql, Int32 commandTimeout) {
            SqlCommand cmd = GetSqlCommand(key);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            if (commandTimeout > 0) {
                cmd.CommandTimeout = commandTimeout;
            }

            try {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            } catch (Exception ex) {
                throw new DaoException(ex.Message + " [running statement: " + sql + "]", ex);
            }
        }

        protected static SqlCommand GetSqlCommand(String key, SqlTransaction transaction) {
            Timer timer = new Timer();

            String connectionString = GetConnectionString(key);

            if (transaction != null) {
                // for now, since there is no functionality for enlisting a connection in a distributed transaction,
                // throw an exception if the connection string is not the same
                //TODO: this will not be the same if there is a password in it
                //		if (!transaction.Connection.ConnectionString.Equals(key)) {
                //		    throw new DaoException("Connection string from transaction (" + transaction.Connection.ConnectionString + ") does not match connection string (" + connectionString + ") retrieved by key (" + key + ")");
                //		}

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = transaction.Connection;
                cmd.Transaction = transaction;

                return cmd;
            } else {
                SqlCommand cmd = GetSqlCommand(key);
                // TODO: System.EnterpriseServices.ITransaction is needed to enlist a connection in a DTC transaction
                //if (transaction != null) {
                //    cmd.Connection.EnlistDistributedTransaction(transaction);
                //}
                return cmd;
            }
        }

        /// <summary>
        /// Determine where the connection string comes from and what it is
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected static String GetConnectionString(String key) {
            String connectionString;

            // try cache first
            if (connectionStrings[key] != null) {
                return connectionStrings[key];
            }

            if (key.ToLower().StartsWith("registry")) {
                String subkey = key.Substring(key.LastIndexOf(":") + 1);
                subkey = subkey.Substring(0, subkey.LastIndexOf("\\"));
                String value = key.Substring(key.LastIndexOf("\\") + 1);
                String hive = key.Substring(9, 4).ToUpper();
                RegistryKey rkey;
                if (hive.Equals("HKLM")) {
                    rkey = Registry.LocalMachine.OpenSubKey(subkey);
                } else if (hive.Equals("HKCU")) {
                    rkey = Registry.CurrentUser.OpenSubKey(subkey);
                } else {
                    throw new Exception("Unable to determine hive from registry type connection key.  Hive understood: " + hive + "  Key used was: " + key);
                }
                if (rkey == null) {
                    throw new Exception("Specified subkey was not found.  Subkey: " + subkey);
                }
                connectionString = rkey.GetValue(value).ToString();
            } else {
                connectionString = ConfigurationManager.AppSettings[key];
            }

            // cache the connection string by key for fast lookup later
            connectionStrings.Add(key, connectionString);

            return connectionString;
        }

        protected static SqlConnection GetSqlConnection(String connectionString) {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }

        protected static SqlCommand GetSqlCommand(String key) {
            String connectionString = GetConnectionString(key);

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            return cmd;
        }

        protected static SqlCommand GetSqlCommand(String key, String commandText, CommandType commandType) {
            SqlCommand cmd = GetSqlCommand(key);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            return cmd;
        }

        protected static SqlCommand GetSqlCommand(String key, String commandText, CommandType commandType, Int32 commandTimeout) {
            SqlCommand cmd = GetSqlCommand(key);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = commandTimeout;
            return cmd;
        }

        protected static SqlCommand GetSqlCommand(String key, String commandText, CommandType commandType, Int32 commandTimeout, SqlTransaction transaction) {
            SqlCommand cmd = GetSqlCommand(key, transaction);
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = commandTimeout;
            return cmd;
        }

        /// <summary>
        /// Returns the sql string for a given entity property name.
        /// </summary>
        /// <param name="propertyToSqlMap">Mapping of property names to sql expressions.</param>
        /// <param name="propertyName">Name of property name to map</param>
        /// <returns>Sql string used to retrieve the property value.</returns>
        /// <exception cref="ApplicationException">When property passed is not found.</exception>
        protected static String GetPropertyMapping(Hashtable propertyToSqlMap, String propertyName) {
            if (!propertyToSqlMap.ContainsKey(propertyName)) {
                throw new ApplicationException("Property " + propertyName + " not found for where clause.");
            }
            return "(" + (String)(propertyToSqlMap[propertyName]) + ")";
        }

        /// <summary>
        /// Maps a string with embedded property names to a string using the sql expressions that correspond to the
        /// property names.  The embedded property names are entity property names and must be enclosed in braces ({}).
        /// </summary>
        /// <param name="propertyToSqlMap">Mapping of property names to sql expressions.</param>
        /// <param name="expression">expression containing property names to map</param>
        /// <returns>String with property names replaced with sql expressions.</returns>
        protected static string ProcessExpression(Hashtable propertyToSqlMap, string expression) {
            string checkExpression = expression;
            string retVal = String.Empty;
            int leftBrace = 0;
            int startPos = 0;
            for (leftBrace = checkExpression.IndexOf("{", startPos); startPos >= 0; leftBrace = checkExpression.IndexOf("{", startPos)) {
                if (leftBrace == -1) {
                    // No more strings to replace.
                    retVal += checkExpression.Substring(startPos, checkExpression.Length - startPos);
                    break;
                } else {
                    // Concatenate portion of string without embedded references.
                    retVal += checkExpression.Substring(startPos, leftBrace - startPos);
                }
                int rightBrace = checkExpression.IndexOf("}", leftBrace);
                if (rightBrace == -1) {
                    throw new ApplicationException("Where clause contains a left brace ({) with no corresponding right brace(}).");
                }

                // Isolate the property reference and concatenate it's expansion.
                string expressionReference = checkExpression.Substring(leftBrace + 1, rightBrace - leftBrace - 1);
                retVal += GetPropertyMapping(propertyToSqlMap, expressionReference);

                // On to the next reference.
                startPos = rightBrace + 1;
            }

            return retVal;
        }
    }
}
