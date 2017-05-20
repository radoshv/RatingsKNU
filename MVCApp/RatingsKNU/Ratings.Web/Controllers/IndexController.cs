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
        private IIndexRepository _indexRepository;
        private IIndexValueRepository _indexValueRepository;
        private IFacultyRepository _facultyRepository;
        private Mapper.Mapper _mapper;
        private Faculty currFaculty;

        public IndexController(IIndexRepository indexRepository, IIndexValueRepository indexValueRepository, IFacultyRepository facultyRepository)
        {
            _indexRepository = indexRepository;
            _indexValueRepository = indexValueRepository;
            _facultyRepository = facultyRepository;
            _mapper = new Mapper.Mapper();
            currFaculty = facultyRepository.FindBy(f => f.Name == "ФІТ").First(); // temp
        }

        // GET: Index
        public ActionResult Index()
        {
            var indices = _indexRepository.GetAll().ToList();
            var values = _indexValueRepository.FindBy(v => v.FacultyId == currFaculty.Id).ToList();

            var models = indices
                .LeftJoin(values, i => i.Id, v => v.IndexId, (i, v) => new {Index = i, Value = v})
                .Select(r => _mapper.MapIndex(r.Index, r.Value));

            return View(models);
        }
    }
}
