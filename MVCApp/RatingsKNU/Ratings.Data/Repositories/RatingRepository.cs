using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Abstract;

namespace Ratings.Data.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        
    }
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(RatingsContext context) : base(context)
        {
        }
    }
}
