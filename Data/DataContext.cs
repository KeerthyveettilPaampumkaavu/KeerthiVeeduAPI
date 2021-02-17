using KeerthiveeduAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeerthiveeduAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<FamilyGroup> FamilyGroups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<Rights> Rights { get; set; }
        public DbSet<Ritual> Rituals { get; set; }
        public DbSet<RitualBooking> RitualBookings { get; set; }
        public DbSet<RitualBookingDetail> RitualBookingDetails { get; set; }
        public DbSet<UserRights> UserRights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Parameters>().HasData(new Parameters
            {
                Id = 1,
                Name = "Family Types",
                IsActive = true,
                PrevId=0,
                ShortCode="FT"

            },
           new Parameters
           {
               Id = 2,
               Name = "Committe Member Posts",
               IsActive = true,
               PrevId = 0,
               ShortCode = "CMT"

           }
            ,
           new Parameters
           {
               Id = 3,
               Name = "Photo Categories",
               IsActive = true,
               PrevId = 0,
               ShortCode = "PC"

           },
           new Parameters
           {
               Id = 101,
               Name = "Ezham Edam",
               IsActive = true,
               PrevId = 1,
               ShortCode = "EE"

           }
           ,
           new Parameters
           {
               Id = 102,
               Name = "Naalam Edam",
               IsActive = true,
               PrevId = 1,
               ShortCode = "NE"

           }
           ,
           new Parameters
           {
               Id = 103,
               Name = "Secretary",
               IsActive = true,
               PrevId = 2,
               ShortCode = "SC"

           },
           new Parameters
           {
               Id = 104,
               Name = "President",
               IsActive = true,
               PrevId = 2,
               ShortCode = "PST"

           }
           ,
           new Parameters
           {
               Id = 105,
               Name = "Executive Member",
               IsActive = true,
               PrevId = 2,
               ShortCode = "EXMEM"

           }
           ,
           new Parameters
           {
               Id = 106,
               Name = "Committee Member Profile",
               IsActive = true,
               PrevId = 3,
               ShortCode = "CMP"

           }
           ,
           new Parameters
           {
               Id = 107,
               Name = "Event Photos",
               IsActive = true,
               PrevId = 3,
               ShortCode = "EVNTP"

           }
           ,
           new Parameters
           {
               Id = 108,
               Name = "Web Photos",
               IsActive = true,
               PrevId = 3,
               ShortCode = "WEBP"

           }
            );

         modelBuilder.Entity<FamilyGroup>().HasData(new FamilyGroup
            {
                Id = 1,
                Name = "PularaKeerthiyil",
                IsActive = true,
                FamilyTypeId=101

            },
         new FamilyGroup
         {
             Id = 2,
             Name = "OralasseryKeerthiyil",
             IsActive = true,
             FamilyTypeId = 102
         },
         new FamilyGroup
         {
             Id = 3,
             Name = "PallarmangalamKeerthiyil",
             IsActive = true,
             FamilyTypeId = 103
         }
         );
            modelBuilder.Entity<Rights>().HasData(new Rights
            {
                Id = 1,
                Name = "Administrator",
                ShortCode = "ADMIN",
                IsActive = true

            }, new Rights
            {
                Id = 2,
                Name = "VerificationUser",
                ShortCode = "VERIFICATION",
                IsActive = true


            });
            modelBuilder.Entity<UserRights>().HasData(new Entities.UserRights
            {
                Id = 1,
                UserId = 1,
                RightsId = 1,
                IsActive = true
            });

        }


    }
}
