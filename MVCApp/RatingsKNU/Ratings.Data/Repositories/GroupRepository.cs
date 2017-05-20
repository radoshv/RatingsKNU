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
    public interface IGroupRepository : IGenericRepository<Group>
    {

    }

    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(RatingsContext context) : base(context)
        {

        }
    }
}
