using System;
using System.Collections.Generic;
using Ratings.Data.Entities;
using Ratings.Web.Areas.Admin.Models;

namespace Ratings.Web.Areas.Admin
{
    public class Mapper
    {
        public IndexModel MapIndexToModel(Index index)
        {
            return new IndexModel
            {
                Id = index.Id,
                Name = index.Name,
                GroupId = index.GroupId,
                GroupName = index.Group.Name,
                ParentId = index.ParentId,
            };
        }

        public GroupModel MapGroupToModel(Group group)
        {
            return new GroupModel
            {
                Id = group.Id,
                Name = group.Name
            };
        }
        public RatingModel MapRatingToModel(Rating group)
        {
            return new RatingModel
            {
                Id = group.Id,
                Name = group.Name
            };
        }

        public LineModel MapLineToModel(ListLine line)
        {
            return new LineModel
            {
                Id = line.Id,
                Line = line.Line
            };
        }

        public Index MapIndexToEntity(IndexModel model)
        {
            return new Index
            {
                Name = model.Name,
                UOM = model.UOM,
                ParentId = model.ParentId,
                GroupId = model.GroupId
            };
        }

        public Group MapGroupToEntity(GroupModel group)
        {
            return new Group
            {
                Name = group.Name
            };
        }
        public Rating MapRatingToEntity(RatingModel rating)
        {
            return new Rating
            {
                Name = rating.Name
            };
        }
    }
}