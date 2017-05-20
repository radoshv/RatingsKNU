using System.Web.Http;

namespace Ratings.Ninject
{
    /// <summary>
    /// The startup config.
    /// </summary>
    public class StartupConfig
    {
        private static System.Web.Http.HttpConfiguration _config;

        /// <summary>
        /// Gets the config.
        /// </summary>
        public static HttpConfiguration Config => _config ?? (_config = new HttpConfiguration());
    }
}
