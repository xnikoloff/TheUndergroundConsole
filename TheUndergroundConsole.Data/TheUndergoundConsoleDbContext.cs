using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Common;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Data
{
    public class TheUndergoundConsoleDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPlayer> CarPlayers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<RaceEvent> RaceEvents { get; set; }


        public TheUndergoundConsoleDbContext()
        {

        }

        public TheUndergoundConsoleDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefaultConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarPlayer>().HasKey(cp => new { cp.CarId, cp.PlayerId });
        }
    }
}
