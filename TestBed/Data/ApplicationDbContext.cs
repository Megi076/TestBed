using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TestBed.Models;


namespace TestBed.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<TaxiRide> TaxiRides2 => Set<TaxiRide>();

        public object TaxiRide { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Означуваме TaxiRide како keyless ентитет, бидејќи го користиме само за читање
            modelBuilder.Entity<TaxiRide>().HasNoKey();
        }
    }
}




