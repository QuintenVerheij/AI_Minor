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

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //public DbSet<Client> Clients { get; set; }
        public DbSet<ClientExercise> ClientExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        //public DbSet<Therapist> Therapists { get; set; }
    }
}
