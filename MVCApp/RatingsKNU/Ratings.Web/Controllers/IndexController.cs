using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ratings.Data;
using Ratings.Data.Entities;
using Ratings.Data.Repositories;
using Ratings.Web.Helpers;
using Ratings.Web.Models.Index;

namespace Ratings.Web.Controllers
{
    public class IndexController : Controller
    {
        private readonly IIndexRepository _indexRepository;
        private readonly IIndexValueRepository _indexValueRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly Mapper.Mapper _mapper;
        private readonly Faculty _currFaculty;

        public IndexController(IIndexRepository indexRepository, IIndexValueRepository indexValueRepository,
            IFacultyRepository facultyRepository, IGroupRepository groupRepository)
        {
            _indexRepository = indexRepository;
            _indexValueRepository = indexValueRepository;
            _facultyRepository = facultyRepository;
            _groupRepository = groupRepository;
            _mapper = new Mapper.Mapper();
            _currFaculty = facultyRepository.FindBy(f => f.Name == "ФІТ").First(); // temp
        }

        // GET: Index
        public ActionResult Index()
        {
            return RedirectToAction("GroupedList");
            var models = GetAllIndexModels().OrderBy(i => i.AddedDate);

            return View(models);
        }

        [HttpGet]
        public ActionResult GroupedList()
        {
            var groups = _groupRepository.GetAll().ToList();
            var groupModels = groups.Select(g => new GroupModel
            {
                AddedDate = g.AddedDate,
                Id = g.Id,
                Name = g.Name,
                Indices = GetIndexModelsForGroup(g.Indices)
            }).OrderBy(i => i.AddedDate);

           
            return View(groupModels);
        }

        private IEnumerable<IndexModel> GetAllIndexModels()
        {
            var indices = _indexRepository.GetAll().ToList();
            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id).ToList();

            var models = indices
                .LeftJoin(values, i => i.Id, v => v.IndexId, (i, v) => new {Index = i, Value = v})
                .Select(r => _mapper.MapIndexToModel(r.Index, r.Value));

            return models;
        }

        private ICollection<IndexModel> GetIndexModelsForGroup(ICollection<Index> indices)
        {
            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id);
            var q =
                from i in indices
                join v in values on i.Id equals v.IndexId into iv
                from v in iv.DefaultIfEmpty()
                select new IndexModel
                {
                    Id = i.Id,
                    ParentId = i.ParentId,
                    Name = i.Name,
                    Value = v.Value,
                    UOM = i.UOM,
                    AddedDate = i.AddedDate
                };

            return q.OrderBy(i => i.AddedDate).ToList();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<IndexModel> md)
        {
            foreach (var item in md)
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

            return RedirectToAction("Index");
        }
    }

}
