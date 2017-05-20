using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            AddedDate = DateTime.UtcNow;
        }

        private DateTime _addedDate;
        [DisplayName("Дата створення")]
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }
    }
}
