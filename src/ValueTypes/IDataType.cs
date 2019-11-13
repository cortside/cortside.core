using System;

namespace Cortside.Core.Types {

    /// <summary>
    /// Common interface for all core types
    /// </summary>
    public interface IDataType {

        Boolean IsDefault { get; }
        Boolean IsUnset { get; }
        Boolean IsValid { get; }

    }
}
