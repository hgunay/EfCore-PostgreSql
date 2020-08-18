namespace EfCorePostgre.Services.Permission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using EfCorePostgre.Core.Data.Repository;
    using EfCorePostgre.Data.Domain.Public;
    using EfCorePostgre.Dto;

    /// <summary>The permission service.</summary>
    public class PermissionService : IPermissionService
    {
        /// <summary>The permission repository.</summary>
        private readonly IRepositoryAsync<Permission> permissionRepository;

        /// <summary>Initializes a new instance of the <see cref="PermissionService"/> class.</summary>
        /// <param name="permissionRepository">The permission repository.</param>
        public PermissionService(IRepositoryAsync<Permission> permissionRepository) => this.permissionRepository = permissionRepository;

        /// <summary>The get permission by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<PermissionDto> GetPermissionById(long id)
        {
            var entity = await this.permissionRepository.FindById(id);

            return entity == null ? null : EntityToDtoMapping(entity);
        }

        /// <summary>The get permission list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<List<PermissionDto>> GetPermissionList()
        {
            Expression<Func<Permission, bool>> query = q => q.IsActive && !q.IsDeleted;

            var list = await this.permissionRepository.Filter(query);

            return list.Select(EntityToDtoMapping).ToList();
        }

        /// <summary>The ınsert permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<long> InsertPermission(PermissionDto permission) => await this.permissionRepository.Insert(DtoToEntityMapping(permission));

        /// <summary>The update permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> UpdatePermission(PermissionDto permission) => await this.permissionRepository.Update(DtoToEntityMapping(permission)) != 0;

        /// <summary>The delete permission.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> DeletePermission(long id) => await this.permissionRepository.Delete(id);

        /// <summary>The entity to dto mapping.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="PermissionDto"/>.</returns>
        private static PermissionDto EntityToDtoMapping(Permission entity) =>
            new PermissionDto
                {
                    Id              = entity.Id,
                    Name            = entity.Name,
                    Description     = entity.Description,
                    IsActive        = entity.IsActive,
                    IsDeleted       = entity.IsDeleted,
                    CreatedUserId   = entity.CreatedUserId,
                    CreatedDateTime = entity.CreatedDateTime,
                    UpdatedUserId   = entity.UpdatedUserId,
                    UpdatedDateTime = entity.UpdatedDateTime
                };

        /// <summary>The dto to entity mapping.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Permission"/>.</returns>
        private static Permission DtoToEntityMapping(PermissionDto permission) =>
            new Permission
                {
                    Id          = permission.Id,
                    Name        = permission.Name,
                    Description = permission.Description
                };
    }
}