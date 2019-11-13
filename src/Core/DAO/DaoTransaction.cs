using System.Data;

namespace Spring2.Core.DAO {

    public class DaoTransaction {

        protected IDbTransaction transaction;

        public DaoTransaction(IDbTransaction transaction) {
            this.transaction = transaction;
        }

        public IDbConnection Connection {
            get {
                return transaction.Connection;
            }
        }

        public IsolationLevel IsolationLevel {
            get {
                return transaction.IsolationLevel;
            }
        }

        public void Dispose() {
            transaction.Dispose();
        }

        public void Commit() {
            IDbConnection conn = transaction.Connection;
            try {
                transaction.Commit();
            } finally {
                conn.Close();
            }
        }

        public void Rollback() {
            IDbConnection conn = transaction.Connection;
            try {
                transaction.Rollback();
            } finally {
                conn.Close();
            }
        }

        public IDbTransaction DbTransaction {
            get {
                return transaction;
            }
        }
    }
}
