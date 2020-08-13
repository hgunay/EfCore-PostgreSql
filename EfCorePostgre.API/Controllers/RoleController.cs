namespace EfCorePostgre.API.Controllers
{
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;
    using EfCorePostgre.Services.Role;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>The role controller.</summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        /// <summary>The role service.</summary>
        private readonly IRoleService roleService;

        /// <summary>Initializes a new instance of the <see cref="RoleController"/> class.</summary>
        /// <param name="roleService">The role service.</param>
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <example>GET: api/Role/1</example>
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(long id)
        {
            var result = await this.roleService.GetRoleById(id);

            if (result != null)
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}