using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ratings.Web.Areas.Admin.Models
{
    public class RatingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<IndexModel> IndexAdminModels { get; set; }
    }
}