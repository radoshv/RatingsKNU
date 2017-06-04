using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ratings.Web.Models.Index;

namespace Ratings.Web.Models.Rating
{
    public class RatingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<IndexModel> Indices { get; set; }
    }
}