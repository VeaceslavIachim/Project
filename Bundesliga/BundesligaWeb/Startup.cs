using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BundesligaEF;
using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BundesligaServices;
using BundesligaServices.Interfaces;
using AutoMapper;
using BundesligaServices.DTO;
using BundesligaWeb.ViewModels;
using System;
using BundesligaServices.Services;
using BundesligaEF.DTO;

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
            services.AddScoped<IMatchServices, MatchServices>();
            services.AddScoped<IStandingsServices, StandingsServices>();
            services.AddScoped<ITeamsServices, TeamsServices>();
            services.AddScoped<ILeagueServices,LeagueServices>();
            services.AddScoped<IPlayerServices, PlayerServices>();
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

            Mapper.Initialize(config =>
            {
                config.CreateMap<LeagueDTO, LeagueViewModel>();
                config.CreateMap<League, LeagueDTO>()
                    .ForMember(x=>x.Country,y=>y.MapFrom(z=>z.Country.Name));

                config.CreateMap<Player, PlayerDetailsDTO>()
                    .ForMember(x => x.Name, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                    .ForMember(x => x.Country, y => y.MapFrom(z => z.Country.Name))
                    .ForMember(x => x.Position, y => y.MapFrom(z => z.Position.Name))
                    .ForMember(x => x.Age, y => y.MapFrom(z => DateTime.Now.Year - z.Age.Year));

                config.CreateMap<PlayerDetailsDTO, PlayerDetailsViewModel>();
                config.CreateMap<TeamDTO, TeamViewModel>();
                config.CreateMap<PlayerDTO, PlayerViewModel>();
                config.CreateMap<Team, TeamDTO>();
                config.CreateMap<Player, PlayerDTO>();
                config.CreateMap<StandingsDetailsDTO, StandingDetailsViewModel>();
                config.CreateMap<TopScorersDTO, TopScorersViewModel>();
                config.CreateMap<StandingsDTO, StandingsViewModel>();
                config.CreateMap<MatchesViewDTO, MatchesViewViewModel>();
                config.CreateMap<TopScorersDTOEF, TopScorersDTO>();
                config.CreateMap<Match, MatchesViewDTO>()
                    .ForMember(x => x.HomeTeamPhoto, y => y.MapFrom(z => z.HomeTeam.Photo))
                    .ForMember(x => x.AwayTeamPhoto, y => y.MapFrom(z => z.AwayTeam.Photo));
                config.CreateMap<Standings, StandingsDTO>()
                    .ForMember(x => x.Team, y => y.MapFrom(z => z.Team.Name))
                    .ForMember(x=>x.Photo,y=>y.MapFrom(z=>z.Team.Photo))
                    .ForMember(x => x.Id, y => y.MapFrom(z => z.TeamId));

                config.CreateMap<Match, MatchesViewDTO>()
                    .ForMember(x => x.HomeTeam, y => y.MapFrom(z => z.HomeTeam.Name))
                    .ForMember(x => x.HomeTeamPhoto, y => y.MapFrom(z => z.HomeTeam.Photo))
                    .ForMember(x => x.AwayTeam, y => y.MapFrom(z => z.AwayTeam.Name))
                    .ForMember(x => x.AwayTeamPhoto, y => y.MapFrom(z => z.AwayTeam.Photo))
                    .ForMember(x => x.Date, y => y.MapFrom(z => z.MatchDate));
                config.CreateMap<MatchesViewDTO, MatchesViewViewModel>();

                config.CreateMap<MatchDTO, MatchViewModel>().ReverseMap();

                config.CreateMap<MatchDTO, Match>().ReverseMap();
                config.CreateMap<MatchStatisticsDTO, MatchStatisticsViewModel>().ReverseMap();
                config.CreateMap<MatchStatisticsDTO, MatchStatistics>();
                   


            });

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
