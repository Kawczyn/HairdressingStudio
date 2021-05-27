using HairdressingStudio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.DatabaseContext
{
    public class HairdressingStudioContext : DbContext
    {
        public HairdressingStudioContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Stylists> StylistsModels { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<HairdressingServices> HairdressingServices { get; set; }
        public DbSet<StylistsWorkingHours> StylistsWorkingHours { get; set; }
        public DbSet<Visits> Visits { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stylists>().ToTable("Stylists", "Studio");
            modelBuilder.Entity<Stylists>().HasKey(i => i.Id);
            //modelBuilder.Entity<Stylists>().Property(i => i.Id).UseIdentityColumn();
            modelBuilder.Entity<Stylists>().Property(i => i.FirstName).IsRequired();
            modelBuilder.Entity<Stylists>().Property(i => i.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Stylists>().Property(i => i.LastName).HasMaxLength(50);
            modelBuilder.Entity<Stylists>().Property(i => i.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<HairdressingServices>().ToTable("HairdressingServices", "Studio");
            modelBuilder.Entity<HairdressingServices>().HasKey(i => i.Id);
            modelBuilder.Entity<HairdressingServices>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<HairdressingServices>().Property(i => i.Name).HasMaxLength(150);
            modelBuilder.Entity<HairdressingServices>().Property(i => i.IsCombining).HasDefaultValue(false);
            modelBuilder.Entity<HairdressingServices>().Property(i => i.ServiceTime).IsRequired();
            modelBuilder.Entity<HairdressingServices>().Property(i => i.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<Clients>().ToTable("Clients", "Studio");
            modelBuilder.Entity<Clients>().HasKey(i => i.Id);
            modelBuilder.Entity<Clients>().Property(i => i.FirstName).IsRequired();
            modelBuilder.Entity<Clients>().Property(i => i.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Clients>().Property(i => i.LastName).IsRequired();
            modelBuilder.Entity<Clients>().Property(i => i.LastName).HasMaxLength(50);
            modelBuilder.Entity<Clients>().Property(i => i.PhoneNumber).IsRequired();
            modelBuilder.Entity<Clients>().Property(i => i.PhoneNumber).HasMaxLength(9);

            modelBuilder.Entity<StylistsWorkingHours>().ToTable("StylistsWorkingHours", "Studio");
            modelBuilder.Entity<StylistsWorkingHours>().HasKey(i => i.Id);

            modelBuilder.Entity<Visits>().ToTable("Visits", "Studio");
            modelBuilder.Entity<Visits>().HasKey(i => i.Id);
            modelBuilder.Entity<Visits>().Property(i => i.IsCanceled).HasDefaultValue(false);

            modelBuilder.Entity<Visits>().HasOne<Clients>(c => c.Clients)
                .WithMany(v => v.Visits).HasForeignKey(v => v.ClientId);
            modelBuilder.Entity<Visits>().HasOne<HairdressingServices>(h => h.HairdressingServices)
                .WithMany(v => v.Visits).HasForeignKey(v => v.ServiceId);
            modelBuilder.Entity<Visits>().HasOne<Stylists>(s => s.Stylists)
                .WithMany(v => v.Visits).HasForeignKey(v => v.StylistId);


            modelBuilder.Seed();

        }
    }
}
