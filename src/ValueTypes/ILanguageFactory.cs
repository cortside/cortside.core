using System;
using Spring2.Core.Types;

namespace Spring2.Core.Types {

    public interface ILanguageFactory {

	ILanguage GetLanguage(String language);
    }
}
