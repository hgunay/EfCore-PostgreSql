namespace EfCorePostgre.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using EfCorePostgre.Core;
    using EfCorePostgre.Core.Data.Repository;
    using EfCorePostgre.Data.Domain.Public;
    using EfCorePostgre.Dto;

    /// <summary>The user service.</summary>
    public class UserService : IUserService
    {
        /// <summary>The user repository.</summary>
        private readonly IRepositoryAsync<User> userRepository;

        /// <summary>Initializes a new instance of the <see cref="UserService"/> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        public UserService(IRepositoryAsync<User> userRepository) => this.userRepository = userRepository;

        /// <summary>The get user by ıd.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<UserDto> GetUserById(long id)
        {
            var entity = await this.userRepository.FindById(id);

            return entity == null ? null : EntityToDtoMapping(entity);
        }

        /// <summary>The get user list.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<List<UserDto>> GetUserList()
        {
            Expression<Func<User, bool>> query = q => q.IsActive && !q.IsDeleted;

            var list = await this.userRepository.Filter(query);

            return list.Select(EntityToDtoMapping).ToList();
        }

        /// <summary>The ınsert user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<long> InsertUser(UserDto user)
        {
            var saltPassword = PasswordHelper.CreateSaltPassword();
            var mapping      = DtoToEntityMapping(user);

            mapping.Password     = PasswordHelper.EncodePassword(user.Password, saltPassword);
            mapping.PasswordSalt = saltPassword;

            return await this.userRepository.Insert(mapping);
        }

        /// <summary>The update user.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> UpdateUser(UserDto user)
        {
            var saltPassword = PasswordHelper.CreateSaltPassword();
            var mapping      = DtoToEntityMapping(user);

            mapping.Password     = PasswordHelper.EncodePassword(user.Password, saltPassword);
            mapping.PasswordSalt = saltPassword;

            return await this.userRepository.Update(mapping) != 0;
        }

        /// <summary>The delete user.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task<bool> DeleteUser(long id) => await this.userRepository.Delete(id);

        /// <summary>The entity to dto mapping.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="UserDto"/>.</returns>
        private static UserDto EntityToDtoMapping(User entity) =>
            new UserDto
                {
                    Id                         = entity.Id,
                    FirstName                  = entity.FirstName,
                    LastName                   = entity.LastName,
                    Email                      = entity.Email,
                    IsPasswordChangeFirstLogin = entity.IsPasswordChangeFirstLogin,
                    Password                   = entity.Password,
                    PasswordSalt               = entity.PasswordSalt,
                    IsActive                   = entity.IsActive,
                    IsDeleted                  = entity.IsDeleted
                };

        /// <summary>The dto to entity mapping.</summary>
        /// <param name="user">The user.</param>
        /// <returns>The <see cref="User"/>.</returns>
        private static User DtoToEntityMapping(UserDto user) =>
            new User
                {
                    Id        = user.Id,
                    FirstName = user.FirstName,
                    LastName  = user.LastName,
                    Email     = user.Email
                };
    }
}