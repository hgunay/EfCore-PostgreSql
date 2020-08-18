namespace EfCorePostgre.API
{
    using System.IO;

    using EfCorePostgre.Core.Data.Repository;
    using EfCorePostgre.Data;
    using EfCorePostgre.Services.Permission;
    using EfCorePostgre.Services.Role;
    using EfCorePostgre.Services.User;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>The startup.</summary>
    public class Startup
    {
        /// <summary>Initializes a new instance of the <see cref="Startup"/> class.</summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        /// <summary>Gets the configuration.</summary>
        public IConfiguration Configuration { get; }

        /// <summary>The configure services.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            // Db Connection
            services.AddScoped<DbContext, EfCorePostgreContext>();

            var settingsPath = Path.Combine(Directory.GetCurrentDirectory());

            if (!string.IsNullOrEmpty(settingsPath))
            {
                var builder = new ConfigurationBuilder().SetBasePath(settingsPath).AddJsonFile("appsettings.json", false).Build();

                services.AddDbContext<EfCorePostgreContext>(optionsBuilder => optionsBuilder.UseNpgsql(builder.GetConnectionString("SampleDbConnection")));
            }

            // Services
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IUserService, UserService>();
        }

        /// <summary>The configure.</summary>
        /// <param name="app">The app.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
                    });
        }
    }
}