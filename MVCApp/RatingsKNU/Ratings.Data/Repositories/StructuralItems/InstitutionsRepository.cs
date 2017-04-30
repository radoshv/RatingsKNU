using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Interfaces;

namespace Ratings.Data.Repositories.StructuralItems
{
    public interface IInstitutionsRepository : IGenericRepository<Institution>
    {
        
    }
    public class InstitutionsRepository : IInstitutionsRepository
    {
        private readonly RatingsContext _context;

        public InstitutionsRepository(RatingsContext context)
        {
            _context = context;
        }
        public Institution First(Expression<Func<Institution, bool>> predicate)
        {
            return _context.Institutions.First(predicate);
        }

        public Institution FirstOrDefault(Expression<Func<Institution, bool>> predicate)
        {
            return _context.Institutions.FirstOrDefault(predicate);
        }

        public IQueryable<Institution> GetAll()
        {
            return _context.Institutions.AsNoTracking();
        }

        public void Add(Institution entity)
        {
            _context.Institutions.Add(entity);
        }

        public void Delete(Institution entity)
        {
            _context.Institutions.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var item = _context.Institutions.FirstOrDefault(i => i.Id == id);
            if (item != null) _context.Institutions.Remove(item);
        }

        public Institution Update(Institution entity)
        {
            var existing = _context.Institutions.FirstOrDefault(i => i.Id == entity.Id);
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
