namespace EfCorePostgre.Services.Role
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;

    /// <summary>The RoleService interface.</summary>
    public interface IRoleService
    {
        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<RoleDto> GetRoleById(long id);

        /// <summary>The get role list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<List<RoleDto>> GetRoleList();

        /// <summary>The ınsert role.</summary>
        /// <param name="roleDto">The role dto.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<long> InsertRole(RoleDto roleDto);

        /// <summary>The update role.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> UpdateRole(RoleDto role);

        /// <summary>The delete role.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> DeleteRole(long id);
    }
}