using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace MatchdayMadness2.Models
{
   
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> context) : base(context) 
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-940GH20\\SQLEXPRESS;database=matchdaymadness;User ID=sa;Password=sa;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matches>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matches>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamid)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Players> Players { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Standings> Standings { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<LiveMatchUpdates> LiveMatchUpdates { get; set; }
        public DbSet<LiveCommentary> LiveCommentary { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Leagues> Leagues { get; set; }

    }
}
