using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ratings.Data.Entities;
using Ratings.Web.Models.Index;
using Ratings.Web.Models.Rating;

namespace Ratings.Web.Mapper
{
    public class Mapper
    {
        #region Map to model
        public IndexModel MapIndexToModel(Index index, IndexValue value)
        {
            return new IndexModel
            {
                Id = index.Id,
                Name = index.Name,
                ParentId = index.ParentId,
                Value = value?.Value,
                AddedDate = index.AddedDate,
                GroupId = index.GroupId,
                UOM = index.UOM
            };
        }

        //todo methods should be reviewed as copied from the admin area
        public GroupModel MapGroupToModel(Group group) //todo review
        {
            return new GroupModel
            {
                Id = group.Id,
                Name = group.Name,
                AddedDate = group.AddedDate
            };
        }

        public LineModel MapLineToModel(ListLine line) //todo review
        {
            return new LineModel
            {
                Id = line.Id,
                Line = line.Line
            };
        }

        public RatingModel MapRatingToModel(Rating rating)
        {
            return new RatingModel
            {
                Id = rating.Id,
                Name = rating.Name
                
            };
        }
        #endregion

        //#region Map to entity 
        //public Index MapIndexToEntity(IndexModel model) //todo review
        //{
        //    return new Index
        //    {
        //        Name = model.Name,
        //        UOM = model.UOM,
        //        ParentId = model.ParentId,
        //        GroupId = model.GroupId
        //    };
        //}

        //public Group MapGroupToEntity(GroupModel group) //todo review
        //{
        //    return new Group
        //    {
        //        Name = group.Name
        //    };
        //}

        //public Rating MapRatingToEntity(RatingModel model)
        //{
        //    return new Rating
        //    {
        //        Name = model.Name
        //    };
        //}
        //#endregion
    }
}