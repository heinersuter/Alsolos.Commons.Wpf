namespace Alsolos.Commons.Wpf.I18N
{
    using System.Collections.Generic;
    using System.Globalization;

    public interface ITranslationProvider
    {
        IEnumerable<CultureInfo> Languages { get; }

        object Translate(string key);
    }
}
