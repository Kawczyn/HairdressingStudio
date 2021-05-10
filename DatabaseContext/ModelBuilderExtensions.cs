using HairdressingStudio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.DatabaseContext
{

    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Stylists>().HasData(
                new Stylists
                {
                    Id = 1,
                    FirstName = "Magda"
                },
                new Stylists
                {
                    Id = 2,
                    FirstName = "Karina"
                }
            );

            modelBuilder.Entity<HairdressingServices>().HasData(
               new HairdressingServices
               {
                   Id = 1,
                   Name = "Strzyżenie włosów męskie - krótkie",
                   Description = "Strzyżenie przy pomocy nożyczek i maszynki",
                   IsCombining = false,
                   ServiceTime = 0.5m,
                   Price = 60,
                   IsActive = true
               },
               new HairdressingServices
               {
                   Id = 2,
                   Name = "Strzyżenie włosów i brody męskie - krótkie",
                   Description = "Mycie, masaż głowy, strzyżenie oraz modelowanie",
                   IsCombining = false,
                   ServiceTime = 1,
                   Price = 60,
                   IsActive = true
               },
               new HairdressingServices
               {
                   Id = 3,
                   Name = "Farbowanie - średnie",
                   Description = "Farbowanie przy użyciu najwyższej klasy produktów",
                   IsCombining = false,
                   ServiceTime = 1,
                   Price = 60,
                   IsActive = true
               }
           );

            modelBuilder.Entity<Clients>().HasData(
               new Clients
               {
                   Id = 1,
                   FirstName = "Edyta",
                   LastName = "Poczekaj",
                   PhoneNumber = 500500500,
                   Email = "poczekaj@o2.pl"
               },
               new Clients
               {
                   Id = 2,
                   FirstName = "Jan",
                   LastName = "Bezdomny",
                   PhoneNumber = 606606606,
                   Email = "bezdomny@o2.pl"
               }
           );

            modelBuilder.Entity<StylistsWorkingHours>().HasData(new GenerateSeeds().Generate());

            modelBuilder.Entity<Visits>().HasData(
                new Visits
                {
                    Id=1,
                    ServiceDate = new System.DateTime(2021, 04, 06, 15, 00, 00),
                    ClientId = 2,
                    StylistId = 1,
                    ServiceId = 2,
                    IsCanceled = false
                },
                new Visits
                {
                    Id = 2,
                    ServiceDate = new System.DateTime(2021, 04, 06, 10, 00, 00),
                    ClientId = 1,
                    StylistId = 2,
                    ServiceId = 3,
                    IsCanceled = false
                },
                new Visits
                {
                    Id = 3,
                    ServiceDate = new System.DateTime(2021, 04, 06, 18, 00, 00),
                    ClientId = 2,
                    StylistId = 1,
                    ServiceId = 1,
                    IsCanceled = false
                }

                );



        }


        
    }
}
