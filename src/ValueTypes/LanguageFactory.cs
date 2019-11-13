using System;

namespace Cortside.Core.Types {
    /// <summary>
    /// Summary description for LanguageFactory.
    /// </summary>
    public class LanguageFactory : ILanguageFactory {
        public LanguageFactory() { }

        public ILanguage GetLanguage(String language) {
            return LanguageEnum.GetInstance(language);
        }
    }
}