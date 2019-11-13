using System;

namespace Cortside.Core.Types {

    public interface ILocaleFactory {

        ILocale GetLocale(String locale);
    }
}
