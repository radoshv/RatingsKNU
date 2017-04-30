using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ratings.Data.Entities;
using Ratings.Data.Repositories.Interfaces;

namespace Ratings.Data.Repositories.StructuralItems
{
    public interface IFacultiesRepository : IGenericRepository<Faculty>
    {       
    }
    public class FacultiesRepository : IFacultiesRepository
    {
        private readonly RatingsContext _context;

        public FacultiesRepository(RatingsContext context)
        {
            _context = context;
        }
        public Faculty First(Expression<Func<Faculty, bool>> predicate)
        {
            return _context.Faculties.First(predicate);
        }

        public Faculty FirstOrDefault(Expression<Func<Faculty, bool>> predicate)
        {
            return _context.Faculties.FirstOrDefault(predicate);
        }

        public IQueryable<Faculty> GetAll()
        {
            return _context.Faculties.AsNoTracking();
        }

        public void Add(Faculty entity)
        {
            _context.Faculties.Add(entity);
        }

        public void Delete(Faculty entity)
        {
            _context.Faculties.Remove(entity);
        }

        public void Delete(Guid id)
        {
            var item = _context.Faculties.FirstOrDefault(i => i.Id == id);
            if (item != null) _context.Faculties.Remove(item);
        }

        public Faculty Update(Faculty entity)
        {
            var existing = _context.Faculties.FirstOrDefault(i => i.Id == entity.Id);
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
