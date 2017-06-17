using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ratings.Data.Enums;

namespace Ratings.Web.Areas.Admin.Models
{
    public class IndexModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public UnitOfMeasure UOM { get; set; }
        public DateTime AddedDate { get; set; }
    }
}