namespace EfCorePostgre.API.Controllers
{
    using System.Collections.Generic;
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
        public RoleController(IRoleService roleService) => this.roleService = roleService;

        /// <summary>The get role by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <example>GET: api/Role/1</example>
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(long id)
        {
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/Role/GetRoleById/1
             * 
             */
            var result = await this.roleService.GetRoleById(id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>The ınsert role.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<long>> InsertRole([FromBody] RoleDto role)
        {
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/Role/InsertRole
             * Body   : Json Raw Data > { "Name":"Api Insert Role Test", "Description":"Api Insert Role Test Description" }
             * 
             */
            var roleId = await this.roleService.InsertRole(role);

            if (roleId <= 0)
            {
                return this.BadRequest();
            }

            return this.Ok(roleId);
        }

        /// <summary>The update role.</summary>
        /// <param name="role">The role.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> UpdateRole([FromBody] RoleDto role) =>
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/Role/UpdateRole
             * Body   : Json Raw Data > { "Id": 2, "Name":"Api Update Role Test", "Description":"Api Update Role Test Description" }
             * 
             */
            this.Ok(await this.roleService.UpdateRole(role));

        /// <summary>The get role list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetRoleList() => 
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/Role/GetRoleList
             * 
             */
            this.Ok(await this.roleService.GetRoleList());

        /// <summary>The delete role.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRole(long id) =>
            /* Sample
             *
             * Method : Delete
             * Url    : http://localhost:5001/api/Role/DeleteRole/2
             * 
             */
            this.Ok(await this.roleService.DeleteRole(id));
    }
}