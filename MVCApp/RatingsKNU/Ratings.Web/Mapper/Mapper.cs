using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ratings.Data.Entities;
using Ratings.Web.Models.Index;

namespace Ratings.Web.Mapper
{
    public class Mapper
    {
        public IndexModel MapIndex(Index index, IndexValue value)
        {
            return new IndexModel
            {
                Id = index.Id,
                Name = index.Name,
                ParentId = index.ParentId,
                Value = value?.Value
            };
        }

         
    }
}