using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ratings.Web.Startup))]
namespace Ratings.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
