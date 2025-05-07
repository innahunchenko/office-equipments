using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeEquipment.DbRepository.Extensions;
using OfficeEquipment.DbRepository.Models;
using OfficeEquipment.Repository.Configuration;
using System;

namespace OfficeEquipment.Data.Configuration
{
    public partial class OfficeEquipmentContext : DbContext
    {
        public OfficeEquipmentContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<TypeEquipment> TypeEquipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:OfficeEquipmentDbContext"]);
            }
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new EquipmentConfiguration());
            modelBuilder.AddConfiguration(new TypeEquipmentConfiguration());
        }
    }
}
