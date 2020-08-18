namespace EfCorePostgre.Services.Permission
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;

    /// <summary>The PermissionService interface.</summary>
    public interface IPermissionService
    {
        /// <summary>The get permission by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<PermissionDto> GetPermissionById(long id);

        /// <summary>The get permission list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<List<PermissionDto>> GetPermissionList();

        /// <summary>The ınsert permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<long> InsertPermission(PermissionDto permission);

        /// <summary>The update permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> UpdatePermission(PermissionDto permission);

        /// <summary>The delete permission.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> DeletePermission(long id);
    }
}