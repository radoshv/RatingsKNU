using System.Data.Entity;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Abstract;

namespace Ratings.Data.Repositories
{
    public interface IFacultyRepository : IGenericRepository<Faculty>
    {

    }

    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(RatingsContext context) : base(context)
        {

        }
    }
}
