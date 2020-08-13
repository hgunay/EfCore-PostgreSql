namespace EfCorePostgre.Services.Role
{
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;

    /// <summary>The RoleService interface.</summary>
    public interface IRoleService
    {
        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<RoleDto> GetRoleById(long id);
    }
}