using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ratings.Web.Areas.Admin.Models
{
    public class CheckedGroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public ICollection<CheckedIndexModel> CheckedIndexModels { get; set; }
    }
}