using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Ratings.Data.Entities;
using Ratings.Data.Repositories;
using Ratings.Web.Helpers;
using Ratings.Web.Models.Index;
using Ratings.Web.Models.Rating;

namespace Ratings.Web.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IIndexRepository _indexRepository;
        private readonly IIndexValueRepository _indexValueRepository;
        private readonly IFacultyRepository _facultyRepository;
        private Mapper.Mapper _mapper;
        private readonly Faculty _currFaculty;

        public RatingController(IRatingRepository ratingRepository, IIndexValueRepository indexValueRepository,
            IFacultyRepository facultyRepository, IIndexRepository indexRepository)
        {
            _ratingRepository = ratingRepository;
            _indexRepository = indexRepository;
            _indexValueRepository = indexValueRepository;
            _facultyRepository = facultyRepository;
            _mapper = new Mapper.Mapper();

            _currFaculty = facultyRepository.FindBy(f => f.Name == "ФІТ").First(); // temp
        }

        // GET: Rating
        public ActionResult Index()
        {
            var list = _ratingRepository
                .GetAll()
                .Select(_mapper.MapRatingToModel);

            return View(list);
        }

        public ActionResult Indices(Guid? ratingId)
        {
            if (ratingId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var rating = _ratingRepository.FindBy(r => r.Id == ratingId.Value).FirstOrDefault();
            if (rating == null)
                return HttpNotFound();

            var ratingModel = _mapper.MapRatingToModel(rating);
            var indexModels = GetIndexModels(rating.Indices);

            ratingModel.Indices = indexModels.ToList();

            return View(ratingModel);
        }

        public ActionResult Save(RatingModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.Indices)
                {
                    var entity =
                        _indexValueRepository.FindBy(i => i.IndexId == item.Id && i.FacultyId == _currFaculty.Id)
                            .FirstOrDefault();
                    if (entity == null)
                    {
                        entity = new IndexValue
                        {
                            Value = item.Value,
                            FacultyId = _currFaculty.Id,
                            IndexId = item.Id
                        };

                        _indexValueRepository.Add(entity);
                    }
                    else
                    {
                        entity.Value = item.Value;
                        _indexValueRepository.Edit(entity);
                    }
                }
                _indexValueRepository.Save();
            }
            return View("Indices", model);
        }

        public ActionResult ToExcel(Guid? ratingId)
        {
            if (ratingId == null) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // excel code
            var rating = _ratingRepository.FindBy(r => r.Id == ratingId.Value).FirstOrDefault();
            var indexIds = rating?.Indices.Select(i => i.Id).ToList();
            if (rating == null)
                return HttpNotFound();

            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id && indexIds.Contains(v.IndexId)).ToList();
            ExportExcel.ExportRatingsToExel(values, rating);
            return RedirectToAction("Index");
        }

        private IEnumerable<IndexModel> GetAllIndexModels(Predicate<Index> filter)
        {
            var indices = _indexRepository.GetAll().Where(i => filter(i)).ToList();

            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id).ToList();

            var models = indices
                .LeftJoin(values, i => i.Id, v => v.IndexId, (i, v) => new { Index = i, Value = v })
                .Select(r => _mapper.MapIndexToModel(r.Index, r.Value));

            return models;
        }

        private IEnumerable<IndexModel> GetIndexModels(IEnumerable<Index> indices)
        {
            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id).ToList();
            var models = indices
                .LeftJoin(values, i => i.Id, v => v.IndexId, (i, v) => new {Index = i, Value = v})
                .Select(r => _mapper.MapIndexToModel(r.Index, r.Value));

            return models;
        }
    }
}