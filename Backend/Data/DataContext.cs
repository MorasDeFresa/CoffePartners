using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffePartners.Models;

namespace CoffePartners.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cultivation> Cultivations { get; set; }
        public DbSet<CultivationHarvest> CultivationHarvests { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<HarvestProcess> HarvestProcesss { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Machinery> Machinerys { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<StatesCultivation> StatesCultivations { get; set; }
        public DbSet<TypeProcess> TypeProcesss { get; set; }
        public DbSet<TypeQuality> TypeQualitys { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}