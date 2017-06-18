using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Versioning;
using System.Web;
using System.Web.Mvc;
using Ratings.Data;
using Ratings.Data.Repositories;
using Ratings.Web.Areas.Admin.Models;
using Ratings.Data.Entities;
using IndexModel = Ratings.Web.Models.Index.IndexModel;

namespace Ratings.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IIndexRepository _indexRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly Mapper _mapper;

        public RatingController(IRatingRepository ratingRepository, IIndexRepository indexRepository,
            IGroupRepository groupRepository)
        {
            _ratingRepository = ratingRepository;
            _indexRepository = indexRepository;
            _groupRepository = groupRepository;
            _mapper = new Mapper();
        }

        // GET: Admin/Rating
        public ActionResult Index()
        {
            var models = _ratingRepository
                .GetAll()
                .Select(_mapper.MapRatingToModel);

            return View(models);
        }

        // GET: Admin/Rating/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var groupModel = _ratingRepository
                .FindBy(g => g.Id == id)
                .Select(_mapper.MapRatingToModel)
                .FirstOrDefault();

            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // GET: Admin/Rating/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Rating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.MapRatingToEntity(ratingModel);
                _ratingRepository.Add(entity);
                _ratingRepository.Save();
                return RedirectToAction("Index");
            }

            return View(ratingModel);
        }

        // GET: Admin/Rating/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _ratingRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();
            if (entity == null)
                return HttpNotFound();

            var editModel = new EditRatingModel
            {
                Id = entity.Id,
                Name = entity.Name,
                CheckedGroupModels = GetCheckedGroupModels(entity)
            };

            return View(editModel);
        }

        private ICollection<CheckedGroupModel> GetCheckedGroupModels(Rating rating)
        {
            var indices = _indexRepository.GetAll().ToList();
            var groups = _groupRepository.GetAll().ToList();

            var ind = indices.Select(i => new CheckedIndexModel
                  {
                      Id = i.Id,
                      AddedDate = i.AddedDate,
                      Checked = rating.Indices.Contains(i),
                      GroupId = i.GroupId,
                      GroupName = i.Group.Name,
                      Name = i.Name,
                      ParentId = i.ParentId,
                      UOM = i.UOM
                  }).ToList();

            var groupmodels = groups.Select(g => new CheckedGroupModel
            {
                AddedDate = g.AddedDate,
                Name = g.Name,
                Id = g.Id,
                CheckedIndexModels = ind.Where(i => i.GroupId == g.Id).OrderBy(i => i.AddedDate).ToList()
            }).OrderBy(g => g.AddedDate).ToList();
            return groupmodels;
        } 

        private ICollection<CheckedGroupModel> GetCheckedGroupModels(Guid ratingId)
        {
            var groups = _groupRepository.GetAll().ToList();
            var groupModels = groups.Select(g => new CheckedGroupModel
            {
                AddedDate = g.AddedDate,
                Id = g.Id,
                Name = g.Name,
                CheckedIndexModels = GetIndexModelsForGroup(g.Indices, ratingId)
            }).OrderBy(i => i.AddedDate);

            return groupModels.ToList();
        }
        private ICollection<CheckedIndexModel> GetIndexModelsForGroup(ICollection<Index> indices, Guid ratingId)
        {
            var checkedModels = indices.Select(i => new CheckedIndexModel
            {
                Checked = i.Ratings.Any(r => r.Id == ratingId),
                Id = i.Id,
                GroupId = i.GroupId,
                Name = i.Name,
                GroupName = i.Group.Name,
                ParentId = i.ParentId,
                UOM = i.UOM,
                AddedDate = i.AddedDate
            })
            .OrderBy(i => i.AddedDate).ToList();

            return checkedModels;
        }

        // POST: Admin/Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _ratingRepository.FindBy(r => r.Id == ratingModel.Id).FirstOrDefault();
                if (entity == null) return HttpNotFound();

                entity.Name = ratingModel.Name;

                UpdateCheckedIndices(ratingModel.CheckedGroupModels
                    .SelectMany(r => r.CheckedIndexModels), entity);

                _ratingRepository.Edit(entity);
                _ratingRepository.Save();
                return RedirectToAction("Index");
            }
            return View(ratingModel);
        }

        // GET: Admin/Rating/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _ratingRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();
            if (entity == null)
            {
                return HttpNotFound();
            }

            var ratingModel = _mapper.MapRatingToModel(entity);
            return View(ratingModel);
        }

        // POST: Admin/Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var entity = _ratingRepository.FindBy(m => m.Id == id).First();
            _ratingRepository.Delete(entity);
            _ratingRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Save()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Index> GetAllIndices(Predicate<Index> filter = null)
        {
            var indices = _indexRepository.GetAll().ToList();
            if (filter != null)
                indices = indices.Where(i => filter(i)).ToList();

            return indices;
        }

        private void UpdateCheckedIndices(IEnumerable<CheckedIndexModel> checkedModels, Rating rating)
        {
            foreach (var checkedModel in checkedModels)
            {
                if (checkedModel.Checked && rating.Indices.All(i => i.Id != checkedModel.Id)) // added new element
                {
                    var entity = _indexRepository.FindBy(i => i.Id == checkedModel.Id).First();
                    rating.Indices.Add(entity);
                    entity.Ratings.Add(rating);
                }
                else if (!checkedModel.Checked && rating.Indices.Any(i => i.Id == checkedModel.Id)) // removed element
                {
                    var entity = _indexRepository.FindBy(i => i.Id == checkedModel.Id).First();
                    rating.Indices.Remove(entity);
                    entity.Ratings.Remove(rating);
                }
            }

            _indexRepository.Save();
        }
    }
}
