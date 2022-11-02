using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School.Domain.Constants;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        public virtual DbSet<Pupil> Pupils { get; set; } = null!;

        public virtual DbSet<Worker> Workers { get; set; } = null!;

        public virtual DbSet<Vacation> Vacations { get; set; } = null!;

        public virtual DbSet<PrideOfSchool> PrideOfSchools { get; set; } = null!;

        public virtual DbSet<VeteranOfSchool> VeteranOfSchools { get; set; } = null!;

        public virtual DbSet<ElectronicLibrary> ElectronicLibraries { get; set; } = null!;

        public virtual DbSet<Class> Classes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasIndex(x => x.PhoneNumber).IsUnique();
            modelBuilder.Entity<Pupil>().HasIndex(x => x.PhoneNumber).IsUnique();
            modelBuilder.Entity<Worker>().HasIndex(x => x.PhoneNumber).IsUnique();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbConstants.CONNECTION_STRING);
        }
    }
}
