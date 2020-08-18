namespace EfCorePostgre.Services.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EfCorePostgre.Dto;

    /// <summary>The UserService interface.</summary>
    public interface IUserService
    {
        /// <summary>The get user by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<UserDto> GetUserById(long id);

        /// <summary>The get user list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<List<UserDto>> GetUserList();

        /// <summary>The ınsert user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<long> InsertUser(UserDto user);

        /// <summary>The update user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> UpdateUser(UserDto user);

        /// <summary>The delete user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<bool> DeleteUser(long id);
    }
}