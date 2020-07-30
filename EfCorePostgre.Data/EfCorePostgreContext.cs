namespace EfCorePostgre.Data
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using EfCorePostgre.Data.Domain.Public;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>The Entity Framework Core and PostgreSQL context.</summary>
    public sealed class EfCorePostgreContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="EfCorePostgreContext"/> class.</summary>
        public EfCorePostgreContext() { }

        /// <summary>Initializes a new instance of the <see cref="EfCorePostgreContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public EfCorePostgreContext(DbContextOptions<EfCorePostgreContext> options)
                : base(options)
        {
            this.Database.EnsureCreated();
        }

        #region [public] Schema Tables

        /// <summary>Gets or sets the roles.</summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>Gets or sets the permissions.</summary>
        public DbSet<Permission> Permissions { get; set; }

        /// <summary>Gets or sets the users.</summary>
        public DbSet<User> Users { get; set; }

        /// <summary>Gets or sets the user roles.</summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>Gets or sets the user permissions.</summary>
        public DbSet<UserPermission> UserPermissions { get; set; }

        #endregion

        /// <summary>The on configuring.</summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                                                    .AddJsonFile("appsettings.json", false)
                                                    .Build();

            optionsBuilder.UseNpgsql(builder.GetConnectionString("SampleDbConnection"));
        }

        /// <summary>The on model creating.</summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}