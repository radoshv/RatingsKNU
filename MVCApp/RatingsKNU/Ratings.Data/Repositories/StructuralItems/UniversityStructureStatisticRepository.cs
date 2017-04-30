using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Interfaces;

namespace Ratings.Data.Repositories.StructuralItems
{
    public interface IUniversityStructureStatisticRepository : IGenericRepository<UniversityStructureStatistic>
    {
        
    }
    public class UniversityStructureStatisticRepository : IUniversityStructureStatisticRepository
    {
        private readonly RatingsContext _context;

        public UniversityStructureStatisticRepository(RatingsContext context)
        {
            _context = context;
        }
        public UniversityStructureStatistic First(Expression<Func<UniversityStructureStatistic, bool>> predicate)
        {
            return _context.UniversityStructureStatistics.First(predicate);
        }

        public UniversityStructureStatistic FirstOrDefault(Expression<Func<UniversityStructureStatistic, bool>> predicate)
        {
            return _context.UniversityStructureStatistics.FirstOrDefault(predicate);
        }

        public IQueryable<UniversityStructureStatistic> GetAll()
        {
            return _context.UniversityStructureStatistics.AsNoTracking();
        }

        public void Add(UniversityStructureStatistic entity)
        {
            _context.UniversityStructureStatistics.Add(entity);
        }

        public void Delete(UniversityStructureStatistic entity)
        {
            _context.UniversityStructureStatistics.Remove(entity);
        }

        public void Delete(Guid facultyId)
        {
            var item = _context.UniversityStructureStatistics.FirstOrDefault(i => i.FacultyId == facultyId);
            if (item != null) _context.UniversityStructureStatistics.Remove(item);
        }

        public UniversityStructureStatistic Update(UniversityStructureStatistic entity)
        {
            var existing = _context.UniversityStructureStatistics.FirstOrDefault(i => i.FacultyId == entity.FacultyId);
            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(entity);
            return existing;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
