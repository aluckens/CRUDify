using CRUDy.Models;
using System.Linq.Expressions;

namespace CRUDy.Repository
{
    public interface ICrudyGenericRepository<TEntity, TEntityId> where TEntity : AuditableEntity<TEntityId> where TEntityId : struct
    {
        /// <summary>
        /// Asynchronously retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<TEntity?> GetByIdAsync(TEntityId id);

        /// <summary>
        /// Asynchronously retrieves all entities.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves entities that match the specified expression.
        /// </summary>
        /// <param name="expression">The expression to filter the entities.</param>
        /// <returns>A collection of entities that match the specified expression.</returns>
        Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Asynchronously creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// Asynchronously updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The number of affected rows.</returns>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Asynchronously deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>The number of affected rows.</returns>
        Task<int> DeleteByIdAsync(TEntityId id);
    }
}
