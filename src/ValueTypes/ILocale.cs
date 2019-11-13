using System;

namespace Spring2.Core.Types {
    /// <summary>
    /// ResourceManager is able to operate on instances of ILocale.
    /// Use this interface to make your custom locale compatibile with the resource manager
    /// </summary>
    public interface ILocale {
        ILocale GetInstanceNonStatic(Object value);

        String Code {
            get;
        }

    }

}
