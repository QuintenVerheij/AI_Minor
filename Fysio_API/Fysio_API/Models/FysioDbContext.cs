using Fysio_API.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class FysioDbContext : IdentityDbContext
    {
        public FysioDbContext(DbContextOptions<FysioDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TherapistClient>()
                        .HasOne(t => t.Therapist)
                        .WithMany(c => c.TherapistClients)
                        .HasForeignKey(f => f.TherapistId);

            modelBuilder.Entity<TherapistClient>()
                        .HasOne(c => c.Client)
                        .WithMany(t => t.ClientTherapists)
                        .HasForeignKey(f => f.ClientId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ClientExercise> ClientExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<PairingCodes> PairingCodes { get; set; }
    }
}
