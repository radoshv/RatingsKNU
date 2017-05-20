using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ratings.Data.Enums;

namespace Ratings.Data.Entities
{
    public class Index : BaseEntity // показник
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public UnitOfMeasure UOM { get; set; }

        // для показників, які залежать від інших показників
        public Guid? ParentId { get; set; }
        public Index Parent { get; set; }

        // група, до якої належить показник
        public Guid GroupId { get; set; } 
        public virtual Group Group { get; set; }
    }
}
