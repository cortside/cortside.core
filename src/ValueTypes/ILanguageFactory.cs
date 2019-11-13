using System;

namespace Cortside.Core.Types {

    public interface ILanguageFactory {

        ILanguage GetLanguage(String language);
    }
}
