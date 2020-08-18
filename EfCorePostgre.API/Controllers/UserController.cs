namespace EfCorePostgre.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EfCorePostgre.Core;
    using EfCorePostgre.Dto;
    using EfCorePostgre.Services.User;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>The user controller.</summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>The user service.</summary>
        private readonly IUserService userService;

        /// <summary>Initializes a new instance of the <see cref="UserController"/> class.</summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService) => this.userService = userService;

        /// <summary>The get user by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(long id)
        {
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/User/GetUserById/1
             * 
             */
            var result = await this.userService.GetUserById(id);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        /// <summary>The ınsert user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<long>> InsertUser([FromBody] UserDto user)
        {
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/User/InsertUser
             * Body   : Json Raw Data > { "FirstName":"Anakin", "LastName":"Skywalker", "Email":"anakin@skywalker.com", "Password":"Anakin!Deathstar123." }
             * 
             */
            var roleId = await this.userService.InsertUser(user);

            if (roleId <= 0)
            {
                return this.BadRequest();
            }

            return this.Ok(roleId);
        }

        /// <summary>The update user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] UserDto user) =>
            /* Sample
             *
             * Method : Post
             * Url    : http://localhost:5001/api/User/UpdateUser
             * Body   : Json Raw Data > { "Id": 2, "FirstName":"Darth", "LastName":"Vader", "Email":"darth.vader@deathstar.com", "Password":"Vader!Deathstar987." }
             * 
             */
            this.Ok(await this.userService.UpdateUser(user));

        /// <summary>The get user list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetUserList() =>
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/User/GetUserList
             * 
             */
            this.Ok(await this.userService.GetUserList());

        /// <summary>The delete user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(long id) =>
            /* Sample
                         *
                         * Method : Delete
                         * Url    : http://localhost:5001/api/User/DeleteUser/2
                         * 
                         */
            this.Ok(await this.userService.DeleteUser(id));
    }
}