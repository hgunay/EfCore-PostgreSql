namespace EfCorePostgre.Data
{
    using EfCorePostgre.Data.Domain.Public;

    using Microsoft.EntityFrameworkCore;

    /// <summary>The model builder extensions.</summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>The seed.</summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasData(
                                 new Role
                                     {
                                         Id          = 1,
                                         Name        = "Role 1",
                                         Description = "Role 1 Açıklaması"
                                     });

            modelBuilder.Entity<Permission>()
                        .HasData(
                                 new Permission
                                     {
                                         Id               = 1,
                                         PermissionTypeId = 1,
                                         Name             = "Permission 1",
                                         Description      = "Permission 1 Açıklaması"
                                     });

            modelBuilder.Entity<User>()
                        .HasData(
                                 new User
                                     {
                                         Id           = 1,
                                         FirstName    = "Admin",
                                         LastName     = "Admin",
                                         Email        = "admin@test.com",
                                         Password     = "Admin123",
                                         PasswordSalt = "Admin123"
                                     });

            modelBuilder.Entity<UserRole>()
                        .HasData(
                                 new UserRole
                                     {
                                         Id     = 1,
                                         UserId = 1,
                                         RoleId = 1,
                                     });

            modelBuilder.Entity<UserPermission>()
                        .HasData(
                                 new UserPermission
                                     {
                                         Id           = 1,
                                         UserId       = 1,
                                         PermissionId = 1,
                                     });
        }
    }
}