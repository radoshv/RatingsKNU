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
    [Authorize(Roles = "Admin")]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        //todo inject mapper
        private readonly Mapper _mapper;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _mapper = new Mapper();
        }

        // GET: Admin/Group
        public ActionResult Index()
        {
            var model = _groupRepository
                .GetAll()
                .Select(_mapper.MapGroupToModel);
            return View(model);
        }

        // GET: Admin/Group/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var groupModel = _groupRepository
                .FindBy(g => g.Id == id)
                .Select(_mapper.MapGroupToModel)
                .FirstOrDefault();

            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // GET: Admin/Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.MapGroupToEntity(groupModel);
                _groupRepository.Add(entity);
                _groupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(groupModel);
        }

        // GET: Admin/Group/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _groupRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();
            var model = _mapper.MapGroupToModel(entity);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _groupRepository.FindBy(m => m.Id == groupModel.Id).First();
                _groupRepository.Edit(entity);
                _groupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(groupModel);
        }

        // GET: Admin/Group/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _groupRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();
            if (entity == null)
            {
                return HttpNotFound();
            }

            var groupModel = _mapper.MapGroupToModel(entity);
            return View(groupModel);
        }

        // POST: Admin/Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var entity = _groupRepository.FindBy(m => m.Id == id).First();
            _groupRepository.Delete(entity);
            _groupRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
