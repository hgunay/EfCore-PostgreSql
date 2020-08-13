namespace EfCorePostgre.Services.Role
{
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
        public RoleService(IRepositoryAsync<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<RoleDto> GetRoleById(long id)
        {
            var entity = await this.roleRepository.FindById(id);

            if (entity == null)
            {
                return null;
            }

            // Entity to DTO Mapping
            var roleDto = new RoleDto
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

            return roleDto;

        }
    }
}