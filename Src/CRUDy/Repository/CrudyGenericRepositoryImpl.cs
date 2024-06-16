using CRUDy.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDy.Repository
{
    public class CrudyGenericRepositoryImpl<TEntity, TEntityId> : ICrudyGenericRepository<TEntity, TEntityId> where TEntity : AuditableEntity<TEntityId> where TEntityId : struct
    {
        private readonly DbContext _context;

        public CrudyGenericRepositoryImpl(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteByIdAsync(TEntityId id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id) ?? throw new ArgumentException($"Entity with id {id} not found");
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression) => await _context.Set<TEntity>().Where(expression).ToListAsync();

        public async Task<TEntity?> GetByIdAsync(TEntityId id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<int> UpdateAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

    }
}
