namespace EfCorePostgre.Core.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using EfCorePostgre.Core.Data.Entity;

    /// <summary>The AsyncRepository interface.</summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IRepositoryAsync<TEntity>
            where TEntity : BaseEntity
    {
        /// <summary>The find by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<TEntity> FindById(long id);

        /// <summary>The ınsert.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<long> Insert(TEntity entity);

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<long> Update(TEntity entity);

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> Delete(long id);

        /// <summary>The get where.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}