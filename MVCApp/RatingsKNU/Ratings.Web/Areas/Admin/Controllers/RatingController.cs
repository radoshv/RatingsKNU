using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ratings.Data;
using Ratings.Data.Repositories;
using Ratings.Web.Areas.Admin.Models;

namespace Ratings.Web.Areas.Admin.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly Mapper _mapper;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
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
            var model = _mapper.MapRatingToModel(entity);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Rating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _ratingRepository.FindBy(m => m.Id == ratingModel.Id).First();
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
    }
}
