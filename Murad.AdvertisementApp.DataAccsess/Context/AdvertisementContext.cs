using Microsoft.EntityFrameworkCore;
using Murad.AdvertisementApp.DataAccsess.Configuration;
using Murad.AdvertisementApp.DataAccsess.Confugiration;
using Murad.AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murad.AdvertisementApp.DataAccsess.Context
{
    public class AdvertisementContext:DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfiguration());
        }
        DbSet<Advertisement> Advertisements { get; set; }
        DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
        DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }
        DbSet<AppRole> AppRoles { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppUserRole> AppUserRoles { get; set; }
        DbSet<Gender> Genders { get; set; } 
        DbSet<MilitaryStatus> MilitaryStatuses { get; set; }    
        DbSet<ProvidedService> ProvidedServices { get; set; }

    }
}
