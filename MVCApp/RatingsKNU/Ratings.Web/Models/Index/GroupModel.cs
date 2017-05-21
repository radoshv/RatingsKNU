using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ratings.Web.Models.Index
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<IndexModel> Indices { get; set; }
    }
}