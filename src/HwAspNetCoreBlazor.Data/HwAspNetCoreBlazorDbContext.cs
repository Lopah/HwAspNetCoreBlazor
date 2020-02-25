using HwAspNetCoreBlazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HwAspNetCoreBlazor.Data
{
    public class HwAspNetCoreBlazorDbContext : DbContext
    {

        public HwAspNetCoreBlazorDbContext(DbContextOptions<HwAspNetCoreBlazorDbContext> options)
            :base(options)
        {

        }

        #region DbSets

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        #endregion

        #region Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(HwAspNetCoreBlazorDbContext)));
        }
        #endregion

    }
}
