using System;
using System.Data.SqlClient;

namespace Cortside.Core.DAO {
    public class SqlDaoTransaction : DaoTransaction {

        public SqlDaoTransaction(SqlTransaction trans) : base(trans) { }

        public void Rollback(String transactionName) {
            SqlTransaction trans = transaction as SqlTransaction;
            SqlConnection conn = trans.Connection;
            try {
                trans.Rollback(transactionName);
            } finally {
                conn.Close();
            }
        }
    }
}