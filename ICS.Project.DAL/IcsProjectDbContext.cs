using System.ComponentModel.DataAnnotations.Schema;
using ICS.Project.DAL.Entities;
using ICS.Project.DAL.EntitiesSeeds;
using Microsoft.EntityFrameworkCore;

namespace ICS.Project.DAL
{
    public class IcsProjectDbContext : DbContext
    {

        private readonly bool _seedData;

        public IcsProjectDbContext(DbContextOptions contextOptions, bool seedData = false)
            : base(contextOptions)
        {
            _seedData = true;
        }

        public DbSet<CarEntity> Cars => Set<CarEntity>();
        public DbSet<RideEntity> Rides => Set<RideEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarEntity>( c =>
            {
                c.HasKey(c => c.Id);
                c.Property(c => c.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserEntity>(u =>
            {
                u.HasKey(u => u.Id);
                u.Property(u => u.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RideEntity>(r =>
            {
                r.HasKey(r => r.Id);
                r.Property(r => r.Id).ValueGeneratedOnAdd();
            });

            if (_seedData)
            {
                CarEntitySeed.Seed(modelBuilder);
                RideEntitySeed.Seed(modelBuilder);
                UserEntitySeed.Seed(modelBuilder);
            }
        }
    }
}