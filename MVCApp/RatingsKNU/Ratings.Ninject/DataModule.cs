using Ninject.Modules;
using Ninject.Web.Common;
using Ratings.Data;
using Ratings.Data.Entities;
using Ratings.Data.Repositories;

namespace Ratings.Ninject
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
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
