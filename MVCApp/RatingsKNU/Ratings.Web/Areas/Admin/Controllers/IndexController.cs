using Ratings.Data.Enums;
using Ratings.Data.Repositories;
using Ratings.Web.Areas.Admin.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ratings.Web.Areas.Admin.Controllers
{
    public class IndexController : Controller
    {
        private readonly IIndexRepository _indexRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly Mapper _mapper;


        public IndexController(IIndexRepository indexRepository, IGroupRepository groupRepository, IRatingRepository ratingRepository)
        {
            _indexRepository = indexRepository;
            _groupRepository = groupRepository;
            _ratingRepository = ratingRepository;
            _mapper = new Mapper();
        }

        // GET: Admin/Index
        public ActionResult Index(Guid? groupId)
        {
            if (groupId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var group = _groupRepository.FindBy(g => g.Id == groupId.Value).FirstOrDefault();
            if (group == null)
                return HttpNotFound();

            var indices = _indexRepository
                .FindBy(m => m.GroupId == groupId)
                .Select(_mapper.MapIndexToModel);

            ViewBag.GroupId = groupId;
            ViewBag.GroupTitle = group.Name;

            var groups = _groupRepository.GetAll().ToList();
            var groupModels = groups.Select(_mapper.MapGroupToModel).ToList();
            var zeroOption = new GroupModel
            {
                Id = new Guid(),
                Name = "Обрати"
            };
            groupModels.Insert(0, zeroOption);

            ViewBag.GroupList = groupModels;

            return View(indices);
        }
        [HttpPost]
        public ActionResult Index(string GroupId, string Name, string UOM)
        {
            IndexModel IM = new IndexModel();

            IM.GroupId = new Guid(GroupId);
            IM.Name = Name;
            IM.UOM = (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure),UOM);
            var entity = _mapper.MapIndexToEntity(IM);
            _indexRepository.Add(entity);
            _indexRepository.Save();
            return RedirectToAction("Index", new { groupId = GroupId });
        }

        // GET: Admin/Index/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var index = _indexRepository.FindBy(m => m.Id == id).FirstOrDefault();
            if (index == null)
            {
                return HttpNotFound();
            }
            var model = _mapper.MapIndexToModel(index);
            return View(model);
        }

        // GET: Admin/Index/Create
        public ActionResult Create(Guid? groupId)
        {
            if (groupId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new IndexModel {GroupId = groupId.Value};
            return View(model);
        }

        // POST: Admin/Index/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndexModel indexModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.MapIndexToEntity(indexModel);
                _indexRepository.Add(entity);
                _indexRepository.Save();
                return RedirectToAction("Index", new {groupId = indexModel.GroupId});
            }

            return View(indexModel);
        }

        // GET: Admin/Index/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _indexRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();
            if (entity == null)
            {
                return HttpNotFound();
            }

            var model = _mapper.MapIndexToModel(entity);
            return View(model);
        }

        // POST: Admin/Index/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IndexModel indexModel)
        {
            if (ModelState.IsValid)
            {
                var entity = _indexRepository.FindBy(m => m.Id == indexModel.Id).First();
                _indexRepository.Edit(entity);
                _indexRepository.Save();
                return RedirectToAction("Index");
            }
            return View(indexModel);
        }

        // GET: Admin/Index/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = _indexRepository
                .FindBy(g => g.Id == id)
                .FirstOrDefault();

            if (entity == null)
            {
                return HttpNotFound();
            }

            var indexModel = _mapper.MapIndexToModel(entity);
            return View(indexModel);
        }

        // POST: Admin/Index/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var entity = _indexRepository.FindBy(m => m.Id == id).First();
            _indexRepository.Delete(entity);
            _indexRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
