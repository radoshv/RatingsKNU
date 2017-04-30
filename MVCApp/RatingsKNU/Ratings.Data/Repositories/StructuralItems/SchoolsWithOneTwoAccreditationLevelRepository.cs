using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Interfaces;

namespace Ratings.Data.Repositories.StructuralItems
{
    public interface ISchoolsWithOneTwoAccreditationLevelRepository :
        IGenericRepository<SchoolsWithOneTwoAccreditationLevel>
    {
        
    }
    public class SchoolsWithOneTwoAccreditationLevelRepository : ISchoolsWithOneTwoAccreditationLevelRepository
    {
        private readonly RatingsContext _context;

        public SchoolsWithOneTwoAccreditationLevelRepository(RatingsContext context)
        {
            _context = context;
        }
        public SchoolsWithOneTwoAccreditationLevel First(Expression<Func<SchoolsWithOneTwoAccreditationLevel, bool>> predicate)
        {
            return _context.SchoolsWithOneTwoAccreditationLevels.First(predicate);
        }

        public SchoolsWithOneTwoAccreditationLevel FirstOrDefault(Expression<Func<SchoolsWithOneTwoAccreditationLevel, bool>> predicate)
        {
            return _context.SchoolsWithOneTwoAccreditationLevels.FirstOrDefault(predicate);
        }

        public IQueryable<SchoolsWithOneTwoAccreditationLevel> GetAll()
        {
            return _context.SchoolsWithOneTwoAccreditationLevels.AsNoTracking();
        }

        public void Add(SchoolsWithOneTwoAccreditationLevel entity)
        {
            _context.SchoolsWithOneTwoAccreditationLevels.Add(entity);
        }

        public void Delete(SchoolsWithOneTwoAccreditationLevel entity)
        {
            _context.SchoolsWithOneTwoAccreditationLevels.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var item = _context.SchoolsWithOneTwoAccreditationLevels.FirstOrDefault(i => i.Id == id);
            if (item != null) _context.SchoolsWithOneTwoAccreditationLevels.Remove(item);
        }

        public SchoolsWithOneTwoAccreditationLevel Update(SchoolsWithOneTwoAccreditationLevel entity)
        {
            var existing = _context.SchoolsWithOneTwoAccreditationLevels.FirstOrDefault(i => i.Id == entity.Id);
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
