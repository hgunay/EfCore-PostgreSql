namespace EfCorePostgre.Core.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using EfCorePostgre.Core.Data.Entity;

    using Microsoft.EntityFrameworkCore;

    /// <summary>The repository async.</summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity>
            where TEntity : AuditEntity
    {
        /// <summary>The db context.</summary>
        private readonly DbContext dbContext;

        /// <summary>Initializes a new instance of the <see cref="RepositoryAsync{TEntity}"/> class.</summary>
        /// <param name="context">The context.</param>
        public RepositoryAsync(DbContext context) => this.dbContext = context;

        #region Implementation of IAsyncRepository<TEntity>

        /// <summary>The find by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<TEntity> FindById(long id) =>
                await this.dbContext.Set<TEntity>()
                          .FindAsync(id);

        /// <summary>The ınsert.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<long> Insert(TEntity entity)
        {
            await this.dbContext.Set<TEntity>()
                      .AddAsync(entity);

            await this.dbContext.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>The update.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            this.dbContext.Entry(entity)
                .State = EntityState.Modified;

            await this.dbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> Delete(long id)
        {
            var entity = await this.FindById(id);

            if (entity == null)
            {
                return false;
            }

            this.dbContext.Set<TEntity>()
                .Remove(entity);

            return await this.dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>The filter.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate) =>
                await this.dbContext.Set<TEntity>()
                          .Where(predicate)
                          .ToListAsync();

        #endregion
    }
}