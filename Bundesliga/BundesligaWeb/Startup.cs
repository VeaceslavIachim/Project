using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BundesligaEF;
using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BundesligaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddScoped<IMatchStatisticsRepository, MatchStatisticsRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IleagueRepository, LeagueRepository>();
            services.AddScoped<IStandingsRepository, StandingsRepository>();
            services.AddScoped<IMatchRepository, MatchRespository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddDbContext<BundesligaContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<BundesligaIdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BundesligaIdentityContext>()
                .AddDefaultTokenProviders();
            services.AddMvc(options=>options.MaxModelValidationErrors=3);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
