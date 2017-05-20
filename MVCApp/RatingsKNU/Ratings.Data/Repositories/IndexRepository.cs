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
    public interface IIndexRepository : IGenericRepository<Index>
    {
        
    }

    public class IndexRepository : BaseRepository<Index>, IIndexRepository
    {
        public IndexRepository(RatingsContext context) : base(context)
        {
            
        }
    }
}
