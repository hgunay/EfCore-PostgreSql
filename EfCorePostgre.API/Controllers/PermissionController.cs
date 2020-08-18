namespace EfCorePostgre.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;
    using EfCorePostgre.Services.Permission;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>The permission controller.</summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        /// <summary>The permission service.</summary>
        private readonly IPermissionService permissionService;

        /// <summary>Initializes a new instance of the <see cref="PermissionController"/> class.</summary>
        /// <param name="permissionService">The permission service.</param>
        public PermissionController(IPermissionService permissionService) => this.permissionService = permissionService;

        /// <summary>The get permission by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDto>> GetPermissionById(long id)
        {
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/Permission/GetPermissionById/1
             * 
             */
            var result = await this.permissionService.GetPermissionById(id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>The ınsert permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<long>> InsertPermission([FromBody] PermissionDto permission)
        {
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/Permission/InsertPermission
             * Body   : Json Raw Data > { "Name":"Api Permission Insert Test", "Description":"Api Permission Insert Test Description" }
             * 
             */
            var permissionId = await this.permissionService.InsertPermission(permission);

            if (permissionId <= 0)
            {
                return this.BadRequest();
            }

            return this.Ok(permissionId);
        }

        /// <summary>The update permission.</summary>
        /// <param name="permission">The permission.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> UpdatePermission([FromBody] PermissionDto permission) =>
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/Permission/UpdatePermission
             * Body   : Json Raw Data > { "Id":2, "Name":"Api Permission Update Test", "Description":"Api Permission Update Test Description" }
             * 
             */
            this.Ok(await this.permissionService.UpdatePermission(permission));

        /// <summary>The get permission list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<PermissionDto>>> GetPermissionList() => 
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/Permission/GetPermissionList
             * 
             */
            this.Ok(await this.permissionService.GetPermissionList());

        /// <summary>The delete permission.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePermission(long id) =>
            /* Sample
             *
             * Method : Delete
             * Url    : http://localhost:5001/api/Permission/DeletePermission/2
             * 
             */
            this.Ok(await this.permissionService.DeletePermission(id));
    }
}