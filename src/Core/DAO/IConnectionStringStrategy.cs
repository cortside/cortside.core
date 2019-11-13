using System;

namespace Spring2.Core.DAO {
    public interface IConnectionStringStrategy {
        String GetConnectionString(String key);
    }
}
