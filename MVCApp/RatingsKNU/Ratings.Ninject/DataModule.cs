using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Ninject.Modules;
using Ninject.Web.Common;
using Ratings.Data;
using Ratings.Data.Entities;
using Ratings.Data.Managers;
using Ratings.Data.Repositories;

namespace Ratings.Ninject
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationUserManager>()
                .ToMethod(
                    context =>
                        new ApplicationUserManager(
                            new UserStore<ApplicationUser>(
                                Kernel.GetService(typeof (RatingsContext)) as RatingsContext)))
                .InRequestScope();
            var ifo = new IdentityFactoryOptions<ApplicationSignInManager>
            {
                DataProtectionProvider = DependencyResolver.Current.GetService<IDataProtectionProvider>()
            };
            Bind<ApplicationSignInManager>()
                .ToMethod(m => ApplicationSignInManager.Create(ifo, HttpContext.Current.GetOwinContext()))
                .InRequestScope();

            //todo inject dbcontext to ratingscontext
            Bind<RatingsContext>().ToSelf().InRequestScope();

            Bind<IFacultyRepository>().To<FacultyRepository>();
            Bind<IGroupRepository>().To<GroupRepository>();
            Bind<IIndexRepository>().To<IndexRepository>();
            Bind<IIndexValueRepository>().To<IndexValueRepository>();
            Bind<IListLineRepository>().To<ListLineRepository>();
            Bind<IRatingRepository>().To<RatingRepository>();
        }
    }
}
