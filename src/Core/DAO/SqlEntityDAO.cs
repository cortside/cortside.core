using System;
using System.Data;
using System.Data.SqlClient;

namespace Spring2.Core.DAO {

    public abstract class SqlEntityDAO : BaseEntityDAO {

        public SqlEntityDAO() {
        }

        public SqlEntityDAO(IConnectionStringStrategy strategy) : base(strategy) {
        }

        protected override IDbCommand GetDbCommand(String key, IDbTransaction transaction) {

            if (transaction == null) {
                return GetDbCommand(key);
            } else {
                // for now, since there is no functionality for enlisting a connection in a distributed transaction,
                // throw an exception if the connection string is not the same
                //TODO: this will not be the same if there is a password in it
                //		if (!transaction.Connection.ConnectionString.Equals(key)) {
                //		    throw new DaoException("Connection string from transaction (" + transaction.Connection.ConnectionString + ") does not match connection string (" + connectionString + ") retrieved by key (" + key + ")");
                //		}

                IDbCommand cmd = new SqlCommand();
                cmd.Connection = transaction.Connection;
                cmd.Transaction = transaction;
                return cmd;
            }
        }

        protected override IDbCommand CreateCommand() {
            return new SqlCommand();
        }

        protected IDbDataParameter CreateDataParameter(ColumnMetaData meta, Object value) {
            return CreateDataParameter(meta, ParameterDirection.Input, value);
        }

        protected IDbDataParameter CreateDataParameter(ColumnMetaData meta, ParameterDirection direction, Object value) {
            return CreateDataParameter("@" + meta.SqlName, meta, direction, value);
        }

        protected IDbDataParameter CreateDataParameter(string parameterName, ColumnMetaData meta, Object value) {
            return CreateDataParameter(parameterName, meta, ParameterDirection.Input, value);
        }

        protected IDbDataParameter CreateDataParameter(string parameterName, ColumnMetaData meta, ParameterDirection direction,
                                                       Object value) {
            if (meta.Length == 0) {
                return CreateDataParameter(parameterName, meta.DBType, direction, value, meta.Precision, meta.Scale);
            } else {
                return CreateDataParameter(parameterName, meta.DBType, direction, value, meta.Length);
            }
        }

        protected override IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value) {
            return CreateDataParameter(parameterName, dbType, direction, value, 0, 0, 0);
        }

        protected override IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value, int length) {
            return CreateDataParameter(parameterName, dbType, direction, value, length, 0, 0);
        }

        protected override IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value, byte precision, byte scale) {
            return CreateDataParameter(parameterName, dbType, direction, value, 0, precision, scale);
        }

        private IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction, Object value, int length, byte precision, byte scale) {
            SqlParameter param = new SqlParameter(parameterName, value);
            param.DbType = dbType;
            param.Direction = direction;
            if (length > 0) {
                param.Size = length;
            }
            if (precision > 0) {
                param.Precision = precision;
            }
            if (scale > 0) {
                param.Scale = scale;
            }
            return param;
        }

        protected override IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, ParameterDirection direction) {
            SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar);
            param.DbType = dbType;
            param.Direction = direction;
            return param;
        }

        protected SqlEqualityPredicate CreateEqualityPredicate(ColumnMetaData meta, EqualityOperatorEnum op, Object value) {
            if (meta.Length == 0) {
                return new SqlEqualityPredicate(meta.SqlName, op, value, meta.Precision, meta.Scale);
            } else {
                return new SqlEqualityPredicate(meta.SqlName, op, value, meta.Length);
            }
        }

        //	protected override IDbDataParameter CreateDataParameter(String parameterName, DbType dbType, Int32 size, ParameterDirection direction, Boolean isNullable, Byte precision, Byte scale, String sourceColumn, DataRowVersion sourceVersion, Object value) {
        //	    SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar, size, direction, isNullable, precision, scale, sourceColumn, sourceVersion, value);
        //	    param.DbType = dbType;
        //	    return param;
        //	}

        protected override IDbConnection CreateConnection(String connectionString) {
            IDbConnection connection = null;
            // check to see if there is a current connection scope and pull connection from that, otherwise create and open a new one
            if (DbConnectionScope.Current != null) {
                connection = DbConnectionScope.Current.GetOpenConnection(SqlClientFactory.Instance, connectionString, false);
            } else {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            InitConnection(connection);
            return connection;
        }

        protected virtual void InitConnection(IDbConnection connection) { }
    }
}
