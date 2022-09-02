using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LibraryWebApplication.Localization
{
    public static class LibraryWebApplicationLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LibraryWebApplicationConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LibraryWebApplicationLocalizationConfigurer).GetAssembly(),
                        "LibraryWebApplication.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
