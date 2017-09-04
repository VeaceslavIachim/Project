using BundesligaDomain;
using Microsoft.EntityFrameworkCore;

namespace BundesligaEF
{
    public class BundesligaContext:DbContext
    {
        public BundesligaContext(DbContextOptions<BundesligaContext> options) : base(options)
        {

        }


        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchStatistics> MatchStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Standings> Standings { get; set; }
        public DbSet<Team> Teams { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Bundesliga;Integrated Security=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeMatches);
            modelBuilder.Entity<Match>()
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches);
           
        }
    }
}
