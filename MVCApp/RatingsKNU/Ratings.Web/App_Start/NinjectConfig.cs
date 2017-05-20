using Ratings.Ninject;
using Ratings.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectConfig), "Stop")]

namespace Ratings.Web
{
    public static class NinjectConfig
    {
        /// <summary>
        /// Starts initialisation of the Ninject bindings.
        /// </summary>
        public static void Start()
        {
            NinjectWebCommon.Start(new DataModule());
        }

        /// <summary>
        /// Destroys the Ninject bindings.
        /// </summary>
        public static void Stop()
        {
            NinjectWebCommon.Stop();
        }
    }
}
