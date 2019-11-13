using Cortside.Core.DAO;

namespace Cortside.Core.Test.DAO {

    /// <summary>
    /// Summary description for TestDAO.
    /// </summary>
    public class TestDAO : SqlEntityDAO {

        protected override string ConnectionStringKey {
            get { return "BloggingDatabase"; }
        }

        public static void GetConnectionString() {
            TestDAO dao = new TestDAO();
            var s = dao.GetConnectionString(dao.ConnectionStringKey);
            if (s == null) {
                throw new System.Exception("didn't find it");
            }
        }
    }
}
