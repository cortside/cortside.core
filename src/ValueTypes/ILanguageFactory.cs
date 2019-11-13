using System;

namespace Spring2.Core.Types {

    public interface ILanguageFactory {

        ILanguage GetLanguage(String language);
    }
}
