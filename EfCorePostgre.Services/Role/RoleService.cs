namespace EfCorePostgre.Services.Role
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using EfCorePostgre.Core.Data.Repository;
    using EfCorePostgre.Data.Domain.Public;
    using EfCorePostgre.Dto;

    /// <summary>The role service.</summary>
    public class RoleService : IRoleService
    {
        /// <summary>The role repository.</summary>
        private readonly IRepositoryAsync<Role> roleRepository;

        /// <summary>Initializes a new instance of the <see cref="RoleService"/> class.</summary>
        /// <param name="roleRepository">The role Repository.</param>
        public RoleService(IRepositoryAsync<Role> roleRepository) => this.roleRepository = roleRepository;

        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<RoleDto> GetRoleById(long id)
        {
            var entity = await this.roleRepository.FindById(id);

            return entity == null ? null : RoleEntityToDtoMapping(entity);
        }

        /// <summary>The get role list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<List<RoleDto>> GetRoleList()
        {
            Expression<Func<Role, bool>> query = q => q.IsActive && !q.IsDeleted;

            var list = await this.roleRepository.Filter(query);

            return list.Select(RoleEntityToDtoMapping).ToList();
        }

        /// <summary>The ınsert role.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<long> InsertRole(RoleDto role) => await this.roleRepository.Insert(RoleDtoToEntityMapping(role));

        /// <summary>The update role.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> UpdateRole(RoleDto role) => await this.roleRepository.Update(RoleDtoToEntityMapping(role)) != 0;

        /// <summary>The delete role.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> DeleteRole(long id) => await this.roleRepository.Delete(id);

        /// <summary>The role entity to dto mapping.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="RoleDto"/>.</returns>
        private static RoleDto RoleEntityToDtoMapping(Role entity) =>
            new RoleDto
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

        /// <summary>The role dto to entity mapping.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Role"/>.</returns>
        private static Role RoleDtoToEntityMapping(RoleDto role) =>
            new Role
                {
                    Id          = role.Id,
                    Name        = role.Name,
                    Description = role.Description
                };
    }
}