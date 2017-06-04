﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings.Data.Entities
{
    public class Rating : BaseEntity
    {
        public Rating()
        {
            Indices = new HashSet<Index>();
        }
        public string Name { get; set; }

        public virtual ICollection<Index> Indices { get; set; }
    }
}
