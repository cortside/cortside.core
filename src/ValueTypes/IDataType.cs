using System;

namespace Spring2.Core.Types {

    /// <summary>
    /// Common interface for all core types
    /// </summary>
    public interface IDataType {

	Boolean IsDefault { get; }
	Boolean IsUnset { get; }
	Boolean IsValid { get; }
    
    }
}
