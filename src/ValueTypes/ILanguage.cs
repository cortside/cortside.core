using System;

namespace Cortside.Core.Types {
    /// <summary>
    /// ResourceManager is able to operate on instances of ILanguage.
    /// Use this interface to make your custom language enum compatibile with the resource manager
    /// </summary>
    public interface ILanguage {
        ILanguage GetInstanceNonStatic(Object value);

        String Code {
            get;
        }

    }
}
