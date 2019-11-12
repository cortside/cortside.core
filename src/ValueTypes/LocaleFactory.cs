using System;

namespace Spring2.Core.Types {
    /// <summary>
    /// Summary description for LocaleFactory.
    /// </summary>
    public class LocaleFactory : ILocaleFactory {
	public LocaleFactory() {}

	public ILocale GetLocale(String locale) {
	    return LocaleEnum.GetInstance(locale);
	}
    }
}
