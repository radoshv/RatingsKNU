using Ninject.Modules;
using Ninject.Web.Common;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.StructuralItems;

namespace Ratings.Ninject
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RatingsContext>().ToSelf().InRequestScope();

            #region Repositories
            Bind<IFacultiesRepository>().To<FacultiesRepository>();
            Bind<IInstitutionsRepository>().To<InstitutionsRepository>();
            Bind<ISchoolsWithOneTwoAccreditationLevelRepository>().To<SchoolsWithOneTwoAccreditationLevelRepository>();
            Bind<IUniversityStructureStatisticRepository>().To<UniversityStructureStatisticRepository>();
            #endregion
        }
    }
}
