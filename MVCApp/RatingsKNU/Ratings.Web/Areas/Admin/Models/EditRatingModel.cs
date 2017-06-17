using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ratings.Web.Areas.Admin.Models
{
    public class EditRatingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CheckedGroupModel> CheckedGroupModels { get; set; }
    }
}