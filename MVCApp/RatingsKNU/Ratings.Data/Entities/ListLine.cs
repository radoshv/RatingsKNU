using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings.Data.Entities
{
    public class ListLine : BaseEntity // для показників, до яких прив'язаний перелік
    {
        public Guid? FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        public string Line { get; set; }
    }
}
