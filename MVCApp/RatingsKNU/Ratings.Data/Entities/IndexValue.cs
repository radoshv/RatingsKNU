using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings.Data.Entities
{
    public class IndexValue : BaseEntity
    {
        public Guid IndexId { get; set; }
        public Index Index { get; set; }

        public Guid? FacultyId { get; set; }
        public virtual Faculty Faculty {get; set; }

        public decimal? Value { get; set; }
    }
}
