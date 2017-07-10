using BusinessLayer.BussinesObjects;
using BusinessLayer.Interfaces;
using BusinessLayer.UnitOfWork;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Repository;
using Infrastructure.Loggers;
using Infrastructure.Middlewares;
using IssuesManager.Models;
using IssuesManager.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IssuesManager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IssuesManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IssuesManagerUser, IssuesManagerRole>()
                .AddEntityFrameworkStores<IdentityContext, int>()
                .AddDefaultTokenProviders();

            //BusinessLayer
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IUserBusinessObject, UserBusinessObject>();

            //DataLayer
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddMvc();
        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDatabase(Configuration, LogLevel.Information);

            app.UseIdentity();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                LoginPath = new PathString("/Home"),
                AccessDeniedPath = new PathString("/Home/Error"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LogoutPath = new PathString("/Home/LogOff")                
            });

            app.UseIssuesManagerExceptionHandler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
