using System;

namespace Spring2.Core.Types {

    public interface ILocaleFactory {

        ILocale GetLocale(String locale);
    }
}
