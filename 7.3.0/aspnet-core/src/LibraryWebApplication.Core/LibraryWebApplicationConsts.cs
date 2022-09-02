using LibraryWebApplication.Debugging;

namespace LibraryWebApplication
{
    public class LibraryWebApplicationConsts
    {
        public const string LocalizationSourceName = "LibraryWebApplication";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e13e92c13ac24a3d87bce340009e6b47";
    }
}
