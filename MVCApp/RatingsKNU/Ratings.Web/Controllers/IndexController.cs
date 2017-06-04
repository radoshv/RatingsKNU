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
            IFacultyRepository facultyRepository)
        {
            _indexRepository = indexRepository;
            _indexValueRepository = indexValueRepository;
            _facultyRepository = facultyRepository;
            _mapper = new Mapper.Mapper();
            _currFaculty = facultyRepository.FindBy(f => f.Name == "ФІТ").First(); // temp
        }

        // GET: Index
        public ActionResult Index()
        {
            var models = GetAllIndexModels();

            return View(models);
        }

        [HttpGet]
        public ActionResult GroupedList()
        {
            var groups = _groupRepository.GetAll().ToList();
            var groupModels = groups.Select(_mapper.MapGroupToModel);

            var indexModels = GetAllIndexModels();

            foreach (var group in groupModels)
            {
                group.Indices = indexModels.Where(m => m.GroupId == group.Id).ToList();
            }

            return View(groupModels);
        }

        private IEnumerable<IndexModel> GetAllIndexModels()
        {
            var indices = _indexRepository.GetAll().ToList();
            var values = _indexValueRepository.FindBy(v => v.FacultyId == _currFaculty.Id).ToList();

            var models = indices
                .LeftJoin(values, i => i.Id, v => v.IndexId, (i, v) => new { Index = i, Value = v })
                .Select(r => _mapper.MapIndexToModel(r.Index, r.Value));

            return models;
        } 
        [HttpPost]
        public ActionResult Index(IEnumerable<Ratings.Web.Models.Index.IndexModel> md)
        {
           
            return View();
        }
    }

}
