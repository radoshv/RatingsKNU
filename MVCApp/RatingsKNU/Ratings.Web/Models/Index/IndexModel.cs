using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ratings.Web.Models.Index
{
    public class IndexModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }

        //public ICollection<> 
    }
}