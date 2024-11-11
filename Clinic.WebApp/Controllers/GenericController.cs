using Clinic.WebApp.Data.Context;
using Clinic.WebApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinic.WebApp.Controllers
{
    public class GenericController<TEntity> 
        : IGenericController<TEntity> where TEntity : class
    {
        private readonly ClinicContext _context;

        public GenericController(ClinicContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().AnyAsync(filter);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityByID(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<bool> Create(TEntity entity)
        {
            if (entity is null) return false;
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        public virtual async Task<bool> Update(TEntity entity)
        {
            int id = 1;
            await _context.Set<TEntity>().FindAsync(id);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> Remove(int Id)
        {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(Id);
            if (entity == null) return false;
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
