using System;

namespace Cortside.Core.DAO {
    public interface IConnectionStringStrategy {
        String GetConnectionString(String key);
    }
}
