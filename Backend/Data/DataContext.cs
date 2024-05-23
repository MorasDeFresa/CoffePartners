using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Archivement> Archivements { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<HistoryPlant> HistoryPlants { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantStates> PlantStates { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<FarmerArchivements> FarmerArchivements { get; set; }
        public DbSet<FarmerScore> FarmerScores { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<TypeQuality> TypeQualitys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Harvest> Harvests { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}